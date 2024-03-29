﻿using FluentValidation;
using NZWEBAPI.Data;
using NZWEBAPI.Models.DTO;

namespace NZWEBAPI.Validators
{
    public class WalksRequestValidators:AbstractValidator<Models.DTO.WalksRequestDTO>
    {
        private readonly NZDBContext db;

        public WalksRequestValidators(NZDBContext db )
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
            if (region == null)
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
    }
}
