using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_LIVRAISON
    {
        private int _Livraison_Id	;
        private DateTime _Livraison_Date	;
        private int _Livraison_QteLivraison	;
        private int _Livraison_MagasinId	;
        private int _Livraison_StatutLivraisonId	;
        private int _Livraison_ArticlePrevisionId;

        private string _Livraison_ArticleDesing;
        private int _Livraison_Etablissement;
        private int _Livraison_UtilisateurId;
        private DateTime _Livraison_DateCreation;
        private int _Livraison_Module;
        private int _Livraison_QtePrev;
        public SGPL_LIVRAISON()   {}
        public string Livraison_ArticleDesing
        {
            get { return _Livraison_ArticleDesing; }
            set { this._Livraison_ArticleDesing = value; }
        }
        public DateTime Livraison_DateCreation
        {
            get { return _Livraison_DateCreation; }
            set { this._Livraison_DateCreation = value; }
        }
        public int Livraison_QtePrev
        {
            get { return _Livraison_QtePrev; }
            set { this._Livraison_QtePrev = value; }
        }
        public int Livraison_Module
        {
            get { return _Livraison_Module; }
            set { this._Livraison_Module = value; }
        }
        public int Livraison_Etablissement
        {
            get { return _Livraison_Etablissement; }
            set { this._Livraison_Etablissement = value; }
        }
        public int Livraison_UtilisateurId
        {
            get { return _Livraison_UtilisateurId; }
            set { this._Livraison_UtilisateurId = value; }
        }
        public int Livraison_Id
        {
            get { return _Livraison_Id; }
            set { this._Livraison_Id = value; }
        }
        public int Livraison_QteLivraison
        {
            get { return _Livraison_QteLivraison; }
            set { this._Livraison_QteLivraison = value; }
        }
        public int Livraison_MagasinId
        {
            get { return _Livraison_MagasinId; }
            set { this._Livraison_MagasinId = value; }
        }
        public int Livraison_StatutLivraisonId
        {
            get { return _Livraison_StatutLivraisonId; }
            set { this._Livraison_StatutLivraisonId = value; }
        }
        public DateTime Livraison_Date
        {
            get { return _Livraison_Date; }
            set { this._Livraison_Date = value; }
        }
        public int Livraison_ArticlePrevisionId
        {
            get { return _Livraison_ArticlePrevisionId; }
            set { this._Livraison_ArticlePrevisionId = value; }
        }
    }
}
