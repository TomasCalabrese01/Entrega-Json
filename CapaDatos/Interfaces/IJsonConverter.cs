using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public interface IJsonConverter
    {
        string RowToJson(DataRow Dr);//fila
        string TableToJson(DataTable Dt);
    }
}
