using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_KIT_ARTICLE
    {
        private int _KitArticle_Id	;
        private int _KitArticle_KitHabillementId	;
        private int _KitArticle_ArticleId	;
        private int _KitArticle_Periodicite;
        private int _KitArticle_Qte;
        public  SGPL_KIT_ARTICLE(){ }

        public int KitArticle_Id
        {
            get { return _KitArticle_Id; }
            set { this._KitArticle_Id = value; }
        }
        public int KitArticle_KitHabillementId
        {
            get { return _KitArticle_KitHabillementId; }
            set { this._KitArticle_KitHabillementId = value; }
        }
        public int KitArticle_ArticleId
        {
            get { return _KitArticle_ArticleId; }
            set { this._KitArticle_ArticleId = value; }
        }
        public int KitArticle_Periodicite
        {
            get { return _KitArticle_Periodicite; }
            set { this._KitArticle_Periodicite = value; }
        }
        public int KitArticle_Qte
        {
            get { return _KitArticle_Qte; }
            set { this._KitArticle_Qte = value; }
        }
    }
}
