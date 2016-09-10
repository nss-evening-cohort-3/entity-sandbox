using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExploreEntity.DAL;
using System.Collections.Generic;
using ExploreEntity.Models;
using Moq;
using System.Data.Entity;

namespace ExploreEntity.Tests.DAL
{
    [TestClass]
    public class BlogRepositoryTests
    {
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
            // How to create a new Author, just sayin'...
            // Author my_author = new Author();

            // Create Mock BlogContext
            Mock<BlogContext> mock_context = new Mock<BlogContext>();
            Mock<DbSet<Author>> mock_author_table = new Mock<DbSet<Author>>();
            List<Author> author_list = new List<Author>();



            BlogRepository repo = new BlogRepository(mock_context.Object);

            // Act
            List<Author> actual_authors = repo.GetAuthors();
            int expected_authors_count = 0;
            int actual_authors_count = actual_authors.Count;

            // Assert
            Assert.AreEqual(expected_authors_count, actual_authors_count);
        }
    }
}
