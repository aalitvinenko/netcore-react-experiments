using FluentValidation;

namespace Backend.Application.Posts.Commands.Update
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(v => v.Description)
                .MaximumLength(2000)
                .WithMessage("Description must not exceed 2000 characters.");

            RuleFor(v => v.Id).NotNull();
        }
    }
}