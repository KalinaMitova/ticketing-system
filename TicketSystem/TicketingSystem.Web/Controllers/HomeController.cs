


namespace TicketingSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(ITicketingSystemData data, IHomeServices homeServices)
            :base(data)
        {
            this.homeServices = homeServices;
        }

        [OutputCache(Duration = 60 * 60)]
        public ActionResult Index()
        {
            var ticketVM = this.homeServices.GetIndexViewModel(4);

            return View(ticketVM);
        } 

        public ActionResult Error()
        {
            return View();
        }
    }
}