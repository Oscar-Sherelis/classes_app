using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes.Providers
{
    public interface IHasId
    {
        public int Id { get; set; }
        // List<Models.Label> Labels { get; set; }
    }
}
