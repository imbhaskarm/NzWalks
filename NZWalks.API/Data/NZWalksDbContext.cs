

using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        public DbSet<Image> Images { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty (){
                    Id=Guid.Parse("5b1429a6-da33-4331-bd09-1b8112b1bf6b"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("ce75fbef-6bd6-459e-aa07-446a747014f4"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("7b85028e-211f-4c42-95f3-713b2a33e7b0"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>()
            {
                new Region
                {
                    Id=Guid.Parse("c3c3291c-a662-40e0-b487-f7f56b710fa4"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl=null
                },
                 new Region
                {
                    Id=Guid.Parse("0a26c63c-0754-449d-80d0-e500cba9488d"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl=null
                },
                  new Region
                {
                    Id=Guid.Parse("3153abda-7349-4806-9c6d-a779a3579f86"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl=null
                },
                   new Region
                {
                    Id=Guid.Parse("160da0c5-bee7-4045-96c8-3893028c3fb5"),
                    Name="Bay Of Plenty",
                    Code="BOP",
                    RegionImageUrl=null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
