namespace TicketingSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using TicketingSystem.Web.ViewModels.Home;

    public interface IHomeServices
    {
        IList<TicketViewModel> GetIndexViewModel(int numberOfTickets);
    }
}
