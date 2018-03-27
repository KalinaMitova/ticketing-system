

namespace TicketingSystem.Web.ViewModels.Tickets
{
    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class ListTicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Priority { get; set; }

        public string TicketTitle { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Ticket, ListTicketViewModel>()
                .ForMember(m => m.TicketTitle, opt => opt.MapFrom(t => t.Title))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ForMember(m => m.Priority, opt => opt.MapFrom(t => t.Priority.ToString()))
                .ReverseMap();
        }
    }
}