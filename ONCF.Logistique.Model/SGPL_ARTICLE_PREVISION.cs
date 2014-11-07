using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_ARTICLE_PREVISION
    {
      private int _ArticlePrevision_Id	;
      private int _ArticlePrevision_PrevisionId	;
      private string _ArticlePrevision_ArticleId	;
      private string _ArticlePrevision_ArticleDesing;
      private int _ArticlePrevision_QtePrevision	;
      private int _ArticlePrevision_QteRecue	;
      private int _ArticlePrevision_EstLivree;
      private int _ArticlePrevision_OrdreLivraisonId;
      private int _ArticlePrevision_UtilisateurId;
      private int _ArticlePrevision_Taille;
      public SGPL_ARTICLE_PREVISION()  { }

      public string ArticlePrevision_ArticleDesing
      {
          get { return _ArticlePrevision_ArticleDesing; }
          set { this._ArticlePrevision_ArticleDesing = value; }
      }
      public int ArticlePrevision_Id
      {
          get { return _ArticlePrevision_Id; }
          set { this._ArticlePrevision_Id = value; }
      }
      public int ArticlePrevision_Taille
      {
          get { return _ArticlePrevision_Taille; }
          set { this._ArticlePrevision_Taille = value; }
      }
      public int ArticlePrevision_UtilisateurId
      {
          get { return _ArticlePrevision_UtilisateurId; }
          set { this._ArticlePrevision_UtilisateurId = value; }
      }
      public int ArticlePrevision_PrevisionId
      {
          get { return _ArticlePrevision_PrevisionId; }
          set { this._ArticlePrevision_PrevisionId = value; }
      }
      public string ArticlePrevision_ArticleId
      {
          get { return _ArticlePrevision_ArticleId; }
          set { this._ArticlePrevision_ArticleId = value; }
      }
      public int ArticlePrevision_QtePrevision
      {
          get { return _ArticlePrevision_QtePrevision; }
          set { this._ArticlePrevision_QtePrevision = value; }
      }
      public int ArticlePrevision_QteRecue
      {
          get { return _ArticlePrevision_QteRecue; }
          set { this._ArticlePrevision_QteRecue = value; }
      }
      public int ArticlePrevision_EstLivree
      {
          get { return _ArticlePrevision_EstLivree; }
          set { this._ArticlePrevision_EstLivree = value; }
      }
      public int ArticlePrevision_OrdreLivraisonId
      {
          get { return _ArticlePrevision_OrdreLivraisonId; }
          set { this._ArticlePrevision_OrdreLivraisonId = value; }
      }
    }
}
