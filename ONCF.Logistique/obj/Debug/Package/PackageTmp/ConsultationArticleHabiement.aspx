<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" CodeBehind="ConsultationArticleHabiement.aspx.cs" Inherits="ONCF.Logistique.ConsultationArticleHabiement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Consulter les prévisions&nbsp; </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
         <div class="left-form">
      
      <table width="100%">
       
                    <tr>
                    <td width="50%" style="height: 37px">
                                <p>
                                    
                                   
                                    <label >
                                        Consultation pour Pole<b style="color: Red"> *</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDLPole" runat="server" width="150px" AutoPostBack="True"
                                       AppendDataBoundItems="True" DataSourceID="SDS_POLE" 
                                        DataTextField="libelle_direction" DataValueField="code_dc" onselectedindexchanged="DDLPole_SelectedIndexChanged" 
                                        >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                           
       
                                    <asp:SqlDataSource ID="SDS_POLE" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="Id_EtablissementMere" Type="Int32" />
                                            <asp:Parameter DefaultValue="2" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                           
       
                                   </p>
                            </td>
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
                                            <asp:ControlParameter ControlID="DDLPole" Name="Id_EtablissementMere" 
                                                PropertyName="SelectedValue" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                               
                                </p>
                            </td>
                    
                    </tr>
                    <tr>
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
                         

                       <td width="50%">
                                <p>
                                    
                               
                                    <label >
                                        Etablissement Fille &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDL_Etablissement_Fille" runat="server" DataSourceID="SDS_ETABLISSEMENT_FILLE" 
                                        width="150px" AutoPostBack="True"   DataTextField="LIBELLE_ORGANISATION" onselectedindexchanged="DDL_Etablissement_Fille_SelectedIndexChanged"
                                DataValueField="CODE_ORGANISATION"  AppendDataBoundItems="True"  >
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
                            
                          </tr>
                           <tr>
                            
                         
<td width="50%">
                                <p>
                                    
                                   
                                    <label >
                                        Agent&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                    <asp:DropDownList ID="DDLAgent" runat="server" width="150px"
                                        DataSourceID="SDS_Agent" DataTextField="agent"
                                DataValueField="agt_mle" AppendDataBoundItems="True" 
                                        onselectedindexchanged="DDLAgent_SelectedIndexChanged" 
                                        AutoPostBack="True" >
                                <asp:ListItem Text="- Sélectionner -" Value="0000" />
                            </asp:DropDownList>
                             
                                    <asp:SqlDataSource ID="SDS_Etab_User" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" 
                                        SelectCommandType="StoredProcedure" >
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Id_EtablissementMere" SessionField="idEtabMere" 
                                                Type="String" />
                                            <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
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
                       <td width="50%">
                          <p>
                              
                                 <label >
                                        Fonction&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                <asp:DropDownList ID="DDLFonction" runat="server" width="150px" 
                                     AutoPostBack="true" AppendDataBoundItems="true" DataSourceID ="SqlDataSourceKit"
                                       DataTextField="FONCTION" DataValueField="code" 
                                     onselectedindexchanged="DDLFonction_SelectedIndexChanged"  >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceKit" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_INTER_GetFonction" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                         
                          </p>
                                
                            </td>
                           </tr>
                        </table>
                        <asp:ImageButton  runat="server" ID ="exporter" ImageUrl="~/images/btn_exporter-excel.gif" Height="30px" Width="100px" Visible="false" 
                 onclick="exporter_Click" />
                 <div align="center" >
                     <asp:HiddenField ID="Hdntype" runat="server" />
                      <asp:GridView ID="GDVAgent" runat="server" AutoGenerateColumns="False" Width="95%"  DataKeyNames="MATRICULE"
                                       EmptyDataText ="Il n'existe aucune prévision"   BorderStyle="None"
                                       AllowPaging ="true" PageSize="10" OnPageIndexChanging ="GDVAgent_OnPageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate >
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                            <th width="10%">
                                                                <asp:Label ID="L1" runat="server" Text="Matricule" Font-Size="15px" ForeColor="White" ></asp:Label>
                                                            </th>
                                                            <th width="90%">
                                                           
                                                                <asp:Label ID="LblNomEnClature1" runat="server" Text="Code effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Label ID="LblDesignation1" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Label ID="LblTail1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantite" Font-Size="15px" ForeColor="White"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </th>
                                                            
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center" >
                                                            <td width="10%">
                                                                                                              
                                                                <asp:Label ID="lblMatricule" runat="server" Text='<%# Eval("MATRICULE") %>' ></asp:Label>
                                                                
                                                            </td>
                                                             
                                                             <td width="90%"  height="40px" colspan="4">
                                                <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False"
                                                Width="100%" DataSourceID="SqlDataSource1"  BorderStyle="None" ShowHeader="False"   >
                                        <Columns>
                                            <asp:TemplateField>
                                             
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%"  align="center"  >
                                                            <td width="20%">
                                                               <asp:Label ID="LblNomEnClature" runat="server" Text='<%# Eval("Article_Id") %>' ></asp:Label>
                                                            </td>
                                                            <td width="30%" >                   
                                                                <asp:Label ID="LblDesignation" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>' ></asp:Label>
                                                             </td> 
                                                             <td width="25%"  >                   
                                                                <asp:Label ID="LblTail" runat="server" Text='<%# Eval("ArticlePrevision_Taille") %>' ></asp:Label>
                                                             </td> 
                                                             
                                                             <td width="25%" >
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("ArticlePrevision_QtePrevision") %>'></asp:Label>
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                         SelectCommand="SGPL_GetArticlePrevisionForModif" SelectCommandType="StoredProcedure">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="GDVAgent" DefaultValue="0" 
                               Name="Prevision_Agent" PropertyName="SelectedValue" Type="String" />
                       </SelectParameters>
                      </asp:SqlDataSource>
                                                              </td>
                                                         </tr>
                                                      </table>
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                       </Columns>
                    </asp:GridView>
                        
                     
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
    <Triggers >
    <asp:PostBackTrigger ControlID ="exporter" />
    </Triggers>
    </asp:UpdatePanel>
     
</asp:Content>
