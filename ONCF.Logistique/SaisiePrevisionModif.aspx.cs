using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

public partial class SaisiePrevisionModif : System.Web.UI.Page
    {
   
    SGPL_PREVISION prev=new SGPL_PREVISION ();
    SGPL_ARTICLE_PREVISION ArticPrevis=new SGPL_ARTICLE_PREVISION ();
    BLL_Prevision BLLprev=new BLL_Prevision();
    BLL_Kit BLLKit = new BLL_Kit();
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
                       HdnSource.Value = Request.Params["source"].ToString();
                       HdnAgent.Value  = Request.Params["idAgent"].ToString();
                       //if (HdnSource.Value != "saisi") BtnFonc.Visible = true;
                       LblMtric.Text = HdnAgent.Value;
                       remplireGrid(HdnAgent.Value);
                    }
            }
        }

           
      
        protected void remplireGrid(string idagent)
        {
            GDVArticle.DataSource = BLLprev.GetArticlePrevisionHabForMod(idagent);
            GDVArticle.DataBind();
           // remplirgridannee(idagent);
                         
        }

        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {

           
                    
                    ArticPrevis.ArticlePrevision_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                    ArticPrevis.ArticlePrevision_QteRecue = 0;
                    ArticPrevis.ArticlePrevision_EstLivree = 0;
                    for (int i = 0; i < GDVArticle.Rows.Count; i++)
                    {

                        ArticPrevis.ArticlePrevision_Id = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblPrevisionid")).Text);
                        ArticPrevis.ArticlePrevision_Taille = Convert.ToInt32(((TextBox)GDVArticle.Rows[i].FindControl("Txtprevision")).Text);
                        
                        BLLprev.UpdateArticlePrevisionHab(ArticPrevis,0);
                    }
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Modification  réussi</b>";
                    ModalPopupExtender2.Show();

                    remplireGrid(Request.Params["idAgent"].ToString());

        }

        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (HdnSource.Value == "saisi")
            Response.Redirect("SaisiePrevision.aspx");
            else
                Response.Redirect("ValidationPolHab.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelChangeFonc.Visible = true;
        }

        protected void DDLKit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string encKit = "";
            DataSet dskit = BLLKit.GetKitByPersonne(HdnAgent.Value);
            DataSet dskitAyanFoc = BLLprev.GetPrevByAgent(HdnAgent.Value);
            string KitAyanFonc = dskitAyanFoc.Tables[0].Rows[0]["Prevision_Flag"].ToString();

            if (dskit.Tables[0].Rows.Count != 0)   encKit = dskit.Tables[0].Rows[0]["COD_FCT"].ToString();
            if (encKit == DDLKit.SelectedValue) LblMesgMemKit.Visible = true;
            else
            {
                if (KitAyanFonc == DDLKit.SelectedValue) LblMesgMemKit.Visible = true;
                else
                {
                    LblMesgMemKit.Visible = false;

                    //--------
                    DataSet dseffet = BLLKit.GeteffetByFonction(DDLKit.SelectedValue);
                    if (dseffet.Tables[0].Rows.Count != 0)
                    {
                        GridViewchangeF.DataSource = dseffet;
                        GridViewchangeF.DataBind();
                        LblAucunEffet.Visible = false;
                        Button4.Visible = true;
                    }
                    else
                    {
                        LblAucunEffet.Visible = true;
                        Button4.Visible = false;
                        GridViewchangeF.DataSource = null;
                        GridViewchangeF.DataBind();
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PanelChangeFonc.Visible = false ;
            GridViewchangeF.DataSource = null;
            GridViewchangeF.DataBind();
            DDLKit.SelectedValue = "0";
        }
        protected void BtnFoncShowPanel_Click(object sender, EventArgs e)
        {
            PanelChangeFonc.Visible = true;
            Button4.Visible = false;
            LblAucunEffet.Visible = false;
            LblMesgMemKit.Visible = false;
        }
        protected void BtnFonc_Click(object sender, EventArgs e)
        {
            int IdPrev=Convert.ToInt32(Request.Params["idPrev"].ToString());
            DataSet dskit = BLLKit.GetKitByPersonne(HdnAgent.Value);
            int fonc=0;
            if (dskit.Tables[0].Rows.Count != 0)
            {
                if (dskit.Tables[0].Rows[0]["COD_FCT"].ToString() != DDLKit.SelectedValue) fonc = Convert.ToInt32(DDLKit.SelectedValue);
            
            }
            BLLprev.UpdatePrevisionFlag(IdPrev, fonc);// modif flag prev
            BLLprev.DeleteArticlePrevision(IdPrev);//sup l 'encien article prev
            //ajout les nouv article prev
                    ArticPrevis.ArticlePrevision_PrevisionId =IdPrev;
                    ArticPrevis.ArticlePrevision_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                    for (int i = 0; i < GDVArticle.Rows.Count; i++)
                    {

                        ArticPrevis.ArticlePrevision_ArticleId = ((Label)GridViewchangeF.Rows[i].FindControl("TblIdArticle")).Text;
                        ArticPrevis.ArticlePrevision_Taille = Convert.ToInt32(((TextBox)GridViewchangeF.Rows[i].FindControl("Txtprevision")).Text);
                        ArticPrevis.ArticlePrevision_QtePrevision = Convert.ToInt32(((Label)GridViewchangeF.Rows[i].FindControl("LblQte")).Text);
                        ArticPrevis.ArticlePrevision_ArticleDesing = ((Label)GridViewchangeF.Rows[i].FindControl("LblLibEffet")).Text;
                        BLLprev.AjoutArticlePrevision(ArticPrevis);
                    }
                    PanelChangeFonc.Visible = false;
                    GridViewchangeF.DataSource = null;
                    GridViewchangeF.DataBind();
                    DDLKit.SelectedValue = "0";
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Modification réussi </b>";
                    ModalPopupExtender2.Show();
                    
               
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (HdnSource.Value == "saisi")
                Response.Redirect("SaisiePrevision.aspx");
            else
                Response.Redirect("ValidationPolHab.aspx");
        }
         
    }
