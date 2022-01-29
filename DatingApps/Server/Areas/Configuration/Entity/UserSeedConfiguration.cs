using DatingApps.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApps.Server.Areas.Configuration.Entity
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Message>
    {

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
                new User
                {
                    Id= 1 ,
                    Username = "Legend",
                    Email = "abcd@gmail.com",
                    Password="1234abcd",
                    Gender="M",
                    Birth="23/12/1990",
                    Status="Happy",
                    GenderP="F",
                    Location="Pungol"

                }

                );
        }



    }
}
