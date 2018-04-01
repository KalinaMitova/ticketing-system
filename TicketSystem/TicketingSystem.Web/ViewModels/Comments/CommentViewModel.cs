namespace TicketingSystem.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;


    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                .ReverseMap();
        }
    }
}