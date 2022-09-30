using FluentValidation;
using NZWEBAPI.Models.DTO;

namespace NZWEBAPI.Validators
{
    public class UpdateRegionRequestValidators: AbstractValidator<UpdateRegionRequest>
    {
        public UpdateRegionRequestValidators()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Lat).GreaterThan(0);
            RuleFor(x=>x.Long).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
