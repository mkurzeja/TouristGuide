using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class UserList
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Write name")]
        [DataType(DataType.Text)]
        public String Name { get; set; }
    }
}
