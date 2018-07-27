using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BarKeep.Models;

namespace BarKeep.DAL
{
    public class BarKeepContext : DbContext      /* establishes new database context */
    {
        public BarKeepContext() : base("BarKeepContext")
        {
        
        }

        public DbSet<Bottle> Bottles { get; set; }


    }
 
}