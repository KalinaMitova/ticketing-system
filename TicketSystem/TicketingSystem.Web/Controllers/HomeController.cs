namespace TicketingSystem.Web.Controllers
{ 
    using System.Web.Mvc;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;

    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

        public HomeController(ITicketingSystemData data, IHomeServices homeServices)
            :base(data)
        {
            this.homeServices = homeServices;
        }

        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult Error()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult MostCommentedTickets()
        {
            var ticketVM = this.homeServices.GetIndexViewModel(6);
            return PartialView("_MostCommentedTicketsPartial", ticketVM);
        }
    }
}