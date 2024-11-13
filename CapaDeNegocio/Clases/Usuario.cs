﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CapaDeNegocio
{
    public class Usuario : IUsuario
    {
        internal Singleton S { get => Singleton.GetInstance; } //obtengo la instancia singleton
        
        #region IID
        public int ID { get ; set ; }

        #endregion

        #region IUsuario
        public string Nombre { get ; set ; }
        public int Dni { get; set; }
        public string Mail { get; set; }

        public bool DniExist()
        {

            return S.ISU.DniExists(this);
            
        }
        public bool MailExist()
        {
            return S.ISU.MailExists(this);

        }
        //-------------realizar los alumnos
        public string FindByDni()
        {
            return S.ISU.FindByDni(this);
        }

        public string FindByMail()
        {
            return S.ISU.FindByMail(this);
        }
        //---------------------------------

        public string List()
        {

            return S.ISU.List();//encapsulamiento, singleton se transforma en ISU
        }
        #endregion

        #region IABMC
        public void Add()
        {
            S.ISU.Add(this);//encapsulamiento, la clase singleton se comporta como ISU, el que realiza la accion es la instancia singleton
        }
        public void Erase()
        {
            S.ISU.Erase(this);
        }

        public string Find()
        {
            
            return S.ISU.Find(this);
        }
        
        public void Modify()
        {
            S.ISU.Modify(this);
        }
        #endregion

    }
}
