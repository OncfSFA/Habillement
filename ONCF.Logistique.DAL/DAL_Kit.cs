using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_Kit
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();


        
        public int AjouteKit(SGPL_KIT_HABILLEMENT kit)
        {
            int id = 0;
            db.AddParameter("@KitHabillement_Libelle", kit.KitHabillement_Libelle);
            db.AddParameter("@KitHabillement_Sexe", kit.KitHabillement_Sexe);
            db.AddParameter("@KitHabillement_ModuleId", kit.KitHabillement_ModuleId);
            DataSet retVal = db.ExecuteDataSet("SGPL_InsertKIT_HABILLEMENT", CommandType.StoredProcedure);
                if (retVal.Tables[0].Rows.Count > 0)
                {
                    id = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());
                }
            
            return id;
        }
        public void UpdateKit(SGPL_KIT_HABILLEMENT marche)
        {
            db.AddParameter("KitHabillement_Id", marche.KitHabillement_Id);
            db.AddParameter("KitHabillement_Libelle", marche.KitHabillement_Libelle);
            db.AddParameter("KitHabillement_Sexe", marche.KitHabillement_Sexe);

            db.ExecuteNonQuery("SGPL_UpdateKIT_HABILLEMENT", CommandType.StoredProcedure);
           
        }
        public void AjoutKitArticle(SGPL_KIT_ARTICLE MarcheArticle)
        {
            db.AddParameter("@KitArticle_KitHabillementId", MarcheArticle.KitArticle_KitHabillementId);
            db.AddParameter("@KitArticle_ArticleId", MarcheArticle.KitArticle_ArticleId);
            db.AddParameter("@KitArticle_Periodicite", MarcheArticle.KitArticle_Periodicite);
            db.AddParameter("@KitArticle_Qte", MarcheArticle.KitArticle_Qte);
            db.ExecuteNonQuery("SGPL_InsertKIT_ARTICLE", CommandType.StoredProcedure);
                        
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

        public DataSet GetKitById(int idMarche)
        {
            try
            {
                db.AddParameter("KitHabillement_Id", idMarche);

                Ds = db.ExecuteDataSet("SGPL_GetKitHabillementById", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetKitHabillementById:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet GeteffetByFonction(string idfonction)
        {
            try
            {
                db.AddParameter("@codeFonction", idfonction);

                Ds = db.ExecuteDataSet("SGPL_INTER_GetArticleByFonction", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_INTER_GetArticleByFonction:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public void DeleteKitArticle(int idmarche)
        {
            db.AddParameter("KitArticle_KitHabillementId", idmarche);

            db.ExecuteNonQuery("SGPL_DeletekitARTICLE", CommandType.StoredProcedure);

        }

        public DataSet GetKitByPersonne(string idpers)
        {
            try
            {
                db.AddParameter("@MATRICULE", idpers);

                Ds = db.ExecuteDataSet("SGPL_INTER_GetFonctionByMatricule", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_INTER_GetFonctionByMatricule:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
    }
}
