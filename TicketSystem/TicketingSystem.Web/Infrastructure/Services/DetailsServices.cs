
namespace TicketingSystem.Web.Infrastructure.Services
{
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using TicketingSystem.Models;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Infrastructure.Services.Base;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Tickets;
    using TicketingSystem.Web.ViewModels.Comments;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using AutoMapper;
    using System.IO;

    public class DetailsServices : BaseServices, IDetailsServices
    {
        public DetailsServices(ITicketingSystemData data)
              : base(data)
        {
        }

        public IList<ListTicketViewModel> GetAllTickets()
        {
            return this.Data
               .Tickets
               .All()
               .ProjectTo<ListTicketViewModel>()
               .ToList(); ;
        }

        public TicketDetailsViewModel GetTicketDetailsView(int id)
        {
           var ticket = this.Data.Tickets
                .All()
                .Where(t => t.Id == id)
                .ProjectTo<TicketDetailsViewModel>()
                .FirstOrDefault();

            if (ticket != null)
            {
                ticket.Comments = this.Data
               .Comments
               .All()
               .Where(c => c.TicketId == ticket.Id)
               .OrderByDescending(c => c.Id)
               .ProjectTo<CommentViewModel>()
               .ToList();
            }
          
            return ticket;
        }

        public Image GetImageById(int id)
        {
            return this.Data.Images.GetById(id);
        }

        public AddTicketViewModel CreateNewTicket()
        {
            return new AddTicketViewModel
            {
                Categories = this.Data.Categories
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return this.Data.Categories
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
        }

        public void AddTicketToDB(AddTicketViewModel ticket)
        {
            var dbTicket = Mapper.Map<Ticket>(ticket);

            if (ticket.UploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    ticket.UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    dbTicket.Image = new Image
                    {
                        Content = content,
                        FileExtension = ticket.UploadedImage.FileName.Split('.')[1]
                    };
                };
            }
            

            this.Data.Tickets.Add(dbTicket);
            this.Data.SaveChanges();
        }
    }

}