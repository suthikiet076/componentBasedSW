using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DonationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DonationContext() : base("name=DonationContext")
        {
        }

        public System.Data.Entity.DbSet<Project.Models.Donation> Donations { get; set; }
    }
}
