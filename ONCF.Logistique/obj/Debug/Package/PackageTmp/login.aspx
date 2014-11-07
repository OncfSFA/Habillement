<%@ Page Title="|| ONCF ||" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="css/default.css" rel="stylesheet" type="text/css" />
<title>|| ONCF ||</title>
<link href="css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="scripts/jquery.js" ></script>
    <script src="scripts/cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
       $(document).ready(function () {
           $.cookie('panel1', null);
           $.cookie('panel2', null);
       });
        // -->
</script>
</head>

<body>
<form runat="server" id="form1">

 <asp:ScriptManager ID="ScriptManager1" ScriptMode="Release" EnableHistory="true"
            runat="server">
        </asp:ScriptManager>
<!-- Debut containaire -->
<div class="container">
        <!-- Debut Header -->
        <div class="header">           
        	<div class="logo">
                <img alt="Logo" src= "images/Logo.jpg" title="Logo" />
            </div>
            <div class="txt-header">
                <h2 style="font-size:20px">Gestion Habillement du Personnel ONCF
                <%--et Logistiques<img alt="Titre" src="images/titre-header.jpg" title="Titre" />--%></h2>
            </div>  
            <div class="connect">
            	<p>Connecté :</p> 
                	<ul>
                        <li class="profile"><a href="#" title="Mon profile" id="profil" runat="server">Profile</a></li>
                     <li class="deconnexion">   <asp:LinkButton ID="lbDeconeexion"  runat="server" Text="Connexion" 
                                onclick="lbDeconeexion_Click" ></asp:LinkButton> </li>
                    </ul>
                   
            </div>       
        </div>
        <!-- Fin Header -->
        <!-- Debut contenu -->
        <div class="contenu">
            <!-- Debut session -->
            <div class="session">            
                <div class="titre-session">
                <h4>Ouvrir une session</h4>
                </div> 
                
                <div class="contenu-session" style="display: block;" >

					<p>
                    <label>Login<span>:</span></label>
                    <asp:TextBox ID="Txtuser1" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="Txtuser1"
                                                            ErrorMessage="User Name is required." 
                            ToolTip="Ce champ est obligatoire" ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                   
                    </p>
                    <p>
                    <label>Mot de passe<span>:</span></label>
                    <asp:TextBox ID="Txtpwd1" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Txtpwd1"
                                                            ErrorMessage="*" 
                            ToolTip="Ce champ est obligatoire" ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
               <asp:Button ID="Button1" style="margin-left:9px" class="bts-session" runat="server" onclick="LoginButton_Click" ValidationGroup="Login1"  />
                  
                   </p>
                            
                
            </div>
            <!-- Fin session -->
        </div>
        <!-- Fin contenu -->
         <!-- Debut footer -->
        <div class="footer">
        	<p>2013 © Copyright ONCF</p>
        </div>
         <!-- Fin footer -->
</div>
<!-- Fin containaire -->
 <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel1"
        TargetControlID="Label92" CancelControlID="LinkButton2" BackgroundCssClass="modalBackground"
        RepositionMode="RepositionOnWindowResize">
    </cc1:ModalPopupExtender>
    <asp:Label ID="Label92" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label97" runat="server" Text=""></asp:Label>
    <asp:Panel ID="Panel1" runat="server" Height="150px" Width="379px">
        <table class="modal">
           <tr>
                <td class="modal_header">
                    <h3>
                        Attention !!</h3>
                    
                </td>
            </tr>
            <tr>
                <td class="modal_body" align="center">
                    <p>
                    <asp:Label ID="msg" runat ="server" Text="Veuillez vérifier votre Matricule ou Mot de passe"></asp:Label>    </p>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <div class="btn-ConfirmRight1">
                       
                             <asp:Button ID="BtnEnregistrer" class="bts" runat="server" Text="ok" CausesValidation="False" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>

</form>
</body>
</html>
