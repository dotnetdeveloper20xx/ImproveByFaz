﻿// <auto-generated />
using ImproveByFaz.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImproveByFaz.Infrastructure.Migrations
{
    [DbContext(typeof(ImproveDbContext))]
    [Migration("20250309172943_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubTopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubTopicId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.StudentMisconception", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrected")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentMisconceptions");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.SubTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("SubTopics");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Question", b =>
                {
                    b.HasOne("ImproveByFaz.Domain.Entities.SubTopic", "SubTopic")
                        .WithMany("Questions")
                        .HasForeignKey("SubTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ImproveByFaz.Domain.ValueObjects.AnswerOption", "Options", b1 =>
                        {
                            b1.Property<int>("QuestionId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("QuestionId", "Id");

                            b1.ToTable("AnswerOption");

                            b1.WithOwner()
                                .HasForeignKey("QuestionId");
                        });

                    b.Navigation("Options");

                    b.Navigation("SubTopic");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.StudentMisconception", b =>
                {
                    b.HasOne("ImproveByFaz.Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImproveByFaz.Domain.Entities.Student", "Student")
                        .WithMany("Misconceptions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.SubTopic", b =>
                {
                    b.HasOne("ImproveByFaz.Domain.Entities.Topic", "Topic")
                        .WithMany("SubTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Student", b =>
                {
                    b.Navigation("Misconceptions");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.SubTopic", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ImproveByFaz.Domain.Entities.Topic", b =>
                {
                    b.Navigation("SubTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
