
namespace TicketingSystem.Models
{
    using System.ComponentModel.DataAnnotations;


    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}