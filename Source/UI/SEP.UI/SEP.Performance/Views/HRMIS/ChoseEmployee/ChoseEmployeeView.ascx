<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChoseEmployeeView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.ChoseEmployee.ChoseEmployeeView" %>
<div class="leftitbor2" >查找人员
<asp:HiddenField ID="Operation" runat="server" />        
</div>

<div class="edittable">
  <table width="100%" border="0">
      <tr>
          <td width="7%" align="left">姓名</td>
          <td align="left" style="width: 24%;">
          <asp:TextBox ID="txtAccountName" runat="server" CssClass="input1" Width="80%">
          </asp:TextBox></td>
          <td width="7%" align="left">部门</td>
          <td align="left" style="width: 24%;" >
          <asp:DropDownList   ID="ddlDepartment" runat="server" Width="80%" >
          </asp:DropDownList></td>
          <td align="left" style="width: 7%;">职位</td>
          <td align="left" style="width: 24%;">
          <asp:DropDownList ID="ddlPosition" runat="server" Width="80%">
          </asp:DropDownList></td>
      </tr>	
  </table>
</div>
<div class="tablebt">      
    <asp:Button ID="Search" runat="server" Text="查  询"  CssClass="inputbt" OnClick="Search_Click" />
</div>       

<div class="edittable">
     <table width="100%" border="0">
         <tr>
             <td align="left" style="width: 100px ;" >
                <asp:ListBox ID="AccountSearched" runat="server"  Height="150px" Width="180px" SelectionMode="Multiple"></asp:ListBox>
             </td>
             <td align="center">
                 <asp:Button ID="ToRight" runat="server" Text=">>" CssClass="inputbt4" OnClick="ToRight_Click"  /><br /><br />
                 <asp:Button ID="ToLeft" runat="server" Text="<<"  CssClass="inputbt4" OnClick="ToLeft_Click"/>
             </td>
             <td align="left">
                 <asp:ListBox ID="AccountToSend" runat="server"  Height="150px"  Width="180px" SelectionMode="Multiple"></asp:ListBox>
             </td>
         </tr>
     </table>
</div>
<div class="tablebt">
     <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="inputbt" OnClick="btnCancel_Click" ></asp:Button>
</div>