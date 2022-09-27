﻿using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Models.DTO
{
    public class WalksDTO
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Region Region { get; set; }

        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
