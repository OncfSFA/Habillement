using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_MARCHE
    {
        private int _Marche_Id	;
        private string _Marche_Num	;
        private DateTime _Marche_Date	;
        private string _Marche_Fournisseur;
        public SGPL_MARCHE()        { }

        public int Marche_Id
        {
            get { return _Marche_Id; }
            set { this._Marche_Id = value; }
        }
        public string Marche_Num
        {
            get { return _Marche_Num; }
            set { this._Marche_Num = value; }
        }
        public DateTime Marche_Date
        {
            get { return _Marche_Date; }
            set { this._Marche_Date = value; }
        }
        public string Marche_Fournisseur
        {
            get { return _Marche_Fournisseur; }
            set { this._Marche_Fournisseur = value; }
        }
    }
}
