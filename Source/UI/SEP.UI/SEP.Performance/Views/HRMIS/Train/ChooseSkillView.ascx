<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChooseSkillView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.ChooseSkillView" %>

<div class="leftitbor2" >���Ҽ���</div>
 
<div class="edittable">
  <table width="100%" border="0">
      <tr>
          <td width="10%" align="left">��������</td>
          <td align="left" style="width: 23%;">
          <asp:TextBox ID="txtSkillName" runat="server" CssClass="input1" Width="80%">
          </asp:TextBox></td>
          <td width="9%" align="left">��������</td>
          <td align="left" style="width: 23%;" >
          <asp:DropDownList   ID="listSkillType" runat="server" Width="80%" >
          </asp:DropDownList></td>
      </tr>	
  </table>
</div>
<div class="tablebt">  
   <asp:Button ID="Search" runat="server" Text="��  ѯ"  CssClass="inputbt" OnClick="Search_Click" />
</div>
<div class="edittable">
  <table width="100%" border="0">
     <tr>
         <td align="left" style="width: 100px ; height:150px" > 
            <asp:ListBox ID="SkillSearched" runat="server"  Height="150px" Width="180px" SelectionMode="Multiple"></asp:ListBox>
         </td>
         <td align="center">
             <asp:Button ID="ToRight" runat="server" Text=">>" CssClass="inputbt4" OnClick="ToRight_Click"  /><br /><br />
             <asp:Button ID="ToLeft" runat="server" Text="<<"  CssClass="inputbt4" OnClick="ToLeft_Click"/>
         </td>
         <td align="left">
             <asp:ListBox ID="SkillToSend" runat="server"  Height="150px"  Width="180px" SelectionMode="Multiple"></asp:ListBox></td>
     <td align="left" style=" height:150px; width: 467px;" >
         &nbsp;</td>
     </tr>
  </table>
</div>
   
<div class="tablebt">
    <asp:Button ID="Button1" runat="server" Text="�ر�" CssClass="inputbt"></asp:Button>
</div>