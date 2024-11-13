using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
namespace CapaDeNegocio
{
    public interface ISingletonUsuario : IGenericSingleton<Usuario>
    {
        bool MailExists(Usuario Data);
        bool DniExists(Usuario Data);
        string FindByDni(Usuario Data);
        string FindByMail(Usuario Data);
        string List();

    }

}

