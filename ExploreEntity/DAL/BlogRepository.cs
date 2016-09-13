using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExploreEntity.Models;

namespace ExploreEntity.DAL
{
    public class BlogRepository
    {
        public BlogContext Context { get; set; }

        public BlogRepository()
        {
            Context = new BlogContext();
        }

        public BlogRepository(BlogContext _context)
        {
            Context = _context;
        }

        public List<Author> GetAuthors()
        {
            return Context.Authors.ToList();
        }
    }
}