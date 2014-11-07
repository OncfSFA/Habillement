<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" 
CodeBehind="ConsultationReceptionCommande.aspx.cs" Inherits="ConsultationReceptionCommande" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AjaxPannel" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MidContent">
    <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Consultation de Réception </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">     

       <div class="left-form">
   <br />
   <div align="left">
    <p>                                    
                                   
                                    <label >
                                        Ordre de livraison N°&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLOL" runat="server" width="150px" AutoPostBack="true" AppendDataBoundItems="true"
                                        DataSourceID="SQLOL" DataTextField="OrdreLivraison_Numero"
                                DataValueField="OrdreLivraison_Id" 
                                        onselectedindexchanged="DDLOL_SelectedIndexChanged">
                                <asp:ListItem Text=" - Séléction - " Value="0"></asp:ListItem>
                                </asp:DropDownList>
                          
                           <asp:SqlDataSource ID="SQLOL" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>"                                
                                        
                                        SelectCommand="SELECT [OrdreLivraison_Id], [OrdreLivraison_Numero] FROM [SGPL_ORDRELIVRAISON] WHERE ([OrdreLivraison_ModuleId] = @OrdreLivraison_ModuleId)">
                               <SelectParameters>
                                   <asp:SessionParameter DefaultValue="0" Name="OrdreLivraison_ModuleId" 
                                       SessionField="Modele" Type="Int32" />
                               </SelectParameters>
                                    </asp:SqlDataSource>
                                
                                </p>
   </div>
  <%-- <asp:ImageButton  runat="server" ID ="exporter" ImageUrl="~/images/btn_exporter-excel.gif" Height="30px" Width="100px" Visible="false" 
                 onclick="exporter_Click" />--%>
    <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" 
               Width="100%" BorderStyle="None"   >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                           
                                                             <th width="20%">
                                                                <asp:Label ID="LblArticle_" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                               <th width="20%">
                                                                <asp:Label ID="LblNomenclature" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="Label3" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                            <th width="20%">
                                                                <asp:Label ID="LblQte_" runat="server" Text="Quantite Commandee" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                               <th width="20%">
                                                                <asp:Label ID="Label1" runat="server" Text="Quantite Recue" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                            
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center">
                                                            <td width="20%">
                                                           
                                                             <asp:Label ID="LabelR" runat="server" Visible="false" Text='<%# Eval("Reception_Id") %>' ></asp:Label>
                                                               
                                                            <asp:Label ID="Labb" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),0) %>'  ></asp:Label>
                                                            </td>
                                                           <td width="20%">
                                                               <asp:Label ID="LblNom" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),2) %>' ></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:Label ID="Label2" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),1) %>'></asp:Label>
                                                           </td>   
                                                             <td width="20%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Reception_QtePrevision") %>'></asp:Label>
                                                           </td>
                                                           <td width="20%">
                                                                <asp:Label ID="LblRecu" runat="server" Text='<%# Eval("MagasinReception_QteRecue") %>'></asp:Label>
                                                           </td>
                                                            
                                                           </tr>

                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
           
<div align="center">

</div>

                        </div>
                       
  
      </div>
        
        <br />

      
    </div>
       

    </ContentTemplate>
   <%--  <Triggers >
    <asp:PostBackTrigger ControlID ="exporter" />
    </Triggers>--%>
    </asp:UpdatePanel>
    


</asp:Content>
