<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="SaisiePrevisionModif.aspx.cs" Inherits="SaisiePrevisionModif" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Modification des prévisions </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
      
      <table width="100%">
          <asp:HiddenField ID="HdnSource" runat="server" />
                    <tr>
                        <td  align="center" width="20%"  >
                          
                          <label >
                                        Matricule &nbsp;:</label>
                         </td>
                         <td width="80%">
                                        <asp:Label ID="LblMtric" runat="server" Text="Label" Font-Size="14px"></asp:Label>
                    </td>
                    </tr>
                        <tr>
                        <td  align="center"  colspan="2" >
                         <br />  
                            <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" Width="95%"  DataKeyNames="Article_Id"
                                        BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 90%; height: 30px" align="center">
                                                            <th width="30%">
                                                                <asp:Label ID="L1" runat="server" Text="Libelle effet" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="Label1" runat="server" Text="Quantité" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             
                                                           
                                                            <th width="50%" >
                                                                <asp:Label ID="L9" runat="server" Text="Prévision (Taille)" Font-Size="13px" oreColor="White"></asp:Label>
                                                            </th>
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="90%" align="center">
                                                            <td width="30%">
                                                                       <asp:Label ID="LblPrevisionid" runat="server" Text='<%# Eval("ArticlePrevision_Id") %>' Visible="false"></asp:Label>                                       
                                                                <asp:Label ID="TblIdArticle" runat="server" Text='<%# Eval("Article_Id") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="LblNomVT" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>'></asp:Label>
                                                               
                                                            </td>
                                                             <td width="20%">
                                                             <asp:Label ID="LblQte" runat="server" Text='<%# Eval("ArticlePrevision_QtePrevision") %>'></asp:Label> 
                                                             </td>
                                                             <%--<td width="60%"  height="40px">
                                                                 <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" width="80%" >
                                                                     <HeaderStyle BackColor="#FF9966" Font-Bold="True" />
                                                                 </asp:GridView>
                                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                     ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                                                     SelectCommand="SGPL_GetPrevisionbyArticletaille" SelectCommandType="StoredProcedure">
                                                                     <SelectParameters>
                                                                        <asp:ControlParameter ControlID="GDVArticle" DefaultValue="0" Name="ArticlePrevision_ArticleId"
                                                        PropertyName="SelectedValue" Type="Int32" />
                                                                         <asp:QueryStringParameter DefaultValue="0" Name="Prevision_Agent" 
                                                                             QueryStringField="idAgent" Type="Int32" />
                                                                     </SelectParameters>
                                                                 </asp:SqlDataSource>
                                                             </td>--%>
                                                            
                                                            <td width="50%" valign="bottom">
                                                                <asp:TextBox ID="Txtprevision" runat="server" class="bts-form" Width="40%" Text='<%# Eval("ArticlePrevision_Taille") %>' ></asp:TextBox>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="Txtprevision" ClientIDMode="AutoID"
                                                                    ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b>" />
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender31" ClientIDMode="AutoID" TargetControlID="RequiredFieldValidator18"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                                
                                                                    <asp:RegularExpressionValidator ID="RangeValidator13" runat="server" ClientIDMode="AutoID"
                                                                     ControlToValidate="Txtprevision" Display="None" 
                                                                     ErrorMessage="&lt;b&gt;seul les valeurs numériques autorisées&lt;/b&gt;" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender32" ClientIDMode="AutoID" TargetControlID="RangeValidator13"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                               
                        </td>
                        </tr>
                        
                        <tr>
                        <td align="center" width="100%"  colspan="2">
                         <p>
                         <asp:Button ID="BtnAnnuler" class="bts" runat="server" Text="Retour" 
                                 onclick="BtnAnnuler_Click" />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Modification" 
                                 ValidationGroup="v" onclick="BtnEnregistrer_Click"  />
                           <asp:Button ID="BtnFonc" class="bts" runat="server" Text="Fonction" onclick="BtnFoncShowPanel_Click" />
                </p>
                        </td>
                        </tr>
                    </table>
           <asp:Panel ID="PanelChangeFonc" runat="server" Visible="false">
         <table width="100%">
         <tr>
         <td align="center" width="20%" >
          <label >
                                        Fonction &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                        </td>
          <td width="80%">
                                <asp:DropDownList ID="DDLKit" runat="server" width="150px" AutoPostBack="true" AppendDataBoundItems="true"
                                       DataTextField="FONCTION" DataSourceID ="SqlDataSourceKit"
                                        DataValueField="code" 
                                        onselectedindexchanged="DDLKit_SelectedIndexChanged"  >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList> <br />
                                    <asp:SqlDataSource ID="SqlDataSourceKit" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_INTER_GetFonction" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
          
          </td>
          </tr>
           <tr>
         <td align ="center" colspan="2">
         <asp:Label ID="LblMesgMemKit" runat="server" 
                                Text="Ce kit est déjà affecté à cet agent " Visible="False" Font-Bold="True" 
                                Font-Size="18px" ForeColor="#FF6600"></asp:Label>
         <asp:Label ID="LblAucunEffet" runat="server" 
                                Text="Cette fonction n'a aucun effet" Visible="False" Font-Bold="True" 
                                Font-Size="18px" ForeColor="#FF6600"></asp:Label>
          <asp:GridView ID="GridViewchangeF" runat="server" AutoGenerateColumns="False" Width="95%"  DataKeyNames="code_effet" BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 90%; height: 30px" align="center">
                                                            <th width="20%">
                                                                <asp:Label ID="L1" runat="server" Text="Libelle effet" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             
                                                              <th width="20%">
                                                                <asp:Label ID="Label3" runat="server" Text="Périodicité" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                              <th width="20%">
                                                                <asp:Label ID="Label5" runat="server" Text="Unité Périod" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                           <th width="20%" >
                                                                <asp:Label ID="Label2" runat="server" Text="Quantité" Font-Size="13px" oreColor="White"></asp:Label>
                                                            </th>
                                                            <th width="20%" >
                                                                <asp:Label ID="L9" runat="server" Text="Taille" Font-Size="13px" oreColor="White"></asp:Label>
                                                            </th>
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="90%" align="center">
                                                            <td width="20%">
                                                                                                              
                                                                <asp:Label ID="TblIdArticle" runat="server" Text='<%# Eval("code_effet") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="LblLibEffet" runat="server" Text='<%# Eval("libelle_effet") %>'></asp:Label>
                                                                
                                                            </td>
                                                             
                                                            
                                                             <td width="20%">
                                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("PERIODICITE") %>'></asp:Label> 
                                                             </td>
                                                             <td width="20%">
                                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("Unite_periodicite") %>'></asp:Label> 
                                                             </td>
                                                             <td width="20%">
                                                             <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label> 
                                                             </td>
                                                            <td width="20%" valign="bottom">
                                                                <asp:TextBox ID="Txtprevision" runat="server" class="bts-form" Width="40%" Text="" ></asp:TextBox>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="Txtprevision" ClientIDMode="AutoID"
                                                                    ValidationGroup="c" Display="None" ErrorMessage="<b>Texte manquant</b>" />
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender31" ClientIDMode="AutoID" TargetControlID="RequiredFieldValidator18"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                                
                                                                    <asp:RegularExpressionValidator ID="RangeValidator13" runat="server" ClientIDMode="AutoID"
                                                                     ControlToValidate="Txtprevision" Display="None" 
                                                                     ErrorMessage="&lt;b&gt;seul les valeurs numériques autorisées&lt;/b&gt;" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="c"></asp:RegularExpressionValidator>
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender32" ClientIDMode="AutoID" TargetControlID="RangeValidator13"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
          </td>
          </tr>
          <tr>
                        <td align="center" width="100%"  colspan="2">
                         <p>
                         <asp:Button ID="Button3" class="bts" runat="server" Text="Annuler" 
                                 onclick="Button3_Click" />
                         <asp:Button ID="Button4" class="bts" runat="server" Text="Modification" 
                                 ValidationGroup="c" onclick="BtnFonc_Click" Visible="false" />
                           
                </p>
                        </td>
                        </tr>
          </table>
           </asp:Panel>

      </div>
        
        <br />
        <br />
        
        <asp:HiddenField ID="HdnAgent" runat="server" />
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
                       
                                                 <asp:Button ID="Button1" class="bts" runat="server" Text="ok" 
                                                     CausesValidation="False" onclick="Button1_Click" />
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                     </asp:Panel>
                    <!------------------------------------------------------------>

    </ContentTemplate>
    </asp:UpdatePanel>
     
</asp:Content>
