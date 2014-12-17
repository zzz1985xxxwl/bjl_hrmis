<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletinSendMailView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Bulletins.BulletinSendMailView" %>

 <div id="message" runat="server" class="leftitbor">
 <asp:Label ID="lblMessage" runat="server"  CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2" >发送邮件</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
          <td align="right" style="width: 18px"></td>
          <td width="50" align="left">公告标题</td>
          <td align="left" colspan="6"><asp:Label ID="lblBulletinTitle" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td align="right" style="width: 9px"></td>
          <td width="50" align="left">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名</td>
          <td align="left" style="width: 70px"><asp:TextBox ID="txtEmployeeName" runat="server" class="input1" ></asp:TextBox></td>
          <td width="50" align="left">部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门</td>
          <td align="left" style="width: 70px"><asp:DropDownList ID="ddlDepartment" runat="server" Width="135px" ></asp:DropDownList></td>
          <td width="50" align="left" >职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位</td>
          <td align="left" style="width: 70px"><asp:DropDownList ID="ddlPosition" runat="server" Width="135px"></asp:DropDownList></td>
          <td align="left"></td>
        </tr>
    </table>
</div>
 
<div class="tablebt">
       <asp:Button ID="Search" runat="server" Text="查  询" OnClick="Search_Click" class="inputbt" />
      </div>
<div class="edittable">
    <table width="100%"  border="0">
        <tr> <td height="7px" colspan="4" ></td></tr>
        <tr>
			    <td align="left" style="width: 18px" > </td>
			    <td align="left" style="width: 204px ; height:245px" > <asp:ListBox ID="EmployeeSearched" runat="server"  Height="245px" Width="230px" SelectionMode="Multiple"></asp:ListBox></td>
			    <td align="center">
			    <asp:Button ID="ToRight" runat="server" Text=">>" OnClick="ToRight_Click"   class="inputbt4"  /><br /><br />
			    <asp:Button ID="ToLeft" runat="server" Text="<<" OnClick="ToLeft_Click" class="inputbt4"/></td>
			    <td align="left" style=" height:245px" ><asp:ListBox ID="EmployeeToSend" runat="server"  Height="245px"  Width="230px" SelectionMode="Multiple"></asp:ListBox></td>
	     </tr>
	</table>
</div>
 <div class="tablebt">
 <asp:Button ID="SendMail" runat="server" Text="发  送" OnClick="SendMail_Click" class="inputbt" />
<asp:Button ID="Cancel" runat="server" Text="取  消"  OnClick="Cancel_Click" class="inputbt" value="取　消" />
</div>