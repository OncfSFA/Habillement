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
    public partial class GenererEscalaHab : System.Web.UI.Page
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

       
       

        protected void BtnESCALA_Click(object sender, EventArgs e)
        {

            DateTime dateSaisie = Convert.ToDateTime(TXTDate.Text);
            string dte = dateSaisie.Day.ToString() + "-" + dateSaisie.Month.ToString() + "-" + dateSaisie.Year.ToString();

            string chemain = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["lienEscala"]) + "ESCALA" + dte + ".txt";

            string Rha_DM, DateSys,NRE, Cod_DM, Etb_DM, Num_DM, Imp, Qte_DM, OE = "";

            FileStream fl = new FileStream(chemain, FileMode.Append);
            fl.Close();
            TextWriter tw = new StreamWriter(chemain);

            DataSet dsEscala = BLLLivraison.Get_ESCALA(dateSaisie);

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

            title.InnerHtml = "Message";
            msg.Text = "<b>Le fichier comptabilité est bien générer :   </br>    « " + chemain + " », veuillez le transféré à l’ESCALA .</b>";
            ModalPopupExtender2.Show();

            TXTDate.Text = "";
        }

       
    }
}
