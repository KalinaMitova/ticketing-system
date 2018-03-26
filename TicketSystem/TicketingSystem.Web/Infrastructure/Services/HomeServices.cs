namespace TicketingSystem.Web.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services.Base;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Home;

    public class HomeServices : BaseServices, IHomeServices
    {

        public HomeServices (ITicketingSystemData data)
            :base(data)
        {
        }

        public IList<TicketViewModel> GetIndexViewModel(int numberOfTickets)
        {
            var indexViewModel = this.Data
               .Tickets
               .All()
               .OrderByDescending(t => t.Comments.Count)
               .Take(numberOfTickets)
               .ProjectTo<TicketViewModel>()
               .ToList();

            return indexViewModel;
        }
    }
}