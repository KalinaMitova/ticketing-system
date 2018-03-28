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

        //[OutputCache(Duration = 60 * 60)]
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