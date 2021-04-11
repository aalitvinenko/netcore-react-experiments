using FluentValidation;

namespace Backend.Application.ApplicationUser.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(v => v.UserName)
                .MaximumLength(20).WithMessage("Username must not exceed 20 characters.")
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}