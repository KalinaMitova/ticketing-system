namespace TicketingSystem.Web.Areas.Administration.ModelsViews.Comments
{
    using System.ComponentModel.DataAnnotations;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;


    public class CommentEditViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}