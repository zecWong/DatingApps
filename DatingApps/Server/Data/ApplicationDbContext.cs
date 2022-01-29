using DatingApps.Server.Areas.Configuration.Entity;
using DatingApps.Server.Models;
using DatingApps.Shared.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApps.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Payment> Subscriptions { get; set; }

        public DbSet<BlockedUser> BlockedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LocationSeedConfiguration());
            builder.ApplyConfiguration(new MessageSeedConfiguration());


        }

    }
    

}
