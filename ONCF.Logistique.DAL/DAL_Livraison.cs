using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_Livraison
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();
        
        public void UpdateQteRecu(int receptionId,int Qte,int recep)
        {
            db.AddParameter("@MagasinReception_Id", receptionId);
            db.AddParameter("@MagasinReception_QteRecue", Qte);
            db.AddParameter("@Id_Magasin", recep);
            db.ExecuteNonQuery("SGPL_UpdateQteRecu", CommandType.StoredProcedure);
           
        }
        public void UpdateEstLivre(int receptionId)
        {
            db.AddParameter("@Reception_Id", receptionId);
            db.ExecuteNonQuery("SGPL_EstLivre", CommandType.StoredProcedure);

        }

        public void InsertMAGASIN_RECEPTION(SGPL_MAGASIN_RECEPTION MAGASIN)
        {
            db.AddParameter("@MagasinReception_ReceptionId", MAGASIN.MagasinReception_ReceptionId);
            db.AddParameter("@MagasinReception_QtePrevision", MAGASIN.MagasinReception_QtePrevision);
            db.AddParameter("@MagasinReception_MagasinId", MAGASIN.MagasinReception_MagasinId);
            db.AddParameter("@MagasinReception_QteRecue", MAGASIN.MagasinReception_QteRecue);
            db.ExecuteNonQuery("SGPL_InsertMAGASIN_RECEPTION", CommandType.StoredProcedure);

        }

        public DataSet InsertRECEPTION(SGPL_RECEPTION RECEPTION)
        {
            db.AddParameter("@Reception_ArticleId", RECEPTION.Reception_ArticleId);
            db.AddParameter("@Reception_OrdreLivraison_Id", RECEPTION.Reception_OrdreLivraison_Id);
            db.AddParameter("@Reception_QtePrevision", RECEPTION.Reception_QtePrevision);
            return db.ExecuteDataSet("SGPL_InsertReception", CommandType.StoredProcedure);

        }
        public DataSet GetListOlMag(int Id_OL)
        {
            db.AddParameter("@OrdreLivraison_Id", Id_OL);

            return db.ExecuteDataSet("SGPL_GetOl_Imp", CommandType.StoredProcedure);

        }
          public DataSet GetNumOl()
        {
            return db.ExecuteDataSet("SGPL_GetNumOL", CommandType.StoredProcedure);

        }

          public void InsertLivraison(SGPL_LIVRAISON livraison)
          {
              db.AddParameter("@Livraison_QteLivraison", livraison.Livraison_QteLivraison);
              db.AddParameter("@Livraison_MagasinId", livraison.Livraison_MagasinId);
              db.AddParameter("@Livraison_StatutLivraisonId", livraison.Livraison_StatutLivraisonId);
              db.AddParameter("@Livraison_ArticlePrevisionId", livraison.Livraison_ArticlePrevisionId);

              db.AddParameter("@Livraison_UtilisateurId", livraison.Livraison_UtilisateurId);
              db.AddParameter("@Livraison_ArticleDesing", livraison.Livraison_ArticleDesing);
              db.AddParameter("@Livraison_Etablissement", livraison.Livraison_Etablissement);
              
              db.AddParameter("@Livraison_QtePrev", livraison.Livraison_QtePrev);
              db.AddParameter("@Livraison_Module", livraison.Livraison_Module);
              db.ExecuteNonQuery("SGPL_InsertLivraison", CommandType.StoredProcedure);

          }
          public DataSet GetLivByEttab(int etab, int module, int escla)
          {
              db.AddParameter("@Livraison_Etablissement", etab);
              db.AddParameter("@Livraison_Module", module);
              db.AddParameter("@escla", escla);
              return db.ExecuteDataSet("SGPL_GetLivByEttab", CommandType.StoredProcedure);

          }
        public DataSet GetmaxOL()
          {
              return db.ExecuteDataSet("SGPL_GetmaxOL", CommandType.StoredProcedure);

          }
          public void UpdateLivraison(int livId,int qteLiv,int statut)
          {
              db.AddParameter("@Livraison_Id", livId);
              db.AddParameter("@Livraison_QteLivraison",qteLiv );
              db.AddParameter("@Livraison_StatutLivraisonId", statut);
              db.ExecuteNonQuery("SGPL_UpdateLivraison", CommandType.StoredProcedure);

          }
          public DataSet GetMagasinByArticlePrevision(int Id_ArticlePrevision)
          {
              db.AddParameter("@ArticlePrevisionId", Id_ArticlePrevision);

              return db.ExecuteDataSet("SGPL_GetMagasinByArticlePrevision", CommandType.StoredProcedure);

          }
          public void MAJ_ESCALA(string datesys,string NRE, string Cod_DM, string Etb_DM, string Num_DM, string Imp, string Qte_DM,string OE)
          {
              db.AddParameter("@DateSys", datesys);
              //db.AddParameter("@Date_DM", Date_DM);
              //db.AddParameter("@Code_DM", Code_DM);
              db.AddParameter("@NRE", NRE);
              db.AddParameter("@Cod_DM", Cod_DM);
              db.AddParameter("@Etb_DM", Etb_DM);
              db.AddParameter("@Num_DM", Num_DM);
              db.AddParameter("@Imp", Imp);
              db.AddParameter("@Qte_DM", Qte_DM);
              db.AddParameter("@OE", OE);
            
              db.ExecuteNonQuery("MAJ_ESCALA", CommandType.StoredProcedure);
          
          }
          public DataSet Get_ESCALA(DateTime date)
          {
             
              db.AddParameter("@date", date);
              return db.ExecuteDataSet("SGPL_GetEscalaHabi", CommandType.StoredProcedure);

          }
          public DataSet Get_TRF_imp(int dst_Etb, string imp_type)
          {

              db.AddParameter("@dst_Etb", dst_Etb);
              db.AddParameter("@imp_type", imp_type);

              return db.ExecuteDataSet("SGPL_Get_TRF_imp", CommandType.StoredProcedure);

          }
          public DataSet GetEscalForInsert(string NRE, string Etb_DM, string type, DateTime date)
          {

              db.AddParameter("@Etb_DM", Etb_DM);
              db.AddParameter("@NRE", NRE);
              db.AddParameter("@Type", type);
              db.AddParameter("@date", date);
              return db.ExecuteDataSet("SGPL_GetEscalForInsert", CommandType.StoredProcedure);

          }
    }
}
