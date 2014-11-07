using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ModelClasse;
namespace BLL
{
    public class BLL_Article
    {
        DAL_Article dal_article = new DAL_Article();

       
        public void AjouteArticle(SGPL_ARTICLE user)
        {
             dal_article.AjouteArticle(user);
        }
        public void UpdateArticle(SGPL_ARTICLE user)
        {
             dal_article.UpdateArticle(user);
        }
        public DataSet GetArticleById(int id, string codeEffet)
        {
            return dal_article.GetArticleById(id,codeEffet);
        }
        public void DeleteArticle(int idUser )
        {
            dal_article.DeleteArticle(idUser);
        }
        public DataSet GetArticleByModulEtablissement(int ModuleId, string IdValeur, int TypeValeur)
        {
            return dal_article.GetArticleByModulEtablissement(ModuleId, IdValeur, TypeValeur);
        }
    }
}
