

namespace TicketingSystem.Web.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;
    using TicketingSystem.Web.Areas.Administration.ModelsViews.Comments;
    using TicketingSystem.Web.Infrastructure.Services.Base;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Comments;

    public class CommentServices : BaseServices, ICommentServices
    {
        public CommentServices(ITicketingSystemData data)
              : base(data)
        {

        }

        public CommentViewModel CreatNewComment(PostCommentViewModel comment)
        {
            Comment newComment = Mapper.Map<Comment>(comment);
            newComment.Author = this.Data.Users.GetById(HttpContext.Current.User.Identity.GetUserId());
            Ticket ticket = this.Data.Tickets.GetById(comment.TicketId);
            if (ticket == null)
            {
                throw new HttpException(404, "Ticket not found!");
            }

            ticket.Comments.Add(newComment);
            this.Data.SaveChanges();
            CommentViewModel comentVM = Mapper.Map<CommentViewModel>(newComment);

            return comentVM;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return this.Data.Comments
                .All()
                .Include(c => c.Author)
                .Include(c => c.Ticket)
                .ToList(); ;
        }

        public IEnumerable<CommentDetailsViewModel> GetAllCommentsAsCommentDetailsViewModel()
        {
            return this.Data
               .Comments
               .All()
               .ProjectTo<CommentDetailsViewModel>()
               .ToList();
    }

        public IEnumerable<SelectListItem> GetAllAuthorsId()
        {
            return this.Data.Comments
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.AuthorId,
                    Text = c.Author.Email
                });
        }

        public IEnumerable<SelectListItem> GetAllTicketsId()
        {
            return this.Data.Comments
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.TicketId.ToString(),
                    Text = c.Ticket.Title
                });
        }

        public CommentDetailsViewModel ModifyComment(CommentEditViewModel editedComment)
        {
            Comment comment = this.GetCommentById(editedComment.Id);
            comment.Content = editedComment.Content;

            this.Data.Comments.Update(Mapper.Map<Comment>(comment));
            this.Data.SaveChanges();

            return Mapper.Map<CommentDetailsViewModel> (comment);
        }

        public Comment GetCommentById(int? id)
        {
           return this.Data.Comments.GetById(id);
        }

        public void DeleteCommentById(int id)
        {
            Comment comment = this.GetCommentById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
        }

        public CommentEditViewModel CreatEditViewModelFromCommentId(int? id)
        {
            Comment comment = this.GetCommentById(id);

            return Mapper.Map<CommentEditViewModel>(comment);
        }

        public CommentDetailsViewModel CreatDetailsViewModelFromCommentId(int? id)
        {
            Comment comment = this.GetCommentById(id);

            return Mapper.Map<CommentDetailsViewModel>(comment);
        }
    }
}