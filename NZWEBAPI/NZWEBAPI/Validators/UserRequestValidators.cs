using FluentValidation;

namespace NZWEBAPI.Validators
{
    public class UserRequestValidators:AbstractValidator<Models.DTO.UserRequest>
    {
        public UserRequestValidators()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
