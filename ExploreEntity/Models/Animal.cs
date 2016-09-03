using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExploreEntity.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Habitat { get; set; }

        public int Species { get; set; }
    }
}