using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ModelClasse;
namespace BLL
{
    public class BLL_Livraison
    {
        DAL_Livraison dal_livraison = new DAL_Livraison();

        public void UpdateQteRecu(int receptionId,int Qte,int recep)
        {
            dal_livraison.UpdateQteRecu(receptionId, Qte, recep);
        }
        public void UpdateEstLivre(int receptionId)
        {
            dal_livraison.UpdateEstLivre(receptionId);
        }

        public void InsertMAGASIN_RECEPTION(SGPL_MAGASIN_RECEPTION MAGASIN)
        {
            dal_livraison.InsertMAGASIN_RECEPTION(MAGASIN);
        }
        public DataSet InsertRECEPTION(SGPL_RECEPTION RECEPTION)
        {
            return dal_livraison.InsertRECEPTION(RECEPTION);
        }
        public DataSet GetListOlMag(int Id_OL)
        {
            return dal_livraison.GetListOlMag(Id_OL);
        }
        public int GetNumOl()
        {
            DataSet ds = dal_livraison.GetNumOl();
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "") 
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                else return 1;
            }
            else return 1;
        }
        public void InsertLivraison(SGPL_LIVRAISON livraison)
        {
            dal_livraison.InsertLivraison(livraison);
        }

        public DataSet GetLivByEttab(int etab, int module, int escla)
         {
             return dal_livraison.GetLivByEttab(etab, module, escla);
          }
        public DataSet GetmaxOL()
        {
            return dal_livraison.GetmaxOL();
        }
        public void UpdateLivraison(int livId, int qteLiv, int statut)
        {
            dal_livraison.UpdateLivraison(livId,qteLiv,statut);
        }
        public DataSet GetMagasinByArticlePrevision(int Id_ArticlePrevision)
        {

            return dal_livraison.GetMagasinByArticlePrevision(Id_ArticlePrevision);
        }

        public void MAJ_ESCALA(string datesys, string NRE, string Cod_DM, string Etb_DM, string Num_DM, string Imp, string Qte_DM, string OE)
        {
            dal_livraison.MAJ_ESCALA(datesys, NRE,  Cod_DM,  Etb_DM,  Num_DM,  Imp,  Qte_DM,  OE);
        }
        public DataSet Get_ESCALA(DateTime date)
        {
            return dal_livraison.Get_ESCALA(date);
        }
        public DataSet Get_TRF_imp(int dst_Etb, string imp_type)
        {
            return dal_livraison.Get_TRF_imp(dst_Etb, imp_type);
        }
         public DataSet GetEscalForInsert(string NRE, string Etb_DM, string type, DateTime date)
          {
              return dal_livraison.GetEscalForInsert( NRE,  Etb_DM,  type,  date);
          }
    }
}
