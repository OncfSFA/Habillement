using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasse;
using BLL;
using System.Data;
using ModelClasse;
public partial class CreationLot : System.Web.UI.Page
{
    BLL_Prevision BLLPrevision = new BLL_Prevision();
    BLL_Livraison BLLlivraison = new BLL_Livraison();
    SGPL_RECEPTION RECEPTION = new SGPL_RECEPTION();
    SGPL_MAGASIN_RECEPTION MAGASIN_RECEPTION = new SGPL_MAGASIN_RECEPTION(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                TxtLot.Text = BLLlivraison.GetNumOl().ToString();
                TXTDate.Text = DateTime.Now.ToString().Substring(0, 10);
                DataSet dsPrevision = BLLPrevision.GetLotForOL(Session["idPole"].ToString(), Convert.ToInt32(Session["Modele"].ToString()));
                //if (dsPrevision.Tables[0].Rows.Count != 0)
                //{
                    GDVArticle.DataSource = dsPrevision;
                    GDVArticle.DataBind();
               // }
            }
        }
    }
    protected bool visibilite()
    {
        if (Session["Modele"].ToString() == "1") return true;
        else return false;
    }
    protected void BtnEnregistrer_Click(object sender, EventArgs e)
    {
        DataSet dsI,ListOlMag;
        
        int LastOlId = 0;
        int idart, tail;
        string idartMod2;
       
        if (GDVArticle.Rows.Count != 0)
        {
            
            int Nlot = Convert.ToInt32(TxtLot.Text);
          LastOlId = BLLPrevision.InsertOrderLivraison(Nlot, Convert.ToInt32(Session["Modele"].ToString()), Convert.ToInt32(Session["IdUser"].ToString()), DateTime.Now);
                for (int i = 0; i < GDVArticle.Rows.Count; i++)
                {
                    if (((CheckBox)GDVArticle.Rows[i].FindControl("ValidArticle")).Checked)
                    {
                        RECEPTION.Reception_ArticleId = ((Label)GDVArticle.Rows[i].FindControl("IdArticle")).Text + "&" + ((Label)GDVArticle.Rows[i].FindControl("LblDesignation")).Text;
                        RECEPTION.Reception_OrdreLivraison_Id = LastOlId;
                        RECEPTION.Reception_QtePrevision = Convert.ToInt32(((Label)GDVArticle.Rows[i].FindControl("LblQte")).Text);
                        dsI = BLLlivraison.InsertRECEPTION(RECEPTION);

                        string[] tab = ((Label)GDVArticle.Rows[i].FindControl("IdArticle")).Text.Split('&');
                        if (Convert.ToInt32(Session["Modele"].ToString()) == 1)
                        {

                        idart = Convert.ToInt32(tab[0]);
                        tail = Convert.ToInt32(tab[1]);
                        BLLPrevision.UpdateOrdreLivraison_ArticlePrevision(LastOlId,idart,tail, DateTime.Now);
                         MAGASIN_RECEPTION.MagasinReception_QtePrevision = RECEPTION.Reception_QtePrevision;
                         MAGASIN_RECEPTION.MagasinReception_MagasinId = 1;
                         MAGASIN_RECEPTION.MagasinReception_ReceptionId = Convert.ToInt32(dsI.Tables[0].Rows[0][0].ToString());
                         BLLlivraison.InsertMAGASIN_RECEPTION(MAGASIN_RECEPTION);
                        }
                        else
                        {
                            idartMod2 = tab[0];
                            string[] tab1 = RECEPTION.Reception_ArticleId.Split('&');
                            BLLPrevision.UpdateOrdreLivraison_ArticlePrevisionImp(LastOlId, idartMod2, DateTime.Now);
                            ListOlMag = BLLlivraison.GetListOlMag(LastOlId);
                            for (int j = 0; j < ListOlMag.Tables[0].Rows.Count; j++)
                            {
                                string Id_Article = Convert.ToString (ListOlMag.Tables[0].Rows[j][0].ToString());
                                if (Id_Article.ToString() == tab1[0])
                                    if (Id_Article == idartMod2)
                                    {
                                        for (int k = 1; k < 4; k++)
                                        {

                                            switch (k)
                                            {
                                                case 1:

                                                    if (ListOlMag.Tables[0].Rows[j][3].ToString() != "")
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = Convert.ToInt32(ListOlMag.Tables[0].Rows[j][3].ToString());
                                                    }
                                                    else
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = 0;
                                                    }
                                                    MAGASIN_RECEPTION.MagasinReception_MagasinId = k;
                                                    MAGASIN_RECEPTION.MagasinReception_ReceptionId = Convert.ToInt32(dsI.Tables[0].Rows[0][0].ToString());
                                                    BLLlivraison.InsertMAGASIN_RECEPTION(MAGASIN_RECEPTION);
                                                    break;
                                                case 2:
                                                    if (ListOlMag.Tables[0].Rows[j][4].ToString() != "")
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = Convert.ToInt32(ListOlMag.Tables[0].Rows[j][4].ToString());
                                                    }
                                                    else
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = 0;
                                                    }
                                                    MAGASIN_RECEPTION.MagasinReception_MagasinId = k;
                                                    MAGASIN_RECEPTION.MagasinReception_ReceptionId = Convert.ToInt32(dsI.Tables[0].Rows[0][0].ToString());
                                                    BLLlivraison.InsertMAGASIN_RECEPTION(MAGASIN_RECEPTION);
                                                    break;
                                                case 3:
                                                    if (ListOlMag.Tables[0].Rows[j][5].ToString() != "")
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = Convert.ToInt32(ListOlMag.Tables[0].Rows[j][5].ToString());
                                                    }
                                                    else
                                                    {
                                                        MAGASIN_RECEPTION.MagasinReception_QtePrevision = 0;
                                                    }
                                                    MAGASIN_RECEPTION.MagasinReception_MagasinId = k;
                                                    MAGASIN_RECEPTION.MagasinReception_ReceptionId = Convert.ToInt32(dsI.Tables[0].Rows[0][0].ToString());
                                                    BLLlivraison.InsertMAGASIN_RECEPTION(MAGASIN_RECEPTION);
                                                    break;
                                            }
                                        }
                                    }
                            }
                        }
                       

                        

                        

                
                    }
                 }
                TxtLot.Text = BLLlivraison.GetNumOl().ToString();
                title.InnerHtml = "Message ";
                msg.Text = "<b>Opération réussi</b>";
                ModalPopupExtender2.Show();
                DataSet dsPrevision = BLLPrevision.GetLotForOL(Session["idPole"].ToString(), Convert.ToInt32(Session["Modele"].ToString()));
                //if (dsPrevision.Tables[0].Rows.Count != 0)
                //{
                    GDVArticle.DataSource = dsPrevision;
                    GDVArticle.DataBind();
                //}      
            }
        }

    protected void BtnAnnuler_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GDVArticle.Rows.Count; i++)
                {((CheckBox)GDVArticle.Rows[i].FindControl("ValidArticle")).Checked = false;}
                   
    }
    }

    
