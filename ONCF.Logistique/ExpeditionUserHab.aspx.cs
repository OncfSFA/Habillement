using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Security;
using BLL;
using ModelClasse;

public partial class ExpeditionUserHab : System.Web.UI.Page
    {
        BLL_Kit BLLKit = new BLL_Kit();
        SGPL_PREVISION prev = new SGPL_PREVISION();
        SGPL_ARTICLE_PREVISION ArticPrevis = new SGPL_ARTICLE_PREVISION();
        BLL_Prevision BLLprev = new BLL_Prevision();

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

        
        protected void DDLAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsexist = BLLprev.GetPrevisionByModule(DateTime.Now.Year, Convert.ToInt32(Session["Modele"].ToString()), DDLAgent.SelectedValue, 0);
            if (dsexist.Tables[0].Rows.Count > 0)
            {
                BtnEnregistrer.Visible = true;
                GDVArticle.DataSource = BLLprev.GetArticlePrevisionHabForMod(DDLAgent.SelectedValue);
                GDVArticle.DataBind();

            }
            else
            {
                BtnEnregistrer.Visible = false;
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
            }

            
        }
       
     
       
        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            int qtePrev = 0;
            ArticPrevis.ArticlePrevision_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
            for (int i = 0; i < GDVArticle.Rows.Count; i++)
            {

                ArticPrevis.ArticlePrevision_Id = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblPrevisionid")).Text);
                ArticPrevis.ArticlePrevision_Taille = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblTail")).Text);
                ArticPrevis.ArticlePrevision_QteRecue = Convert.ToInt32(((TextBox)GDVArticle.Rows[i].FindControl("TXTQteRecu")).Text);
                qtePrev = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblQte")).Text);
                if (qtePrev == ArticPrevis.ArticlePrevision_QteRecue )
                ArticPrevis.ArticlePrevision_EstLivree = 1;
                else ArticPrevis.ArticlePrevision_EstLivree = 0;

                BLLprev.UpdateArticlePrevisionHab(ArticPrevis,1);// exp = 1
            }
            title.InnerHtml = "Message";
            msg.Text = "<b>Récéption  faite</b>";
            ModalPopupExtender2.Show();
        }
       
        protected void DDLEtablissement_SelectedIndexChanged(object sender, EventArgs e)
        {

            DDLAgent.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "- Sélectionner -";
            item.Value = "0";
            DDLAgent.Items.Add(item);

            DDLAgent.DataSource = BLLprev.INTER_GetUserByEtab(DDLEtablissement.SelectedValue);
            DDLAgent.DataBind();
            BtnEnregistrer.Visible = false;
            GDVArticle.DataSource = null;
            GDVArticle.DataBind();
        }

      

      

  
    }

