using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class post_recipe
    {
        [Key]
        public int post_recipe_id { get; set; }
        public Nullable<int> userid { get; set; }
        public string post_ImageName { get; set; }
        public string post_ImagePath { get; set; }
        public string post_recipe_name { get; set; }

        public virtual ICollection<post_ingredient> post_ingredient { get; set; }
        public virtual ICollection<post_instruction> post_instruction { get; set; }
        public virtual user_list user_list { get; set; }
    }
}