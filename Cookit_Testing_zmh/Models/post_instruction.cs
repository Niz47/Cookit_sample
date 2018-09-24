using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class post_instruction
    {
        [Key]
        public int post_instruction_id { get; set; }
        public Nullable<int> post_recipe_id { get; set; }
        public string post_instruction_detail { get; set; }

        public virtual post_recipe post_recipe { get; set; }
    }
}