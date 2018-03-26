
namespace TicketingSystem.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class TicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TicketTitle { get; set; }

        public string CategoryName { get; set; }

        public string AuthorUserName { get; set; }

        public int NumberOfComments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Ticket, TicketViewModel>()
                .ForMember(m => m.TicketTitle, opt => opt.MapFrom(t => t.Title))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(t => t.Category.Name))
                .ForMember(m => m.AuthorUserName, opt => opt.MapFrom(t => t.Author.UserName))
                .ForMember(m => m.NumberOfComments, opt => opt.MapFrom(t => t.Comments.Count()))
                .ReverseMap();
        }
    }
}