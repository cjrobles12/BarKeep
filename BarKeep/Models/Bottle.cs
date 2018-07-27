using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BarKeep.Models
{
    public enum BottleType
    {
        Bourbon, Beer, Gin, Liqeur, Rum, Scotch, Tequila, Whiskey, Wine, Other
    }



    public class Bottle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BottleType BottleType { get; set; }
        public int Volume { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
        public int Par { get; set; }
        public int OnHand { get; set; }
       


    }
}