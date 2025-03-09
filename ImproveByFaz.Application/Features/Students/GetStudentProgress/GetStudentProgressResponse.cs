using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Students.GetStudentProgress
{
    public record GetStudentProgressResponse(bool Success, string Message, StudentProgressDto? Data);
}
