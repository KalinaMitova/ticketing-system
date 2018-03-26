namespace TicketingSystem.Web.ViewModels.Tickets
{
    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;


    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Ticket, TicketDetailsViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ReverseMap();
        }
    }
}