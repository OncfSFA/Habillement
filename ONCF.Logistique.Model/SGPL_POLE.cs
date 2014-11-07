using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
   public  class SGPL_POLE
    {
       private int _Pole_Id;
       private string _Pole_Libelle;
       public SGPL_POLE() { }
       public int Pole_Id
        {
            get { return _Pole_Id; }
            set { this._Pole_Id = value; }
        }
       public string Pole_Libelle
        {
            get { return _Pole_Libelle; }
            set { this._Pole_Libelle = value; }
        }
 
    }
}
