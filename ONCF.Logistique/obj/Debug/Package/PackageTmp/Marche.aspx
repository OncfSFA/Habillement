<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="Marche.aspx.cs" Inherits="Marche" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
            <div class="bloc-right">
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Gestion Marche</h4>
    </div>
    <%-- probleme = contenu-right--%>
    <div class="contenu-right" style="display: block; background-color:White;">
     <div class="left-form">
         <asp:HiddenField ID="HdnIdMarche" runat="server" />
          
      <table width="100%">
       
                    
                    <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Numéro du marché&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtNum" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="TxtNum"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le numéro ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6" TargetControlID="RequiredFieldValidator4"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                          <td width="50%">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Date&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtDate" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="TxtDate"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer la Date ." />
                                    <cc1:MaskedEditExtender ID="TxtDateHeure_MaskedEditExtender" runat="server" MaskType="Date"
                                Mask="99/99/9999" TargetControlID="TxtDate"/>
                            
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7" TargetControlID="RequiredFieldValidator5"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                          <asp:RangeValidator ID="RangeValidator1" CssClass="ValidatorFont" runat="server" ValidationGroup="v"
                                ErrorMessage="<b>Texte non valide</b><br />Veuillez entrer une Date valide ." ControlToValidate="TxtDate" Type="Date" MaximumValue="31/12/9999"
                                MinimumValue="01/01/1900" Display="None" ></asp:RangeValidator>
                          
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RangeValidator1"
                                        HighlightCssClass="validatorCalloutHighlight" /> 
                         
                                </p>
                            </td>

                        </tr>
                        <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Fournisseur&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtFournisseur" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="TxtFournisseur"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer le Fournisseur ." />
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator3"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                </p>
                            </td>
                         
                        
                         <td width="50%"  > 
                         <p>
                         <label >
                                        Effet&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                        <asp:DropDownList ID="DDL_Article" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            Width="150px" DataSourceID="SDSGetArticle" DataTextField="Article_Id" DataValueField="libelle_effet"
                                            OnSelectedIndexChanged="DDL_Article_SelectedIndexChanged">
                                            <asp:ListItem Text="- Sélectionner -" Value="0" />
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SDSGetArticle" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>"
                                            SelectCommand="SGPL_GetArticleByDatePart" SelectCommandType="StoredProcedure">
                                        </asp:SqlDataSource>
                                        <cc1:ListSearchExtender ID="listeSerchRapide" runat="server" PromptText ="Recherche rapide ..." TargetControlID ="DDL_Article">
                                        </cc1:ListSearchExtender>
                         </p>      
                </td>
                        </tr>
                        <tr>
                        <td width="50%"></td>
                        <td width="50%">
                        <asp:Button ID="BtnAnnuler" class="bts" runat="server" Text="Annuler" 
                                        onclick="BtnAnnuler_Click"  />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" 
                                        ValidationGroup="v" onclick="BtnEnregistrer_Click"   />
                                    </td>
                        </tr>
                        <tr>
                        <td colspan="2" align="center" width="100%" >
                          <asp:Label runat="server" id="Label5" Text="Liste des articles" Font-Size="Large" Font-Bold="True" ForeColor="#FF3300" />
                              <br /><br />                  
                            <asp:CheckBoxList ID="ChBoxListArticle" runat="server" DataTextField="libelle_effet" 
                                DataValueField="Article_Id" RepeatColumns="3" width="95%"
                                RepeatDirection="Horizontal"  TextAlign="Right">   
                            </asp:CheckBoxList> 

                                 
                        </td>
                        </tr>
                        
                     
                    </table>

    </div>
                     <asp:HiddenField ID="hdnIdUser" runat="server" />
                          
    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
            SelectCommand="SELECT * FROM [SGPL_ARTICLE]">
        </asp:SqlDataSource>
             
</div>

 
   
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