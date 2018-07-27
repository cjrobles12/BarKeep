using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BarKeep.Models;

namespace BarKeep.DAL
{
    public class BarKeepContext : DbContext
    {
        public BarKeepContext() : base("BarKeepContext")
        {

        }

        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


    }
 
}