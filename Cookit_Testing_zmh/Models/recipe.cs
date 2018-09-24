using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class recipe
    {
        [Key]
        public int recipe_id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string recipe_name { get; set; }

        public virtual ICollection<ingredient> ingredients { get; set; }
        public virtual ICollection<instruction> instructions { get; set; }
        public virtual ICollection<fav_recipe> fav_recipe { get; set; }
    }
}