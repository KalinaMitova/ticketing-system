namespace TicketingSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;
    using TicketingSystem.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private ICommentServices commentServices;

        public CommentsController(ITicketingSystemData data, ICommentServices commentServices)
            :base(data)
        {
            this.commentServices = commentServices;
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {

            if (comment != null && ModelState.IsValid)
            {
                CommentViewModel commentVM =  this.commentServices.CreatNewComment(comment);

                return PartialView("_CommentPartial",commentVM );
            }

            throw new HttpException(400, "Invalid comment!");
        }
    }
}