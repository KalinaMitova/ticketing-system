
namespace TicketingSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TicketingSystem.Models;
    using TicketingSystem.Web.ViewModels.Tickets;

    public interface IDetailsServices
    {
        TicketDetailsViewModel GetTicketDetailsView(int id);

        Image GetImageById(int id);

        AddTicketViewModel CreateNewTicket();

        IEnumerable<SelectListItem> GetCategories();

        void AddTicketToDB(AddTicketViewModel ticket);

    }
}