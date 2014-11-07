using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

namespace ONCF.Logistique
{
    public partial class ValidationPolHab : System.Web.UI.Page
    {
        BLL_Prevision BLLprev = new BLL_Prevision();
        BLL_Article BLLArticle = new BLL_Article();
        BLL_Prevision BLLPrevision = new BLL_Prevision();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string module = Session["Modele"].ToString();
              
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
            }

        }

        
        protected void DDLEtablissementMere_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
          
           if (RdbVal.Checked)
           {
               DataSet dsPrevision = BLLPrevision.GetPrevisionForValidHabil(DDLEtablissementMere.SelectedValue, Convert.ToInt32(Session["Modele"].ToString()), "Mere",2);
               if (dsPrevision.Tables[0].Rows.Count != 0)
               {
                   GDValid.DataSource = dsPrevision;
                   GDValid.DataBind();
                   BtnValider.Visible = true;
                  // BtnRejet.Visible = true;
                   GDValid.Visible = true;
               }
               else
               {
                   title.InnerHtml = "Message";
                   msg.Text = "<b>Les prévisions ne sont pas disponibles ou sont déjà validées  </b>";
                   ModalPopupExtender2.Show();
                   BtnValider.Visible = false;
                   GDValid.DataSource = null;
                   GDValid.DataBind();
               }
               BtnModification.Visible = false;
               GDVArticle.Visible = false;
           }
           else
           {
               GDVArticle.Visible = true;
               GDValid.Visible = false;
               BtnRejet.Visible = false;
               BtnValider.Visible = false;
           }
        }

        protected void rafrichirDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "- Sélectionner -";
            item.Value = "0";
            ddl.Items.Add(item);   
        }

        protected void DDLAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // statut
            string statut = "0";DataSet dsstatut =new DataSet ();
            DataSet dsexist = BLLprev.GetPrevisionByModule(DateTime.Now.Year, Convert.ToInt32(Session["Modele"].ToString()), DDLAgent.SelectedValue, 0);
            if (dsexist.Tables[0].Rows.Count != 0)
            {
                dsstatut = BLLprev.GetStatutPrevision(Convert.ToInt32(dsexist.Tables[0].Rows[0]["Prevision_Id"].ToString()));
                if (dsstatut.Tables[0].Rows.Count != 0)
                    statut = dsstatut.Tables[0].Rows[0]["HistoStatutPrevision_StatutPrevisionId"].ToString();
            }
            //
            if (DDLAgent.SelectedValue != "")
            {
                HdnAgent.Value = DDLAgent.SelectedValue;
                DataSet ds = BLLprev.GetArticlePrevisionHabForMod(HdnAgent.Value);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    HdnPrevision.Value = ds.Tables[0].Rows[0]["ArticlePrevision_PrevisionId"].ToString();
                    if (RdbRejet.Checked) { BtnRejet.Visible = true; BtnModification.Visible = false; }
                    if (RdbModif.Checked) { BtnModification.Visible = true; BtnRejet.Visible = false; }
                 GDVArticle.DataSource = ds;
                GDVArticle.DataBind();
                }
                else
                {
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Il n'existe aucune prévision  </b>";
                    ModalPopupExtender2.Show();
                    GDVArticle.DataSource = null ;
                    GDVArticle.DataBind();
                    BtnModification.Visible = false;
                    BtnRejet.Visible = false;
                }
                if (statut == "5") //valider
                {
                    BtnModification.Visible = false;
                    BtnRejet.Visible = false;
                }
               
                GDVArticle.Visible = true;
            }
        }

        protected void DDLAyantFonc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // statut
            DataSet dsexist = BLLprev.GetPrevisionByModule(DateTime.Now.Year, Convert.ToInt32(Session["Modele"].ToString()), DDLAyantFonc.SelectedValue, 0);
            DataSet dsstatut = BLLprev.GetStatutPrevision(Convert.ToInt32(dsexist.Tables[0].Rows[0]["Prevision_Id"].ToString()));
            string statut = dsstatut.Tables[0].Rows[0]["HistoStatutPrevision_StatutPrevisionId"].ToString();
            //
            HdnAgent.Value = DDLAyantFonc.SelectedValue;
            DataSet ds = BLLprev.GetArticlePrevisionHabForMod(HdnAgent.Value);
            if (ds.Tables[0].Rows.Count != 0)
            {
                HdnPrevision.Value = ds.Tables[0].Rows[0]["ArticlePrevision_PrevisionId"].ToString();
                if (statut == "5") //valider
                   {
                BtnModification.Visible = false;
               
                    }
                else BtnModification.Visible = true;
            }
            else BtnModification.Visible = false;
            GDVArticle.DataSource = ds;
            GDVArticle.DataBind();
            GDVArticle.Visible = true;
           
        }
        protected void BtnModification_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaisiePrevisionModif.aspx?source=valid&idAgent=" + HdnAgent.Value + "&idPrev=" + HdnPrevision.Value);
        }

        protected void RdbVal_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbVal.Checked)
            {
                lblag.Visible = false;
                lblagfonc.Visible = false;
                DDLAgent.Visible = false;
                DDLAyantFonc.Visible = false;
                BtnModification.Visible = false;
                BtnRejet.Visible = false;
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
                GDValid.DataSource = null;
                GDValid.DataBind();
            }
            DDLDirection.SelectedValue = "0";
            rafrichirDDL(DDLEtablissementMere);
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
        }

        protected void RdbModif_CheckedChanged(object sender, EventArgs e)
        {
                lblag.Visible = true;
                lblagfonc.Visible = true;
                BtnValider.Visible = false;
                BtnRejet.Visible = false;
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
                GDValid.DataSource = null;
                GDValid.DataBind();
                DDLAgent.Visible = true;           
                DDLAyantFonc.Visible = true;
               
            if (RdbRejet.Checked)
                {
                    DDLAyantFonc.Visible = false;
                    lblagfonc.Visible = false ;
                }
          
            DDLDirection.SelectedValue = "0";
            rafrichirDDL(DDLEtablissementMere);
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
        }

        protected void DDLDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLEtablissementMere);            
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);

             if (RdbVal.Checked)
           {
            DataSet dsPrevision = BLLPrevision.GetPrevisionForValidHabil(DDLDirection.SelectedValue, Convert.ToInt32(Session["Modele"].ToString()), "Dir",2);
            if (dsPrevision.Tables[0].Rows.Count != 0)
            {
                GDValid.DataSource = dsPrevision;
                GDValid.DataBind();
                BtnValider.Visible = true;
               // BtnRejet.Visible = true;
                GDValid.Visible = true;
            }
            else
            {
                title.InnerHtml = "Message";
                msg.Text = "<b>Les prévisions ne sont pas disponibles ou sont déjà validées  </b>";
                ModalPopupExtender2.Show();
                BtnValider.Visible = false;
                GDValid.DataSource = null;
                GDValid.DataBind();
            }
            BtnModification.Visible = false;
            BtnRejet.Visible = false;
            GDVArticle.Visible = false;
           }
             else
             {
                 GDVArticle.Visible = true;
                 GDValid.Visible = false;
                // BtnRejet.Visible = false;
                 BtnValider.Visible = false;
             }
        }

        protected void DDL_Etablissement_Fille_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLAgent);
        }

        protected void BtnValider_Click(object sender, EventArgs e)
        {
            SGPL_HISTO_STATUT_PREVISION HistoPrevi = new SGPL_HISTO_STATUT_PREVISION();
            int etab =Convert.ToInt32 (DDLDirection.SelectedValue);
            string type="Dir";
            if (DDLEtablissementMere.SelectedValue != "0")
            {
                etab = Convert.ToInt32(DDLEtablissementMere.SelectedValue);
                type="Mere";
            }

            DataSet dsPrevision = BLLPrevision.GetIdPrevisionToValidByPoleHab(etab, Convert.ToInt32(Session["Modele"].ToString ()), type);
            if (dsPrevision.Tables[0].Rows.Count != 0)
            {
                try
                {
                    for (int i = 0; i < dsPrevision.Tables[0].Rows.Count; i++)
                    {
                        BLLPrevision.UpdateStatutPrevision(Convert.ToInt32(dsPrevision.Tables[0].Rows[i][0].ToString()), 5, Convert.ToInt32(Session["IdUser"].ToString()));
                    }
                    BtnValider.Visible = false;
                    BtnRejet.Visible = false;
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Opération réussi </b>";
                    ModalPopupExtender2.Show();
                    GDValid.DataBind();

                }
                catch (Exception)
                {

                    title.InnerHtml = "Message";
                    msg.Text = "<b>Erreur </b>";
                    ModalPopupExtender2.Show();
                   

                }


            }
        }

        protected void BtnRejet_Click(object sender, EventArgs e)
        {
            SGPL_HISTO_STATUT_PREVISION HistoPrevi = new SGPL_HISTO_STATUT_PREVISION();
             BLLPrevision.UpdateStatutPrevision(Convert.ToInt32(HdnPrevision.Value), 6, Convert.ToInt32(Session["IdUser"].ToString()));
            
            GDValid.DataBind();
                    BtnValider.Visible = false;
                    BtnRejet.Visible = false;
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Opération réussi </b>";
                    ModalPopupExtender2.Show();
                  


        }
    }
}
