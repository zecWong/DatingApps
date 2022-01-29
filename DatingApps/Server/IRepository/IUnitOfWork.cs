using DatingApps.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApps.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<BlockedUser> BlockedUsers { get; }
        IGenericRepository<Location> Locations { get; }
        IGenericRepository<Match> Matchs { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<Notify> Notifys { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Subscription> Subscriptions { get; }
        IGenericRepository<User> User { get; }
    }
}