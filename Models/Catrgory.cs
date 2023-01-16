using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsOffers.Models
{
    public class Catrgory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="نوع الوظيفه")]
        public string CatrgoryName { get; set; }
        [Required]
        [Display(Name = "وصف النوع")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

    }
}