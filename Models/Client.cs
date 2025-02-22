using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnlineHaine.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int WishlistId { get; set; }
    }
}