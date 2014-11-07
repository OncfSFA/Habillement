using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Security;
using BLL;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class ExpeditionAchat : System.Web.UI.Page
    {
         BLL_Article BLLArticle = new BLL_Article();
        BLL_Prevision BLLPrevision = new BLL_Prevision();
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

        protected bool visibilite()
        {
            if (Session["Modele"].ToString() == "1") return true;
            else return false;
        }
       
        protected void DDLDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLEtablissementMere);
            DataSet dsPrevision = BLLPrevision.GetExpeditionAchat(DDLDirection.SelectedValue, Convert.ToInt32(Session["Modele"].ToString()), "Dir");
            if (dsPrevision.Tables[0].Rows.Count != 0)
            {
                GDVArticle.DataSource = dsPrevision;
                GDVArticle.DataBind();
            }
            else
            {
                title.InnerHtml = "Message";
                msg.Text = "<b>Il n'existe aucune prévision  </b>";
                ModalPopupExtender2.Show();
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
            }
            //if (dsPrevision.Tables[0].Rows.Count != 0) exporter.Visible = true;
            //else exporter.Visible = false;
        }
        
        protected void rafrichirDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "- Sélectionner -";
            item.Value = "0";
            ddl.Items.Add(item);
        }
        protected void DDLEtablissementMere_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsPrevision = BLLPrevision.GetExpeditionAchat(DDLEtablissementMere.SelectedValue, Convert.ToInt32(Session["Modele"].ToString()), "Mere");
            if (dsPrevision.Tables[0].Rows.Count != 0)
            {
                GDVArticle.DataSource = dsPrevision;
                GDVArticle.DataBind();
            }
            else
            {
                title.InnerHtml = "Message";
                msg.Text = "<b>Il n'existe aucune prévision  </b>";
                ModalPopupExtender2.Show();
                GDVArticle.DataSource = null;
                GDVArticle.DataBind();
            }
                //if (dsPrevision.Tables[0].Rows.Count != 0) exporter.Visible = true;
                //else exporter.Visible = false;
           
            
        }
       
        //protected void exporter_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (GDVArticle.Rows.Count > 0)
        //    {

        //        //Export the GridView to Excel
        //        GDVArticle.AllowPaging = false;
        //        GDVArticle.AllowSorting = false;

        //        GDVArticle.HeaderStyle.ForeColor = Color.White;
        //        GDVArticle.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C00000");
        //        GDVArticle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
        //        GDVArticle.RowStyle.HorizontalAlign = HorizontalAlign.Center;
        //        GDVArticle.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
        //        PrepareGridViewForExport(GDVArticle);
        //        ExportGridView(GDVArticle);
        //    }
        //    else
        //    {

        //    }
        //}
        //private void PrepareGridViewForExport(Control gv)
        //{
        //    LinkButton lb = new LinkButton();
        //    Literal l = new Literal();
        //    string name = String.Empty;

        //    for (int i = 0; i < gv.Controls.Count; i++)
        //    {
        //        if (gv.Controls[i].GetType() == typeof(LinkButton))
        //        {
        //            l.Text = (gv.Controls[i] as LinkButton).Text;
        //            gv.Controls.Remove(gv.Controls[i]);
        //            gv.Controls.AddAt(i, l);
        //        }
        //        if (gv.Controls[i].GetType() == typeof(ImageButton))
        //        {
        //            gv.Controls.Remove(gv.Controls[i]);
        //        }
        //        if (gv.Controls[i].GetType() == typeof(HyperLink))
        //        {
        //            l.Text = (gv.Controls[i] as LinkButton).Text;
        //            gv.Controls.Remove(gv.Controls[i]);
        //            gv.Controls.AddAt(i, l);
        //        }
        //        else if (gv.Controls[i].GetType() == typeof(DropDownList))
        //        {
        //            l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
        //            gv.Controls.Remove(gv.Controls[i]);
        //            gv.Controls.AddAt(i, l);
        //        }
        //        else if (gv.Controls[i].GetType() == typeof(CheckBox))
        //        {
        //            l.Text = (gv.Controls[i] as CheckBox).Checked ? "Oui" : "Non";
        //            gv.Controls.Remove(gv.Controls[i]);
        //            gv.Controls.AddAt(i, l);
        //        }
        //        if (gv.Controls[i].HasControls())
        //        {
        //            PrepareGridViewForExport(gv.Controls[i]);
        //        }
        //    }

        //}
        //private void ExportGridView(GridView gv)
        //{
        //    string FileName = DateTime.Now + ".xls";
        //    string attachment = "attachment; filename=" + FileName;
        //    Response.ClearContent();
        //    Response.ContentEncoding = Encoding.UTF8;
        //    Response.AddHeader("content-disposition", attachment);
        //    Response.ContentType = "application/ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);

        //    // Create a form to contain the grid
        //    HtmlForm frm = new HtmlForm();

        //    gv.Parent.Controls.Add(frm);
        //    frm.Attributes["runat"] = "server";

        //    frm.Controls.Add(gv);

        //    frm.RenderControl(htw);

        //    //GridView1.RenderControl(htw);
        //    Response.Write(sw.ToString());
        //    Response.End();

        //}

        }

      

  


