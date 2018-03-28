

namespace TicketingSystem.Web.Infrastructure.Services
{
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;
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
            newComment.Author =this.Data.Users.GetById(HttpContext.Current.User.Identity.GetUserId());
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
    }
}