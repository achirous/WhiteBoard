using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhiteBoard2.Models
{
    public class ViewedPost
    {
        public int ViewedPostId { get; set; }
        [StringLength(50),Required]
        public string ViewedByName { get; set; }
        [Required]
        public int IdViewed { get; set; }
        [Required]
        public virtual ApplicationUser ViewedByUser { get; set; }
        [Required]
        public virtual Post ViewPost { get; set; }

    }
}