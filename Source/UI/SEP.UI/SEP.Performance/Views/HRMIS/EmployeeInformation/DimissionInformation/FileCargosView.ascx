<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileCargosView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.DimissionInformation.FileCargosView" %>

<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>              
<div class="edittable">
    <table width="100%" border="0" style=" text-align:left">
        <tr>
          <td style="width: 14%;">资料类型</td>
          <td style="width: 86%;">
            <asp:DropDownList ID="ddFileCargoType" runat="server" Width="83.5%"></asp:DropDownList>
              <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label></td>
	   </tr>
	    <tr>
	    <td>备 注</td>
        <td>
            <asp:TextBox ID="txtRemark" runat="server" Height="185px" TextMode="MultiLine" Width="82%" CssClass="input1"></asp:TextBox>
        </td>
	</tr>
     </table>
</div>
<div class="tablebt">
	 <asp:Button ID="btnOK" runat="server" CssClass="inputbt" Text="确定" OnClick="btnOK_Click"/>
     <asp:Button ID="btnCancel" runat="server" Text="取消"  CssClass="inputbt" OnClick="btnCancel_Click"/>
</div>     