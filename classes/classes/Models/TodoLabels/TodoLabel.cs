using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes.Models.TodoLabels
{
    public class TodoLabel
    {
        public int TodoId { get; set; }
        public Todo Todo { get; set; }

        public int Id { get; set; }
        public Label Label { get; set; }
    }
}
