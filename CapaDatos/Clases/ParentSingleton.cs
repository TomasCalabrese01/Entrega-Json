using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ParentSingleton
    {
        public IConnection IConnection => Connection.GetInstance;
        public IJsonConverter IJsonConverter
        {
            get => new JsonConverter();
        } 


    }
}
