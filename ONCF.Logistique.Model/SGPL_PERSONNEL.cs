using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_PERSONNEL
    {
        private int _Personnel_Id	;
        private string _Personnel_Matricule	;
        private string _Personnel_Nom	;
        private string _Personnel_Prenom	;
        private int _Personnel_FonctionPrincipale	;
        private int _Personnel_Etat;
        public  SGPL_PERSONNEL()    { }

        public int Personnel_Id
        {
            get { return _Personnel_Id; }
            set { this._Personnel_Id = value; }
        }
        public string Personnel_Matricule
        {
            get { return _Personnel_Matricule; }
            set { this._Personnel_Matricule = value; }
        }
        public string Personnel_Prenom
        {
            get { return _Personnel_Prenom; }
            set { this._Personnel_Prenom = value; }
        }
        public int Personnel_FonctionPrincipale
        {
            get { return _Personnel_FonctionPrincipale; }
            set { this._Personnel_FonctionPrincipale = value; }
        }
        public string Personnel_Nom
        {
            get { return _Personnel_Nom; }
            set { this._Personnel_Nom = value; }
        }
        public int Personnel_Etat
        {
            get { return _Personnel_Etat; }
            set { this._Personnel_Etat = value; }
        }
    }
}
