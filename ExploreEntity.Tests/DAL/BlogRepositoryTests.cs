using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExploreEntity.DAL;
using System.Collections.Generic;
using ExploreEntity.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace ExploreEntity.Tests.DAL
{
    [TestClass]
    public class BlogRepositoryTests
    {
        Mock<BlogContext> mock_context { get; set; }
        Mock<DbSet<Author>> mock_author_table { get; set; }
        List<Author> author_list { get; set; } // Fake

        public void ConnectMocksToDatastore()
        {
            var queryable_list = author_list.AsQueryable();

            // Lie to LINQ make it think that our new Queryable List is a Database table.
            mock_author_table.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_author_table.As<IQueryable<Author>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_author_table.As<IQueryable<Author>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_author_table.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(queryable_list.GetEnumerator());

            // Have our Author property return our Queryable List AKA Fake database table.
            mock_context.Setup(c => c.Authors).Returns(mock_author_table.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            // Create Mock BlogContext
            mock_context = new Mock<BlogContext>();
            mock_author_table = new Mock<DbSet<Author>>();
            author_list = new List<Author>(); // Fake
        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            BlogRepository repo = new BlogRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            BlogRepository repo = new BlogRepository();

            BlogContext actual_context = repo.Context;

            Assert.IsInstanceOfType(actual_context, typeof(BlogContext));
        }

        [TestMethod]
        public void RepoEnsureWeHaveNoAuthors()
        {
            // Arrange
            ConnectMocksToDatastore();
            BlogRepository repo = new BlogRepository(mock_context.Object);

            // Act
            List<Author> actual_authors = repo.GetAuthors();
            int expected_authors_count = 0;
            int actual_authors_count = actual_authors.Count;

            // Assert
            Assert.AreEqual(expected_authors_count, actual_authors_count);
        }

        [TestMethod]
        public void RepoEnsureAddAuthorToDatabase()
        {
            // Arrange
            ConnectMocksToDatastore();
            BlogRepository repo = new BlogRepository(mock_context.Object);
            Author my_author = new Author { FirstName = "Sally", LastName = "Mae", PenName = "Voldemort"}; // Property Initializer
            /* Same as
             Author my_author = new Author();
             my_author.FirstName = "Sally";
             my_author.LastName = "Mae";
             my_author.PenName = "Voldemort";
             */
            // Act
            repo.AddAuthor(my_author);
            // repo.AddAuthor("Sally", "Mae", "Voldemort")
            int actual_author_count = repo.GetAuthors().Count;
            /* Same as
            List<Author> list_of_authors = repo.GetAuthors();
            int actual_author_count = list_of_authors.Count;
             */
            int expected_author_count = 1;

            // Assert
            Assert.AreEqual(expected_author_count, actual_author_count);
        }
    }
}
