<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSkillInfoView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.SkillInfomation.EmployeeSkillInfoView" %>
<%@ Register Src="EmployeeSkillListView.ascx" TagName="EmployeeSkillListView" TagPrefix="uc1" %>
<%@ Register Src="EmployeeSkillView.ascx" TagName="EmployeeSkillView" TagPrefix="uc2" %>

<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
       <ContentTemplate>
              <%--档案成员的小界面--%>
                   <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender1" runat="server" Drag="true" PopupDragHandleControlID="pnlAttendance" BackgroundCssClass="modalBackground" PopupControlID="pnlAttendance" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    <div id="divMPE">
                        <asp:Panel ID="pnlAttendance" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
				            <div style="white-space: nowrap; text-align: center;">
                                <uc2:EmployeeSkillView Id="EmployeeSkillView1" runat="server" />

                            </div>
			            </asp:Panel>
			        </div>
           <uc1:EmployeeSkillListView ID="EmployeeSkillListView1" runat="server" />
			         <%--主界面--%>

       </ContentTemplate>
</asp:UpdatePanel>



