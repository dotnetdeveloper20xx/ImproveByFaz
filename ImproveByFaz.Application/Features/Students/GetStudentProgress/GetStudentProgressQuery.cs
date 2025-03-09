using MediatR;
using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Students.GetStudentProgress
{
    public record GetStudentProgressQuery(int StudentId) : IRequest<GetStudentProgressResponse>;
}
