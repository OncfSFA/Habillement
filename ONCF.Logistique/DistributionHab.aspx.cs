using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;

using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Winnovative.WnvHtmlConvert;
namespace ONCF.Logistique
{
    public partial class DistributionHab : System.Web.UI.Page
    {
        BLL_Article BLLArticle = new BLL_Article();
        BLL_Prevision BLLPrevision = new BLL_Prevision();
        SGPL_LIVRAISON Liv = new SGPL_LIVRAISON();
        BLL_Livraison BLLLivraison = new BLL_Livraison();
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

        protected void DDLDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLEtablissementMere);
            BtnEnregistrer.Visible = false;
            BtnTelecharger.Visible = false;
            BtnModif.Visible = false;
            GDVArticle.DataSource = null;
            GDVArticle.DataBind();
            GDModif.DataSource = null;
            GDModif.DataBind();
        }
        
        protected void rafrichirDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "- Sélectionner -";
            item.Value = "0";
            ddl.Items.Add(item);
        }
        protected void DDL_Etablissement_Fille_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnTelecharger.Visible = false;
            DataSet dsliv=BLLLivraison.GetLivByEttab( Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue), Convert.ToInt32(Session["Modele"].ToString()),0);// 0= select ts , 1= select qui on une quantité
            if (dsliv.Tables[0].Rows.Count != 0)
            {
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
                if (dsliv.Tables[0].Rows.Count != 0)
                {
                    GDModif.Visible = true;
                    GDModif.DataSource = dsliv;
                    GDModif.DataBind();
                }
                else
                {
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Aucun effet à distribué pour cet établissement  </b>";
                    ModalPopupExtender2.Show();
                    GDModif.DataSource = null;
                    GDModif.DataBind();
                }
                BtnModif.Visible = true;
               
                BtnEnregistrer.Visible = false;
               
                
            }
            else
            {
                DataSet dsPrevision = BLLPrevision.GetPrevisionForValidHabil(DDL_Etablissement_Fille.SelectedValue, Convert.ToInt32(Session["Modele"].ToString()), "Etab", 5);
                              

                if (dsPrevision.Tables[0].Rows.Count != 0)
                {
                    GDVArticle.DataSource = dsPrevision;
                    GDVArticle.DataBind();
                    BtnEnregistrer.Visible = true; }
                else
                { 
                    BtnEnregistrer.Visible = false;

                    title.InnerHtml = "Message";
                    msg.Text = "<b>Aucun effet à distribué pour cet établissement  </b>";
                    ModalPopupExtender2.Show();
                    GDVArticle.DataSource = null;
                    GDVArticle.DataBind();
                }
                BtnModif.Visible = false;
               
                GDModif.DataSource = null;
                GDModif.DataBind();
            }
        }
        protected void DDLEtablissementMere_SelectedIndexChanged(object sender, EventArgs e)
        {

            rafrichirDDL(DDL_Etablissement_Fille);
            BtnEnregistrer.Visible = false;
            BtnTelecharger.Visible = false;
            BtnModif.Visible = false;
            GDVArticle.DataSource = null ;
            GDVArticle.DataBind();
            GDModif.DataSource = null;
            GDModif.DataBind();
        }
        protected bool Verification()
        {
            int QteRecue = 0, QtePrev = 0;
            Boolean err = false;
            for (int i = 0; i < GDModif.Rows.Count; i++)
            {
                QtePrev = Convert.ToInt32(((Label)GDModif.Rows[i].FindControl("Label3")).Text);
                QteRecue = Convert.ToInt32(((TextBox)GDModif.Rows[i].FindControl("TXTQteLivre")).Text) + Convert.ToInt32(((Label)GDModif.Rows[i].FindControl("LblQte")).Text);
                if (QtePrev < QteRecue)
                {
                    err = true;
                    break;
                }
            }
            return err;
        
        }
        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HdnAction.Value = "Ajout";
                    Liv.Livraison_Etablissement = Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue);
                    Liv.Livraison_UtilisateurId = Convert.ToInt32(Session["IdUser"].ToString());
                    Liv.Livraison_MagasinId = 1;
                    Liv.Livraison_ArticlePrevisionId = 0;
                    Liv.Livraison_Module = Convert.ToInt32(Session["Modele"].ToString());
                    for (int i = 0; i < GDVArticle.Rows.Count; i++)
                    {

                        Liv.Livraison_ArticleDesing = ((Label)GDVArticle.Rows[i].FindControl("LblArticleId")).Text + "&" + ((Label)GDVArticle.Rows[i].FindControl("LblTail")).Text + "&" + ((Label)GDVArticle.Rows[i].FindControl("LblArticleDesing")).Text;
                        Liv.Livraison_QteLivraison = Convert.ToInt32(((TextBox)GDVArticle.Rows[i].FindControl("TXTQteLivre")).Text);
                        Liv.Livraison_QtePrev = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblQte")).Text);
                        if (Liv.Livraison_QtePrev == Liv.Livraison_QteLivraison) Liv.Livraison_StatutLivraisonId = 1;
                        else Liv.Livraison_StatutLivraisonId = 2;
                        BLLLivraison.InsertLivraison(Liv);
                    }
                    GDVArticle.DataSource = null;
                    GDVArticle.DataBind();
                   
                  BtnEnregistrer.Visible = false;
                  BtnTelecharger.Visible = true;
                  MAJESCALA();
                  
                  
            }

        }

        protected void BtnModif_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HdnAction.Value = "Modification";
                Boolean err = Verification();
                if (err)
                {
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Il existe un effet ayant la quantité livrée supérieure à la quantité prévision, vérifier les données </b>";
                    ModalPopupExtender2.Show();
                    return;
                }
                else
                {

                    for (int i = 0; i < GDModif.Rows.Count; i++)
                    {

                        Liv.Livraison_Id = Convert.ToInt32(((Label)GDModif.Rows[i].FindControl("LblLivraisonId")).Text);
                        Liv.Livraison_QteLivraison = Convert.ToInt32(((TextBox)GDModif.Rows[i].FindControl("TXTQteLivre")).Text) + Convert.ToInt32(((Label)GDModif.Rows[i].FindControl("LblQte")).Text);

                        Liv.Livraison_QtePrev = Convert.ToInt32(((Label)GDModif.Rows[i].FindControl("Label3")).Text);
                        if (Liv.Livraison_QtePrev == Liv.Livraison_QteLivraison) Liv.Livraison_StatutLivraisonId = 1;
                        else Liv.Livraison_StatutLivraisonId = 2;

                        BLLLivraison.UpdateLivraison(Liv.Livraison_Id, Liv.Livraison_QteLivraison, Liv.Livraison_StatutLivraisonId);
                    }
                    

                    MAJESCALAModif();
                    GDModif.Visible = false;
                    //GDModif.DataSource = null;
                    //GDModif.DataBind();
                    BtnModif.Visible = false;
                    BtnTelecharger.Visible = true;
                    // génération fichier 
                   
                   // GenerationFichDistribution();                   
                    //

                }
                
            }
        }
        protected string getchamp(string chaine, int index)
        {

            string[] tab = chaine.Split('&');
            return tab[index];
        }
       
        protected void GenerationFichDistribution()
        {

            PdfConverter PDF = new PdfConverter();
            PDF.LicenseKey = "+tHL2svazM302s/UytrJy9TLyNTDw8PD";
            PDF.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            PDF.PdfDocumentOptions.JpegCompressionEnabled = false;
            PDF.PdfDocumentOptions.ShowFooter = PDF.PdfDocumentOptions.ShowHeader = false;
            PDF.PdfDocumentOptions.RightMargin = PDF.PdfDocumentOptions.TopMargin = PDF.PdfDocumentOptions.LeftMargin = PDF.PdfDocumentOptions.BottomMargin = 0;
            byte[] downloadBytes = null;
           

            //******************************* 
            string  HTML = GetHtml(HdnAction.Value);
            
            downloadBytes = PDF.GetPdfBytesFromHtmlString(HTML);

            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition", "attachment; filename=Bordereau.pdf; size=" + downloadBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();

            

        }
        public string GetHtml(string action)
        {
            string HdnCodEffet = "", HdnEff = "", HdnTail = "", HdnQte = "";
            string ol = "";
            if (action == "Ajout")
            {
             DataSet dsliv=BLLLivraison.GetLivByEttab( Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue), Convert.ToInt32(Session["Modele"].ToString()),0);
             for (int i=0;i<dsliv.Tables[0].Rows.Count;i++)
             {
                 HdnCodEffet += getchamp(dsliv.Tables[0].Rows[i]["Livraison_ArticleDesing"].ToString(),0) + "<br/>";
                 HdnEff += getchamp(dsliv.Tables[0].Rows[i]["Livraison_ArticleDesing"].ToString(),2) + "<br/>";
                 HdnTail += getchamp(dsliv.Tables[0].Rows[i]["Livraison_ArticleDesing"].ToString(),1) + "<br/>";
                 HdnQte += dsliv.Tables[0].Rows[i]["Livraison_QteLivraison"].ToString() + "<br/>";
             }
            }
            else
            {
                 for (int i = 0; i < GDModif.Rows.Count; i++)
            {
                if (((TextBox)GDModif.Rows[i].FindControl("TXTQteLivre")).Text != "0")
                {
                    HdnCodEffet += ((Label)GDModif.Rows[i].FindControl("LblArticleId")).Text + "<br/>";
                    HdnEff += ((Label)GDModif.Rows[i].FindControl("LblArticleDesing")).Text + "<br/>";
                    HdnTail += ((Label)GDModif.Rows[i].FindControl("LblTail")).Text + "<br/>";
                    HdnQte += ((TextBox)GDModif.Rows[i].FindControl("TXTQteLivre")).Text + "<br/>";
                }
            }
            }
            // obtenir ol
             DataSet dsol = BLLLivraison.GetmaxOL();
            
                 ol= dsol.Tables[0].Rows[0]["ol"].ToString();

            //
           
            string HTML = "<div align='center'>" +
                 " <table border='0' cellpadding='0' cellspacing='0' width='960'>" +
                      "<tr><td><table width='100%'><tr><td align='left'><table><tr><td align='center'><b>" +
                         DDLDirection.SelectedItem.Text + "<br />" + DDLEtablissementMere.SelectedItem.Text + "<br />" +
                            DDL_Etablissement_Fille.SelectedItem.Text + "<br /></b></td></tr></table></td>" +

                                  "<td align='right' valign='top'><b><br />LE " + DateTime.Now.ToString().Substring(0,10).ToString ()+
                                  " </b></td></tr></table></td></tr><br /><br /><br />" +
            "<tr><br /><td align='center'><font size='3.5'><b>BORDEREAU DE DISTRIBUTION Pour OL :</b>" + ol + "</font>" +
      "</td></tr><br /><br /><tr><td><br />" +
        "<table width='100%' style='border-style: solid; border-width: 1px'>" +
            "<tr align='center'>" +
               " <td style='border-style: solid; border-width: 1px'> <b>   Code Effet         </b>   </td>" +
                "<td style='border-style: solid; border-width: 1px'> <b>   Libelle Effet      </b>   </td>" +
                "<td style='border-style: solid; border-width: 1px'> <b>   Taille             </b>   </td>" +
                "<td style='border-style: solid; border-width: 1px'> <b>   Qte distribution   </b>   </td>" +
            "</tr>" +
            "<tr align='center'>" +
                "<td style='border-style: solid; border-width: 1px' >" + "<b>" + HdnCodEffet + "</b></td>" +
                "<td style='border-style: solid; border-width: 1px' >" + "<b>" + HdnEff  + "</b></td>" +
                "<td style='border-style: solid; border-width: 1px' >" + "<b>" + HdnTail  + "</b></td>" +
                "<td style='border-style: solid; border-width: 1px' >" + "<b>" + HdnQte  + "</td>" +
            "</tr></table></td></tr></table></div><br/><Div valign ='baseline' align='center'>Emargement :</div>";

            return HTML;
        }
      
        protected void MAJESCALA()
        {
           
            string HdnCodEffet = "", Nomenc = "0", IMP = "92" + DDLDirection.SelectedValue + "400105";
            int sumQtDis = 0, j = 0;
            string OE = DDL_Etablissement_Fille.SelectedValue + "00";
            string  cd_dm = "0";//cod_dem = "0",
            int NumDem=800000;
          //pour remplir IMP et OE
            DataSet dsImp = BLLLivraison.Get_TRF_imp(Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue), "17");
            if (dsImp.Tables[0].Rows.Count != 0)
            {
                IMP = dsImp.Tables[0].Rows[0]["imp_compt"].ToString();
                OE = dsImp.Tables[0].Rows[0]["imp_dest"].ToString();
            }
            //
           
           
            DataSet dsliv = BLLLivraison.GetLivByEttab(Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue), Convert.ToInt32(Session["Modele"].ToString()),1);

            for (int i = 0; i < dsliv.Tables[0].Rows.Count; i++)
            {
                HdnCodEffet = getchamp(dsliv.Tables[0].Rows[i]["Livraison_ArticleDesing"].ToString(), 0);
                sumQtDis = Convert.ToInt32(dsliv.Tables[0].Rows[i]["Livraison_QteLivraison"].ToString());
                for (j = i + 1; j < dsliv.Tables[0].Rows.Count; j++)
                {
                    if (HdnCodEffet == getchamp(dsliv.Tables[0].Rows[j]["Livraison_ArticleDesing"].ToString(), 0))
                    {
                        sumQtDis += Convert.ToInt32(dsliv.Tables[0].Rows[j]["Livraison_QteLivraison"].ToString());
                        i = j;
                    }


                }
                if (sumQtDis != 0)
                {
                    Nomenc = "0";
                    DataSet ds = BLLUSR.GetArticleById(0, HdnCodEffet);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Nomenc = ds.Tables[0].Rows[0]["Correspondance_CodeArticle"].ToString();
                    }

                    //string dateliv = dsliv.Tables[0].Rows[i]["Livraison_Date"].ToString();
                    //dateliv = dateliv.Substring(0, 2).ToString() + dateliv.Substring(3, 2).ToString() + dateliv.Substring(9, 1).ToString();
                    string datenow = DateTime.Now.ToString();
                    datenow = datenow.Substring(0, 2).ToString() + datenow.Substring(3, 2).ToString() + datenow.Substring(9, 1).ToString();

                    //pour remplir NumDem
                    DataSet dsNumDem = BLLLivraison.GetEscalForInsert("", "", "0", DateTime.Now);
                    if (dsNumDem.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                    {

                        DataSet dsNumDemNow = BLLLivraison.GetEscalForInsert(Nomenc, DDL_Etablissement_Fille.SelectedValue, "1", DateTime.Now);
                        if (dsNumDemNow.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                            NumDem = Convert.ToInt32(dsNumDemNow.Tables[0].Rows[0]["Num_DM"].ToString());

                        else
                        {
                            DataSet dsNumDemhier = BLLLivraison.GetEscalForInsert("", "", "0", DateTime.Now);
                            if (dsNumDemhier.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                                NumDem = Convert.ToInt32(Convert.ToInt32(dsNumDemhier.Tables[0].Rows[0]["Num_DM"].ToString()) + 1);

                        }

                    }
                    //
                    // ajouter dans la table
                    BLLLivraison.MAJ_ESCALA(datenow, Nomenc, cd_dm, DDL_Etablissement_Fille.SelectedValue, NumDem.ToString(), IMP, sumQtDis.ToString() + ",00 ", OE);
                }
            }

            GenerationFichESCALA();
        }
        protected void GenerationFichESCALA()
        {
            //sup fichier d'hier
            string dteHier = (DateTime.Now.Day-1).ToString () + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            string chemainhier = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["lienEscala"]) + "ESCALA" + dteHier + ".txt";
            
            if (File.Exists(chemainhier)) File.Delete(chemainhier);
            //
            string dte= DateTime.Now.Day.ToString ()+"-" +DateTime.Now.Month.ToString ()+"-" + DateTime.Now.Year.ToString ();

            string chemain =Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["lienEscala"]) + "ESCALA" + dte + ".txt";

            string Rha_DM, DateSys, NRE, Cod_DM, Etb_DM, Num_DM, Imp, Qte_DM, OE = "";

            FileStream fl = new FileStream(chemain, FileMode.Append);
            fl.Close();
            TextWriter tw = new StreamWriter(chemain);

            DataSet dsEscala = BLLLivraison.Get_ESCALA(DateTime.Now);

            for (int i = 0; i < dsEscala.Tables[0].Rows.Count; i++)
            {
                Rha_DM = dsEscala.Tables[0].Rows[i]["Rha_DM"].ToString();
                DateSys = dsEscala.Tables[0].Rows[i]["DateSys"].ToString();
                //Code_DM = dsEscala.Tables[0].Rows[i]["Code_DM"].ToString();
                //Date_DM = dsEscala.Tables[0].Rows[i]["Date_DM"].ToString();
                NRE = dsEscala.Tables[0].Rows[i]["NRE"].ToString();
                Cod_DM = dsEscala.Tables[0].Rows[i]["Cod_DM"].ToString();
                Etb_DM = dsEscala.Tables[0].Rows[i]["Etb_DM"].ToString();
                Num_DM = dsEscala.Tables[0].Rows[i]["Num_DM"].ToString();
                Imp = dsEscala.Tables[0].Rows[i]["Imp"].ToString();
                Qte_DM = dsEscala.Tables[0].Rows[i]["Qte_DM"].ToString();
                OE = dsEscala.Tables[0].Rows[i]["OE"].ToString();

                tw.WriteLine(Rha_DM.Trim() + DateSys.Trim() + NRE.Trim() + Cod_DM.Trim() + Etb_DM.Trim() + "   " + Num_DM.Trim() + "    " + Imp.Trim() + Qte_DM.Trim() + "                   " + OE.Trim());
            }
            tw.Close();

            //title.InnerHtml = "Message";
            //msg.Text = "<b>Le fichier comptabilité est bien générer :   </br>    « " + chemain + " », veuillez le transféré à l’ESCALA .</b>";
            //ModalPopupExtender2.Show();
        }

        protected void MAJESCALAModif()
        {

            string HdnCodEffet = "", Nomenc = "0", IMP = "92" + DDLDirection.SelectedValue + "400105";
            int sumQtDis = 0, j = 0;
            string OE = DDL_Etablissement_Fille.SelectedValue + "00";
            string  cd_dm = "0";
            int NumDem = 800000;
            //pour remplir IMP et OE
            DataSet dsImp = BLLLivraison.Get_TRF_imp(Convert.ToInt32(DDL_Etablissement_Fille.SelectedValue), "17");
            if (dsImp.Tables[0].Rows.Count != 0)
            {
                IMP = dsImp.Tables[0].Rows[0]["imp_compt"].ToString();
                OE = dsImp.Tables[0].Rows[0]["imp_dest"].ToString();
            }
            //
            for (int i = 0; i < GDModif.Rows.Count; i++)
            {


                HdnCodEffet = ((Label)GDModif.Rows[i].FindControl("LblArticleId")).Text;
                sumQtDis = Convert.ToInt32(((TextBox)GDModif.Rows[i].FindControl("TXTQteLivre")).Text);
                for (j = i + 1; j < GDModif.Rows.Count; j++)
                {
                    if (HdnCodEffet == ((Label)GDModif.Rows[j].FindControl("LblArticleId")).Text)
                    {
                        sumQtDis += Convert.ToInt32(((TextBox)GDModif.Rows[j].FindControl("TXTQteLivre")).Text);
                        i = j;
                    }
                }

                if (sumQtDis != 0)
                {
                    Nomenc = "0";
                    DataSet ds = BLLUSR.GetArticleById(0, HdnCodEffet);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Nomenc = ds.Tables[0].Rows[0]["Correspondance_CodeArticle"].ToString();
                    }

                    //string dateliv = DateTime.Now.ToString();
                    //dateliv = dateliv.Substring(0, 2).ToString() + dateliv.Substring(3, 2).ToString() + dateliv.Substring(9, 1).ToString();
                    string datenow = DateTime.Now.ToString();
                    datenow = datenow.Substring(0, 2).ToString() + datenow.Substring(3, 2).ToString() + datenow.Substring(9, 1).ToString();

                    //pour remplir NumDem
                    DataSet dsNumDem = BLLLivraison.GetEscalForInsert("", "", "0", DateTime.Now);
                    if (dsNumDem.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                    {
                       
                            DataSet dsNumDemNow = BLLLivraison.GetEscalForInsert(Nomenc, DDL_Etablissement_Fille.SelectedValue, "1", DateTime.Now);
                            if (dsNumDemNow.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                            NumDem = Convert.ToInt32(dsNumDemNow.Tables[0].Rows[0]["Num_DM"].ToString()) ;
                              
                            else
                            {
                                DataSet dsNumDemhier = BLLLivraison.GetEscalForInsert("", "", "0", DateTime.Now);
                                if (dsNumDemhier.Tables[0].Rows[0]["Num_DM"].ToString().Trim() != "")
                                 NumDem = Convert.ToInt32(Convert.ToInt32(dsNumDemhier.Tables[0].Rows[0]["Num_DM"].ToString()) + 1);
                               
                            }
                        
                    }
                    //
                    // ajouter dans la table

                    BLLLivraison.MAJ_ESCALA(datenow, Nomenc, cd_dm, DDL_Etablissement_Fille.SelectedValue, NumDem.ToString(), IMP, sumQtDis.ToString() + ",00 ", OE);
                }
            }



            GenerationFichESCALA();

        }

        protected void BtnTelecharger_Click(object sender, EventArgs e)
        {
            GenerationFichDistribution();    
        }
       
    }
}
