using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using classes.Models;
using EFDataAccessLibrary.Models;

namespace classes.Providers
{
    public class InMemoryCategoryProvider : InMemoryDataProvider<Category>
    {
        public InMemoryCategoryProvider() : base()
        {
            Add(new Category() { Id = 0, Name = "C#" });
            Add(new Category() { Id = 1, Name = "Architecture" });
        }
    }
}
