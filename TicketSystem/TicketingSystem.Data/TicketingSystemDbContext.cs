namespace TicketingSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TicketingSystem.Models;

    public class TicketingSystemDbContext : IdentityDbContext<User>
    {
        public TicketingSystemDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Ticket> Tickets { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Category> Category { get; set; }

        public virtual IDbSet<Image> Images { get; set; }


        public static TicketingSystemDbContext Create()
        {
            return new TicketingSystemDbContext();
        }
    }
}
