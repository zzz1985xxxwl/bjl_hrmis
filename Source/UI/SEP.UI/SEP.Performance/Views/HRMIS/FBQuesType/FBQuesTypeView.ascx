<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FBQuesTypeView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.FBQuesType.FBQuesTypeView" %>
 <div  id="tbResultMessage"    runat="server" class="leftitbor" >	
<asp:Label ID="lblResultMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2">
<asp:Label ID="FBQuesTypeOperation" runat="server" />
</div>
<asp:Label ID="lbTypeId" runat="server" Text="" Visible="false"></asp:Label>
<asp:HiddenField ID="Operation" runat="server" />

<div class="edittable">
 <table width="100%" border="0">
    <tr>
      <td align="right" style="width: 10%" >编号</td>
      <td align="left" style="width: 15%" >
      <asp:TextBox  runat="server" ID="TxtID" Width="60%" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;&nbsp;
       </td> 
      <td align="right" style="width: 6%" >名称&nbsp;<span class = "redstar">*</span></td>
      <td align="left" style="width:46%;">
      <asp:TextBox  runat="server" ID="TxtName" Width="60%" CssClass="input1"></asp:TextBox>&nbsp;
      <asp:Label runat="server" ID="lblNameMessage" CssClass="psword_f"></asp:Label>			  
	  </td>
  </table>
</div>
<div class="tablebt">
<asp:Button  Text="确  定" ID="BtnOK"  OnClick="BtnOK_Click" runat="server" CssClass="inputbt"/>
<asp:Button  Text="取　消" ID="BtnCancel" runat="server" CssClass="inputbt" />
</div>