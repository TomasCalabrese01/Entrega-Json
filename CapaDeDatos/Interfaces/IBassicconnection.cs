﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDeDatos
{
    public interface IBasicConnection
    {
        SqlConnection MyConnection { get; set; }
        SqlCommand MyCommand { get; set; } 
        string Referente { get; set; }
        string ConnectionString { get; set; }
        void OpenConnection();
    
    }
}
