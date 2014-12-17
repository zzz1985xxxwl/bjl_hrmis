<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChosePositionView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AssessManagement.ChosePositionView" %>
<div class="leftitbor2" >选择职位 
</div>
<div class="edittable">
     <table width="100%" border="0">
         <tr>
             <td align="left" style="width: 100px ;" >
                <asp:ListBox ID="AllPosition" runat="server"  Height="150px" Width="180px" SelectionMode="Multiple"></asp:ListBox>
             </td>
             <td align="center">
                 <asp:Button ID="ToRight" runat="server" Text=">>" CssClass="inputbt4" OnClick="ToRight_Click"  /><br /><br />
                 <asp:Button ID="ToLeft" runat="server" Text="<<"  CssClass="inputbt4" OnClick="ToLeft_Click"/>
             </td>
             <td align="left">
                 <asp:ListBox ID="PositionSelected" runat="server"  Height="150px"  Width="180px" SelectionMode="Multiple"></asp:ListBox>
             </td>
         </tr>
     </table>
</div>
<div class="tablebt">
     <asp:Button ID="btnCancel" runat="server" Text="关闭" CssClass="inputbt"  ></asp:Button>
</div>