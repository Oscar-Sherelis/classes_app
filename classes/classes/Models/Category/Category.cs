using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using classes.Providers;

namespace classes.Models
{
    public class Category : IHasId
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
