using FluentValidation;
using NZWEBAPI.Models.DTO;

namespace NZWEBAPI.Validators
{
    public class WalksRequestValidators:AbstractValidator<Models.DTO.WalksRequestDTO>
    {
        public WalksRequestValidators()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
           
        }
    }
}
