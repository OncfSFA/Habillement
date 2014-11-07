<%@ Page Title="" Language="C#" MasterPageFile="~/MasterONCF.master" AutoEventWireup="true" CodeBehind="GenererEscalaHab.aspx.cs" Inherits="ONCF.Logistique.GenererEscalaHab" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Génération fichier ESCALA  </h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

       <div class="left-form">
         <div class="left-form">
      
      <table width="100%">
       
                    <tr>
                        
                          <td width="50%" style="height: 37px">
                                 <p>
                                                                       
                                    <label >
                                        Date &nbsp;<b style="color: Red">*</b>&nbsp;:</label>

                                 <asp:TextBox runat="server" ID="TXTDate" class="bts-form" Text="" Width="150px" ></asp:TextBox>
                                   </p>
                            </td>
                 
                            <td width="50%">
                           
        <asp:Button ID="BtnESCALA" class="bts" runat="server" Text="Fiche ESCALA" 
          onclick="BtnESCALA_Click" 
         OnClientClick="return confirm('Veuillez transférer le fichier comptabilité  généré à l’ESCALA" />
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
      <Triggers >
    <asp:PostBackTrigger ControlID ="BtnESCALA" />
    
    </Triggers>
    </asp:UpdatePanel>
     
</asp:Content>
