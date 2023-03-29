using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        [EmailAddress(ErrorMessage = "The email address is invalid")]
        public string UserEmail { get; set; }
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long")]
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }

}