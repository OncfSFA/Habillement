using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_ORDRE_LIVRAISON
    {
        private int _OrdreLivraison_Id	;
        private string _OrdreLivraison_Numero	;
        private DateTime _OrdreLivraison_DateLivraison;
        private int _OrdreLivraison_UtilisateurId;
        private DateTime _OrdreLivraison_DateCreation;
        private int _OrdreLivraison_ModuleId;

        public  SGPL_ORDRE_LIVRAISON() { }
        public int OrdreLivraison_Id
        {
            get { return _OrdreLivraison_Id; }
            set { this._OrdreLivraison_Id = value; }
        }
        public int OrdreLivraison_UtilisateurId
        {
            get { return _OrdreLivraison_UtilisateurId; }
            set { this._OrdreLivraison_UtilisateurId = value; }
        }
        public DateTime OrdreLivraison_DateCreation
        {
            get { return _OrdreLivraison_DateCreation; }
            set { this._OrdreLivraison_DateCreation = value; }
        }
        public int  OrdreLivraison_ModuleId
        {
            get { return _OrdreLivraison_ModuleId; }
            set { this._OrdreLivraison_ModuleId = value; }
        }
        public string OrdreLivraison_Numero
        {
            get { return _OrdreLivraison_Numero; }
            set { this._OrdreLivraison_Numero = value; }
        }
        public DateTime OrdreLivraison_DateLivraison
        {
            get { return _OrdreLivraison_DateLivraison; }
            set { this._OrdreLivraison_DateLivraison = value; }
        }
    }
}
