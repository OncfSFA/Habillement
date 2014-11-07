<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="utilisateur.aspx.cs" Inherits="utilisateur" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Gestion utilisateurs</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

      
      <table width="100%">
      
                    <tr>
                    <td width="50%">
                                <p>
                                     <label runat="server" id="Label5">
                                        Role&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLRole" runat="server" width="150px" AutoPostBack="true"
                                        DataSourceID="SDSGetRole" DataTextField="Role_Libelle"
                                DataValueField="Role_Id" AppendDataBoundItems="true" 
                                        >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                           <asp:SqlDataSource ID="SDSGetRole" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>"
                                SelectCommand="SGPL_GetRole" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                   <asp:SessionParameter DefaultValue="0" Name="Modele" SessionField="modele" 
                                       Type="Int32" />
                               </SelectParameters>
                                     </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="DDLRole" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir un role" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator1">
        </cc1:ValidatorCalloutExtender>
                                   
                                </p>
                            </td>
                       <td width="50%">
                                <p>
                       <label runat="server" id="Label4">
                                        Matricule&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtMatric" runat="server" class="bts-form" Text="" Width="150px"
                                     AutoPostBack="true" ontextchanged="TxtMatric_TextChanged"></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="TxtMatric"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le matricule ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator2"
                                        HighlightCssClass="validatorCalloutHighlight" />
                       </p>
                       </td>
                       
                    </tr>
                    <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Nom&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtNom" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="TxtNom"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le nom ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6" TargetControlID="RequiredFieldValidator4"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                          <td width="50%">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Prénom&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtPrenom" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="TxtPrenom"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le prénom ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7" TargetControlID="RequiredFieldValidator5"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Login&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="Txtuser" runat="server" class="bts-form" Text="" Width="150px" 
                                        Enabled="false" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="Txtuser"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer login ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator3"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                          <td width="50%">
                                <p>
                                    
                                   <asp:HiddenField ID="HdnPassword" runat="server"></asp:HiddenField>
                                   <label runat="server" id="LblAnc" visible ="false" >
                                       Ancien Mot de passe&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <label runat="server" id="Label1" >
                                        Mot de passe&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtPWD" runat="server" class="bts-form" Text="" Width="150px" TextMode="Password" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TxtPWD"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le mot de passe ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>

                        </tr>
                         <tr>
                            
                          <td width="50%">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label3" >
                                        Email&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtEmail" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="TxtEmail" ValidationGroup="v"
     ErrorMessage="<b>Texte invalide</b><br />Veuillez entrer une adresse email valide ." ValidationExpression="[a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+"></asp:RegularExpressionValidator>
  
     <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4" TargetControlID="RegularExpressionValidator1"
      HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                            <td width="50%">
                                <p>
                                    
                                    &nbsp;<asp:Panel ID="PnlMotPass" runat="server" Visible ="false">
                                    <table>
                                    <tr>
                                    <td>
                                     <p>
                                    
                                   
                                    <label runat="server" id="Label2" >
                                        Nouveau mot de passe&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtNouv" runat="server" class="bts-form" Text=""  Width="150px" TextMode="Password" ></asp:TextBox>
                                 </p>
                                    </td>
                                    </tr>
                                     <tr>
                                    <td>
                                     <p>
                                    
                                   
                                    <label runat="server" id="Label7" style="Height:30px"  >
                                        Confirmer mot de passe&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtCofirm" runat="server" class="bts-form" Text="" Width="150px" TextMode="Password" ></asp:TextBox>
                                 </p>
                                    </td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                                   
         <asp:HiddenField ID="HdnEtab" runat="server" />
                                   
                       
                               
                              
                            </td>
                        </tr>
                        
                        <tr align="center">
                        
                         <td width="100%" colspan="2" >
                                <p>
                                <asp:Button ID="BtnAnnlMonProf" class="bts" runat="server" Text="Annuler" 
                                        Visible="false" onclick="BtnAnnlMonProf_Click"/>
                         <asp:Button ID="BtnAnnuler" class="bts" runat="server" Text="Annuler" 
                                        onclick="BtnAnnuler_Click"  />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" 
                                        ValidationGroup="v" onclick="BtnEnregistrer_Click"   />
                        <asp:Button ID="BtnActive" class="bts" runat="server" Text="Activer" 
                                         onclick="BtnActive_Click"   />
                        
                </p>
                </td>
                        </tr>
                    </table>
                     <asp:HiddenField ID="hdnIdUser" runat="server" />
       <asp:GridView ID="gdvAlerteTolTechn" runat="server" 
                                 AutoGenerateColumns="False" border="0" cellpadding="0" 
                                 CssClass="Data small" DataSourceID="SqlDataSource1"  
                                 width="97%" Height="50px" 
                                 ondatabound="gdvAlerteTolTechn_DataBound" 
                                 DataKeyNames="Utilisateur_Id" onrowcommand="gdvAlerteTolTechn_RowCommand">
                                 <AlternatingRowStyle CssClass="Blanc" />
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
                                                CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CommandName="modifier" Text="Modifier"></asp:LinkButton>
                                         </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>
                                     <asp:TemplateField ShowHeader="False">
                                         <ItemTemplate>
                                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/supprime.gif" />
                                             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" 
                                                 CommandName="supprimer" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"
                                                  Text="Désactiver" OnClientClick="return confirm('Êtes-vous sûr de vouloir désactiver cet utilisateur ?');"></asp:LinkButton>
                                         </ItemTemplate>
                                         <ItemStyle CssClass="grvIcon" />
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                          
    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
            SelectCommand="SGPL_GetUserByRole" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDLRole" DefaultValue="0" 
                            Name="Utilisateur_Role" PropertyName="SelectedValue" Type="Int32" />
                        <asp:SessionParameter DefaultValue="0" Name="Utilisateur_ModuleId" 
                            SessionField="modele" Type="Int32" />
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