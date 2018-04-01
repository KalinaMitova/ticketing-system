namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    using System.Net;
    using System.Web.Mvc;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;
    using TicketingSystem.Web.Areas.Administration.ModelsViews.Comments;
    using TicketingSystem.Web.Infrastructure.Services.Contracts;

    public class CommentsController : AdminController
    {
        private ICommentServices commentServices;

        public CommentsController(ITicketingSystemData data, ICommentServices commentServices)
            : base(data)
        {
            this.commentServices = commentServices;
        }

        // GET: Administration/Comments
        public ActionResult Index()
        {
            return View(this.commentServices.GetAllCommentsAsCommentDetailsViewModel());
        }

        // GET: Administration/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentDetailsViewModel commentVM = this.commentServices.CreatDetailsViewModelFromCommentId(id);
            if (commentVM == null)
            {
                return HttpNotFound();
            }

            return View(commentVM);
        }

        // GET:  Administration/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentEditViewModel comment = this.commentServices.CreatEditViewModelFromCommentId(id);
            if (comment == null)
            {
                return HttpNotFound("Comment not found");
            }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentEditViewModel editedComment)
        {
           if (ModelState.IsValid)
           {
               this.commentServices.ModifyComment(editedComment);
               
               return RedirectToAction("Index");
           }
            return View(editedComment);
        }

        // GET: Administration/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Administration/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.commentServices.DeleteCommentById(id);
            return RedirectToAction("Index");
        }
    }
}
