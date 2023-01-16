using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace JobsOffers.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }

        public int JopId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("JopId")]
        public virtual Job Job { get; set; }
        [ForeignKey("UserId")]
        public virtual  ApplicationUser  User { get; set; }


    }
}