using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;

public partial class MasterONCF : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (Session["user"] != null)
            {
                lblDate.Text = DateTime.Now.ToString().Substring(0,11);
                Lbluser.Text = Session["User"].ToString();
                profil.InnerText = Session["Etablissement"].ToString();
                string role = Session["Role"].ToString();
            
                if (role == "Achat")
                { 
                        Utilisateur.Visible = true;
                        Magasin.Visible = true;
                        Pole.Visible = true;
                        Backoffice.Visible = true;
                        Achat.Visible = true;
                }
               
                else if (role == "Utilisateur")        Utilisateur.Visible = true;
                else if (role == "Magasin")            Magasin.Visible = true;
                else if (role == "Pole")               Pole.Visible = true;
               
                lbDeconeexion.Text = "Déconnexion";
            }
            else
            {
                lbDeconeexion.Text = "Connexion";
                Response.Redirect("~/login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERREUR : " + ex.Message);
        }
    }
    
    protected void lbDeconeexion_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbDeconeexion.Text == "Déconnexion")
            {
                Session["User"] = null;
                Session["Etablissement"] = null;
                Session["Modele"] = null;
                Session["Role"] = null;
                profil.InnerText = "Profil";
                lbDeconeexion.Text = "Connexion";
                Response.Redirect("~/login.aspx");
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERREUR : " + ex.Message);
        }

    }

    protected string returnLienModul()
    {
        string lien = "SaisiePrevision.aspx";
        if (Session["Modele"].ToString() == "2") lien="SaisiePrevisionImprim.aspx";
        return lien;
    
    }
}
