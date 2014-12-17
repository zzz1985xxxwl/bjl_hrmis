<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeListView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.EmployeeListView" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    <div style="float: left;">
        <span>查询员工</span></div>
    <div style="float: right;">
        <asp:LinkButton runat="server" ForeColor="black" ID="lbListPattern" Text="列表" OnClick="lbListPattern_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ForeColor="black" Style="margin-right: 8px;" ID="lbCardPattern"
            Text="卡片" OnClick="lbCardPattern_Click"></asp:LinkButton>
    </div>
    <div style="clear: both;">
    </div>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                职位
            </td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                职系
            </td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="ddGrades" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                员工类型
            </td>
            <td align="left">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left">
                部门
            </td>
            <td align="left">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList>
                <asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="包括子部门" />
            </td>
            <td align="left">
                司龄
            </td>
            <td align="left">
                <asp:TextBox ID="txtCompanyAgeFrom" runat="server" CssClass="input1" Width="18%"></asp:TextBox>---<asp:TextBox
                    ID="txtCompanyAgeTo" runat="server" CssClass="input1" Width="18%"></asp:TextBox>
                <asp:Label ID="lblCompanyAgeError" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                员工状态
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                    <asp:ListItem Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="在职" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="离职" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <div id="tdExport" runat="server" style="display: inline;">
        <input id="btnExportClient" type="button" value="导　出" onclick="document.getElementById('cphCenter_btnExportServer').click();"
            class="inputbt" />
    </div>
</div>
