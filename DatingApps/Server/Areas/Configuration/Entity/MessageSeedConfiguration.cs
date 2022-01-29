using DatingApps.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApps.Server.Areas.Configuration.Entity
{
    public class MessageSeedConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasData(
            new Message
            {
                Id = 1,
                Message_content = "joey number 1",
                Message_timestamp = DateTime.Now,
                Message_read = "Read",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Message
            {
                Id = 2,
                Message_content = "joey number 2",
                Message_timestamp = DateTime.Now,
                Message_read = "Not Read",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            });
        }
    }
}
