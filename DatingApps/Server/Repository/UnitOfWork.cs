using DatingApps.Server.Data;
using DatingApps.Server.IRepository;
using DatingApps.Server.Models;
using DatingApps.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingApps.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<BlockedUser> _blockedUsers;
        private IGenericRepository<Location> _locations;
        private IGenericRepository<Match> _matchs;
        private IGenericRepository<Message> _messages;
        private IGenericRepository<Notify> _notifys;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Subscription> _subscriptions;
        private IGenericRepository<User> _users;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IGenericRepository<BlockedUser> BlockedUsers
            => _blockedUsers ??= new GenericRepository<BlockedUser>(_context);

        public IGenericRepository<Location> Locations
            => _locations ??= new GenericRepository<Location>(_context);

        public IGenericRepository<Match> Matchs
            => _matchs ??= new GenericRepository<Match>(_context);

        public IGenericRepository<Message> Messages
            => _messages ??= new GenericRepository<Message>(_context);

        public IGenericRepository<Notify> Notifys
            => _notifys ??= new GenericRepository<Notify>(_context);

        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);

        public IGenericRepository<Subscription> Subscriptions
            => _subscriptions ??= new GenericRepository<Subscription>(_context);

        public IGenericRepository<User> Users
            => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<User> User => throw new NotImplementedException();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}