namespace TicketingSystem.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Tickets;

    public class TicketsController : BaseController
    {
        private IDetailsServices detailsServices;

        public TicketsController(ITicketingSystemData data, IDetailsServices detailsServices)
            : base(data)
        {
            this.detailsServices = detailsServices;
        }

        [Authorize]
        public ActionResult Add()
        {
            var AddTicketsViewModel = this.detailsServices.CreateNewTicket();

            return View(AddTicketsViewModel);

        }

        [Authorize]
         [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Add(AddTicketViewModel ticket)
        {
            
            if (ticket != null && ModelState.IsValid)
            {
                 
                this.detailsServices.AddTicketToDB(ticket);

                return RedirectToAction("All", "Tickets");
            }

            ticket.Categories = this.detailsServices.GetCategories();
            return View(ticket);
        }

        public ActionResult Details(int id)
        {
            var ticket = this.detailsServices.GetTicketDetailsView(id);

            if (ticket == null)
            {
                throw new HttpException(404, "Ticket not found!");
            }         

            return View(ticket);
        }

        public ActionResult Image(int id)
        {
            var image = this.detailsServices.GetImageById(id);

            if (image == null)
            {
                throw new HttpException(404, "Image not found!");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}