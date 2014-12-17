<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCompanyRegulationsView.ascx.cs"
    Inherits="SEP.Performance.Views.EditCompanyRegulationsView" %>
<script language="javascript" src="../../Control/DatePicker/WdatePicker.js" type="text/javascript"
    charset="gb2312"></script>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div id="message" runat="server" class="leftitbor">
    <asp:Label ID="llbErrorMessageForCompanyRegulations" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server" Text="设置公司规章制度"></asp:Label></div>
<div class="edittable">
    <table width="100%" border="0">
        <colgroup>
            <col style="width:2%"/>
            <col style="width:15%"/>
            <col style="width:83%"/>
        </colgroup>
        <tbody>
            <tr>
                <td align="right" style="height: 24px">
                </td>
                <td align="left" style="height: 24px;">
                    类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;型&nbsp;<span class="redstar">*</span>&nbsp;
                </td>
                <td align="left" valign="middle" style="height: 24px">
                    <asp:DropDownList ID="ddlCompanyRegulationsType" runat="server" Width="200px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlCompanyRegulationsType_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 24px">
                </td>
                <td align="left" style="height: 24px;">
                    标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题&nbsp;<span class="redstar">*</span>&nbsp;
                </td>
                <td align="left" valign="middle" style="height: 24px">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input1" Width="341px"></asp:TextBox>
                    <asp:Label ID="lblCompanyRegulationsTitleError" runat="server" CssClass="psword_f"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left" valign="top" style="height: 189px;">
                    内&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;容
                </td>
                <td align="left" valign="middle" height="200">
                    <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Width="579px" Height="580px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left" valign="top">
                    附件列表
                </td>
                <td align="left" valign="middle">
                    <asp:ListBox ID="lbAppendixList" runat="server" Height="159px" Width="579px"></asp:ListBox>
                    <br />
                    <asp:Label ID="lblAppendixMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left" valign="middle">
                    <asp:Button ID="btnDeleteAppendix" runat="server" OnClick="btnDeleteAppendix_Click"
                        Text="删除" CssClass="inputbt" />&nbsp;&nbsp;
                    <asp:FileUpload ID="Upload" runat="server" Width="375px" CssClass="fileupload" onkeydown="event.returnValue=false;"
                        onpaste="return false" />&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnAddAppendix_Click" Text="增加附件"
                        CssClass="inputbt" />&nbsp;&nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnOK" runat="server" Text="确定" CssClass="inputbt" OnClick="btnOK_Click">
    </asp:Button>
    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="inputbt" OnClick="btnCancel_Click">
    </asp:Button>
</div>
