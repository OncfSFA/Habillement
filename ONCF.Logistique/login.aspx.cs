using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbDeconeexion_Click(sender, e);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
               
                BLL_User bll_user = new BLL_User();
                DataSet dsEtab=new DataSet();
                DataSet ds = bll_user.GetUserByLoginAndPass(Txtuser1.Text.ToLower().Trim(), Txtpwd1.Text.Trim(),1);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Session["User"] = ds.Tables[0].Rows[0]["Utilisateur_Login"].ToString();
                    Session["IdUser"] = ds.Tables[0].Rows[0]["Utilisateur_Id"].ToString();
                    Session["Role"] = ds.Tables[0].Rows[0]["Role_Libelle"].ToString();
                    Session["Modele"] = ds.Tables[0].Rows[0]["Utilisateur_ModuleId"].ToString();

                    if (Session["Modele"].ToString ()=="2")
                    {

                        msg.Text = "<b>Désolé, vous n’avez pas le droit d’accéder  à cette application </b>";
                        ModalPopupExtender2.Show();
                        return;
                    }

                    dsEtab = bll_user.INTER_GetEtabByUser(ds.Tables[0].Rows[0]["Utilisateur_Matricule"].ToString());
                    if (dsEtab.Tables[0].Rows.Count != 0)
                    {
                        Session["Etablissement"] = dsEtab.Tables[0].Rows[0]["LIB_ABREV"].ToString();
                        Session["idEtablissement"] = dsEtab.Tables[0].Rows[0]["CODE_ORG_AFF"].ToString();
                        Session["idEtabMere"] = dsEtab.Tables[0].Rows[0]["CODE_P_MAT"].ToString();
                        Session["idPole"] = dsEtab.Tables[0].Rows[0]["COD_DIR_C"].ToString();
                        Session["idDirection"] = dsEtab.Tables[0].Rows[0]["COD_DIR"].ToString();
                        Boolean IsPdf = false;
                        Session.Add("IsPdf", IsPdf);
                    }
                    lbDeconeexion.Text = "Déconnexion";
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ModalPopupExtender2.Show();
                }
            }
            catch (Exception ex)
            {

                Response.Write("ERREUR : " + ex.Message);

            }
        }

    }
    protected void lbDeconeexion_Click(object sender, EventArgs e)
    {
        try
        {
            Session["User"] = null;
            Session["Etablissement"] = null;
            Session["Modele"] = null;
            profil.InnerText = "Profil";
            lbDeconeexion.Text = "Connexion";
        }
        catch (Exception ex)
        {
            Response.Write("ERREUR : " + ex.Message);
        }
    }
}