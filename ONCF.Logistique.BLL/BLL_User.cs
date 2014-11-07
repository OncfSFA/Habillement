using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using ModelClasse;
namespace BLL
{
    public class BLL_User
    {
        DAL_User dal_user = new DAL_User();

        public DataSet GetUserByLoginAndPass(string login, string pass, int module)
        {
            return dal_user.GetUserByLoginAndPass(login, pass,module);
        }
        public DataSet INTER_GetEtabByUser(string Matr)
        {
            return dal_user.INTER_GetEtabByUser(Matr);
        }
        public int AjouteUtilisateur(SGPL_UTILISATEUR user)
        {
            return dal_user.AjouteUtilisateur(user);
        }
        public int UpdateUtilisateur(SGPL_UTILISATEUR user)
        {
            return dal_user.UpdateUtilisateur(user);
        }
          public DataSet GetUserById(int id)
        {
            return dal_user.GetUserById(id);
        }
        public void ActivDesactivUtilisateur(int idUser,string activ )
        {
            dal_user.ActivDesactivUtilisateur(idUser,activ);
        }
       
    }
}
