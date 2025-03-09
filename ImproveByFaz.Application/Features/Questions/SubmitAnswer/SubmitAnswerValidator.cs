using FluentValidation;

namespace ImproveByFaz.Application.Features.Questions.SubmitAnswer
{
    public class SubmitAnswerValidator : AbstractValidator<SubmitAnswerCommand>
    {
        public SubmitAnswerValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0);
            RuleFor(x => x.QuestionId).GreaterThan(0);
            RuleFor(x => x.SelectedAnswer).NotEmpty().Must(value => new[] { "A", "B", "C", "D" }.Contains(value))
                .WithMessage("Answer must be one of A, B, C, or D.");
        }
    }
}
