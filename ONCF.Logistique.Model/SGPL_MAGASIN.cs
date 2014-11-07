using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_MAGASIN
    {
        private int _Magasin_Id	;
        private string _Magasin_Libelle;
        public SGPL_MAGASIN()        { }
        public int Magasin_Id
        {
            get { return _Magasin_Id; }
            set { this._Magasin_Id = value; }
        }
        public string Magasin_Libelle
        {
            get { return _Magasin_Libelle; }
            set { this._Magasin_Libelle = value; }
        }
    }
}
