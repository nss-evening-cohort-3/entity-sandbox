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
        public void RepoEnsureWeHaveNoAuthors()
        {
            // Arrange
            BlogRepository repo = new BlogRepository();

            // Act
            List<Author> actual_authors = repo.GetAuthors();
            int expected_authors_count = 0;
            int actual_authors_count = actual_authors.Count;

            // Assert
            Assert.AreEqual(expected_authors_count, actual_authors_count);
        }
    }
}
