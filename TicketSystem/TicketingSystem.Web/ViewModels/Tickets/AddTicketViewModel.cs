namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using TicketingSystem.Models;
    using TicketingSystem.Web.Infrastructure.Mapping;

    public class AddTicketViewModel : IMapFrom<Ticket>
    {
        [UIHint("Enum")]
        [DefaultValue(PrioriryType.Medium)]
        public PrioriryType Priority { get; set; }

        [Required]
        [StringLength(50)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [StringLength(1000)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Display(Name ="Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public HttpPostedFileBase UplaodedImage { get; set; }


    }
} 