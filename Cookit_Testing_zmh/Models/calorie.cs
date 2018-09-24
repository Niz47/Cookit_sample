using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookit_Testing_zmh.Models
{
    public class calorie
    {
        [Key]
        public int calorie_id { get; set; }
        public Nullable<int> calorie_amount { get; set; }
    }
}