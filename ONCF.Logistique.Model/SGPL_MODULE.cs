using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
   public  class SGPL_MODULE
    {
       private int _Module_Id	;
       private string _Module_Libelle;
        public SGPL_MODULE() { }
        public int Module_Id
        {
            get { return _Module_Id; }
            set { this._Module_Id = value; }
        }
        public string Module_Libelle
        {
            get { return _Module_Libelle; }
            set { this._Module_Libelle = value; }
        }
 
    }
}
