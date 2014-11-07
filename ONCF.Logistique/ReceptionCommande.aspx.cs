using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ModelClasse;
using System.Data;

public partial class ReceptionCommande : System.Web.UI.Page
    {
    BLL_Prevision BLLPrevision = new BLL_Prevision();
    BLL_Livraison BLLLivraison = new BLL_Livraison();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 bool err = false;
                    try
                    {
                        string module = Session["Modele"].ToString();
                    }
                    catch
                    {
                        err = true;
                        
                    }
                    if (err) Response.Redirect("login.aspx");
                   
            }
        }
        protected bool visibilite()
        {
            if (Session["Modele"].ToString() == "1") return true;
            else return false;
        }
        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Reception = 1;// fixe car un seul magasin qui fait la reception
                int QteRecue = 0;
                string QteRecueVid = "0";
                Boolean err = Verification();
                if (err)
                {
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Il existe un effet ayant la quantité reçue supérieure à la quantité commandée, vérifier les données  </b>";
                    ModalPopupExtender2.Show();                    
                    return;
                }
                else
                {
                    for (int i = 0; i < GDVArticle.Rows.Count; i++)
                    {
                        QteRecueVid = ((TextBox)GDVArticle.Rows[i].FindControl("TXTQteRecu")).Text.Trim();
                        if (QteRecueVid == "") QteRecueVid = "0";
                        Reception = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LabelR")).Text);
                        QteRecue = Convert.ToInt32(QteRecueVid) + Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblRecu")).Text);
                      
                        BLLLivraison.UpdateQteRecu(Reception, QteRecue,1);
                        BLLLivraison.UpdateEstLivre(Reception);
                    }
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Insertion réussi</b>";
                    ModalPopupExtender2.Show();
                    BtnEnregistrer.Text = "Enregistrer";
                    remplirGrid();
                }
            }
            
        }
        protected bool Verification()
        {
            int QteRecue = 0, QtePrev = 0;
            Boolean err = false;
            string QteRecueVid = "0";
            for (int i = 0; i < GDVArticle.Rows.Count; i++)
            {
                QteRecueVid = ((TextBox)GDVArticle.Rows[i].FindControl("TXTQteRecu")).Text.Trim();
                if (QteRecueVid == "") QteRecueVid = "0";
                QtePrev = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblQte")).Text);
                QteRecue = Convert.ToInt32(QteRecueVid) + Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblRecu")).Text);
                if (QtePrev < QteRecue)
                {
                    err = true;
                    break;
                }
            }
            return err;
        
        }
        protected void DDLOL_SelectedIndexChanged(object sender, EventArgs e)
        {
            remplirGrid();
           
        }
        protected void remplirGrid()
        {
            int modul = Convert.ToInt32(Session["Modele"].ToString());
            int OL = Convert.ToInt32(DDLOL.SelectedValue);
            DataSet dsPrevision = BLLPrevision.GetPrevisionToConsultDrLiva(modul, OL);

            GDVArticle.DataSource = dsPrevision;
            GDVArticle.DataBind();
        
        }
        protected string getchamp(string chaine, int index)
        {

            string[] tab = chaine.Split('&');
            return tab[index];
        }
       

    }
