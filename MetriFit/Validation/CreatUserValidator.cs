using FluentValidation;

namespace MetriFit.Validation
{
    public class CreatUserValidator : AbstractValidator<User>
    {
        public CreatUserValidator(IUserRepository userRepository)
        {
            RuleFor(c => c.Email).MustAsync(async (Email, _) =>
            {
                return await userRepository.IsEmailUniq(Email);
            }).WithMessage("Email is Used before: it should be Unique");
            
        }

    }
}
