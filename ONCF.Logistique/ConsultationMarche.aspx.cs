using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;
public partial class ConsultationMarche : System.Web.UI.Page
    {
        SGPL_MARCHE marche = new SGPL_MARCHE();
       BLL_Marche BLLmarche = new BLL_Marche();
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
       
       
        protected void gdvAlerteTolTechn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //bloc de recuperation des info pour faire la modification
                if (e.CommandName == "modifier")
                {
                    int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());
                    Response.Redirect("Marche.aspx?IdMarche="+ID);
                 
                }
                ////////////////////////

                //bloc de suppression
                //if (e.CommandName == "supprimer")
                //{
                //    //////on recupére DEMO_ID
                //    int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());

                //   // BLLmarche.DeleteMarche(ID);

                //    gdvAlerteTolTechn.DataBind();
                //    title.InnerHtml = "Message !!!";
                //    msg.Text = "<b>Suppression réussite</b>";
                //    ModalPopupExtender2.Show();
                       
                      
                   
                //}
                ////////////////////
            }
            catch (Exception ex)
            {
                title.InnerHtml = "ERREUR ";
                msg.Text = "<b>" + ex.Message + "</b>";
                ModalPopupExtender2.Show();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marche.aspx?IdMarche=0");
        }

       

       
        
    }
