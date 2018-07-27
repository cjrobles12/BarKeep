using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarKeep.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public int BottleID { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name = "Phone Number")]
        public string SupplierPhone { get; set; }
        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }
        public string Notes { get; set; }

        
        public virtual ICollection<Bottle> Bottles { get; set; }

    }
}