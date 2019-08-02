using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comment
    {
        public Comment()
        {
            _created_at = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ApplicationUser User { get; set; }

        private DateTime _created_at { get; set; }

        public DateTime created_at
        {
            get
            {
                return this._created_at;
            }
        }
    }
}