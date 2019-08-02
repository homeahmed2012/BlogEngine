using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Profile
    {

        public Profile()
        {
            _created_at = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }
        private DateTime _created_at { get; set; }

        public virtual ApplicationUser User { get; set; }


        public DateTime created_at
        {
            get
            {
                return this._created_at;
            }
        }

    }
}