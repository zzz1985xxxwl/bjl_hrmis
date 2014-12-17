<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkillTypeView.ascx.cs" Inherits="SEP.Performance.Views.SkillType.SkillTypeView" %>

<div  id="tbMessage" runat="server" class="leftitbor" >
<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
<asp:Label ID="lblOperation" runat="server" >  
</asp:Label>
 &nbsp;
<asp:HiddenField ID="Operation" runat="server" />        
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
         <td width="8px" align="right" ></td>
          <td width="8%" align="left" >编&nbsp;&nbsp;&nbsp;号</td>
         <td width="10%" align="left" >
          <asp:TextBox  runat="server" ID="txtID" ReadOnly="True" CssClass="input1" Width="81px" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
          </td> 
          <td width="18%" align="left" >
              类&nbsp;型&nbsp;名&nbsp;称&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td align="left">
          <asp:TextBox  runat="server" ID="txtName" CssClass="input1"></asp:TextBox>&nbsp;               
          <asp:Label runat="server" ID="lblNameMsg" CssClass="psword_f"></asp:Label>			  
	      </td>
	      </tr> 			
      </table>
</div>
<div class="tablebt">
<asp:Button  Text="确  定" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
<asp:Button  Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>        