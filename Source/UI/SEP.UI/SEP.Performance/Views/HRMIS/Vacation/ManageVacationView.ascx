<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageVacationView.ascx.cs" Inherits="SEP.Performance.ManageVacationView" %>


<asp:UpdatePanel ID="UpdatePanel2" runat="server">    
    <ContentTemplate>
    <div class="edittable">
  <table width="100%" border="0" style=" text-align:left">
    <tr>
      <td style="width: 14%;">员工姓名</td>
      <td style="width: 86%;"><asp:TextBox ID="txtName" runat="server" BackColor="Control" ReadOnly="True" class="input1" size="28"></asp:TextBox></td>
	</tr>
	
	<tr>
       <td>年假起始日&nbsp;<span class = "redstar">*</span>&nbsp;</td>
      <td>
          <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVacationStartDate" Format="yyyy-MM-dd">
          </ajaxToolKit:CalendarExtender>
      <asp:TextBox ID="txtVacationStartDate" runat="server" OnTextChanged="txtVacationStartDate_TextChanged"  class="input1" size="28"></asp:TextBox>
      <asp:Label ID="lblValidateStartDay" runat="server" CssClass="psword_f"></asp:Label></td>
	</tr>
	
	<tr>
       <td>年假到期日</td>
      <td>
        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtVacationEndDate" Format="yyyy-MM-dd">
          </ajaxToolKit:CalendarExtender>
          <asp:TextBox ID="txtVacationEndDate" runat="server"    class="input1" size="28"></asp:TextBox></td>
	</tr>

	<tr>
      <td>年假总天数&nbsp;<span class = "redstar">*</span>&nbsp;</td>
      <td><asp:TextBox ID="txtVacationDayNum" runat="server"  OnTextChanged="txtVacationDayNum_TextChanged" class="input1" size="28"></asp:TextBox>
      <asp:Label ID="lblValidateDayNum" runat="server" CssClass="psword_f" ></asp:Label></td>
	</tr>
	
	<tr>
      <td>已用天数&nbsp;&nbsp;<span class = "redstar">*</span>&nbsp;</td>
      <td><asp:TextBox ID="txtUsedDayNum" runat="server"  OnTextChanged="txtUsedDayNum_TextChanged"  class="input1" size="28"></asp:TextBox>
      <asp:Label ID="lblValidateUsedDayNum" runat="server" CssClass="psword_f"></asp:Label></td>
	</tr>
	
	<tr>
      <td>剩余天数</td>
      <td> <asp:TextBox ID="txtSurplusDayNum" runat="server" BackColor="Control" ReadOnly="True" class="input1" size="28"></asp:TextBox></td>
	</tr>
	
	<tr>
      <td>备注</td>
      <td>
      <asp:TextBox ID="txtRemark" runat="server" Height="100px" Width="50%" TextMode="MultiLine" CssClass="grayborder"></asp:TextBox></td>
	</tr>
	
     <tr runat="server" id="AdjustVisible">
      <td>剩余调休</td>
      <td> <asp:TextBox ID="txtAdjustRest" runat="server" BackColor="Control" ReadOnly="True" class="input1" size="28"></asp:TextBox>&nbsp;小时</td>
	</tr>
	
    </table>
   </div>
    <asp:Label ID="lblID" runat="server"  Visible="False" Enabled="False"></asp:Label>
        <asp:Label ID="lblEmployeeID" runat="server"  Visible="False" Enabled="False"></asp:Label>
    </ContentTemplate>
     </asp:UpdatePanel>


