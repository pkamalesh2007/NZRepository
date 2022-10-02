﻿using Microsoft.EntityFrameworkCore;
using NZWEBAPI.Models.Domain;

namespace NZWEBAPI.Data
{
    public class NZDBContext : DbContext
    {
        public NZDBContext(DbContextOptions<NZDBContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>().
                HasOne(x => x.Role).
                WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>().
                HasOne(x => x.User).
                WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);



        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulties  { get; set; }

        public DbSet<NationalPark> NationalParks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role> Users_Roles { get; set; }
    }
    
}
