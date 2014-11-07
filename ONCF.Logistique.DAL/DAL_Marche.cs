using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_Marche
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();


        
        public int AjouteMarche(SGPL_MARCHE marche)
        {
            int idUtilisateur = 0;
            db.AddParameter("@Marche_Num", marche.Marche_Num);
            db.AddParameter("@Marche_Date", marche.Marche_Date);
            db.AddParameter("@Marche_Fournisseur", marche.Marche_Fournisseur);

            DataSet retVal = db.ExecuteDataSet("SGPL_InsertMarche", CommandType.StoredProcedure);
                if (retVal.Tables[0].Rows.Count > 0)
                {
                    idUtilisateur = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());
                }
            
            return idUtilisateur;
        }
        public void UpdateMarche(SGPL_MARCHE marche)
        {
            db.AddParameter("Marche_Id", marche.Marche_Id);
            db.AddParameter("Marche_Num", marche.Marche_Num);
            db.AddParameter("Marche_Date", marche.Marche_Date);
            db.AddParameter("Marche_Fournisseur", marche.Marche_Fournisseur);

            db.ExecuteNonQuery("SGPL_UpdateMarche", CommandType.StoredProcedure);
           
        }
        public void  AjoutMarcheArticle(SGPL_MARCHE_ARTICLE MarcheArticle)
        {
            db.AddParameter("@MarcheArticle_MarcheId", MarcheArticle.MarcheArticle_MarcheId);
            db.AddParameter("@MarcheArticle_ArticleId", MarcheArticle.MarcheArticle_ArticleId);
            db.AddParameter("@MarcheArticle_UtilisateurId", MarcheArticle.MarcheArticle_UtilisateurId);
            db.AddParameter("@MarcheArticle_DateCreation", MarcheArticle.MarcheArticle_DateCreation);
            db.AddParameter("@MarcheArticle_ArticlLibelle", MarcheArticle.MarcheArticle_ArticlLibelle);
            db.ExecuteNonQuery("SGPL_InsertMARCHE_ARTICLE", CommandType.StoredProcedure);
                        
        }
        public DataSet GetArticleByModul(int id)
        {
            try
            {
                db.AddParameter("Article_ModuleId", id);

                Ds = db.ExecuteDataSet("SGPL_GetArticleByModule", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetArticleByModule:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet GetMarche(int idmodule)
        {
            try
            {
                db.AddParameter("Utilisateur_ModuleId", idmodule);

                Ds = db.ExecuteDataSet("SGPL_GetMarche", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetMarche:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }

        public DataSet GetMarcheById(int idMarche)
        {
            try
            {
                db.AddParameter("Marche_Id", idMarche);

                Ds = db.ExecuteDataSet("SGPL_GetMarcheBuId", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetMarcheBuId:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet GetMarcheArticleByIdMarche(int idMarche)
        {
            try
            {
                db.AddParameter("MarcheArticle_MarcheId", idMarche);

                Ds = db.ExecuteDataSet("SGPL_GetMarcheArticleById", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetMarcheArticleById:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public void DeleteMarcheArticle(int idmarche)
        {
            db.AddParameter("MarcheArticle_MarcheId", idmarche);

            db.ExecuteNonQuery("SGPL_DeleteMercheARTICLE", CommandType.StoredProcedure);

        }
        public void DeleteMarche(int idmarche)
        {
            db.AddParameter("Marche_Id", idmarche);

            db.ExecuteNonQuery("SGPL_DeleteMarche", CommandType.StoredProcedure);

        }
    }
}
