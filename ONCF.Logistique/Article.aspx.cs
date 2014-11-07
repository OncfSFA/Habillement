using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;
public partial class Article : System.Web.UI.Page
    {
        SGPL_ARTICLE article = new SGPL_ARTICLE();
       BLL_Article BLLUSR = new BLL_Article();
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
       
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            BtnEnregistrer.Text = "Enregistrer";
            TxtCodeEffet.Text = "";
            TxtArticle.Text = "";
            TxtLibelle.Text = "";
        }
        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //pour tester l'icon de progress
                    System.Threading.Thread.Sleep(1000);

                    //on teste la proprieté text du bouton :
                    //si il est égal à 'Enregistrer' on fait l'ajout sinon egal à 'Modifier' on fait la modification
                    if (BtnEnregistrer.Text == "Enregistrer")
                    {


                        article.Article_CodeArticle = TxtArticle.Text.ToUpper();
                        article.Article_CodeEffet = TxtCodeEffet.Text.ToUpper();
                        article.LibelleEffet = TxtLibelle.Text.ToUpper(); 
                        article.Article_ModuleId = Convert.ToInt32(Session["Modele"].ToString());

                       BLLUSR.AjouteArticle(article);
                       
                            title.InnerHtml = "Message";
                            msg.Text = "<b>Insertion réussi </b>";
                            ModalPopupExtender2.Show();
                            BtnEnregistrer.Text = "Enregistrer";
                        
                       
                    }
                    else//egal à 'Modifier'
                    {
                        //on fait la modification
                        article.Article_Id =Convert.ToInt32(hdnIdUser.Value);
                        article.Article_CodeArticle = TxtArticle.Text.ToUpper();
                        article.Article_CodeEffet = TxtCodeEffet.Text.ToUpper();
                        article.Article_ModuleId = Convert.ToInt32(Session["Modele"].ToString());
                        article.LibelleEffet = TxtLibelle.Text.ToUpper();
                        BLLUSR.UpdateArticle(article);
                       
                            title.InnerHtml = "Message";
                            msg.Text = "<b>Modification réussi</b>";
                            ModalPopupExtender2.Show();
                            BtnEnregistrer.Text = "Enregistrer";
                        
                    }
                    gdvAlerteTolTechn.DataBind();
                    //on vide apres ajout
                    TxtCodeEffet.Text = "";
                    TxtArticle.Text = "";
                    TxtLibelle.Text = "";                  
                   
                                       
                }


                catch (Exception ex)
                {
                    title.InnerHtml = "ERREUR ";
                    msg.Text = "<b>" + ex.Message + "</b>";
                    ModalPopupExtender2.Show();
                }

            }
        }
        protected void gdvAlerteTolTechn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //bloc de recuperation des info pour faire la modification
                if (e.CommandName == "modifier")
                {
                    //////on recupére DEMO_ID
                    int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());
                    //////on change la propriété TEXT du Bouton
                    BtnEnregistrer.Text = "Modifier";
                    //////on memorise l'ID dans Un hiddenfiel
                    hdnIdUser.Value = ID.ToString();
                    //////on récupere les info relatives à l'ID et on les affiche sur la page
                    ////RequiredFieldValidator1.Enabled = false;
                    DataSet ds = BLLUSR.GetArticleById(ID,"0");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        TxtCodeEffet.Text = ds.Tables[0].Rows[0]["Correspondance_CodeEffet"].ToString();
                        TxtArticle.Text = ds.Tables[0].Rows[0]["Correspondance_CodeArticle"].ToString();
                        TxtLibelle.Text = ds.Tables[0].Rows[0]["Correspondance_LibelleEffet"].ToString();
                    }
                 
                }
                ////////////////////////

                //bloc de suppression
                if (e.CommandName == "supprimer")
                {
                    //////on recupére DEMO_ID
                    int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());

                    BLLUSR.DeleteArticle(ID);
                   
                        gdvAlerteTolTechn.DataBind();
                        title.InnerHtml = "Message ";
                        msg.Text = "<b>Suppression réussi</b>";
                        ModalPopupExtender2.Show();                       
                       BtnEnregistrer.Text = "Enregistrer";
                   
                }
                //////////////////
            }
            catch (Exception ex)
            {
                title.InnerHtml = "ERREUR ";
                msg.Text = "<b>" + ex.Message + "</b>";
                ModalPopupExtender2.Show();
            }
        }



       
       
        
    }
