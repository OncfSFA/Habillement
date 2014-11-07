



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;
public partial class utilisateur : System.Web.UI.Page
{
    SGPL_UTILISATEUR usr = new SGPL_UTILISATEUR();
    BLL_User BLLUSR = new BLL_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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

                string idUsr = Request.Params["Idusr"].ToString();
                TxtPrenom.Text = "";
                TxtPWD.Text = "";
                if (idUsr != "nouv")
                {
                    afficheUser(Convert.ToInt32(Session["IdUser"].ToString()));
                    BtnEnregistrer.Text = "Modification";
                    BtnAnnuler.Visible = false; gdvAlerteTolTechn.Visible = false;
                    BtnActive.Visible = false; TxtNom.Enabled = false;
                    TxtPrenom.Enabled = false; Txtuser.Enabled = false;
                    DDLRole.Enabled = false; TxtMatric.Enabled = false;
                    BtnAnnlMonProf.Visible = true;
                    PnlMotPass.Visible = true;
                    LblAnc.Visible = true;
                    Label1.Visible = false;
                }
               
            }
        }
    }
    protected void gdvAlerteTolTechn_DataBound(object sender, EventArgs e)
    {
        // pour fusioner deux cellule 'Actions'
        if (gdvAlerteTolTechn.Rows.Count != 0)
        {
            gdvAlerteTolTechn.HeaderRow.Cells[4].ColumnSpan = 2;
            gdvAlerteTolTechn.HeaderRow.Cells[5].Visible = false;
        }
    }
    protected void BtnAnnuler_Click(object sender, EventArgs e)
    {
        BtnEnregistrer.Text = "Enregistrer";
        //on vide 
        TxtMatric.Text = "";
        Txtuser.Text = "";
        TxtNom.Text = "";
        TxtPrenom.Text = "";
        DDLRole.SelectedValue = "0";
        TxtPWD.Text = ""; TxtEmail.Text = "";
    }
    protected void BtnActive_Click(object sender, EventArgs e)
    {
        Response.Redirect("Activeutilisateur.aspx");
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


                    usr.Matricule = TxtMatric.Text;
                    usr.Email = TxtEmail.Text;
                    usr.Login = Txtuser.Text;
                    usr.Password = TxtPWD.Text;// Secur.CryptePassword(TxtPWD.Text);
                    usr.Module = Convert.ToInt32(Session["Modele"].ToString());
                    usr.Etablissement = Convert.ToInt32(HdnEtab.Value);
                    usr.Nom = TxtNom.Text;
                    usr.Prenom = TxtPrenom.Text;
                    usr.Role = Convert.ToInt32(DDLRole.SelectedValue);

                    int IDuser = BLLUSR.AjouteUtilisateur(usr);
                    if (IDuser == 0)
                    {
                        title.InnerHtml = "Message";
                        msg.Text = "<b>Cet utilisateur existe déjà </b>";
                        ModalPopupExtender2.Show();
                        return;
                    }
                    else
                    {

                        title.InnerHtml = "Message";
                        msg.Text = "<b>Insertion réussi</b>";
                        ModalPopupExtender2.Show();
                        BtnEnregistrer.Text = "Enregistrer";
                    }

                }
                else//egal à 'Modifier'
                {
                    //on fait la modification
                    usr.Id = Convert.ToInt32(hdnIdUser.Value);
                    usr.Matricule = TxtMatric.Text;
                    usr.Email = TxtEmail.Text;
                    usr.Login = Txtuser.Text;
                    //
                    if (PnlMotPass.Visible)
                    {
                        if (TxtPWD.Text != HdnPassword.Value)
                        {
                            title.InnerHtml = "Message";
                            msg.Text = "<b>le mot de passe est incorrecte </b>";
                            ModalPopupExtender2.Show(); return;
                        }
                        
                        else if (TxtNouv.Text != TxtCofirm.Text )
                        {
                            title.InnerHtml = "Message";
                            msg.Text = "<b>le nouveau mot de passe est incompatible avec la confirmation </b>";
                            ModalPopupExtender2.Show(); return;
                        }
                        else if (TxtNouv.Text =="" && TxtCofirm.Text == "") usr.Password = TxtPWD.Text;
                        else usr.Password = TxtNouv.Text;
                    }
                    //
                    else usr.Password = TxtPWD.Text;// Secur.CryptePassword(TxtPWD.Text);
                    DataSet dsEtab = BLLUSR.INTER_GetEtabByUser(TxtMatric.Text);
                    if (dsEtab.Tables[0].Rows.Count != 0) HdnEtab.Value = dsEtab.Tables[0].Rows[0]["CODE_ORGANISATION"].ToString();
                    else HdnEtab.Value = "0";
                    usr.Etablissement = Convert.ToInt32(HdnEtab.Value);
                    usr.Nom = TxtNom.Text;
                    usr.Prenom = TxtPrenom.Text;
                    usr.Role = Convert.ToInt32(DDLRole.SelectedValue);

                    int IDuser = BLLUSR.UpdateUtilisateur(usr);
                    
                    title.InnerHtml = "Message";
                    msg.Text = "<b>Modification réussi </b>";
                    ModalPopupExtender2.Show();

                    if (Request.Params["Idusr"].ToString() != "nouv") BtnEnregistrer.Visible = false;
                    BtnEnregistrer.Text = "Enregistrer";
                   
                }
                gdvAlerteTolTechn.DataBind();
                //on vide apres ajout
                TxtMatric.Text = "";
                Txtuser.Text = "";
                TxtNom.Text = "";
                TxtPrenom.Text = "";
                DDLRole.SelectedValue = "0";
                TxtPWD.Text = ""; TxtEmail.Text = "";

            }


            catch (Exception ex)
            {
                title.InnerHtml = "ERREUR ";
                msg.Text = "<b>" + ex.Message + "</b>";
                ModalPopupExtender2.Show();
            }

        }
    }
    protected void afficheUser(int idUser)
    {
        DataSet ds = BLLUSR.GetUserById(idUser);
        hdnIdUser.Value = idUser.ToString();
        if (ds.Tables[0].Rows.Count != 0)
        {

            TxtMatric.Text = ds.Tables[0].Rows[0]["Utilisateur_Matricule"].ToString();
            Txtuser.Text = ds.Tables[0].Rows[0]["Utilisateur_Login"].ToString();
            TxtPWD.Text = HdnPassword.Value = ds.Tables[0].Rows[0]["Utilisateur_Password"].ToString();
            TxtEmail.Text = ds.Tables[0].Rows[0]["Utilisateur_Email"].ToString();
            DDLRole.SelectedValue = ds.Tables[0].Rows[0]["Utilisateur_Role"].ToString().Trim();
            TxtNom.Text = ds.Tables[0].Rows[0]["Utilisateur_Nom"].ToString();
            TxtPrenom.Text = ds.Tables[0].Rows[0]["Utilisateur_Prenom"].ToString();
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

                afficheUser(ID);

            }
            ////////////////////////

            //bloc de suppression
            if (e.CommandName == "supprimer")
            {
                //////on recupére DEMO_ID
                int ID = int.Parse(gdvAlerteTolTechn.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())].Value.ToString());

                BLLUSR.ActivDesactivUtilisateur(ID, "Desactiv");

                gdvAlerteTolTechn.DataBind();
                title.InnerHtml = "Message ";
                msg.Text = "<b>Désactivation réussi</b>";
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

    protected void TxtMatric_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = BLLUSR.INTER_GetEtabByUser(TxtMatric.Text);
        if (ds.Tables[0].Rows.Count != 0)
        {

            TxtNom.Text = ds.Tables[0].Rows[0]["NOM"].ToString();
            TxtPrenom.Text = ds.Tables[0].Rows[0]["PRENOM"].ToString();
            Txtuser.Text = TxtMatric.Text;
           // TxtEmail.Text = TxtMatric.Text + "@ONCF.ma";
            HdnEtab.Value = ds.Tables[0].Rows[0]["CODE_ORGANISATION"].ToString();
        }
        else
        {
            TxtNom.Text = "";
            TxtPrenom.Text = "";
            Txtuser.Text = "";
            HdnEtab.Value = "";
            title.InnerHtml = "Message";
            msg.Text = "<b>Cet agent n’est pas un fonctionnaire ONCF </b>";
            ModalPopupExtender2.Show();


        }
    }

    protected void BtnAnnlMonProf_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

   




}