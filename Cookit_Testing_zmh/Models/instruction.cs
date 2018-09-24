using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class instruction
    {
        [Key]
        public int instruction_id { get; set; }
        public Nullable<int> recipe_id { get; set; }
        public string instruction_detail { get; set; }

        public virtual recipe recipe { get; set; }
    }
}