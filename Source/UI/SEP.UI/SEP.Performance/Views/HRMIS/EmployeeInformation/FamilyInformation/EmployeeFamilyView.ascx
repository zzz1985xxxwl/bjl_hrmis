<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeFamilyView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.FamilyInformation.EmployeeFamilyView" %>
<%@ Register Src="FamilyBasicView.ascx" TagName="FamilyBasicView" TagPrefix="uc1" %>
<%@ Register Src="FamilyMemberView.ascx" TagName="FamilyMemberView" TagPrefix="uc3" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
       <ContentTemplate>
                <%--家庭成员的小界面--%>
                   <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender1" runat="server" Drag="false" BackgroundCssClass="modalBackground" PopupControlID="pnlAttendance" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    <div id="divMPE">
                        <asp:Panel ID="pnlAttendance" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
				            <div style="white-space: nowrap; text-align: center;">
				                <uc3:FamilyMemberView Id="FamilyMemberView1" runat="server" />
                            </div>
			            </asp:Panel>
			        </div>
			         <%--主界面--%>
			         <uc1:FamilyBasicView ID="FamilyBasicView1" runat="server" />
       </ContentTemplate>
</asp:UpdatePanel>
