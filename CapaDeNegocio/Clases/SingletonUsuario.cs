using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Text.Json.Serialization;
namespace CapaDeNegocio
{
    internal partial class Singleton : ISingletonUsuario// es una clase parcial porque se va a comportar como ISingleton usuario
    {
        #region InstanciaSingletonUsuario
        public ISingletonUsuario ISU {  get => this; }//aca se produce el polimorfismo obteniendo una instancia de la propia clase que se comporta como Isingleton usuario

        #endregion
        #region IgenericSingletonUsuario
        void IGenericSingleton<Usuario>.Add(Usuario Data)//aca se implementa el metodo add que recibe como parametro un usuario que se llama Data en este caso
        {
            if (Data.DniExist()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExist()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Insert", "Usuario");//Iconnection ya pertenece a la capa de datos
            IConnection.ParameterAddVarChar("Nombre", Data.Nombre);//mapeo
            IConnection.ParameterAddInt("Dni", Data.Dni);//mapeo
            IConnection.ParameterAddVarChar("Mail", Data.Mail);//mapeo
            Data.ID = IConnection.Insert();//devuelve la primera columna de la primera fila, osea el ID
        }
        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Delete", "Usuarios");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.Delete();
        }
        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Find", "Usuarios");
            IConnection.ParameterAddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }
        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            if (Data.DniExist()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExist()) throw new Exception("Existe otro usuario con el mismo Mail");
            IConnection.CreateCommand("Usuarios_Update", "Usuario");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Nombre", Data.Nombre);
            IConnection.ParameterAddInt("Dni", Data.Dni);
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            IConnection.Update();
        }
        #endregion
        #region SingletonUsuario
        bool ISingletonUsuario.MailExists(Usuario Data) 
        {
            IConnection.CreateCommand("Usuarios_MailExists", "Usuarios");
            IConnection.ParameterAddInt("id", Data.ID);
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            return IConnection.Exists();
        }
        bool ISingletonUsuario.DniExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_DniExists", "Usuario");
            IConnection.ParameterAddInt("id", Data.ID);
            IConnection.ParameterAddInt("Dni", Data.Dni);
            return IConnection.Exists();
        }
        string ISingletonUsuario.FindByDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByDni", "Usuario");
            IConnection.ParameterAddInt("Dni", Data.Dni);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }
        string ISingletonUsuario.FindByMail(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMail", "Usuarios");
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }
        string ISingletonUsuario.List()
        {
            try
            {
                IConnection.CreateCommand("Usuarios_List", "Usuarios");//se crea el comando usuario list que es el que figura en nuestra bd
                DataTable Dt = IConnection.List();//se almacena un data table porque nos va a devolver una lista
                return IJsonConverter.TableToJson(Dt);
            }
            catch (Exception)
            {
                throw new Exception("ERROR:no se pudo listar los usuarios");
            }        
        }

        #endregion



    }



}
