
namespace TicketingSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Models;

    public class BaseController :Controller
    {
        protected ITicketingSystemData Data { get; set; }

        protected User UserProfile { get; set; }

        public BaseController(ITicketingSystemData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();
             
            return base.BeginExecute(requestContext, callback, state); 
        }
    }
}