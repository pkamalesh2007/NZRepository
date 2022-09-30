using FluentValidation;
using NZWEBAPI.Models.DTO;

namespace NZWEBAPI.Validatiors
{
    public class AddRegionRequestValidators:AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidators()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Lat).GreaterThan(0);
            RuleFor(x => x.Long).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);

        }
    }
}
