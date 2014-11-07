using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

public partial class ReconductionSaisiePrevision : System.Web.UI.Page
    {
   
    SGPL_PREVISION prev=new SGPL_PREVISION ();
    SGPL_ARTICLE_PREVISION ArticPrevis=new SGPL_ARTICLE_PREVISION ();
    BLL_Prevision BLLprev=new BLL_Prevision();

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


        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {

           
            DataSet dsexiscetAnne = BLLprev.GetPrevisionReconduction(DateTime.Now.Year);
            if (dsexiscetAnne.Tables[0].Rows.Count != 0)
            {
                title.InnerHtml = "Message";
                msg.Text = "<b>Il existe déjà des prévisions pour cette année .</b>";
                ModalPopupExtender2.Show(); return;
            }
            else
            {
                DataSet dsexist = BLLprev.GetPrevisionReconduction(DateTime.Now.Year-1);
                if (dsexist.Tables[0].Rows.Count == 0)
                {
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Il n'existe aucune prévision pour la reconduire à l'année actuelle .</b>";
                    ModalPopupExtender2.Show(); return;
                }
                else
                {
                    for (int j = 0; j < dsexist.Tables[0].Rows.Count; j++)
                    {
                        int previsID = Convert.ToInt32(dsexist.Tables[0].Rows[j]["Prevision_Id"].ToString());
                        // insertion des prevision
                        prev.Prevision_EtablissementId = Convert.ToInt32(dsexist.Tables[0].Rows[j]["Prevision_EtablissementId"].ToString());
                        prev.Prevision_ModuleId = 1;
                        prev.Prevision_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                        prev.Prevision_Agent = dsexist.Tables[0].Rows[j]["Prevision_Agent"].ToString();
                        prev.Prevision_Flag = Convert.ToInt32(dsexist.Tables[0].Rows[j]["Prevision_Flag"].ToString());
                        int IDprevv = BLLprev.AjoutePrevision(prev);

                        if (IDprevv != 0)
                        {
                            ArticPrevis.ArticlePrevision_PrevisionId = IDprevv;
                            ArticPrevis.ArticlePrevision_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                            // insertion des article
                            DataSet dsarticlPrev = BLLprev.GetArticlePrevisionReconduction(previsID);
                            for (int i = 0; i < dsarticlPrev.Tables[0].Rows.Count; i++)
                            {

                                ArticPrevis.ArticlePrevision_ArticleId = dsarticlPrev.Tables[0].Rows[i]["ArticlePrevision_ArticleId"].ToString();
                                ArticPrevis.ArticlePrevision_Taille = Convert.ToInt32(dsarticlPrev.Tables[0].Rows[i]["ArticlePrevision_Taille"].ToString());
                                ArticPrevis.ArticlePrevision_QtePrevision = Convert.ToInt32(dsarticlPrev.Tables[0].Rows[i]["ArticlePrevision_QtePrevision"].ToString());
                                ArticPrevis.ArticlePrevision_ArticleDesing = dsarticlPrev.Tables[0].Rows[i]["ArticlePrevision_ArticleDesing"].ToString();
                                BLLprev.AjoutArticlePrevision(ArticPrevis);
                            }

                        }
                        title.InnerHtml = "Message";
                        msg.Text = "<b>Insertion réussite .</b>";
                        ModalPopupExtender2.Show();

                    }
                }

            }


        }
      
    }
