using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class UserTokken
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public String Tokken { get; set; }

        public DateTime LastAccessTime { get; set; }

    }
}