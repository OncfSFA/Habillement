using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_MARCHE_ARTICLE
    {
        private int _MarcheArticle_Id	;
        private int _MarcheArticle_MarcheId	;
        private string _MarcheArticle_ArticleId;
        private int _MarcheArticle_UtilisateurId;
        private DateTime _MarcheArticle_DateCreation;
        private string _MarcheArticle_ArticlLibelle;
        public SGPL_MARCHE_ARTICLE()      { }

        public int MarcheArticle_Id
        {
            get { return _MarcheArticle_Id; }
            set { this._MarcheArticle_Id = value; }
        }
        public int MarcheArticle_MarcheId
        {
            get { return _MarcheArticle_MarcheId; }
            set { this._MarcheArticle_MarcheId = value; }
        }
        public string MarcheArticle_ArticlLibelle
        {
            get { return _MarcheArticle_ArticlLibelle; }
            set { this._MarcheArticle_ArticlLibelle = value; }
        }
        public string MarcheArticle_ArticleId
        {
            get { return _MarcheArticle_ArticleId; }
            set { this._MarcheArticle_ArticleId = value; }
        }
        public int MarcheArticle_UtilisateurId
        {
            get { return _MarcheArticle_UtilisateurId; }
            set { this._MarcheArticle_UtilisateurId = value; }
        }
        public DateTime MarcheArticle_DateCreation
        {
            get { return _MarcheArticle_DateCreation; }
            set { this._MarcheArticle_DateCreation = value; }
        }
   
    }
}
