using FluentValidation;
using NZWEBAPI.Models.Domain;
using NZWEBAPI.Models.DTO;
using NZWEBAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Data;

namespace NZWEBAPI.Validators
{
    public class UpdateWalksRequestValidators:AbstractValidator<Models.DTO.WalksUpdateRequest>
    {
        private readonly NZDBContext db;

        public UpdateWalksRequestValidators(NZDBContext db )
        {
            
            this.db = db;
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
            RuleFor(x => x.RegionId).Must(ValidateRegionId).WithMessage("Enter a valid Region Id");
            RuleFor(x => x.WalkDifficultyId).Must(ValidateWalkDiffiultyId).WithMessage("Enter a valid WalkDifficulty Id");

        }

        private bool ValidateRegionId(Guid regionId)
        {
            var region = db.Regions.Where(x => x.Id == regionId).FirstOrDefault();
            if(region == null)
            {
                return false;
            }
            return true;
            
           

        }


        private bool ValidateWalkDiffiultyId(Guid difficultyId)
        {
            var region = db.WalkDifficulties.Where(x => x.Id == difficultyId).FirstOrDefault();
            if (region == null)
            {
                return false;
            }
            return true;



        }


        //private  async Task<bool> ValidateUpdateRegionIdAsync(WalksUpdateRequest walksUpdateRequest)
        //{
        //    var region = await regionRepository.GetAsync(walksUpdateRequest.RegionId);
        //    return true;
        //}

        //private async Task<bool> ValidateUpdateDifficultyId(WalksUpdateRequest walksUpdateRequest)
        //{
        //    var walkDifficulty = await walkDifficultyRepository.GetWalkDifficultyByIdAsync(walksUpdateRequest.WalkDifficultyId);
        //    return true;
        //}


    }
}
