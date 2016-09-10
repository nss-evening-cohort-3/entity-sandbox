using ExploreEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExploreEntity.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<PublishedWork> Works { get; set; }
        public DbSet<CitationStyle> CitationStyles { get; set; } // To make seeding easy
    }
}