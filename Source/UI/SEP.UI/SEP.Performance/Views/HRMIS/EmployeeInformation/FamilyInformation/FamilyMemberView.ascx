<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FamilyMemberView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.FamilyInformation.FamilyMemberView" %>

<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>              
<div class="edittable">
      <table width="100%" border="0" style="text-align:left">
        <tr>
          <td style="width: 14%;">
              ����&nbsp;<span class = "redstar">*</span></td>
          <td style="width: 86%;">
          <asp:TextBox ID="txtName" Width="60%" runat="server" size="28" CssClass="input1"></asp:TextBox>
          <asp:Label ID="lblName" runat="server" CssClass = "psword_f"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
              ��ν&nbsp;<span class = "redstar">*</span></td>
          <td>
              <asp:TextBox ID="txtRelationShip" Width="60%" runat="server" size = "28" CssClass="input1"></asp:TextBox>
              <asp:Label ID="lblRelationShip" runat="server"  CssClass = "psword_f"></asp:Label></td>
        </tr>
        <tr style="display:none">
          <td>
              ����&nbsp;<span class = "redstar">*</span></td>
          <td>
              <asp:TextBox ID="txtAge" CssClass ="input1" Width="60%" size="28" runat="server" ReadOnly="true" ></asp:TextBox>
              <asp:Label ID="lblAge" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
        <tr>
          <td>
              ��������&nbsp;</td>
          <td>
              <asp:TextBox ID="txtBirthday" CssClass ="input1" Width="60%" size="28" runat="server" ></asp:TextBox>
              <asp:Label ID="lblBirthday" runat="server" CssClass = "psword_f"></asp:Label>
              <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBirthday" Format="yyyy-MM-dd">
              </ajaxToolKit:CalendarExtender>
            
          </td>
        </tr>
        <tr>
          <td>��˾</td>
          <td>
          <asp:TextBox ID="txtCompany" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
              <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
          <td>��ע</td>
          <td>
                <asp:TextBox ID="txtRemark" runat="server" Width="61%" Height="185px" CssClass="grayborder" TextMode="MultiLine"></asp:TextBox>
          </td>
        </tr>
</table>
</div>
<div class="tablebt">
	 <asp:Button ID="btnOK" runat="server" CssClass="inputbt" Text="ȷ��" OnClick="btnOK_Click"/>
     <asp:Button ID="btnCancel" runat="server" Text="ȡ��"  CssClass="inputbt" OnClick="btnCancel_Click"/>
</div>
