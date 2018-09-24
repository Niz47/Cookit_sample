using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class grocery_list
    {
        [Key]
        public int grocery_id { get; set; }
        public Nullable<int> userid { get; set; }
        public string grocery_item { get; set; }
        public string grocery_amount { get; set; }

        public virtual user_list user_list { get; set; }
    }
}