using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhiteBoard2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [StringLength(50)]
        public String PostName { get; set; }
        [Required]
        public String PostText { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostTime { get; set; }
        
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection <ViewedPost> SeenBy { get; set; }

    }
   
}