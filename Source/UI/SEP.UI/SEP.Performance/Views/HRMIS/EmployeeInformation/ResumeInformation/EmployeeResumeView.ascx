<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeResumeView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.ResumeInformation.EmployeeResumeView" %>
<%@ Register Src="EmployeeResumeBasicView.ascx" TagName="EmployeeResumeBasicView"
    TagPrefix="uc4" %>
<%@ Register Src="EducationExperienceView.ascx" TagName="EducationExperienceView"
    TagPrefix="uc2" %>
<%@ Register Src="WorkExperienceView.ascx" TagName="WorkExperienceView" TagPrefix="uc3" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                     <%--主界面--%>
			         <uc4:EmployeeResumeBasicView id="EmployeeResumeBasicView1" runat="server">
                </uc4:EmployeeResumeBasicView> 
                    <%--教育经历的小界面--%>
                   <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender1" runat="server" Drag="true" PopupDragHandleControlID="pnlAttendance" BackgroundCssClass="modalBackground" PopupControlID="pnlAttendance" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    <div id="divMPE">
                            <asp:Panel ID="pnlAttendance" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
				                <div style="white-space: nowrap; text-align: center;">
				                     <uc2:EducationExperienceView ID="EducationExperienceView1" runat="server" />
                                </div>
			                </asp:Panel>
			        </div>
                    <%--工作经历的小界面--%>           
                    <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender2" runat="server" Drag="true" PopupDragHandleControlID="pnlAttendance1" BackgroundCssClass="modalBackground" PopupControlID="pnlAttendance1" 
                    TargetControlID="btnHidden1"></ajaxToolKit:ModalPopupExtender>
               
                     <asp:Button ID="btnHidden1" runat="Server" Style="display: none" />
                     <div id="divMPE1">
       			        <asp:Panel ID="pnlAttendance1" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
				        <div style="white-space: nowrap; text-align: center;">
				            <uc3:WorkExperienceView Id="WorkExperienceView1" runat="server" />
                        </div>
			        </asp:Panel>
			        </div>
            </ContentTemplate>
   
</asp:UpdatePanel>


