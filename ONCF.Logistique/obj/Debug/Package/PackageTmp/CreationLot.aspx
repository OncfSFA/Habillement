<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" CodeBehind="CreationLot.aspx.cs" Inherits="CreationLot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Génération des Ordres de livraisons </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
         <div class="left-form">
      
      <table width="100%">
       
                    <tr>
                    <td width="50%" style="height: 37px">
                                <p>
                                    
                                   
                                    <label >
                                        N° Lot<b style="color: Red"> *</b>&nbsp;:</label>
                                         <asp:TextBox ID="TxtLot" runat="server" class="bts-form" Enabled="false" Width="150px"  />
                                                      
       
                                   </p>
                            </td>
                          <%--<td width="50%" style="height: 37px">
                                <p>
                                    
                                   
                                    <label runat="server" id="Label6">
                                        Marché&nbsp;<b style="color: Red">*</b>&nbsp;:</label>
                                     <asp:DropDownList ID="DDLmarche" runat="server" width="150px" 
                                       AppendDataBoundItems="True" DataSourceID="SqlMarche" 
                                        DataTextField="Marche_Num" DataValueField="Marche_Id"
                                    >
                                <asp:ListItem Text="- Sélectionner -" Value="0" />
                            </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlMarche" runat="server" ConnectionString="<%$ ConnectionStrings:CNX_Logistique %>" 
                                        SelectCommand="SELECT Marche_Id, ' N° : ' + Marche_Num + ' , ' +  Marche_Fournisseur as Marche_Num FROM [SGPL_MARCHE]"></asp:SqlDataSource>
              <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="DDLDirection" Display="None" 
            ErrorMessage="&lt;b&gt;Texte manquant&lt;/b&gt;&lt;br /&gt;Veuillez Choisir un marché" 
            Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" 
            Enabled="True" PopupPosition="right" TargetControlID="CompareValidator1">
        </cc1:ValidatorCalloutExtender>
                                </p>
                            </td>--%>
                    <td width="50%" >
                                <p>
                                                                       
                                    <label >
                                        Date &nbsp;<b style="color: Red">*</b>&nbsp;:</label>

                                 <asp:TextBox runat="server" ID="TXTDate" class="bts-form" Text="" Width="150px" 
                                        ReadOnly="True"></asp:TextBox>
                                   </p>
                            </td>
                    </tr>
                    <%--<tr>
                            
                         

                       
                             <td width="50%">
                                <p>
                                    
                                   
                                    &nbsp;</p>
                               
                              
                            </td>
                          </tr>--%>
                        </table>
                        <asp:GridView ID="GDVArticle" runat="server" AutoGenerateColumns="False" 
               Width="100%" BorderStyle="None"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr style="background-color: #fbb17f; width: 100%; height: 30px" align="center">
                                                          

                                                             <th width="25%">
                                                                <asp:Label ID="LblNumArticle" runat="server" Text="Sélectionner effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                             <th width="25%">
                                                                <asp:Label ID="LblDesignation" runat="server" Text="Libelle effet" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                            <th width="25%" runat ="server" id="idt" visible ='<%# visibilite() %>'>
                                                                <asp:Label ID="Label1" runat="server" Text="Taille" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                                                                <th width="25%">
                                                                <asp:Label ID="LblQte1" runat="server" Text="Quantité" Font-Size="15px" ForeColor="White"></asp:Label>
                                                            </th>
                              
                                                           
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr width="100%" align="center">
                                                             <td width="25%">
                                                                  <asp:CheckBox  runat="server" ID="ValidArticle" />
                                                      
                                                            </td>
                                                            <%--   <td width="25%">  
                                                                     
                                                                         
                                                              <asp:Label ID="LblNArticle" runat="server" Text='<%# Eval("Article_Nomenclature") %>' ></asp:Label>
                                                             </td> --%>
                                                            <td width="25%">
                                                             <asp:Label ID="IdArticle" runat="server" Text='<%# Eval("ArticlePrevision_ArticleId") %>' visible = "false" ></asp:Label>
                                                               <asp:Label ID="LblDesignation" runat="server" Text='<%# Eval("ArticlePrevision_ArticleDesing") %>' ></asp:Label>
                                                            </td>
                                                            <td width="25%" runat ="server" id="idtt" visible ='<%# visibilite() %>'>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ArticlePrevision_Taille") %>'></asp:Label>
                                                           </td>
                                                             <td width="25%">
                                                                <asp:Label ID="LblQte" runat="server" Text='<%# Eval("Qte") %>'></asp:Label>
                                                           </td>
                                                           </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
<table width="100%">
   <tr>
                        <td colspan="2" align="center" width="100%">
                         <p>
                          <asp:Button ID="BtnAnnuler" class="bts" runat="server" Text="Annuler" onclick="BtnAnnuler_Click" 
                                  />
                         <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="Valider" 
                                 ValidationGroup="v" onclick="BtnEnregistrer_Click"  />
                        
                </p>
                        </td>
                        </tr>
                    </table>

                    
                                   
       

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