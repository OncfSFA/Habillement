using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_Prevision
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();

      
        public DataSet GetPrevisionByModule(int annee, int module, string agent, int EtablissementId)
        {
            string exist = "Non";
            db.AddParameter("@Annee", annee);
            db.AddParameter("@Prevision_ModuleId", module);
            db.AddParameter("@Prevision_Agent", agent);
            db.AddParameter("@Prevision_EtablissementId", EtablissementId);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionbyModule", CommandType.StoredProcedure);
           

            return retVal;
        }
        public DataSet GetActivedesactive(int module, string action)
        {
            //int id = 0;
            db.AddParameter("@ActiveDesactive_Module", module);
            db.AddParameter("@ActiveDesactive_Action", action);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetActiveDesactive", CommandType.StoredProcedure);
            //if (retVal.Tables[0].Rows.Count > 0)
            //{
            //    id = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());
            //}

            return retVal;
        }
        public void Activedesactive(DateTime  dateD,DateTime dateF, int module, string action)
        {
            db.AddParameter("@ActiveDesactive_DateD", dateD);
            db.AddParameter("@ActiveDesactive_DateF", dateF);
            db.AddParameter("@ActiveDesactive_Module", module);
            db.AddParameter("@ActiveDesactive_Action", action);
            db.ExecuteNonQuery("SGPL_UpdateActiveDesactive", CommandType.StoredProcedure);
        }
        public int AjoutePrevision(SGPL_PREVISION previs)
        {
            int id = 0;
            db.AddParameter("@Prevision_EtablissementId", previs.Prevision_EtablissementId);
            db.AddParameter("@Prevision_ModuleId", previs.Prevision_ModuleId);
            db.AddParameter("@Prevision_UtilisateurId", previs.Prevision_UtilisateurId);
            db.AddParameter("@Prevision_Agent", previs.Prevision_Agent);
            db.AddParameter("@Prevision_Flag", previs.Prevision_Flag);
            db.AddParameter("@Prevision_Fonction", previs.Prevision_Fonction);
            db.AddParameter("@Prevision_LibelEtab", previs.Prevision_LibelEtab);
            DataSet retVal = db.ExecuteDataSet("SGPL_InsertPrevisionHab", CommandType.StoredProcedure);
                if (retVal.Tables[0].Rows.Count > 0)
                {
                    id = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());
                }
            
            return id;
        }
        public void DeleteArticlePrevision(int idArticleprev)
        {
            db.AddParameter("@ArticlePrevision_Id", idArticleprev);
            db.ExecuteNonQuery("SGPL_DeletArticlePrevisionById", CommandType.StoredProcedure);
            
        }
        public DataSet GetReelCode(int code)
        {
            db.AddParameter("@code", code);
            DataSet retVal = db.ExecuteDataSet("SGPL_INTER_GetReelCode", CommandType.StoredProcedure);
            return retVal;
        }
        public void AjoutArticlePrevision(SGPL_ARTICLE_PREVISION Articlepreviv)
        {
            db.AddParameter("@ArticlePrevision_PrevisionId", Articlepreviv.ArticlePrevision_PrevisionId);
            db.AddParameter("@ArticlePrevision_ArticleId", Articlepreviv.ArticlePrevision_ArticleId);
            db.AddParameter("@ArticlePrevision_QtePrevision", Articlepreviv.ArticlePrevision_QtePrevision);
            db.AddParameter("@ArticlePrevision_UtilisateurId", Articlepreviv.ArticlePrevision_UtilisateurId);
            db.AddParameter("@ArticlePrevision_Taille", Articlepreviv.ArticlePrevision_Taille);
            db.AddParameter("@ArticlePrevision_ArticleDesing", Articlepreviv.ArticlePrevision_ArticleDesing);
            db.ExecuteNonQuery("SGPL_InsertArticlePrevision", CommandType.StoredProcedure);
                        
        }
        public void UpdateArticlePrevisionHab(SGPL_ARTICLE_PREVISION Articlepreviv,int exp)
        {
            db.AddParameter("@ArticlePrevision_Id", Articlepreviv.ArticlePrevision_Id);
            db.AddParameter("@ArticlePrevision_UtilisateurId", Articlepreviv.ArticlePrevision_UtilisateurId);
            db.AddParameter("@ArticlePrevision_Taille", Articlepreviv.ArticlePrevision_Taille);
            db.AddParameter("@ArticlePrevision_QteRecue", Articlepreviv.ArticlePrevision_QteRecue);
            db.AddParameter("@ArticlePrevision_EstLivree", Articlepreviv.ArticlePrevision_EstLivree);
            db.AddParameter("@Expedition", exp);
            db.ExecuteNonQuery("SGPL_UpdateArticlePrevisionHab", CommandType.StoredProcedure);

        }
         public void UpdatePrevisionFlag(int idPrev,int flag)
        {
            db.AddParameter("@ArticlePrevision_Id", idPrev);
            db.AddParameter("@Prevision_Flag", flag);
            db.ExecuteNonQuery("SGPL_UpdatePrevisionFlag", CommandType.StoredProcedure);

        }
        public DataSet GetArticlePrevisionHabForMod(string idAgent)
        {
            db.AddParameter("@Prevision_Agent", idAgent);
            DataSet ds= db.ExecuteDataSet("SGPL_GetArticlePrevisionForModif", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetPrevisionByModuleId(int annee, int module, int agent)
        {

            db.AddParameter("@Annee", annee);
            db.AddParameter("@Prevision_ModuleId", module);
            db.AddParameter("@Prevision_Agent", agent);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionbyModuleId", CommandType.StoredProcedure);

            return retVal;
        }



        public void UpdateArticlePrevision(SGPL_ARTICLE_PREVISION Articlepreviv)
        {
            db.AddParameter("@ArticlePrevision_Id", Articlepreviv.ArticlePrevision_Id);
            db.AddParameter("@ArticlePrevision_QtePrevision", Articlepreviv.ArticlePrevision_QtePrevision);
            db.ExecuteNonQuery("SGPL_UpdateArticlePrevision", CommandType.StoredProcedure);

        }
        public void UpdateStatutPrevision(int prevId,int statut,int userId)
        {
           
            db.AddParameter("@HistoStatutPrevision_PrevisionId", prevId);
            db.AddParameter("@HistoStatutPrevision_StatutPrevisionId", statut);
            db.AddParameter("@HistoStatutPrevision_UtilisateurId", userId);

            db.ExecuteNonQuery("SGPL_UpdateStatutPrevision", CommandType.StoredProcedure);

        }
        public DataSet GetStatutPrevision(int PrevisionID)
        {
            db.AddParameter("@HistoStatutPrevision_PrevisionId", PrevisionID);

           return db.ExecuteDataSet("SGPL_GetStatutPrev", CommandType.StoredProcedure);

        }

        public DataSet GetIdPrevisionToValidByPole(int Etablissement_PoleId)
        {

            db.AddParameter("@Etablissement_PoleId", Etablissement_PoleId);

            DataSet retVal = db.ExecuteDataSet("SGPL_GetIdPrevisionToValidByPole", CommandType.StoredProcedure);

            return retVal;

        }
         public DataSet GetIdPrevisionToValidByPoleHab(int Etablissement,int module,string type)
        {
            db.AddParameter("@Etablissement", Etablissement);
            db.AddParameter("@Module", module);
            db.AddParameter("@Type", type);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetIdPrevisionToValidByPoleHab", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetPrevisionToValid(int Etablissement_PoleId)
        {
            db.AddParameter("@Etablissement_PoleId", Etablissement_PoleId);

            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionToValid", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetPrevisionToValidByEtablissement(int Etablissement_PoleId, int Module, int EtablissementId)
        {

            db.AddParameter("@Etablissement_PoleId", Etablissement_PoleId);

            db.AddParameter("@ModuleId", Module);

            db.AddParameter("@EtablissementId", EtablissementId);

            DataSet retVal = db.ExecuteDataSet("SGPL_GetPToValidByEtablissement", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetPrevisionToValidByModule(int Etablissement_PoleId, int Module)
        {

            db.AddParameter("@Etablissement_PoleId", Etablissement_PoleId);

            db.AddParameter("@ModuleId", Module);

            DataSet retVal = db.ExecuteDataSet("SGPL_GetPToValidByModule", CommandType.StoredProcedure);


            return retVal;

        }
        public DataSet GetIdPrevisionByEtablissement(int IdEtablissement)
        {

            db.AddParameter("@EtablissementId", IdEtablissement);

            DataSet ds = db.ExecuteDataSet("SGPL_GetIdPrevisionByEtablissement", CommandType.StoredProcedure);

            return ds;

        }

        public DataSet GetPrevisionToConsultDrLiva(int module,int OL)
        {
            db.AddParameter("@Prevision_ModuleId", module);
            db.AddParameter("@ArticlePrevision_OrdreLivraisonId", OL);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionToConsultDrLiva", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetLotForOL(string Etablissement_PoleId, int Module)
        {

            db.AddParameter("@Etablissement_PoleId", Etablissement_PoleId);
            db.AddParameter("@ModuleId", Module);
            
            DataSet retVal = db.ExecuteDataSet("SGPL_GetLotForOL", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetExpeditionAchat(string Etablissement_PoleId, int Module, string type)
        {
            db.AddParameter("@Etablissement", Etablissement_PoleId);
            db.AddParameter("@ModuleId", Module);
            db.AddParameter("@Type", type);

            DataSet retVal = db.ExecuteDataSet("SGPL_GetExpeditionAchat", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetPrevisionForValidHabil(string Etablissement_PoleId, int Module,string type,int statut)
        {

            db.AddParameter("@Etablissement", Etablissement_PoleId);
            db.AddParameter("@ModuleId", Module);
            db.AddParameter("@Type", type);
            db.AddParameter("@Statut", statut);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionForValidHabil", CommandType.StoredProcedure);

            return retVal;

        }
       
        public DataSet GetAgentRejetHabil(string Etablissement_PoleId)
        {

            db.AddParameter("@Etablissement", Etablissement_PoleId);
            
            DataSet retVal = db.ExecuteDataSet("SGPL_GetAgentRejetHabil", CommandType.StoredProcedure);

            return retVal;

        }
        public DataSet GetPrevisionForValidImp(string Etablissement_PoleId, int Module, string type, int statut)
        {

            db.AddParameter("@Etablissement", Etablissement_PoleId);
            db.AddParameter("@ModuleId", Module);
            db.AddParameter("@Type", type);
            db.AddParameter("@Statut", statut);
            DataSet retVal = db.ExecuteDataSet("SGPL_GetPrevisionForValidImp", CommandType.StoredProcedure);

            return retVal;

        }

        public void UpdateOrdreLivraison_ArticlePrevision(int OrdreLivraisonId, int IdArticle,int taille, DateTime date)
        {
            db.AddParameter("@OrdreLivraisonId", OrdreLivraisonId);
            db.AddParameter("@IdArticle", IdArticle);
            db.AddParameter("@date", date);
            db.AddParameter("@taille", taille);
            db.ExecuteNonQuery("SGPL_UpdateOrdreLivraison_ArticlePrevision", CommandType.StoredProcedure);

        }
        public void UpdateOrdreLivraison_ArticlePrevisionImp(int OrdreLivraisonId, string IdArticle, DateTime date)
        {
            db.AddParameter("@OrdreLivraisonId", OrdreLivraisonId);
            db.AddParameter("@IdArticle", IdArticle);
            db.AddParameter("@date", date);
           
            db.ExecuteNonQuery("SGPL_UpdateOrdreLivraison_ArticlePrevisionImp", CommandType.StoredProcedure);

        }

        public int InsertOrderLivraison(int OrdreLivraison_Numero, int OrdreLivraison_ModuleId, int OrdreLivraison_UtilisateurId, DateTime OrdreLivraison_DateLivraison)
        {
            int id = 0;

            db.AddParameter("@OrdreLivraison_Numero", OrdreLivraison_Numero);
            db.AddParameter("@OrdreLivraison_DateLivraison", OrdreLivraison_DateLivraison);
            db.AddParameter("@OrdreLivraison_UtilisateurId", OrdreLivraison_UtilisateurId);
            db.AddParameter("@OrdreLivraison_ModuleId", OrdreLivraison_ModuleId);

            DataSet retVal = db.ExecuteDataSet("SGPL_InsertOrderLivraison", CommandType.StoredProcedure);

            if (retVal.Tables[0].Rows.Count > 0)
            {

                id = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());

            }

            return id;


        }
        public DataSet INTER_GetUserByEtab(string codeEtab)
        {
            db.AddParameter("@etb_code", codeEtab);
            DataSet ds = db.ExecuteDataSet("SGPL_INTER_GetUserByEtab", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet INTER_GetPoleByEtab(string codeEtab)
        {
            db.AddParameter("@Id_EtablissementMere", codeEtab);
            db.AddParameter("@Type", 2);
            DataSet ds = db.ExecuteDataSet("SGPL_GetListEtabByIdEtab", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet INTER_GetDirectionByEtab(string codeEtab)
        {
            db.AddParameter("@Id_EtablissementMere", codeEtab);
            db.AddParameter("@Type", 0);
            DataSet ds = db.ExecuteDataSet("SGPL_GetListEtabByIdEtab", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet INTER_GetEtabByEtab(string codeEtab)
        {
            db.AddParameter("@Id_EtablissementMere", codeEtab);
            db.AddParameter("@Type", 1);
            DataSet ds = db.ExecuteDataSet("SGPL_GetListEtabByIdEtab", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet SGPL_GetPrevisionArticleToConsulte(int codeEtab, int annee)
        {
            db.AddParameter("@Etablissement_Id", codeEtab);
            db.AddParameter("@Anne", annee);
            DataSet ds = db.ExecuteDataSet("SGPL_GetPrevisionArticleToConsulte", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet SGPL_CheckStatutPrevision(int PrevisionId)
        {
            db.AddParameter("@PrevisionId", PrevisionId);

            DataSet ds = db.ExecuteDataSet("SGPL_CheckStatutPrevision", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetPrevisionReconduction(int annee)
        {
            db.AddParameter("@Annee", annee);

            DataSet ds = db.ExecuteDataSet("SGPL_GetPrevisionReconduction", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetArticlePrevisionReconduction(int idPrev)
        {
            db.AddParameter("@PrevisionId", idPrev);

            DataSet ds = db.ExecuteDataSet("SGPL_GetArticlePrevisionReconduction", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet GetPrevByAgent(string Prevision_Agent)
        {
            db.AddParameter("@Prevision_Agent", Prevision_Agent);

            DataSet ds = db.ExecuteDataSet("SGPL_GetPrevByAgent", CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetUserForConsultationEtab(string etb_code, string type,string fonction)
        {
            db.AddParameter("@etb_code", etb_code);
            db.AddParameter("@type", type);
            db.AddParameter("@fonction", fonction);
            DataSet ds = db.ExecuteDataSet("SGPL_INTER_GetUserForConsultationEtab", CommandType.StoredProcedure);
            return ds;
        }
        public DataSet HistoriquePrevision(string etb_code)
        {
            db.AddParameter("@etb_code", etb_code);
           
            DataSet ds = db.ExecuteDataSet("SGPL_HistoriquePrevision", CommandType.StoredProcedure);
            return ds;
        }
    }
}
