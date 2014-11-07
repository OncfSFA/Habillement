using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

public partial class historiqueSaisiePrevision : System.Web.UI.Page
    {
   
    BLL_Prevision BLLprev=new BLL_Prevision();

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
                    else
                    {
                        
                       SDS_ETABLISSEMENT_MERE.SelectParameters["Id_EtablissementMere"].DefaultValue = BLLprev.GetReelCode(Convert.ToInt32(Session["idDirection"].ToString())).ToString();
                       DDLEtablissementMere.DataSource = SDS_ETABLISSEMENT_MERE;
                        DDLEtablissementMere.DataBind();
                    }
            }
        }
        protected void DDLEtablissementMere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLEtablissementMere.SelectedValue != "0")
            {
                DataSet dsHIstorique = BLLprev.HistoriquePrevision(DDLEtablissementMere.SelectedValue);
                if (dsHIstorique.Tables[0].Rows.Count != 0)
                {
                    GDVArticle.DataSource = dsHIstorique;
                    GDVArticle.DataBind();
                }
                else
                {
                    GDVArticle.DataSource = null ;
                    GDVArticle.DataBind();
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Il n'existe aucune prévision </b>";
                    ModalPopupExtender2.Show();
                    return;
                }
            }
            
        }
      
       
    }
