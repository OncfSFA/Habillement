<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="Article.aspx.cs" Inherits="Article" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Correspondance entre effet et nomenclature génèrale</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

      
      <table width="100%">
       
                    
                    <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Code effet&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtCodeEffet" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="TxtCodeEffet"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le code effet ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6" TargetControlID="RequiredFieldValidator4"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                          <td width="50%">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Article&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtArticle" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="TxtArticle"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer l'article correspondant ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7" TargetControlID="RequiredFieldValidator5"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>

                        </tr>
                        <tr >
                            <td colspan="2" width="100%">
                            <p>
                                    
                                   
                                    <label >
                                        Libellé effet&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtLibelle" runat="server" class="bts-form" Text="" Width="300px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TxtLibelle"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le Libellé effet ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                                        HighlightCssClass="validatorCalloutHighlight" />
                              <%--  </p>
                            </td>
                          <td width="50%">
                                                   
                                <p>--%>
                         <asp:Button ID="BtnAnnuler" class="bts" runat="server" Text="Annuler" 
                                        onclick="BtnAnnuler_Click"  />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" 
                                        ValidationGroup="v" onclick="BtnEnregistrer_Click"   />
                        
                </p>
                
                              
                            </td>

                        </tr>
                         
                        
                       
                    </table>
                     <asp:HiddenField ID="hdnIdUser" runat="server" />
       <asp:GridView ID="gdvAlerteTolTechn" runat="server" 
                                 AutoGenerateColumns="False" border="0" cellpadding="0" 
                                 CssClass="Data small" DataSourceID="SqlDataSource1" 
                                 width="97%" Height="50px"                                   
                                 DataKeyNames="Correspondance_Id" 
            onrowcommand="gdvAlerteTolTechn_RowCommand">
                                 <AlternatingRowStyle CssClass="Blanc" />
                                 <Columns>
                                     <asp:BoundField DataField="Correspondance_CodeEffet" HeaderText="Code Effet" 
                                         SortExpression="Correspondance_CodeEffet" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Correspondance_LibelleEffet" HeaderText="Libellé Effet" 
                                         SortExpression="Correspondance_LibelleEffet" >
                                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Correspondance_CodeArticle" HeaderText="Article" 
                                         SortExpression="Correspondance_CodeArticle" >
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
                                    <%-- <asp:TemplateField ShowHeader="False">
                                         <ItemTemplate>
                                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/supprime.gif" />
                                             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" 
                                                 CommandName="supprimer" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"
                                                  Text="supprimer" OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer cet utilisateur ?');"></asp:LinkButton>
                                         </ItemTemplate>
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>--%>
                                 </Columns>
                             </asp:GridView>
                          
    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
            
            SelectCommand="SELECT * FROM [SGPL_CORRESPONDANCE] WHERE ([Correspondance_Module] = @Correspondance_Module)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Correspondance_Module" SessionField="Modele" 
                            Type="Int32" />
                    </SelectParameters>
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