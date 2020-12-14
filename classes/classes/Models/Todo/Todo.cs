using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using classes.Models.TodoLabels;
using classes.Providers;

namespace classes.Models
{
    public class Todo : IHasId
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Timestamp]
        public DateTime CreatedTimestamp { get; set; } = new DateTime();

        [Timestamp]
        public DateTime Deadline { get; set; }

        [Range(1, 5)]
        [Required]
        public int Priority { get; set; } = 3;

        // public List<Label> Labels { get; set; } = new List<Label>();
        public IList<TodoLabel> TodoLabels { get; set; }
    }
}
