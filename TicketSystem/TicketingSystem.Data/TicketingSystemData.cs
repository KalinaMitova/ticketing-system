namespace TicketingSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;

    public class TicketingSystemData : ITicketingSystemData
    {
        private readonly DbContext context;
        
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TicketingSystemData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Ticket> Tickets => this.GetRepository<Ticket>();

        public IRepository<Comment> Comments => this.GetRepository<Comment>();

        public IRepository<User> Users => this.GetRepository<User>();

        public IRepository<Category> Categories => this.GetRepository<Category>();

        public IRepository<Image> Images => this.GetRepository<Image>();

        public DbContext Contex => this.context;

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        } 

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose (bool disposing)
        {
            if(disposing)
            {
                if(this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T :class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>); 

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }



       
    }
}
