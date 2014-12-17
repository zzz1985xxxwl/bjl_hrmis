<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkillView.ascx.cs" Inherits="SEP.Performance.Views.Skill.SkillView" %>
<div id="tbMessage" runat="server" class="leftitbor">
<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
 <div class="leftitbor2" >
<asp:Label ID="lblOperation" runat="server" >  
</asp:Label>
<asp:HiddenField ID="Operation" runat="server" />        
</div>
	<div class="edittable">
          <table width="100%" border="0">
            <tr>
              <td align="right" style="width: 2%" ></td>
              <td align="left" style="width: 16%" >编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号</td>
              <td align="left" style="width: 88%" >
              <asp:TextBox  runat="server" ID="txtID" CssClass="input1" ReadOnly="True" Width="40%"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
              </td>               
			  </tr>  
			  
			  <tr>
              <td align="right" style="height: 24px" ></td>              
              <td align="left" style="height: 24px" >
                  技 能 名 称&nbsp;<span class = "redstar">*</span></td>
              <td align="left" style="height: 24px" colspan="2" >
              <asp:TextBox  runat="server" ID="txtName" CssClass="input1" Width="40%"></asp:TextBox>&nbsp;
			  <asp:Label runat="server" ID="lblNameMsg" CssClass="psword_f"></asp:Label>
			  </td>
			  </tr>  
			  
			  <tr>
              <td align="right" style="height: 37px" ></td>
              <td align="left" style="height: 37px" >
                  技 能 类 型&nbsp;<span class = "redstar">*</span></td>          
             <td align="left" colspan="2" ><asp:DropDownList ID="listSkillType" runat="server" Width="42%" ></asp:DropDownList>&nbsp;
			  <asp:Label runat="server" ID="lblSTMsg"  CssClass="psword_f"></asp:Label>
			  </td>
			  </tr>  
			           
          </table>
		  </div>
<div class="tablebt">  
		   <asp:Button  Text="确  定" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
           <asp:Button  Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>