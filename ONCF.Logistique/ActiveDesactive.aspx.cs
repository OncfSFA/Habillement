using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;
public partial class ActiveDesactive : System.Web.UI.Page
    {
        
       BLL_Prevision BLLprev = new BLL_Prevision();
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
            if (Page.IsValid)
            {
                try
                {
                    BLLprev.Activedesactive(Convert.ToDateTime(TxtDateD.Text), Convert.ToDateTime(TxtDateF.Text), Convert.ToInt32(Session["Modele"].ToString()), DDLAction.SelectedValue);
                       
                            title.InnerHtml = "Message";
                            msg.Text = "<b>Les prévisions ont été activées  </b>";
                            ModalPopupExtender2.Show();
                            BtnEnregistrer.Text = "Enregistrer";
                                     
                }


                catch (Exception ex)
                {
                    title.InnerHtml = "ERREUR ";
                    msg.Text = "<b>" + ex.Message + "</b>";
                    ModalPopupExtender2.Show();
                }

            }
        }
     
       
        
    }
