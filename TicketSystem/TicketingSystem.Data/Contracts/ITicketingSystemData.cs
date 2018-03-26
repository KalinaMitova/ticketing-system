namespace TicketingSystem.Data.Contracts
{
    using System.Data.Entity;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;

    public interface ITicketingSystemData
    {
        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Image> Images { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<User> Users { get; }

        DbContext Contex { get; }

        void Dispose();

        int SaveChanges();
    }
}