using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDeDatos.Interfaces
{
    internal interface IParameters
    {
        void ParameterAddVarChar (string name, int len, string value);
        void ParameterAddInt (string name, string value);
        void ParameterAddBool (string name, bool value);
        void ParameterAddDateTime (string name, System.DateTime value);
        void ParameterAddFloat  (string name, double value);
    }
}
