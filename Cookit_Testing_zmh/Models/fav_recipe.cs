using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class fav_recipe
    {
        [Key]
        public int fav_recipe_id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> recipe_id { get; set; }

        public virtual recipe recipe { get; set; }
        public virtual user_list user_list { get; set; }
    }
}