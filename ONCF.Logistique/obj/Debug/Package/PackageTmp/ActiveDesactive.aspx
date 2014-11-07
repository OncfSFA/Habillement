<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="ActiveDesactive.aspx.cs" Inherits="ActiveDesactive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Gestion Activation prévision</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

      
      <table width="100%">
       
                    <tr>
                            <td width="50%">
                               <p>
                                    
                                   
                                    <label runat="server" id="Label1">
                                        Date Debut&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtDateD" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="TxtDateD"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer la Date ." />
                                    <cc1:MaskedEditExtender ID="TxtDateHeure_MaskedEditExtender" runat="server" MaskType="Date"
                                Mask="99/99/9999" TargetControlID="TxtDateD"/>
                            
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7" TargetControlID="RequiredFieldValidator5"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                          <asp:RangeValidator ID="RangeValidator1" CssClass="ValidatorFont" runat="server" ValidationGroup="v"
                                ErrorMessage="<b>Texte non valide</b><br />Veuillez entrer une Date valide ." ControlToValidate="TxtDateD" Type="Date" MaximumValue="31/12/9999"
                                MinimumValue="01/01/1900" Display="None" ></asp:RangeValidator>
                          
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RangeValidator1"
                                        HighlightCssClass="validatorCalloutHighlight" /> 
                         
                                </p> 
                            </td>
                          <td width="50%">                               
                              
                                <p>
                          <label runat="server" id="Label2">
                                        Date Fin&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   <asp:TextBox ID="TxtDateF" runat="server" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TxtDateF"
                                        ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b><br />Veuillez entrer la Date ." />
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date"
                                Mask="99/99/9999" TargetControlID="TxtDateF"/>
                            
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator1"
                                        HighlightCssClass="validatorCalloutHighlight" />
                                          <asp:RangeValidator ID="RangeValidator2" CssClass="ValidatorFont" runat="server" ValidationGroup="v"
                                ErrorMessage="<b>Texte non valide</b><br />Veuillez entrer une Date valide ." ControlToValidate="TxtDateF" Type="Date" MaximumValue="31/12/9999"
                                MinimumValue="01/01/1900" Display="None" ></asp:RangeValidator>
                          
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="RangeValidator2"
                                        HighlightCssClass="validatorCalloutHighlight" /> 
                        
                </p>
                
                              
                            </td>

                        </tr>
                    <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Action&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLAction" runat="server" width="150px" >
                                    <asp:ListItem Text="Ajout" Value="Ajout" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Modif" Value="Modif"></asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                            </td>
                          <td width="50%">
                                <p>
                                    
                                   
                                  
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" 
                                        ValidationGroup="v" onclick="BtnEnregistrer_Click"   />
                                </p>
                            </td>

                        </tr>
                        
                         
                        
                       
                    </table>
             
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