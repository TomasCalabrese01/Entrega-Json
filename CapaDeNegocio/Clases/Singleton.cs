using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;   
namespace CapaDeNegocio
{
    internal partial class Singleton : ParentSingleton 
    {
        static Singleton instance => new Singleton();// static : se carga una sola vez cuando se invoca por primera vez a la clase
        private Singleton() { } // private : permite que no se pueda crear otro constructor publico
        public static Singleton GetInstance => instance; // nos va a devolver la instancia 
    }
}
