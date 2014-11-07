<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" CodeBehind="ValidationPolHab.aspx.cs" Inherits="ONCF.Logistique.ValidationPolHab" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Validation des prévisions </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
         <div class="left-form">
      
      <table width="100%">
        <tr>
                   
                          <td width="100%" colspan="2" style="height: 37px">
                               <table >
                               <tr>
                                <td width="33%" style="height: 37px">
                             <p ><big><b> Valider</b></big> 
                                    <asp:RadioButton ID="RdbVal" runat="server" GroupName="rdb" 
                                        Checked ="true" AutoPostBack="true" TextAlign="Left" Width="10%"
                                        oncheckedchanged="RdbVal_CheckedChanged"/>
                                </p>
                                </td>
                                <td width="33%" style="height: 37px">
                                <p><big><b>Rejet</b></big>
                                <asp:RadioButton ID="RdbRejet" runat="server" GroupName="rdb" 
                                        AutoPostBack="true" TextAlign="Left"  Width="10%"
                                        oncheckedchanged="RdbModif_CheckedChanged"/>
                                </p> 
                                </td>
                                <td width="36%" style="height: 37px">
                                <p><big><b>Modifier</b></big>
                                        
                                <asp:RadioButton ID="RdbModif" runat="server" GroupName="rdb" 
                                        AutoPostBack="true" TextAlign="Left"  Width="10%"
                                        oncheckedchanged="RdbModif_CheckedChanged"/>
                                </p> 
                                </td> 
                                 </tr>
                               </table>
                                </td>
                                </tr>
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
                    <tr id="lblag" runat="server"  Visible="false">
                            
                         

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
                                <p>
                                    
                                   
                                    <label >
                                        Agent &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLAgent" runat="server" width="150px" Visible="false"
                                        DataSourceID="SDS_Agent" DataTextField="agent" 
                                DataValueField="agt_mle" AppendDataBoundItems="True" 
                                        onselectedindexchanged="DDLAgent_SelectedIndexChanged" 
                                        AutoPostBack="True" >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_Agent" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_INTER_GetUserByEtab" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDL_Etablissement_Fille" Name="etb_code" 
                                                PropertyName="SelectedValue" Type="String" DefaultValue="" />
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
                          </tr>
                           <tr>
                           
                            <td width="50%">
                                <p>
                                    
                                   
                                    <label id="lblagfonc" runat="server"  Visible="false">
                                        Agent ayant fonction&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLAyantFonc" runat="server" width="150px"  Visible="false"
                                        DataSourceID="SqlayantFonc" DataTextField="agent" 
                                DataValueField="Matric" AppendDataBoundItems="True" 
                                      
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DDLAyantFonc_SelectedIndexChanged" >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlayantFonc" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        
                                        SelectCommand="SGPL_GetPrevAyantFonction" 
                                        SelectCommandType="StoredProcedure" >
                                    </asp:SqlDataSource>
                                  <asp:CompareValidator ID="CompareValidator4" runat="server" 
            ControlToValidate="DDLAgent" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir un Agent" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator2">
        </cc1:ValidatorCalloutExtender>
                                </p>
                            </td>    
                            <td>
                             <asp:Button ID="BtnValider" class="bts" runat="server" Text="Valider" CausesValidation="false"
                                 Visible="false" onclick="BtnValider_Click" />
                                 <asp:Button ID="BtnRejet" class="bts" runat="server" Text="Rejet" CausesValidation="false"
                                 Visible="false" onclick="BtnRejet_Click" />
                            <asp:Button ID="BtnModification" class="bts" runat="server" Text="Modification" Visible="false"
                                  onclick="BtnModification_Click"  />
                            </td> 
                          </tr>
                        </table>
                        <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" 
               Width="100%"   BorderStyle="None"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                           
                                                             <th width="25%">
                                                                <asp:Label ID="LblNomEnClature1" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="25%">
                                                                <asp:Label ID="LblDesignation1" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="25%">
                                                                <asp:Label ID="LblTail1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="25%">
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantité" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                              
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center" >
                                                            <td width="25%">
                                                                <asp:Label ID="LblDesignation" runat="server" Text='<%# Eval("Article_Id") %>' ></asp:Label>
                                                            </td>
                                                            <td width="25%"> 
                                                             <asp:Label ID="LblNomEnClature" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>' ></asp:Label>                  
                                                              
                                                             </td> 
                                                             <td width="25%">                   
                                                                <asp:Label ID="LblTail" runat="server" Text='<%# Eval("ArticlePrevision_Taille") %>' ></asp:Label>
                                                             </td> 
                                                             
                                                             <td width="25%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("ArticlePrevision_QtePrevision") %>'></asp:Label>
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
 <asp:GridView ID="GDValid" runat="server" AutoGenerateColumns="False" 
               Width="100%"  BorderStyle="None"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                          
                                                          <th width="50%">
                                                                <asp:Label ID="Label2" runat="server" Text="Etablissement" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="10%">
                                                                <asp:Label ID="LblNumArticle" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="20%">
                                                                <asp:Label ID="LblDesignation" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                           <th width="10%">
                                                                <asp:Label ID="Label1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="10%">
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantité" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                              
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center">
                                                        <td width="50%">
                                                                  <asp:Label ID="Label3" runat="server" Text='<%# Eval("Prevision_EtablissementId") %>'  ></asp:Label>
                                                        --
                                                          
                                                                  <asp:Label ID="Label5" runat="server" Text='<%# Eval("Prevision_LibelEtab") %>'  ></asp:Label>
                                                      
                                                            </td>
                                                             <td width="10%">
                                                                  <asp:Label ID="IdArticle" runat="server" Text='<%# Eval("ArticlePrevision_ArticleId") %>'  ></asp:Label>
                                                      
                                                            </td>
                                                           
                                                            <td width="20%">
                                                            
                                                               <asp:Label ID="LblDesignation" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>' ></asp:Label>
                                                            </td>
                                                           <td width="10%">                   
                                                                <asp:Label ID="LblTail" runat="server" Text='<%# Eval("ArticlePrevision_Taille") %>' ></asp:Label>
                                                             </td> 
                                                             
                                                             <td width="10%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Qte") %>'></asp:Label>
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
             <asp:HiddenField ID="HdnAgent" runat="server" />
                       <asp:HiddenField ID="HdnPrevision" runat="server" />
                        
                 
       

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
