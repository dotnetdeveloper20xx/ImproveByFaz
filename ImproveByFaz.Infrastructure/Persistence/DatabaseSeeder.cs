using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.Enums;
using ImproveByFaz.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ImproveByFaz.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ImproveDbContext>();
            var logger = serviceProvider.GetRequiredService<ILogger<ImproveDbContext>>();

          
            
            // Ensure database is deleted and recreated on every start (FOR DEV ONLY)
            logger.LogInformation("Deleting existing database...");

            context.Database.EnsureDeleted();

            logger.LogInformation("Applying migrations...");
            context.Database.Migrate();            

            logger.LogInformation("Seeding Database...");



            // Ensure Database Connection
            if (!context.Database.CanConnect())
            {
                logger.LogError("Database connection failed.");
                return;
            }

            // Seed Topics
            logger.LogInformation("Seeding Topics...");
            var topics = new List<Topic>();

            for (int i = 1; i <= 5; i++)
            {
                var topic = new Topic
                {
                    Name = $"Topic {i}",
                    SubTopics = new List<SubTopic>()
                };

                // Seed SubTopics
                for (int j = 1; j <= 5; j++)
                {
                    var subTopic = new SubTopic
                    {
                        Name = $"SubTopic {j} of Topic {i}",
                        Questions = new List<Question>()
                    };

                    for (int k = 1; k <= 10; k++)
                    {
                        var options = new List<AnswerOption> // Moved inside the loop to avoid shared references
            {
                new AnswerOption("A", "Option A Explanation"),
                new AnswerOption("B", "Option B Explanation"),
                new AnswerOption("C", "Option C Explanation"),
                new AnswerOption("D", "Option D Explanation")
            };

                        subTopic.Questions.Add(new Question
                        {
                            ImageUrl = $"https://cdn.eedi.com/questions/q{i}{j}{k}.png", // Fixed question URL
                            CorrectAnswer = AnswerChoice.B,
                            Explanation = "Explanation of the correct answer.",
                            Options = options // Directly assigning the list
                        });
                    }

                    topic.SubTopics.Add(subTopic);
                }

                topics.Add(topic);
            }

            try
            {
                context.Topics.AddRange(topics);
                context.SaveChanges();
                logger.LogInformation("✅ Seeded Topics, SubTopics, and Questions successfully!");
            }
            catch (DbUpdateException ex)
            {
                logger.LogError($"❌ Database Seeding Error: {ex.InnerException?.Message ?? ex.Message}");
                foreach (var entry in ex.Entries)
                {
                    logger.LogError($"❌ Entity: {entry.Entity.GetType().Name} - State: {entry.State}");
                }
                throw;
            }




            // Seed Students
            var students = new List<Student>();
            for (int i = 1; i <= 5; i++)
            {
                var student = new Student
                {
                    Name = $"Student {i}",
                    Misconceptions = new List<StudentMisconception>()
                };

                // Assign misconceptions (incorrect answers) to 5 subtopics in each topic
                foreach (var topic in topics)
                {
                    foreach (var subTopic in topic.SubTopics.Take(5)) // 5 subtopics per topic
                    {
                        foreach (var question in subTopic.Questions) // All 10 questions in each subtopic
                        {
                            student.Misconceptions.Add(new StudentMisconception
                            {
                                Question = question,
                                IsCorrected = false
                            });
                        }
                    }
                }

                students.Add(student);
            }

            context.Students.AddRange(students);
            context.SaveChanges();
            logger.LogInformation("Seeded Students and Misconceptions.");

            logger.LogInformation("Database Seeding Completed Successfully!");
        }
    }
}
