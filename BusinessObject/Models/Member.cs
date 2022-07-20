using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace BusinessObject.Models
{
    public partial class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }
        //[Required]
        //[Range(1, 100, ErrorMessage = "Input id from 1 to 999")]
        public int MemberId { get; set; }

        [Required]
        [RegularExpression(@"^[\w.+\-]+@fstore\.com$", ErrorMessage = "Enter the email address in the format ex: elizabeth@fstore.com")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]*", ErrorMessage = "Company name consist only of letters and space")]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]*", ErrorMessage = "City consist only of letters and space")]
        public string City { get; set; }
       
        [Required]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]*", ErrorMessage = "Country consist only of letters and space")]
        public string Country { get; set; }

        public string Password { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
