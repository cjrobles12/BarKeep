using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BarKeep.Models
{
    public enum BottleType             /*Will be used for drop down list*/
    {
        Bourbon, Beer, Gin, Liqeur, Rum, Scotch, Tequila, Whiskey, Wine, Other
    }
    
    public enum Volume
    {
        Fifth, 
        Liter,
        Bottle,
        Six,
        Case,
        Keg,

    }


    public class Bottle
    {
        public int ID { get; set; }
        [Required]                           /* Data Annotation for validation. Makes name a required property */
        [StringLength(50)]                  /* Set maximum string length for normal uses */
        public string Name { get; set; }

        [Display(Name = "Catgeory")]
        public BottleType BottleType { get; set; }

        [Required]     
        [Display(Name="Unit Size")] 
        public Volume Volume { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Please Enter A Valid Cost")] /* ensures cost is a positive decimal number */
        public decimal Cost { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Enter A Valid Price")]
        public decimal Price { get; set; }

       [Required]
       [Range(1,500, ErrorMessage = "Please Enter A Valid Par Level")]
        public int Par { get; set; }
     

        [Required]
        [Display(Name="In Stock")]
        [Range(0,int.MaxValue, ErrorMessage = "Number in stock must be 0 or greater.")]
        public int OnHand { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }
       


    }
}