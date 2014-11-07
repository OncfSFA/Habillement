<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="SaisiePrevision.aspx.cs" Inherits="SaisiePrevision" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Saisie des prévisions  </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
      
      <table width="100%">
          <asp:HiddenField ID="HdnEncFonc" runat="server" />
          <asp:HiddenField ID="HdnAgen" runat="server" />          
                    <tr>
                            <td width="50%">
                           
                                <p>
                                    
                                   
                                    <label >
                                        Saisie pour &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDLEtablissement" runat="server" width="150px" AutoPostBack="True"
                                        DataSourceID="SDSGetEtabliss" DataTextField="LIBELLE_ORGANISATION"
                                DataValueField="CODE_ORGANISATION" AppendDataBoundItems="True" onselectedindexchanged="DDLEtablissement_SelectedIndexChanged" 
                                        >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                           <asp:SqlDataSource ID="SDSGetEtabliss" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>"
                                SelectCommand="SGPL_GetListEtabByIdEtab" SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                   <asp:SessionParameter DefaultValue="0" Name="Id_EtablissementMere" 
                                       SessionField="idEtabMere" Type="Int32" />
                                   <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
                               </SelectParameters>
                                    </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="DDLEtablissement" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir une étabelissement" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="1"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator1">
        </cc1:ValidatorCalloutExtender>
                                   </p>
                            </td>
                          <td width="50%">
                          <p>
                              <asp:Button ID="Button2" class="bts"  runat="server" Text="Fonction" 
                                 onclick="RBchangeFonction_CheckedChanged"   />
                                <asp:DropDownList ID="DDLKit" runat="server" width="150px" AutoPostBack="true" AppendDataBoundItems="true"
                                       DataTextField="FONCTION" Visible="false"
                                        DataValueField="code" 
                                        onselectedindexchanged="DDLKit_SelectedIndexChanged"  >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceKit" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_INTER_GetFonction" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                         
                          </p>
                                
                            </td>

                        </tr>
                        <tr>
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Agent&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLAgent" runat="server" width="150px" AutoPostBack="true"
                                         DataTextField="Agent"
                                DataValueField="agt_mle" AppendDataBoundItems="true" 
                                        onselectedindexchanged="DDLAgent_SelectedIndexChanged" >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                           <asp:SqlDataSource ID="SDGetAgent" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>"
                                
                                        SelectCommand="SGPL_INTER_GetUserByEtab" 
                                        SelectCommandType="StoredProcedure">
                               <SelectParameters>
                                   <asp:ControlParameter ControlID="DDLEtablissement" DefaultValue="1" 
                                       Name="etb_code" PropertyName="SelectedValue" />
                               </SelectParameters>
                                    </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator2" runat="server" 
            ControlToValidate="DDLAgent" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir un Agent" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator2">
        </cc1:ValidatorCalloutExtender>
                                </p>
                            </td>
                         
                        
                         <td width="50%"   >
                            <%-- <p id="fonct" runat="server" visible="false">
                                                                       
                                    <label runat="server" id="Label6">
                                        Fonction&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                   
                              
                                </p>  --%>
                </td>
                        </tr>
                        <tr>
                        <td colspan="2" align="center"  >
                         <br />  
                            <asp:Label ID="LblAucunEffet" runat="server" 
                                Text="Cette fonction n'a aucun effet" Visible="False" Font-Bold="True" 
                                Font-Size="18px" ForeColor="#FF6600"></asp:Label>
                            <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" Width="95%"  DataKeyNames="code_effet"
                                        BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 90%; height: 30px" align="center">
                                                            <th width="20%">
                                                                <asp:Label ID="L1" runat="server" Text="Libelle effet" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             <th width="40%">
                                                                <asp:Label ID="Label1" runat="server" Text="Historique" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                              <th width="10%">
                                                                <asp:Label ID="Label3" runat="server" Text="Périodicité" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                              <th width="10%">
                                                                <asp:Label ID="Label5" runat="server" Text="Unité Périod" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                           <th width="10%" >
                                                                <asp:Label ID="Label2" runat="server" Text="Quantité" Font-Size="13px" oreColor="White"></asp:Label>
                                                            </th>
                                                            <th width="10%" runat="server" visible='<%# visible() %>' >
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
                                                             
                                                             <td width="40%"  height="40px">
                                                                 <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" width="80%" >
                                                                     <HeaderStyle BackColor="#FF9966" Font-Bold="True" />
                                                                 </asp:GridView>
                                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                     ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                                                     SelectCommand="SGPL_GetPrevisionbyArticletaille" SelectCommandType="StoredProcedure">
                                                                     <SelectParameters>
                                                                        <asp:ControlParameter ControlID="GDVArticle" DefaultValue="0" Name="ArticlePrevision_ArticleId"
                                                        PropertyName="SelectedValue" Type="String" />
                                                                         <asp:ControlParameter ControlID="DDLAgent" DefaultValue="0" 
                                                                             Name="Prevision_Agent" PropertyName="SelectedValue" Type="String" />
                                                                     </SelectParameters>
                                                                 </asp:SqlDataSource>
                                                             </td>
                                                             <td width="10%">
                                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("PERIODICITE") %>'></asp:Label> 
                                                             </td>
                                                             <td width="10%">
                                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("Unite_periodicite") %>'></asp:Label> 
                                                             </td>
                                                             <td width="10%">
                                                             <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label> 
                                                             </td>
                                                            <td width="10%" valign="bottom" runat="server" visible='<%# visible() %>'  >
                                                                <asp:TextBox ID="Txtprevision" runat="server" class="bts-form" Width="40%" Text="" ></asp:TextBox>
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
                        <td colspan="2" align="center" width="100%">
                         <p>
                         <asp:Button ID="BtnValider" class="bts" runat="server" Text="Valider" 
                                 Visible="false" onclick="BtnValider_Click" />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Enregistrer" Visible ="false" 
                                 ValidationGroup="v" onclick="BtnEnregistrer_Click"  />
                        
                         <asp:Button ID="BtnModification" class="bts" runat="server" Text="Modification" Visible="false"
                                  onclick="BtnModification_Click"  />
                </p>
                        </td>
                        </tr>
                    </table>
       

      </div>
        
        <br />
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
