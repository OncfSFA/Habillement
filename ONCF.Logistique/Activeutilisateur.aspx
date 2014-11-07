<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="Activeutilisateur.aspx.cs" Inherits="Activeutilisateur" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Activer utilisateurs</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">
    <div align="center">
    <br />
      <asp:Button ID="BtnActive" class="bts" runat="server" Text="Retour" 
                                         onclick="BtnActive_Click"   /> </div>
       <asp:GridView ID="gdvAlerteTolTechn" runat="server" 
                                 AutoGenerateColumns="False" border="0" cellpadding="0" 
                                 CssClass="Data small" DataSourceID="SqlDataSource1" 
                                 width="97%" Height="50px" 
                                 EmptyDataText="Tous les comptes sont actifs "
                                 DataKeyNames="Utilisateur_Id" onrowcommand="gdvAlerteTolTechn_RowCommand">
                               
                                 <Columns>
                                     <asp:BoundField DataField="Utilisateur_Login" HeaderText="login" 
                                         SortExpression="Utilisateur_Login" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Utilisateur_Matricule" HeaderText="Matricule" 
                                         SortExpression="Utilisateur_Matricule" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Utilisateur_Nom" HeaderText="Nom" 
                                         SortExpression="Utilisateur_Nom" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Utilisateur_Prenom" HeaderText="Prenom" 
                                         SortExpression="Utilisateur_Prenom" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                         <ItemTemplate>
                                             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/modifier.gif" />
                                             <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                                CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CommandName="modifier" Text="Activer"></asp:LinkButton>
                                         </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>
                                     
                                 </Columns>
                             </asp:GridView>
                          
    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
            SelectCommand="SGPL_GetUserDesactiv" SelectCommandType="StoredProcedure">
                   
        </asp:SqlDataSource>
      </div>
        
        <br />
        <br />
        
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
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
     
</asp:Content>
