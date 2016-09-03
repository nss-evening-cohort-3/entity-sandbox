using ExploreEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreEntity.DAL
{
    public class ZoolandiaContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
    }
}