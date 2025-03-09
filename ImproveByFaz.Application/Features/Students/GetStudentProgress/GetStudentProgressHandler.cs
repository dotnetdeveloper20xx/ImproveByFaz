using MediatR;
using ImproveByFaz.Domain.Interfaces;
using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Students.GetStudentProgress
{
    public class GetStudentProgressHandler : IRequestHandler<GetStudentProgressQuery, GetStudentProgressResponse>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentProgressHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<GetStudentProgressResponse> Handle(GetStudentProgressQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentByIdAsync(request.StudentId);

            if (student == null)
                return new GetStudentProgressResponse(false, "Student not found", null);

            var progress = new StudentProgressDto
            {
                StudentId = student.Id,
                Name = student.Name,
                TotalMisconceptions = student.Misconceptions.Count,
                CorrectedMisconceptions = student.Misconceptions.Count(m => m.IsCorrected)
            };

            return new GetStudentProgressResponse(true, "Success", progress);
        }
    }
}
