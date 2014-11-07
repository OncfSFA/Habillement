using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ModelClasse;
namespace DAL
{
    public class DAL_User
    {
        private DataSet Ds = new DataSet();
        private DatabaseHelper db = new DatabaseHelper();


        public DataSet GetUserByLoginAndPass(string login,string pass,int module)
        {
            try
            {
                db.AddParameter("@LOGIN", login);
                db.AddParameter("@PASSWORD", pass);
                db.AddParameter("@Utilisateur_ModuleId", module);
                Ds = db.ExecuteDataSet("SGPL_GetUser", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetUser:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet INTER_GetEtabByUser(string Matr)
        {
            try
            {
                db.AddParameter("@agt_mle", Matr);
               
                Ds = db.ExecuteDataSet("SGPL_INTER_GetEtabByUser", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_INTER_GetEtabByUser:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet GetUserforupdate(int id)
        {
            try
            {
                //db.AddParameter("@LOGIN", login);
                //db.AddParameter("@PASSWORD", pass);
                db.AddParameter("@Utilisateur_Id", id);
                Ds = db.ExecuteDataSet("SGPL_GetUserForUpdat", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetUserForUpdat:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
        public DataSet GetUserById(int id)
        {
            try
            {
                db.AddParameter("@Utilisateur_Id", id);

                Ds = db.ExecuteDataSet("SGPL_GetUserById", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string s = "Error DAL_User - SGPL_GetUserById:" + ex.Message.ToString();
                throw new Exception(s);
            }
            return Ds;
        }
       
        public int AjouteUtilisateur(SGPL_UTILISATEUR user)
        {   
            int idUtilisateur=0;
            DataSet dsexiste = GetUserByLoginAndPass(user.Login, "0",1);
            if (dsexiste.Tables[0].Rows.Count == 0)
            {
                db.AddParameter("Utilisateur_Matricule", user.Matricule);
                db.AddParameter("Utilisateur_Nom", user.Nom);
                db.AddParameter("Utilisateur_Prenom", user.Prenom);
                db.AddParameter("Utilisateur_ModuleId", user.Module);
                db.AddParameter("Utilisateur_Login", user.Login);
                db.AddParameter("Utilisateur_Password", user.Password);
                db.AddParameter("Utilisateur_Email", user.Email);
                db.AddParameter("Utilisateur_Role", user.Role);
                db.AddParameter("Utilisateur_EtablissementId", user.Etablissement);

                DataSet retVal = db.ExecuteDataSet("SGPL_InsertUtilisateur", CommandType.StoredProcedure);
                if (retVal.Tables[0].Rows.Count > 0)
                {
                    idUtilisateur = Convert.ToInt32(retVal.Tables[0].Rows[0][0].ToString());
                }
            }
            return idUtilisateur;
        }

        public int  UpdateUtilisateur(SGPL_UTILISATEUR user)
        {
            int idUtilisateur=0;
            DataSet dsexiste = GetUserforupdate(user.Id);
            if (dsexiste.Tables[0].Rows.Count != 0)
            {
                

                    db.AddParameter("Utilisateur_Id", user.Id);
                    db.AddParameter("Utilisateur_Matricule", user.Matricule);
                    db.AddParameter("Utilisateur_Nom", user.Nom);
                    db.AddParameter("Utilisateur_Prenom", user.Prenom);
                    // db.AddParameter("Utilisateur_ModuleId", user.Module);
                    db.AddParameter("Utilisateur_Login", user.Login);
                    db.AddParameter("Utilisateur_Password", user.Password);
                    db.AddParameter("Utilisateur_Email", user.Email);
                    db.AddParameter("Utilisateur_Role", user.Role);              
                
                db.AddParameter("Utilisateur_EtablissementId", user.Etablissement);

                    db.ExecuteNonQuery("SGPL_UpdateUtilisateur", CommandType.StoredProcedure);
               
            }
            return idUtilisateur;
        }
        public void ActivDesactivUtilisateur(int idUser,string activ )
        {
            int flag=0 ;
            if (activ == "Desactiv") flag = 1; 
            db.AddParameter("Utilisateur_Id", idUser );
            db.AddParameter("@Utilisateur_Flag", flag);

            db.ExecuteNonQuery("SGPL_ActiveDesactiveUtilisateur", CommandType.StoredProcedure);


        }
    }
}
