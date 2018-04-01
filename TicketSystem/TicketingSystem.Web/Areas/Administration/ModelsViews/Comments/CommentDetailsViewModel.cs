
namespace TicketingSystem.Web.Areas.Administration.ModelsViews.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class CommentDetailsViewModel : IMapFrom<Comment>, IHaveCustomMappings
        {
            public int Id { get; set; }

            [Required]
            [StringLength(2000, MinimumLength = 100)]
            [DataType(DataType.MultilineText)]
            public string Content { get; set; }

            public string AuthorName { get; set; }

            public string TicketTitle { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
            {
                config.CreateMap<Comment, CommentDetailsViewModel>()
                    .ForMember(m => m.AuthorName, opt => opt.MapFrom(c => c.Author.UserName))
                    .ForMember(m => m.TicketTitle, opt => opt.MapFrom(c => c.Ticket.Title))
                    .ReverseMap();
            }
        }
}