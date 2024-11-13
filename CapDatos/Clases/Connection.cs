using CapaDeDatos;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
        public class Connection : IBasicConnection, IConnection
    {
        public SqlConnection MyConnection { get; set; }
        public SqlCommand MyCommand { get; set; }
        public string Referente { get; set; }//tabla
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
        public void CreateCommand(string storeprocedure, string refetente)//store procedure es lo que se encuentra creado en la base de datos en este caso usuarios inser
        {
            MyCommand = new SqlCommand(storeprocedure, MyConnection); //en ese momento es usuarios insert
            MyCommand.CommandType = CommandType.StoredProcedure;//se crea el comando 
            Referente = refetente;//es la tabla usuario 
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
      
        public bool Exists() 
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

        public int Insert()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());//ejecuta el comando y devuelve la primera columna de la primera fila
                return i; //devuelve el valor de la primera columna de la primera fila (ID)
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

        public DataTable List()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader());//carga en la tabla de datos
                return DT;

            }
            catch( Exception ) 
            {
                throw new Exception("ERROR:no se pudo listar " + Referente);
            }
            finally { MyConnection.Close( ); } 

        }
        public DataRow Find()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader());
                return DT.Rows[0];
            }
            catch ( Exception )
            {
                throw new Exception("ERROR:no se pudo encontrar" + Referente);
            }
            finally { MyConnection.Close();}
        }
        public void Update()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw new Exception("ERROR:no se pudo actualizar el registro");
            }
            finally
            {

                MyConnection.Close();
            }
        }
        #region Tparameters
        public void ParameterAddBool(string Name, bool value)
        {
            MyCommand.Parameters.AddWithValue("@"+ Name, value); 
        }
        public void ParameterAddDateTime(string Name, DateTime value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, value);
        }

        public void ParameterAddFloat(string Name,double value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, value);
        }
        public void ParameterAddInt(string Name, int value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, value);
        }
        public void ParameterAddVarChar(string Name, string value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, value);//aca vemos como lo mapea el nombre 
        }

    }
    #endregion
}

