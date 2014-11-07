using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_Article
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();


        public DataSet GetArticleById(int id, string codeEffet)
        {
            try
            {
                db.AddParameter("@Correspondance_CodeEffet", codeEffet);
                db.AddParameter("@Correspondance_Id", id);
                Ds = db.ExecuteDataSet("SGPL_GetArticleById", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetArticleById:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public void AjouteArticle(SGPL_ARTICLE article)
        {

            db.AddParameter("@Correspondance_CodeEffet", article.Article_CodeEffet);
            db.AddParameter("@Correspondance_CodeArticle", article.Article_CodeArticle);
            db.AddParameter("@Correspondance_Module", article.Article_ModuleId);
            db.AddParameter("@Correspondance_LibelleEffet", article.LibelleEffet);
                db.ExecuteNonQuery("SGPL_InsertArticle", CommandType.StoredProcedure);
               
           
        }

        public void UpdateArticle(SGPL_ARTICLE article)
        {
            db.AddParameter("@Correspondance_Id", article.Article_Id);
            db.AddParameter("@Correspondance_CodeEffet", article.Article_CodeEffet);
            db.AddParameter("@Correspondance_CodeArticle", article.Article_CodeArticle);
            db.AddParameter("@Correspondance_Module", article.Article_ModuleId);
            db.AddParameter("@Correspondance_LibelleEffet", article.LibelleEffet);

            db.ExecuteNonQuery("SGPL_UpdateArticle", CommandType.StoredProcedure);

            
        }
      
        public void DeleteArticle(int id)
        {
            db.AddParameter("@ArticlePrevision_Id", id);

            db.ExecuteNonQuery("SGPL_DeletArticlePrevision", CommandType.StoredProcedure);


        }
        public DataSet GetArticleByModulEtablissement(int ModuleId, string IdValeur, int TypeValeur)
        {
            try
            {
                db.AddParameter("@IdModule", ModuleId);
                db.AddParameter("@Value", TypeValeur);
                db.AddParameter("@IdValue", IdValeur);

                Ds = db.ExecuteDataSet("SGPL_GetListArticleBy_Date_Etab_Dir_Pol", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetListArticleBy_Date_Etab_Dir_Pol:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }

    }
}
