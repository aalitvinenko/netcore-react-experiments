using FluentValidation;

namespace Backend.Application.Posts.Commands.Create
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(v => v.Description)
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.")
                .NotEmpty().WithMessage("Description is required.");
        }
    }
}