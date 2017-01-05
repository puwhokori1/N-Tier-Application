using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluralSightBook.Web.Models
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
    }
}