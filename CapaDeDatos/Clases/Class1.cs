using CapaDeDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Clases
{
    internal class Connection : IBasicConnection, IConnection
    {
        public SqlConnection MyConnection { get; set; }
        public SqlCommand MyCommand { get; set; }
        public string Referente { get; set; }
        public string ConnectionString { get; set; }

        static Connection instance = new Connection();
        public static Connection GetInstance => instance;
        private Connection() 
        {
            string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "web.config";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                MyConnection = new SqlConnection(ConnectionString);
                return;
            }
            throw new Exception("ERROR:No se encontro la base de datos");
        
        }
         public void OpenConnection()
        {
            if (MyConnection.State != System.Data.ConnectionState.Open)
                try
                {
                    MyConnection.Open();
                }
                catch (Exception) 
                {
                    throw new Exception("ERROR:No se puede abrir la conexion");
                }
        }
        public void CreateCommand(string storeprocedure, string refetente)
        {
            MyCommand = new SqlCommand(storeprocedure, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            Referente = refetente;
        }
           
        public void Delete() 
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR:No se puede eliminar el registro"+ Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        
        }
      
        public void Exists() 
        { 
        OpenConnection() ;
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                
                return i > 0;
            }
            catch
           {
                throw new Exception("ERROR:No se pudo encontrar" + Referente);
           }
            finally { MyConnection.Close(); }
        }

        public int insert()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                return i;
            }
            catch (Exception)
            {
                throw new Exception("ERROR:no se pudo agregar" + Referente);
            }
            finally { MyConnection.Close(); }
        }
        public void InsertWithoutID()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            
            catch(Exception) 
            {
                throw new Exception("ERROR:no se pudo insertar el registro");
            }
            finally
            {

            MyConnection.Close(); 
            }
        }
}
}
