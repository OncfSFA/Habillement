using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_ETABLISSEMENT
    {
        private int _Etablissement_Id	;
        private string _Etablissement_Libelle;
        private int _Etablissement_DirectionId	;
        public  SGPL_ETABLISSEMENT()     { }

        public int Etablissement_Id
        {
            get { return _Etablissement_Id; }
            set { this._Etablissement_Id = value; }
        }
        public string Etablissement_Libelle
        {
            get { return _Etablissement_Libelle; }
            set { this._Etablissement_Libelle = value; }
        }
        public int Etablissement_DirectionId
        {
            get { return _Etablissement_DirectionId; }
            set { this._Etablissement_DirectionId = value; }
        }
    }
}
