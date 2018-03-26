
namespace TicketingSystem.Web.Infrastructure.Services.Base
{
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;

    public abstract class BaseServices 
    {
        protected ITicketingSystemData Data { get; private set; }

        public BaseServices(ITicketingSystemData data)
        {
            this.Data = data;
        }
    }
}