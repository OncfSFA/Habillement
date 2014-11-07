using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ModelClasse;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Drawing;
public partial class ConsultationReceptionCommande : System.Web.UI.Page
    {
    BLL_Prevision BLLPrevision = new BLL_Prevision();
    BLL_Livraison BLLLivraison = new BLL_Livraison();
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
                   
            }
        }

       
        protected void DDLOL_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int modul = Convert.ToInt32(Session["Modele"].ToString());
            int OL = Convert.ToInt32(DDLOL.SelectedValue);
            DataSet dsPrevision = BLLPrevision.GetPrevisionToConsultDrLiva(modul, OL);

            GDVArticle.DataSource = dsPrevision;
            GDVArticle.DataBind();
            //if (dsPrevision.Tables[0].Rows.Count != 0) exporter.Visible = true;
            //else exporter.Visible = false;
        
        }
       
        protected string getchamp(string chaine, int index)
        {

            string[] tab = chaine.Split('&');
            return tab[index];
        }

 //protected void exporter_Click(object sender, ImageClickEventArgs e)
 //       {
 //           if (GDVArticle.Rows.Count > 0)
 //           {

 //               //Export the GridView to Excel
 //               GDVArticle.AllowPaging = false;
 //               GDVArticle.AllowSorting = false;

 //               GDVArticle.HeaderStyle.ForeColor = Color.White;
 //               GDVArticle.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C00000");
 //               GDVArticle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
 //               GDVArticle.RowStyle.HorizontalAlign = HorizontalAlign.Center;
 //               GDVArticle.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
 //               PrepareGridViewForExport(GDVArticle);
 //               ExportGridView(GDVArticle);
 //           }
 //           else
 //           {

 //           }
 //       }
 //       private void PrepareGridViewForExport(Control gv)
 //       {
 //           LinkButton lb = new LinkButton();
 //           Literal l = new Literal();
 //           string name = String.Empty;

 //           for (int i = 0; i < gv.Controls.Count; i++)
 //           {
 //               if (gv.Controls[i].GetType() == typeof(LinkButton))
 //               {
 //                   l.Text = (gv.Controls[i] as LinkButton).Text;
 //                   gv.Controls.Remove(gv.Controls[i]);
 //                   gv.Controls.AddAt(i, l);
 //               }
 //               if (gv.Controls[i].GetType() == typeof(ImageButton))
 //               {
 //                   gv.Controls.Remove(gv.Controls[i]);
 //               }
 //               if (gv.Controls[i].GetType() == typeof(HyperLink))
 //               {
 //                   l.Text = (gv.Controls[i] as LinkButton).Text;
 //                   gv.Controls.Remove(gv.Controls[i]);
 //                   gv.Controls.AddAt(i, l);
 //               }
 //               else if (gv.Controls[i].GetType() == typeof(DropDownList))
 //               {
 //                   l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
 //                   gv.Controls.Remove(gv.Controls[i]);
 //                   gv.Controls.AddAt(i, l);
 //               }
 //               else if (gv.Controls[i].GetType() == typeof(CheckBox))
 //               {
 //                   l.Text = (gv.Controls[i] as CheckBox).Checked ? "Oui" : "Non";
 //                   gv.Controls.Remove(gv.Controls[i]);
 //                   gv.Controls.AddAt(i, l);
 //               }
 //               if (gv.Controls[i].HasControls())
 //               {
 //                   PrepareGridViewForExport(gv.Controls[i]);
 //               }
 //           }

 //       }
 //       private void ExportGridView(GridView gv)
 //       {
 //           string FileName = DateTime.Now + ".xls";
 //           string attachment = "attachment; filename=" + FileName;
 //           Response.ClearContent();
 //           Response.ContentEncoding = Encoding.UTF8;
 //           Response.AddHeader("content-disposition", attachment);
 //           Response.ContentType = "application/ms-excel";
 //           StringWriter sw = new StringWriter();
 //           HtmlTextWriter htw = new HtmlTextWriter(sw);

 //           // Create a form to contain the grid
 //           HtmlForm frm = new HtmlForm();

 //           gv.Parent.Controls.Add(frm);
 //           frm.Attributes["runat"] = "server";

 //           frm.Controls.Add(gv);

 //           frm.RenderControl(htw);

 //           //GridView1.RenderControl(htw);
 //           Response.Write(sw.ToString());
 //           Response.End();

 //       }
    }
