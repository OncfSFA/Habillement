using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_REF_FONCTION
    {       
        private int _Fonction_Id;
        private string _Fonction_Libelle;
        private int _Fonction_KitHabillementId	;
        public SGPL_REF_FONCTION()  { }
        public int Fonction_Id
        {
            get { return _Fonction_Id; }
            set { this._Fonction_Id = value; }
        }
        public string Fonction_Libelle
        {
            get { return _Fonction_Libelle; }
            set { this._Fonction_Libelle = value; }
        }
        public int Fonction_KitHabillementId
        {
            get { return _Fonction_KitHabillementId; }
            set { this._Fonction_KitHabillementId = value; }
        }
        
    }
}
