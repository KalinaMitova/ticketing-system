namespace TicketingSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TicketingSystem.Models;
    using TicketingSystem.Web.Areas.Administration.ModelsViews.Comments;
    using TicketingSystem.Web.ViewModels.Comments;

    public interface ICommentServices
    {
        CommentViewModel CreatNewComment(PostCommentViewModel comment);

        IEnumerable<Comment> GetAllComments();

        IEnumerable<SelectListItem> GetAllAuthorsId();

        IEnumerable<SelectListItem> GetAllTicketsId();

        CommentDetailsViewModel ModifyComment(CommentEditViewModel comment);

        Comment GetCommentById(int? id);

        void DeleteCommentById(int id);

        CommentEditViewModel CreatEditViewModelFromCommentId(int? id);

        IEnumerable<CommentDetailsViewModel> GetAllCommentsAsCommentDetailsViewModel();

        CommentDetailsViewModel CreatDetailsViewModelFromCommentId(int? id);
    }
}