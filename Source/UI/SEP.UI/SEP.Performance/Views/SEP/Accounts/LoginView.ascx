<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LoginView.ascx.cs" Inherits="SEP.Performance.Views.LoginView" %>
<div id="login03" >
    用户名<br />
    <asp:TextBox ID="txtLoginName" runat="server" CssClass="input1" MaxLength="50" Width="145px" />
    <asp:Label ID="lblValidateLoginName" runat="server" CssClass="psword_f" style="vertical-align:middle; "/>
    <br />
     密&nbsp;&nbsp;&nbsp;&nbsp;码<br />
    <asp:TextBox ID="txtPassword" runat="server" Width="145px" CssClass="input1" MaxLength="50" TextMode="Password" Wrap="False"></asp:TextBox>
    <asp:Label ID="lblValidatePassword" runat="server" CssClass="psword_f"  style="vertical-align:middle;"></asp:Label>
</div>


<div id="loginablebt" >
		<asp:Button ID="btnOK" runat="server" CssClass="btbg1" Text="登　录"  OnClientClick='var confirm=GetUsbKey();return confirm;'  OnClick="btnOK_Click" />
   	    <asp:Button ID="btnCancel" runat="server" CssClass="btbg1" Text="取　消"/>
   	    <asp:Label ID="lblResultMessage" runat="server" CssClass="psword_f"></asp:Label>
</div>  
   	  

<input id="lbUsbKeyCount" type="hidden" class="UsbKeyCount" runat="server" />
<input id="lbUsbKey" type="hidden" class="UsbKey"  runat="server" />
<script language="javascript " type="text/javascript" src="Inc/UsbKey.js"></script>