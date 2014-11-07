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

namespace ONCF.Logistique
{
    public partial class ConsultationArticleHabiement : System.Web.UI.Page
    {
        BLL_Article BLLArticle = new BLL_Article();
        BLL_Prevision BLLPrevision = new BLL_Prevision();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Hdntype.Value = "";
                    string module = Session["Modele"].ToString();
                    if (Session["Role"].ToString() != "Achat" )
                    {

                        DDLPole.Enabled = false;
                        DDLDirection.Enabled = false;
                       
                        DDLDirection.Items.Clear();
                        ListItem item = new ListItem();
                        item.Text = "- Sélectionner -";
                        item.Value =BLLPrevision.GetReelCode(Convert.ToInt32(Session["idDirection"].ToString())).ToString();
                        DDLDirection.Items.Add(item);

                       
                       DDLEtablissementMere.DataBind();
                      

                    }
                    
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
            }

        }



        protected void rafrichirDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ListItem item = new ListItem();
            item.Text = "- Sélectionner -";
            item.Value = "0";
            ddl.Items.Add(item);
        }
        protected void DDLPole_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLDirection);
            rafrichirDDL(DDLEtablissementMere);
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
            remplireGrid(DDLPole, "Pole");
            Hdntype.Value = "Pole";
        }

        protected void DDLDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            rafrichirDDL(DDLEtablissementMere);
            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
            remplireGrid(DDLDirection, "Dir");
            Hdntype.Value = "Dir";
        }

        protected void DDLEtablissementMere_SelectedIndexChanged(object sender, EventArgs e)
        {

            rafrichirDDL(DDL_Etablissement_Fille);
            rafrichirDDL(DDLAgent);
            remplireGrid(DDLEtablissementMere, "EtabMere");
            Hdntype.Value = "EtabMere";
        }

        protected void DDL_Etablissement_Fille_SelectedIndexChanged(object sender, EventArgs e)
        {
            rafrichirDDL(DDLAgent);
            remplireGrid(DDL_Etablissement_Fille, "EtabFille");
            Hdntype.Value = "EtabFille";
        }

        protected void DDLAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            remplireGrid(DDLAgent, "Agent");
            Hdntype.Value = "Agent";
        }
        protected void remplireGrid(DropDownList ddl,string type)
        {
            if (ddl.SelectedValue != "")
            {
                if (ddl.SelectedValue != "0")
                {
                    DataSet dskit = BLLPrevision.GetUserForConsultationEtab(ddl.SelectedValue, type,DDLFonction.SelectedValue);
                    if (dskit.Tables[0].Rows.Count != 0)
                    {
                        exporter.Visible = true;                       
                        GDVAgent.DataSource = dskit;
                        GDVAgent.DataBind();
                        remplirgridarticle();
                    }
                    else
                    {
                        exporter.Visible = false;                        
                        GDVAgent.DataSource = null;
                        GDVAgent.DataBind();
                    }

                }
                else
                {
                    exporter.Visible = false ;
                    GDVAgent.DataSource = null;
                    GDVAgent.DataBind();
                }
            }
        
        }

        protected void remplirgridarticle()
        {
            int count = GDVAgent.Rows.Count;
            string fff = "";
            for (int i = 0; i < count; i++)
            {
                fff = ((Label)GDVAgent.Rows[i].FindControl("lblMatricule")).Text;
                ((SqlDataSource)GDVAgent.Rows[i].FindControl("SqlDataSource1")).SelectParameters["Prevision_Agent"].DefaultValue = ((Label)GDVAgent.Rows[i].FindControl("lblMatricule")).Text;
                

            }

        }

        protected void GDVAgent_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GDVAgent.PageIndex = e.NewPageIndex;
           switch  (Hdntype.Value) 
           {
               case "Pole": remplireGrid(DDLPole, "Pole"); break;
               case "Agent": remplireGrid(DDLAgent, "Agent"); break;
               case "EtabFille": remplireGrid(DDL_Etablissement_Fille, "EtabFille"); break;
               case "EtabMere": remplireGrid(DDLEtablissementMere, "EtabMere"); break;
               case "Dir": remplireGrid(DDLDirection, "Dir"); break;
              
           }
        }

        protected void DDLFonction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Hdntype.Value)
            {
                case "Pole": remplireGrid(DDLPole, "Pole"); break;
                case "Agent": remplireGrid(DDLAgent, "Agent"); break;
                case "EtabFille": remplireGrid(DDL_Etablissement_Fille, "EtabFille"); break;
                case "EtabMere": remplireGrid(DDLEtablissementMere, "EtabMere"); break;
                case "Dir": remplireGrid(DDLDirection, "Dir"); break;

            }
        }
        protected void exporter_Click(object sender, ImageClickEventArgs e)
        {
            if (GDVAgent.Rows.Count > 0)
            {

                //Export the GridView to Excel
                GDVAgent.AllowPaging = false;
                GDVAgent.AllowSorting = false;

                //GDVAgent.HeaderStyle.ForeColor = Color.White;
                //GDVAgent.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C00000");
                //GDVAgent.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
                GDVAgent.RowStyle.HorizontalAlign = HorizontalAlign.Center;
               // GDVAgent.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFCC");
                PrepareGridViewForExport(GDVAgent);
                ExportGridView(GDVAgent);
            }
            else
            {

            }
        }
        private void PrepareGridViewForExport(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;

            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].GetType() == typeof(ImageButton))
                {
                    gv.Controls.Remove(gv.Controls[i]);
                }
                if (gv.Controls[i].GetType() == typeof(HyperLink))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "Oui" : "Non";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }

        }
        private void ExportGridView(GridView gv)
        {
            string FileName = DateTime.Now + ".xls";
            string attachment = "attachment; filename=" + FileName;
            Response.ClearContent();
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            // Create a form to contain the grid
            HtmlForm frm = new HtmlForm();

            gv.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";

            frm.Controls.Add(gv);

            frm.RenderControl(htw);

            //GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
                                                                                                                                                       
    }
}
