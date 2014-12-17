<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"
    AutoEventWireup="true" Codebehind="RestoreData.aspx.cs" Inherits="AJAXEnabledWebApplication1.RestoreData" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="leftitbor" id="Message" runat="server">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
                <div class="leftitbor2">
                    数据导入</div>
                    <div  class="edittable">
                    <table width="100%">
                        <tr align="left">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="请将主系统的数据文件上传"></asp:Label></td>
                            <td colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileupload" />
                                <asp:Button ID="btnUpload" runat="server"  CssClass="inputbt" OnClick="btnUpload_Click" Text="上传" /></td>
                        </tr>
                        <tr align="left">
                            <td>
                                <asp:Label ID="lblRuleName" runat="server" Text="规则名字："></asp:Label>
                                <asp:Label ID="lblRuleNameValue" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblParameter" runat="server" Text="时间参数："></asp:Label>
                                <asp:Label ID="lblParameterValue" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnRuleToString" runat="server" CssClass="inputbt"  OnClick="btnRuleToString_Click" Text="规则详情" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <asp:Button ID="btnRestore" runat="server"  CssClass="inputbt" Text="开始导入" OnClick="btnRestore_Click" />
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label7" runat="server" Text="运行状态："></asp:Label><asp:Label ID="lblRunningStatus"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <td width="20%">
                                <asp:Label ID="Label8" runat="server" Text="运行详情："></asp:Label>
                            </td>
                            <td colspan="2" width="80%">
                                <asp:TextBox ID="txtRunningDetails" runat="server" Height="200px"  CssClass="grayborder" Width="100%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">
        </asp:Timer>
    </div>
</asp:Content>
