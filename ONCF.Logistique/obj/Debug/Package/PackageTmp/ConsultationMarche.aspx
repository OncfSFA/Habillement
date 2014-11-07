<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="ConsultationMarche.aspx.cs" Inherits="ConsultationMarche" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Gestion Marché</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">
    <div >
    <br />
                     
                   <asp:Button ID="Button2" class="bts"  runat="server" Text="Nouveau" 
                            onclick="Button2_Click"   />
                   <br /><br />
     </div>
   

       <asp:GridView ID="gdvAlerteTolTechn" runat="server" AllowPaging="True" 
                                 AutoGenerateColumns="False" border="0" cellpadding="0" 
                                 CssClass="Data small" DataSourceID="SqlDataSource1" 
                                 width="97%" Height="50px" 
                                
                                 DataKeyNames="Marche_Id" 
            onrowcommand="gdvAlerteTolTechn_RowCommand">
                                 <AlternatingRowStyle CssClass="Blanc" />
                                 <Columns>
                                     <asp:BoundField DataField="Marche_Num" HeaderText="Numéro" 
                                         SortExpression="Marche_Num" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Marche_Fournisseur" HeaderText="Fournisseur" 
                                         SortExpression="Marche_Fournisseur" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Marche_Date" HeaderText="Date" 
                                         SortExpression="Marche_Date" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                    
                                     <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                         <ItemTemplate>
                                             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/modifier.gif" />
                                             <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                                CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CommandName="modifier" Text="Modifier"></asp:LinkButton>
                                         </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>
                                   <%--  <asp:TemplateField ShowHeader="False">
                                         <ItemTemplate>
                                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/supprime.gif" />
                                             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" 
                                                 CommandName="supprimer" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"
                                                  Text="supprimer" OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer ce marché ?');"></asp:LinkButton>
                                         </ItemTemplate>
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>--%>
                                 </Columns>
                             </asp:GridView>
                          
    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
            SelectCommand="SELECT * FROM [SGPL_MARCHE]">
        </asp:SqlDataSource>
       
</div>

   
      <!-- Un bloc pour affiche le message de confirmation d'ajout-->
                       <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel1"
                        BackgroundCssClass="modalBackground" TargetControlID="Label92"
                        RepositionMode="RepositionOnWindowResize">
                       </cc1:ModalPopupExtender>
                        <asp:Label ID="Label92" runat="server" Text=""></asp:Label>
                           <asp:Panel ID="Panel1" runat="server" Height="150px" Width="379px">
                            <table class="modal">
                               <tr>
                                    <td class="modal_header">
                                        <h3 id="title" runat="server">
                                            </h3>
                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="modal_body" align="center">
                                        <p>
                                        <asp:Label ID="msg" runat ="server" Text=""></asp:Label>    </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <div class="btn-ConfirmRight1">
                       
                                                 <asp:Button ID="Button1" class="bts" runat="server" Text="ok" CausesValidation="False" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                     </asp:Panel>
                    <!------------------------------------------------------------>
 </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>