using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crud;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] == null) return;
        switch (Request["accion"])
        {

            case "ADDUSUARIO": AddUsuario(); break;
            case "LISTUSUARIOS": ListUsuarios(); break;
            case "DELETEUSUARIO": DeleteUsuario(); break;
            case "MODIFYUSUARIO": ModifyUser(); break;
            case "FINDUSUARIO": FindUser(); break;//nuevo caso
        }
    }

        private void AddUsuario()
        {
            Usuario U = new Usuario();
            U.Nombre = Request["Nombre"];
            U.Mail = Request["Mail"];
            U.Dni = int.Parse(Request["Dni"]);
            try
            {
                U.Add();
                Response.Write("OK");
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }

        }
    private void ListUsuarios()
    {
        Usuario U = new Usuario();
        string lista = U.List();
        Response.Write(lista);

    }

    private void DeleteUsuario ()
    {
        Usuario U = new Usuario();
        U.ID= int.Parse(Request["id"]);
        try
        {
            U.Erase();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }

    private void ModifyUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);
        U.Nombre = Request["Nombre"];
        try
        {
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }
    private void FindUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);
        try
        {
            string user = U.Find();
            Response.Write(user);
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }    

    }
    


} 


