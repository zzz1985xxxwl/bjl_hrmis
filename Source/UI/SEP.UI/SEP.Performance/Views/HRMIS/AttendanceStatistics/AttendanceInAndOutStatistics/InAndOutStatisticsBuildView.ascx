<%@ Control Language="C#" AutoEventWireup="true" Codebehind="InAndOutStatisticsBuildView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.InAndOutStatisticsBuildView" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
<%@ Register Src="../AttendanceInAndOutStatistics/InAndOutStatisticsView.ascx" TagName="InAndOutStatisticsView"
    TagPrefix="uc1" %>
<%@ Register Src="../ReadDataInfo/ReadHistoryListView.ascx" TagName="ReadHistoryListView"
    TagPrefix="uc2" %>
<%@ Register Src="../ReadDataInfo/SetReadDataRuleView.ascx" TagName="SetReadDataRuleView"
    TagPrefix="uc3" %>
<%@ Register Src="../../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc4" %>
<link href="../../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeInAndOutStatistics1" runat="server" Drag="true"
            PopupDragHandleControlID="pnlInAndOutStatistics1" BackgroundCssClass="modalBackground"
            PopupControlID="pnlInAndOutStatistics1" TargetControlID="btnHiddenPostButton1">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton1" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPEReadHistoryListView">
            <asp:Panel ID="pnlInAndOutStatistics1" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:ReadHistoryListView ID="ReadHistoryListView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <ajaxToolKit:ModalPopupExtender ID="mpeInAndOutStatistics2" runat="server" Drag="true"
            PopupDragHandleControlID="pnlInAndOutStatistics2" BackgroundCssClass="modalBackground"
            PopupControlID="pnlInAndOutStatistics2" TargetControlID="btnHiddenPostButton2">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton2" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPESetReadDataRuleView">
            <asp:Panel ID="pnlInAndOutStatistics2" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc3:SetReadDataRuleView ID="SetReadDataRuleView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <ajaxToolKit:ModalPopupExtender ID="mpeInAndOutStatistics3" runat="server" Drag="false"
            BackgroundCssClass="modalBackground" PopupControlID="pnlInAndOutStatistics3"
            TargetControlID="btnHiddenPostButton3">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton3" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPECreateAttendanceForOperator">
            <asp:Panel ID="pnlInAndOutStatistics3" runat="server" CssClass="modalBox" Style="display: none;"
                Width="700px">
                <div style="white-space: nowrap; text-align: center;">
                    <div id="tbMessage" runat="server" class="leftitbor">
                        <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
                    </div>
                    <div class="leftitbor2">
                        读取Excel考勤数据
                    </div>
                   
                                    
<div  class="edittable">
  <table width="100%" border="0">
                                        <tr>
                                            <td width="2%" align="right">
                                            </td>
                                            <td width="20%" align="left" style="height: 36px">
                                                考勤统计时间</td>
                                            <td align="left" width="88%">
                                                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                                                    Format="yyyy-MM-dd">
                                                </ajaxToolKit:CalendarExtender>
                                                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                                                    Format="yyyy-MM-dd">
                                                </ajaxToolKit:CalendarExtender>
                                                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
                                                -- &nbsp;
                                                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="2%" align="right">
                                            </td>
                                            <td align="left" style="height: 30px;">
                                                需要进行统计的员工
                                            </td>
                                            <td align="left" style="height: 30px;">
                                                <asp:TextBox ID="txtEmployeeList" runat="server" CssClass="grayborder" Rows="3" Width="460px" Height="50px"
                                                    TextMode="MultiLine" onfocus="btnChooseMailCCClick();"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="2%" align="right">
                                            </td>
                                            <td width="20%" align="left" style="height: 36px">
                                                Excel文档路径</td>
                                            <td align="left" valign="middle" style="height: 40px">
                                                <asp:FileUpload ID="fuExcel" runat="server" Height="26px" onkeydown="event.returnValue=false;"
                                                    onpaste="return false" CssClass="fileupload"
                                                    Width="460px" />&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    <%--</table>
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                    <div class="tablebt">
                        <asp:Button ID="btnReadFromXLS" runat="server" Text="读Excel数据" CssClass="inputbtlong"
                            OnClick="btnReadFromXLS_Click" />
                        <asp:Button Text="取  消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
                    </div>
                </div>
            </asp:Panel>
        </div>
        <!--小界面-->
        <ajaxToolKit:ModalPopupExtender ID="mpeChoseEmployeeView" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlChooseEmployee" TargetControlID="btnChooseEmployeeHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnChooseEmployeeHidden" runat="Server" Style="display: none" />
        <div id="divMPEChooseEmployee" runat="server">
            <asp:Panel ID="pnlChooseEmployee" runat="server" CssClass="modalBox" Style="display: none;"
                Width="700px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc4:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <!--大界面-->
        <uc1:InAndOutStatisticsView ID="InAndOutStatisticsView1" runat="server"></uc1:InAndOutStatisticsView>
        <!--Loading界面 -->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing ID="Progressing1" runat="server"></uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnReadFromXLS" />
    </Triggers>
</asp:UpdatePanel>

<script type="text/javascript">
function btnChooseMailCCClick()
{
$("#cphCenter_InAndOutStatisticsBuildView1_btnChooseEmployeeHidden").trigger("click");
} 
</script>

