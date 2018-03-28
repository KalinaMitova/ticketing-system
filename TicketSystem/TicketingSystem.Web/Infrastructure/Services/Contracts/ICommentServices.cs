namespace TicketingSystem.Web.Infrastructure.Services.Contracts
{
    using TicketingSystem.Models;
    using TicketingSystem.Web.ViewModels.Comments;

    public interface ICommentServices
    {
        CommentViewModel CreatNewComment(PostCommentViewModel comment);
    }
}