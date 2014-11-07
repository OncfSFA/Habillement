using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

public partial class Marche : System.Web.UI.Page
    {
    SGPL_MARCHE march = new SGPL_MARCHE();
    SGPL_MARCHE_ARTICLE marchArticle = new SGPL_MARCHE_ARTICLE();
    BLL_Marche BLLmarch = new BLL_Marche();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                 try
                {
                    string module = Session["Modele"].ToString();
                //ChBoxListArticle.DataSource = BLLmarch.GetArticleByModul(Convert.ToInt32(Session["Modele"].ToString()));
                //ChBoxListArticle.DataBind();
               
                int idmarc =Convert.ToInt32(Request.Params["IdMarche"].ToString());
                HdnIdMarche.Value = idmarc.ToString();
                if (idmarc != 0)
                {
                    BtnEnregistrer.Text = "Modifier";
                    remplireChamp(idmarc);
                }
                }
                 catch
                 {
                     Response.Redirect("login.aspx");
                 }
            }
        }
        protected void remplireChamp(int id)
        {
            DataSet ds = BLLmarch.GetMarcheById(id);
            if (ds.Tables[0].Rows.Count != 0)
            {
                TxtDate.Text = ds.Tables[0].Rows[0]["Marche_Date"].ToString();
                TxtNum.Text = ds.Tables[0].Rows[0]["Marche_Num"].ToString();
                TxtFournisseur.Text = ds.Tables[0].Rows[0]["Marche_Fournisseur"].ToString();
               
            }
            ChBoxListArticle.Visible = true;
            DataSet dsArticleMarche = BLLmarch.GetMarcheArticleByIdMarche(id);
           
            if (dsArticleMarche.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < dsArticleMarche.Tables[0].Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = dsArticleMarche.Tables[0].Rows[i]["MarcheArticle_ArticlLibelle"].ToString();
                    item.Value = dsArticleMarche.Tables[0].Rows[i]["MarcheArticle_ArticleId"].ToString();
                    item.Selected = true;
                    ChBoxListArticle.Items.Add(item);
                   
                }
            }
        
        }
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
         
            Response.Redirect("ConsultationMarche.aspx");
           
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

                        //tol_tech.TOL_TECHN_ID = int.Parse(hdnfTolTechID.Value);
                        march.Marche_Date =Convert.ToDateTime(TxtDate.Text);
                        march.Marche_Num = TxtNum.Text;
                        march.Marche_Fournisseur = TxtFournisseur.Text;
                        int IDmarche = BLLmarch.AjouteMarche(march);
                       
                        if (IDmarche != 0)
                        {
                            marchArticle.MarcheArticle_UtilisateurId=Convert.ToInt32(Session["IdUser"].ToString());
                            marchArticle.MarcheArticle_DateCreation = DateTime.Now;
                            marchArticle.MarcheArticle_MarcheId = IDmarche;
                            foreach (ListItem lstItem in ChBoxListArticle.Items)
                            {

                                if (lstItem.Selected == true)
                                {
                                    marchArticle.MarcheArticle_ArticleId = lstItem.Value;
                                    marchArticle.MarcheArticle_ArticlLibelle = lstItem.Text;
                                    BLLmarch.AjoutMarcheArticle(marchArticle);

                                }
                            }

                            title.InnerHtml = "Message";
                            msg.Text = "<b>Insertion réussi</b>";
                            ModalPopupExtender2.Show();
                            BtnEnregistrer.Text = "Enregistrer";
                        }
                        else
                        {
                            title.InnerHtml = "Message";
                            msg.Text = "<b>Insertion non effectuée </b>";
                            ModalPopupExtender2.Show();
                        }
                    }
                    else//egal à 'Modifier'
                    {
                        //on fait la modification
                        march.Marche_Id = Convert.ToInt32(HdnIdMarche.Value);
                        march.Marche_Date = Convert.ToDateTime(TxtDate.Text);
                        march.Marche_Num = TxtNum.Text;
                        march.Marche_Fournisseur = TxtFournisseur.Text;
                       
                        BLLmarch.UpdateMarche(march);
                        BLLmarch.DeleteMarcheArticle(march.Marche_Id);
                       
                        marchArticle.MarcheArticle_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                        marchArticle.MarcheArticle_DateCreation = DateTime.Now;
                        marchArticle.MarcheArticle_MarcheId = Convert.ToInt32(HdnIdMarche.Value);
                        foreach (ListItem lstItem in ChBoxListArticle.Items)
                        {

                            if (lstItem.Selected == true)
                            {
                                marchArticle.MarcheArticle_ArticleId = lstItem.Value;
                                marchArticle.MarcheArticle_ArticlLibelle = lstItem.Text;
                                BLLmarch.AjoutMarcheArticle(marchArticle);

                            }
                        }
                       
                        title.InnerHtml = "Message";
                        msg.Text = "<b>Modification réussi</b>";
                        ModalPopupExtender2.Show();
                        BtnEnregistrer.Text = "Enregistrer";
                       
                    }
                   
                    //on vide apres ajout
                    TxtFournisseur.Text = "";
                    TxtDate.Text = "";                   
                    TxtNum.Text = "";
                    ChBoxListArticle.Items.Clear();
                    DDL_Article.SelectedValue = "0";
                }


                catch (Exception ex)
                {
                    title.InnerHtml = "ERREUR ";
                    msg.Text = "<b>" + ex.Message + "</b>";
                    ModalPopupExtender2.Show();
                }

            }
        }



        protected void DDL_Article_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
            ListItem item = new ListItem();
            item.Value = DDL_Article.SelectedItem.Text ;
            item.Text = DDL_Article.SelectedValue;
            item.Selected = true;
            ChBoxListArticle.Items.Add(item);
        
        }

       
        
    }
