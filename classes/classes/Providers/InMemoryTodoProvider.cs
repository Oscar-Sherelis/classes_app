using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using classes.Models;
using EFDataAccessLibrary.Models;

namespace classes.Providers
{
    public class InMemoryTodoProvider : InMemoryDataProvider<Todo>
    {
        public InMemoryTodoProvider() : base()
        {
            Add(new Todo() { Id = 0, Description = "C#" });
            Add(new Todo() { Id = 1, Description = "Architecture" });
        }
    }
}
