<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" 
CodeBehind="ReceptionCommande.aspx.cs" Inherits="ReceptionCommande" %>
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
            Réception Magasinier </h4>
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
    <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" 
               Width="100%" BorderStyle="None"   >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                           
                                                             <th width="16%">
                                                                <asp:Label ID="LblArticle_" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                               <th width="20%">
                                                                <asp:Label ID="LblNomenclature" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="16%"  >
                                                                <asp:Label ID="Label3" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="16%">
                                                                <asp:Label ID="LblQte_" runat="server" Text="Quantité Commandée" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                               <th width="16%">
                                                                <asp:Label ID="Label1" runat="server" Text="Quantité Recue" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="16%">
                                                                <asp:Label ID="Label4" runat="server" Text="Quantité " Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center">
                                                            <td width="16%">
                                                             <%--<asp:Label ID="LblIdReception" runat="server" Visible="false" Text='<%# Eval("MagasinReception_Id") %>' ></asp:Label>--%>
                                                             <asp:Label ID="LabelR" runat="server" Visible="false" Text='<%# Eval("Reception_Id") %>' ></asp:Label>
                                                               
                                                            <asp:Label ID="Labb" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),0) %>'  ></asp:Label>
                                                            </td>
                                                           <td width="20%">
                                                               <asp:Label ID="LblNom" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),2) %>' ></asp:Label>
                                                            </td>
                                                            <td width="16%"  >
                                                                <asp:Label ID="Label2" runat="server" Text='<%# getchamp(Eval("Reception_ArticleId").ToString(),1) %>'></asp:Label>
                                                           </td>   
                                                             <td width="16%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Reception_QtePrevision") %>'></asp:Label>
                                                           </td>
                                                           <td width="16%">
                                                                <asp:Label ID="LblRecu" runat="server" Text='<%# Eval("MagasinReception_QteRecue") %>'></asp:Label>
                                                           </td>
                                                            <td width="16%">
                                                                <asp:TextBox ID="TXTQteRecu" runat="server" Text="0"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TXTQteRecu" ClientIDMode="AutoID"
                                                                    ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b>" />
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" ClientIDMode="AutoID" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                                                --%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="AutoID"
                                                                     ControlToValidate="TXTQteRecu" Display="None" 
                                                                     ErrorMessage="&lt;b&gt;seul les valeurs numériques autorisées&lt;/b&gt;" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" ClientIDMode="AutoID" TargetControlID="RegularExpressionValidator1"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                               
                                                                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TXTQteRecu " Display="None" 
                                                                     ErrorMessage="La quantité reçue doit être inférieur ou égale à la quantité Commandée" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"
                                                                 Operator="LessThanEqual" Type="Integer" ValueToCompare='<%# Eval("Reception_QtePrevision") %>'></asp:CompareValidator>

                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" ClientIDMode="AutoID" TargetControlID="CompareValidator1"
                                                                    HighlightCssClass="validatorCalloutHighlight" />--%>
                                                           </td>
                                                           </tr>

                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
          <br />
<div align="center">
 <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" 
        ValidationGroup="v" 
        OnClientClick="return confirm('Êtes-vous sûr de la quantité reçue saisie !!');" 
        onclick="BtnEnregistrer_Click"    />
</div>

                        </div>
                       
  
      </div>
        
        <br />

      
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
