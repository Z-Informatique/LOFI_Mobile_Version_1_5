using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Helpers
{
    public class SerializeClass<T>
    {
        public string Serialize(T t)
        {
            string data = JsonConvert.SerializeObject(t);
            return data;
        }

        public T Deserialize(string obj)
        {
            T data = JsonConvert.DeserializeObject<T>(obj);
            return data;
        }
    }
}
