
namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System.Collections.Generic;

    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;
    using TicketingSystem.Web.ViewModels.Comments;

    public class TicketDetailsViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public PrioriryType Priority { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Ticket, TicketDetailsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ReverseMap();
        }
    }
}