<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetEmployeeAccountSet.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.SetEmployeeAccountSet" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="divResultMessage" class="leftitbor" runat="server">
            <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
        </div>
        <div class="leftitbor2">
            <asp:Label ID="lblOperation" runat="server">设置员工工资套</asp:Label>
            &nbsp;
            <asp:HiddenField ID="Operation" runat="server" />
            <asp:HiddenField ID="hfDescription" runat="server" />
        </div>
<div  class="edittable">
  <table width="100%" border="0">
                            <tr>
                                <td width="2%" align="right">
                                </td>
                                <td align="right" style="width: 8%;">
                                    员工姓名</td>
                                <td align="left" style="width: 40%;">
                                    <asp:Label ID="lbName" runat="server"></asp:Label></td>
                                <td align="right" width="8%">
                                    员工类型</td>
                                <td align="left" width="40%">
                                    <asp:Label ID="lbType" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="right">
                                    部门</td>
                                <td align="left">
                                    <asp:Label ID="lbDepartment" runat="server"></asp:Label></td>
                                <td align="right">
                                    职位</td>
                                <td align="left">
                                    <asp:Label ID="lbPosition" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="right">
                                    帐套</td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAccountSet" runat="server" Width="60%" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlAccountSet_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td align="right">
                                </td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr id="trAccountSet" runat="server"  class="green2">
                                <td colspan="5">
                                    <table width="100%" id="tbAccountSet" runat="server" border="0">
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="right">
                                    备注
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="tbDescription" runat="server" Width="72%" class="input1"></asp:TextBox></td>
                            </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
            <asp:Button Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
