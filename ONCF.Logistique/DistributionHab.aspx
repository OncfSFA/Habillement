<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" CodeBehind="DistributionHab.aspx.cs" Inherits="ONCF.Logistique.DistributionHab" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Distribution des Articles </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
         <div class="left-form"  >
      
      <table width="100%">
       
                    <tr>
                        
                          <td width="50%" style="height: 37px">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Direction&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                     <asp:DropDownList ID="DDLDirection" runat="server" width="150px" 
                                        AutoPostBack="True" AppendDataBoundItems="True" DataSourceID="SDS_DIRECTION" 
                                        DataTextField="libelle_direction" DataValueField="cod_org_d" onselectedindexchanged="DDLDirection_SelectedIndexChanged" 
                                    >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                               
                                    <asp:SqlDataSource ID="SDS_DIRECTION" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Id_EtablissementMere" SessionField="idPole" 
                                                Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                               
                                </p>
                            </td>
                    <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Etablissement Mere &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDLEtablissementMere" runat="server" width="150px" AutoPostBack="True"
                                        DataTextField="LIBELLE_ORGANISATION"
                                DataValueField="CODE_ORGANISATION" AppendDataBoundItems="True" 
                                        onselectedindexchanged="DDLEtablissementMere_SelectedIndexChanged" DataSourceID="SDS_ETABLISSEMENT_MERE"  
                                        >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_ETABLISSEMENT_MERE" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLDirection" Name="Id_EtablissementMere" 
                                                PropertyName="SelectedValue" Type="String" />
                                            <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="DDLEtablissementmere" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir une étabelissement" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator1">
        </cc1:ValidatorCalloutExtender>
                                   </p>
                            </td>
                    </tr>
                           <tr>
                                                  

                       <td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Etablissement Fille &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDL_Etablissement_Fille" runat="server" DataSourceID="SDS_ETABLISSEMENT_FILLE" 
                                        width="150px" AutoPostBack="True"   DataTextField="LIBELLE_ORGANISATION"
                                DataValueField="CODE_ORGANISATION"  AppendDataBoundItems="True" 
                                        onselectedindexchanged="DDL_Etablissement_Fille_SelectedIndexChanged" >
                                <asp:ListItem Text="- Sélectionner -" Value="0000" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_ETABLISSEMENT_FILLE" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLEtablissementMere" Name="Id_EtablissementMere" 
                                                PropertyName="SelectedValue" Type="String" />
                                            <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator3" runat="server" 
            ControlToValidate="DDLEtablissementMere" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir une étabelissement" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator1">
        </cc1:ValidatorCalloutExtender>
                                    
                                   </p>
                            </td>
                            <td width="50%">
                          
        </td>
                            </tr>
                        </table>
                         <asp:HiddenField ID="HdnAction" runat="server" />
                        <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" 
               Width="100%"  BorderStyle="None"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                           
                                                             <th width="20%">
                                                                <asp:Label ID="LblNomEnClature1" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="LblDesignation1" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="LblTail1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="20%">
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantité Prev" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                              <th width="20%">
                                                                <asp:Label ID="Label1" runat="server" Text="Quantité à Distribuer" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center" >
                                                            <td width="20%">                   
                                                                <asp:Label ID="LblArticleId" runat="server" Text='<%# Eval("ArticlePrevision_ArticleId") %>' ></asp:Label>
                                                             </td> 
                                                              <td width="20%">
                                                               <asp:Label ID="LblArticleDesing" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>' ></asp:Label>
                                                            </td>
                                                           
                                                             <td width="20%">                   
                                                                <asp:Label ID="LblTail" runat="server" Text='<%# Eval("ArticlePrevision_Taille") %>' ></asp:Label>
                                                             </td> 
                                                             
                                                             <td width="20%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Qte") %>'></asp:Label>
                                                           </td>
                                                           <td width="20%">
                                                                <asp:TextBox ID="TXTQteLivre" runat="server" Text="0"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TXTQteLivre" ClientIDMode="AutoID"
                                                                    ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b>" />
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" ClientIDMode="AutoID" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                                                
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="AutoID"
                                                                     ControlToValidate="TXTQteLivre" Display="None" 
                                                                     ErrorMessage="&lt;b&gt;seul les valeurs numériques autorisées&lt;/b&gt;" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" ClientIDMode="AutoID" TargetControlID="RegularExpressionValidator1"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                               
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TXTQteLivre" Display="None" 
                                                                     ErrorMessage="La quantité livré doit être inférieur ou égale à la quantité Commandée" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"
                                                                 Operator="LessThanEqual" Type="Integer" ValueToCompare='<%# Eval("Qte") %>'></asp:CompareValidator>

                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" ClientIDMode="AutoID" TargetControlID="CompareValidator1"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                    <asp:GridView ID="GDModif" runat="server" AutoGenerateColumns="False" 
               Width="100%"    BorderStyle="None"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                           
                                                             <th width="16%">
                                                                <asp:Label ID="LblNomEnClature1" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="LblDesignation1" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="16%">
                                                                <asp:Label ID="LblTail1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="16%">
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantité Prev" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="16%">
                                                                <asp:Label ID="Label2" runat="server" Text="Quantité Distribue" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                              <th width="16%">
                                                                <asp:Label ID="Label1" runat="server" Text="Quantité à Distribuer" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center" >
                                                            <td width="16%">   
                                                                  <asp:Label ID="LblLivraisonId" runat="server" Visible="false" Text='<%# Eval("Livraison_Id") %>' ></asp:Label>           
                                                                <asp:Label ID="LblArticleId" runat="server" Text='<%# getchamp(Eval("Livraison_ArticleDesing").ToString(),0) %>' ></asp:Label>
                                                             </td> 
                                                              <td width="20%">
                                                               <asp:Label ID="LblArticleDesing" runat="server" Text='<%# getchamp(Eval("Livraison_ArticleDesing").ToString(),2) %>' ></asp:Label>
                                                            </td>
                                                           
                                                             <td width="16%">                   
                                                                <asp:Label ID="LblTail" runat="server" Text='<%# getchamp(Eval("Livraison_ArticleDesing").ToString(),1) %>' ></asp:Label>
                                                             </td> 
                                                              <td width="16%">
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Livraison_QtePrev") %>'></asp:Label>
                                                           </td>
                                                             <td width="16%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Livraison_QteLivraison") %>'></asp:Label>
                                                           </td>
                                                           <td width="16%">
                                                                <asp:TextBox ID="TXTQteLivre" runat="server" Text="0"></asp:TextBox>
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TXTQteLivre" ClientIDMode="AutoID"
                                                                    ValidationGroup="v" Display="None" ErrorMessage="<b>Texte manquant</b>" />
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" ClientIDMode="AutoID" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                                                
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="AutoID"
                                                                     ControlToValidate="TXTQteLivre" Display="None" 
                                                                     ErrorMessage="&lt;b&gt;seul les valeurs numériques autorisées&lt;/b&gt;" 
                                                                     SetFocusOnError="True" ValidationExpression="([0-9]+(?:[.,][0-9]+)?)" 
                                                                     ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" ClientIDMode="AutoID" TargetControlID="RegularExpressionValidator1"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                               
                                          
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <div align="center">
         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Valider" 
        ValidationGroup="v" onclick="BtnEnregistrer_Click" Visible ="false"
        OnClientClick="return confirm('Êtes-vous sûr de la quantité à distribuer !!');"    />
                           <asp:Button ID="BtnModif" class="bts" runat="server" Text="Enregistrer" 
        ValidationGroup="v"  Visible ="false" onclick="BtnModif_Click"  
        OnClientClick="return confirm('Êtes-vous sûr de la quantité à distribuer !!');"   />
       
        <asp:Button ID="BtnTelecharger"  runat="server" Text="Telecharger le bordereau de distribution" BackColor="White" ForeColor="#FF6600" Width="450px" Height="30px"
        ValidationGroup="v"  Visible ="false" onclick="BtnTelecharger_Click"    />
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
                                    <td class="modal_header" >
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
       <Triggers >
    <asp:PostBackTrigger ControlID ="BtnEnregistrer" />
    <asp:PostBackTrigger ControlID ="BtnModif" />    
     <asp:PostBackTrigger ControlID ="BtnTelecharger" />
    </Triggers>
    </asp:UpdatePanel>
     
</asp:Content>
