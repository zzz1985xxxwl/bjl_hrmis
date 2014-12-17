<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkExperienceView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.ResumeInformation.WorkExperienceView" %>

<div class="leftitbor2">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>    
<div class="edittable">
      <table width="100%" border="0">
		<tr>
          <td align="left" style="width: 14%" >
          起止时间&nbsp;<span class = "redstar">*</span></td>
<td align="left" width="50%">
<asp:TextBox ID="txtPeriod" runat="server" CssClass="input1"></asp:TextBox>
<asp:Label ID="msgPeriod" runat="server" CssClass = "psword_f" ></asp:Label>
             
          </td>
          </tr>


 
<tr>
         <td align="left" >
        工作单位&nbsp;<span class = "redstar">*</span></td>
         <td align="left" >
<asp:TextBox ID="txtcompany" runat="server" CssClass="input1" ></asp:TextBox>       
<asp:Label ID="msgcompany" runat="server"  CssClass = "psword_f"></asp:Label></td>

</tr>

<tr>
         <td align="left">
        工作内容&nbsp;<span class = "redstar">*</span></td>
         <td align="left" >
<asp:TextBox ID="txtContent" runat="server" CssClass="input1"></asp:TextBox>
   
<asp:Label ID="msgcontent" runat="server"  CssClass = "psword_f" ></asp:Label></td>

</tr>

<tr>
         <td align="left">
        联系人&nbsp;</td>
         <td align="left" >
<asp:TextBox ID="txtcontactperson" runat="server" CssClass="input1"></asp:TextBox>       
<asp:Label ID="lblId" runat="server" Visible="False"></asp:Label></td>
</tr>
<tr>
         <td align="left">
        备注&nbsp;</td>
         <td align="left" >
<asp:TextBox ID="txtremark" runat="server" CssClass="input1"></asp:TextBox>    </td>  


</tr>

</table>
</div>

<div class="tablebt">
	 <asp:Button ID="btnAction" runat="server" CssClass="inputbt" Text="确定" OnClick="btnOK_Click"/>
     <asp:Button ID="btnCancle" runat="server" Text="取消"  CssClass="inputbt"/>
</div>    