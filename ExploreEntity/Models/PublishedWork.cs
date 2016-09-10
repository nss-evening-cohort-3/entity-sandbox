using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreEntity.Models
{
    public class PublishedWork
    {
        [Key]
        public int PublishedWorkId { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
    }
}