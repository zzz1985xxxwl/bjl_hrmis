<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeListView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.EmployeeListView" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    <div style="float: left;">
        <span>��ѯԱ��</span></div>
    <div style="float: right;">
        <asp:LinkButton runat="server" ForeColor="black" ID="lbListPattern" Text="�б�" OnClick="lbListPattern_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ForeColor="black" Style="margin-right: 8px;" ID="lbCardPattern"
            Text="��Ƭ" OnClick="lbCardPattern_Click"></asp:LinkButton>
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
                Ա������
            </td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ְλ
            </td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                ְϵ
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
                Ա������
            </td>
            <td align="left">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left">
                ����
            </td>
            <td align="left">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList>
                <asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="�����Ӳ���" />
            </td>
            <td align="left">
                ˾��
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
                Ա��״̬
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                    <asp:ListItem Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="��ְ" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="��ְ" Value="1"></asp:ListItem>
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
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <div id="tdExport" runat="server" style="display: inline;">
        <input id="btnExportClient" type="button" value="������" onclick="document.getElementById('cphCenter_btnExportServer').click();"
            class="inputbt" />
    </div>
</div>
