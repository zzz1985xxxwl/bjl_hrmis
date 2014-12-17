<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetailView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Employees.EmployeeDetailView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $(".positionsearch").autocomplete("../../GoogleDown.ashx?type=Position", { mouseovershow: false });
    })
</script>
<div id="divResultMessage" runat="server" class="leftitbor">
    <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label></div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">新增员工</asp:Label>
    &nbsp;
    <asp:HiddenField ID="hfOperation" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="right" style="width: 3%">
            </td>
            <td align="left" style="width: 8%;">
                工号
            </td>
            <td align="left" colspan="2">
                <asp:TextBox ID="tbID" runat="server" Width="60%" Enabled="False" CssClass="input1"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                登录名&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" style="width: 40%">
                <asp:TextBox ID="tbLoginName" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblLoginNameMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                姓名&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" colspan="2">
                <asp:TextBox ID="tbName" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lbNameMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td align="left" style="width: 8%">
                手机
            </td>
            <td align="left" width="40%">
                <asp:TextBox ID="tbPhone" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                部门
            </td>
            <td align="left" colspan="2">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="61%">
                </asp:DropDownList>
                <asp:Label ID="lbDepartment" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td align="left" style="width: 8%">
                职位&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" width="40%">
                <asp:TextBox ID="txtPosition" runat="server" Width="60%" CssClass="positionsearch"></asp:TextBox>
                <asp:Label ID="lbPosition" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                Email&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" colspan="2">
                <asp:TextBox ID="tbEmail" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblEmailMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td align="left" style="width: 8%">
                Email2
            </td>
            <td align="left" width="40%">
                <asp:TextBox ID="tbEmail2" runat="server" Width="60%" CssClass="input1"></asp:TextBox>&nbsp;
                <asp:Label ID="lblEmailMsg2" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                职系&nbsp;
            </td>
            <td align="left" colspan="2">
                <asp:DropDownList ID="ddGrades"  Width="60%" runat="server">
                </asp:DropDownList>
            </td>
            <td align="right" style="width: 8%;">
                有效性&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" width="40%">
                <asp:RadioButtonList ID="rbValidate" runat="server" RepeatDirection="Horizontal"
                    Width="60%">
                    <asp:ListItem>无效</asp:ListItem>
                    <asp:ListItem>有效</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                子系统
            </td>
            <td align="left" colspan="2">
                <asp:CheckBox ID="cbHRMIS" runat="server" Text="HRMIS" />&nbsp;&nbsp;
                <asp:CheckBox ID="cbCRM" runat="server" Text="CRM" />&nbsp; &nbsp;
                <asp:CheckBox ID="cbMYCMMI" runat="server" Text="MYCMMI" />&nbsp; &nbsp;
                <asp:CheckBox ID="cbEShopping" runat="server" Text="ESHOPPING" />
            </td>
            <td align="right" style="width: 8%;">
            </td>
            <td align="left" width="40%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>
