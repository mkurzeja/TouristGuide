using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class AttractionsList
    {
        public int ID { get; set; }
        public int ListId { get; set; }
        public int AttractionId { get; set; }
    }
}
