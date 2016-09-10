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

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        public CitationStyle Citation { get; set; } // Navigation Property


        public List<Author> Authors { get; set; }
    }
}