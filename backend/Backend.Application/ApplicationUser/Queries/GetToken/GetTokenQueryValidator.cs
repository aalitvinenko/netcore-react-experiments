using FluentValidation;

namespace Backend.Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
    {
        public GetTokenQueryValidator()
        {
            RuleFor(v => v.EmailOrUserName)
                .MaximumLength(100).WithMessage("Email or username must not exceed 100 characters.")
                .NotEmpty().WithMessage("Email or username is required.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}