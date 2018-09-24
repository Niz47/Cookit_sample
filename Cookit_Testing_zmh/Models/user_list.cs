using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class user_list
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string user_email { get; set; }

        public virtual ICollection<post_recipe> post_recipe { get; set; }
        public virtual ICollection<grocery_list> grocery_list { get; set; }
        public virtual ICollection<fav_recipe> fav_recipe { get; set; }
    }
}