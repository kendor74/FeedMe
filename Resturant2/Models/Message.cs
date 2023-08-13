using System.ComponentModel.DataAnnotations;

namespace Resturant2.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required , MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public string MessageDescription { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required , EmailAddress]
        public string Email{ get; set; }

        public DateTime Date { get; set; }
    }
}
