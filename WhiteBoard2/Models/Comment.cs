using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhiteBoard2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [StringLength(50),Required]
        public String CommentName { get; set; }
        [Required]
        public String CommentText { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CommentTime { get; set; }
        [Required]
        public virtual Post Post { get; set; }
    }
}