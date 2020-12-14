using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes.Providers
{
    public interface IDataProvider<DataClass>
    {
        //Create
        void Add(DataClass todo);

        //Read
        List<DataClass> GetAll();
        DataClass Get(int id);

        //Update
        void Update(DataClass todo);

        //Delete
        void Remove(int id);
    }
}