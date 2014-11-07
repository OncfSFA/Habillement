using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ModelClasse;
namespace BLL
{
    public class BLL_Marche
    {
        DAL_Marche dal_marche = new DAL_Marche();

        public int AjouteMarche(SGPL_MARCHE marche)
        {
            return dal_marche.AjouteMarche(marche);
        }
        public void AjoutMarcheArticle(SGPL_MARCHE_ARTICLE marche)
        {
            dal_marche.AjoutMarcheArticle(marche);
        }
        public void DeleteMarcheArticle(int idmarche)
        {
            dal_marche.DeleteMarcheArticle(idmarche);
        }
        public void DeleteMarche(int idmarche)
        {
            dal_marche.DeleteMarche(idmarche);
        }
        public DataSet GetArticleByModul(int id)
        {
            return dal_marche.GetArticleByModul(id);
        }
        public DataSet GetMarche(int idmodule)
        {
            return dal_marche.GetMarche(idmodule);
        }
         public DataSet GetMarcheById(int idMarche)
        {
            return dal_marche.GetMarcheById(idMarche);
        }
         public DataSet GetMarcheArticleByIdMarche(int idMarche)
        {
            return dal_marche.GetMarcheArticleByIdMarche(idMarche);
        }
         public void UpdateMarche(SGPL_MARCHE marche)
         {
             dal_marche.UpdateMarche(marche);
         }
    }
}
