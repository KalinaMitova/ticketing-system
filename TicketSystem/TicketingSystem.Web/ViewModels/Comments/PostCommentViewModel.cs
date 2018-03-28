namespace TicketingSystem.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {

        }

        public PostCommentViewModel(int ticketId)
        {
            this.TicketId = ticketId;
        }

        public int TicketId { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        [UIHint("MultiLineText")]
        public string Content { get; set; }
    }
}