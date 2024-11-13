using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class ParentSingleton //puerta de acceso a todas las clases que quiera compartir de la capa de datos a la capa de negocio
    {
        public IConnection IConnection => Connection.GetInstance; //nos permite conectar la base de datos 
        public IJsonConverter IJsonConverter//nos permite convertir una fila o tabla en Json
        {
            get => new JsonConverter();
        } 


    }
}
