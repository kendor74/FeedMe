using Microsoft.AspNetCore.Identity;
using Resturant2.Data.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Resturant2.Models
{
    public class UserMessages 
    {
        [Key]
        public int Id { get; set; }

        public int UserID { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public int MessageID { get; set; }
        public virtual Message Message { get; set; }

        
    }
}
