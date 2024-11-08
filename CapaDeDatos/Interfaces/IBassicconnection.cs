using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDeDatos.Interfaces
{
    internal interface IBasicConnection
    {
        SqlConnection Myconnection { get; set; }
        SqlCommand Mycommand { get; set; } 
        string Referente { get; set; }
        string ConnectionString { get; set; }
        void OpenConnection();
    
    }
}
