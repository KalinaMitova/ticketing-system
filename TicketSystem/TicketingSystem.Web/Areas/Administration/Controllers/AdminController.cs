


namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using TicketingSystem.Common;
    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public AdminController(ITicketingSystemData data) 
            : base(data)
        {
        }
    }
}