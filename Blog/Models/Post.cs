using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {

        public Post()
        {
            Created_at = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        public string Text { get; set; }

        public DateTime Created_at{ get; private set; }

        public virtual ApplicationUser User { get; set; }
    }
}