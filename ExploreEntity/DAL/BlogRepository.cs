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
            int i = 1;
            return Context.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            Context.Authors.Add(author);
            Context.SaveChanges();
        }

        public void AddAuthor(string first_name, string last_name, string penname)
        {
            Author author = new Author { FirstName = first_name, LastName = last_name, PenName = penname };
            Context.Authors.Add(author);
            Context.SaveChanges();
        }

        public Author FindAuthorByPenName(string pen_name)
        {
            // Very Inefficient! b/c
            // SELECT * from Authors; Gets ALL the authors.

            // Much faster to to use LINQ to generate something like:
            // SELECT * from Authors WHERE PenName == pen_name; // Gets only the one we want
            List<Author> found_authors = Context.Authors.ToList(); 
            foreach (var author in found_authors)
            {
                if (author.PenName.ToLower() == pen_name.ToLower())
                {
                    return author;
                }
            }
            return null;
        }

        public Author RemoveAuthor(string pen_name)
        {
            Author found_author = FindAuthorByPenName(pen_name);
            if (found_author != null)
            {
                Context.Authors.Remove(found_author);
                Context.SaveChanges();
            }
            return found_author;
        }
    }
}