using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace JobsOffers.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Display(Name ="اسم الوظيفه")]
        public string JobTitle { get; set; }
        [Display(Name = "وصف الوظيفه")]
        public string JobDescription { get; set; }
        [Display(Name = "صورة الوظيفه")]
        public string JobImg { get; set; }
        [Display(Name ="نوع الوظيفة")]
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Catrgory Catrgory { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual  ApplicationUser User { get; set; }

    }
}