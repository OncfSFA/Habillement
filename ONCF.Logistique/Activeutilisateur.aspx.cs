using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


public partial class Activeutilisateur : System.Web.UI.Page
    {
    BLL_User BLLUSR = new BLL_User();
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

             
                
                if (e.CommandName == "modifier")
                {
                    
                    int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());

                    BLLUSR.ActivDesactivUtilisateur(ID, "activ");

                    gdvAlerteTolTechn.DataBind();
                    title.InnerHtml = "Message !!!";
                    msg.Text = "<b>Activation réussi </b>";
                    ModalPopupExtender2.Show();
                   

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

       
        protected void BtnActive_Click(object sender, EventArgs e)
        {
            Response.Redirect("utilisateur.aspx?Idusr=nouv");
        }
    }
