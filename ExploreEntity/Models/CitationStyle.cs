using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreEntity.Models
{
    public class CitationStyle
    {
        [Key]
        public int CitationStyleId { get; set; }
        public string Name { get; set; }
    }
}