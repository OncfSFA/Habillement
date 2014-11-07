using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ModelClasse;
namespace BLL
{
    public class BLL_Kit
    {
        DAL_Kit dal_Kit = new DAL_Kit();

        public int AjouteKit(SGPL_KIT_HABILLEMENT Kit)
        {
            return dal_Kit.AjouteKit(Kit);
        }
        public void AjoutKitArticle(SGPL_KIT_ARTICLE Kit)
        {
            dal_Kit.AjoutKitArticle(Kit);
        }
        public void DeleteKitArticle(int idKit)
        {
            dal_Kit.DeleteKitArticle(idKit);
        }
       
        public DataSet GetArticleByModul(int id)
        {
            return dal_Kit.GetArticleByModul(id);
        }
        public DataSet GetKitByPersonne(string idpers)
        {
            return dal_Kit.GetKitByPersonne(idpers);
        }
         public DataSet GetKitById(int idKit)
        {
            return dal_Kit.GetKitById(idKit);
        }
         public DataSet GeteffetByFonction(string idKit)
        {
            return dal_Kit.GeteffetByFonction(idKit);
        }
         public void UpdateKit(SGPL_KIT_HABILLEMENT Kit)
         {
             dal_Kit.UpdateKit(Kit);
         }
    }
}
