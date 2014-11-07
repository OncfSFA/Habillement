<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true"
 CodeBehind="historiqueSaisiePrevision.aspx.cs" Inherits="historiqueSaisiePrevision" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Historique des prévisions  </h4>
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
                                        Etablissement Mere &nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                         <asp:DropDownList ID="DDLEtablissementMere" runat="server" width="150px" AutoPostBack="True"
                                        DataTextField="LIBELLE_ORGANISATION"
                                DataValueField="CODE_ORGANISATION" AppendDataBoundItems="True" 
                                        onselectedindexchanged="DDLEtablissementMere_SelectedIndexChanged" >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                         <asp:SqlDataSource ID="SDS_ETABLISSEMENT_MERE" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SGPL_GetListEtabByIdEtab" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="1" Name="Id_EtablissementMere" Type="String" />
                                            <asp:Parameter DefaultValue="1" Name="Type" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                 
                                   </p>
                            </td>
                          

                        </tr>
                        
                        <tr>
                        <td  align="center"  >
                         <br />  
                           
                            <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" Width="95%"  
                                        BorderStyle="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 90%; height: 30px" align="center">
                                                            <th width="30%">
                                                                <asp:Label ID="L1" runat="server" Text="Agent" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             <th width="30%">
                                                                <asp:Label ID="Label1" runat="server" Text="Date de Mise a jour" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                              <th width="40%">
                                                                <asp:Label ID="Label3" runat="server" Text="Responsable" Font-Size="13px" ></asp:Label>
                                                            </th>
                                                             
                                                         
                                                        </tr>
                                                        
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="90%" align="center">
                                                            <td width="30%">
                                                                <asp:Label ID="LblLibEffet" runat="server" Text='<%# Eval("Prevision_Agent") %>'></asp:Label>
                                                                
                                                            </td>
                                                             
                                                             <td width="30%">
                                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("ArticlePrevision_DateCreation") %>'></asp:Label> 
                                                             </td>
                                                             <td width="40%">
                                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("Utilisateur_Matricule") %>'></asp:Label> 
                                                             </td>
                                                             
                                                            
                                                            
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                               
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
