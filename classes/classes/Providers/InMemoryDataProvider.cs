using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace classes.Providers
{
    public class InMemoryDataProvider<DataClass> : IDataProvider<DataClass> where DataClass : IHasId
    {
        private static int MaxId = -1;

        private List<DataClass> data = new List<DataClass>();

        public void Add(DataClass item)
        {
            item.Id = ++MaxId;
            data.Add(item);
        }

        public List<DataClass> GetAll()
        {
            return data;
        }

        public DataClass Get(int id)
        {
            DataClass item = data.Find(d => d.Id == id);
            if (item == null)
            {
                throw new ProviderHasNoDataException(item.Id);
            }
            return item;
        }

        public void Update(DataClass item)
        {
            DataClass oldItem = Get(item.Id);
            if (item != null)
            {
                data.Remove(oldItem);
                data.Add(item);
            }
            else
            {
                throw new ProviderHasNoDataException(item.Id);
            }
        }

        public void Remove(int id)
        {
            DataClass item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
            else
            {
                throw new ProviderHasNoDataException(id);
            }
        }
    }

    [Serializable]
    internal class ProviderHasNoDataException : Exception
    {
        private object id;

        public ProviderHasNoDataException()
        {
        }

        public ProviderHasNoDataException(object id)
        {
            this.id = id;
        }

        public ProviderHasNoDataException(string message) : base(message)
        {
        }

        public ProviderHasNoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProviderHasNoDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
