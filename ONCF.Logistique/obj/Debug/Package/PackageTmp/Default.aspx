<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/MasterONCF.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="RDV_CNIE.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MidContent">
     <asp:UpdatePanel runat="server" id="Panel">
            <ContentTemplate>
    <div runat="server" id="divTF" class="top-right">
        <h4>
            Acceuil</h4>
    </div>
    <div class="contenu-right" style="display: block; background-color:White;">

      <div align="center" style="position:relative;margin:15px 20px 20px 20px;height:40px;">
      
                  &nbsp;
      </div>
        
        <br />
        <br />
        
      
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
     
</asp:Content>
