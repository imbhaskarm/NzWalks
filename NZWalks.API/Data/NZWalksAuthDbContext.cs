using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "dd914aad-38a0-460e-962e-01e98cc628bf";
            var writerRoleId = "35d6c7e2-1d8b-463c-a38d-a384bcbae22";

            var roles = new List<IdentityRole>
            {

                new IdentityRole {
                Id =readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
               },
                new IdentityRole
               {
                    Id =writerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
               }

               
            };

            builder.Entity<IdentityRole>().HasData(roles);


        }


    }
}
