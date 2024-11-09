using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public interface IGenericSingleton <T>
    {
        void Add(T data);
        void Erase(T data);
        void Modify (T data);
        string Find (T data);

    }
}
