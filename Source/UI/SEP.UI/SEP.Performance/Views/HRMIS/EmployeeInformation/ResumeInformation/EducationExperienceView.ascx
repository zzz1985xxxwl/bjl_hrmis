<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EducationExperienceView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.ResumeInformation.EducationExperienceView" %>
<div class="leftitbor2">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>  
<div class="edittable">
<table width="100%" border="0" >
    <tr>
      <td align="left" style="width: 14%" >
      ��ֹʱ��&nbsp;<span class = "redstar">*</span></td>
    <td align="left" width="50%">
    <asp:TextBox ID="txtPeriod" runat="server" CssClass="input1"></asp:TextBox>
    <asp:Label ID="msgPeriod" runat="server" CssClass = "psword_f" ></asp:Label>
         
      </td>
      </tr>

    <tr>
     <td align="left">
    ��ѵ����&nbsp;<span class = "redstar">*</span></td>
     <td align="left" >
    <asp:TextBox ID="txtSchool" runat="server" CssClass="input1"></asp:TextBox>       
    <asp:Label ID="msgSchool" runat="server" CssClass = "psword_f" ></asp:Label></td>

    </tr>

    <tr>
     <td align="left" >
    ��ѵ����</asp:Label>&nbsp;<span class = "redstar">*</span></td>
     <td align="left" >
    <asp:TextBox ID="txtContent" runat="server" CssClass="input1"></asp:TextBox>

    <asp:Label ID="msgcontent" runat="server" CssClass = "psword_f" ></asp:Label></td>
    </tr>

    <tr>
     <td align="left" >
    ��ע&nbsp;</td>
     <td align="left" >
    <asp:TextBox ID="txtremark" runat="server" CssClass="input1"></asp:TextBox>       
    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label></td>
    </tr>

</table>
</div>
<div class="tablebt">
	 <asp:Button ID="btnAction" runat="server" CssClass="inputbt" Text="ȷ��" OnClick="btnOK_Click"/>
     <asp:Button ID="btnCancle" runat="server" Text="ȡ��"  CssClass="inputbt"/>
</div>  