<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeReimburseView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.EmployeeReimburseView" %>
<%@ Register Src="ReimburseView.ascx" TagName="ReimburseView" TagPrefix="uc1" %>
<%@ Register Src="ReimburseItemView.ascx" TagName="ReimburseItemView" TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc3" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
       <ContentTemplate>
                <%--家庭成员的小界面--%>
                   <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlReimburseItem" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    <div id="divMPEReimburse" runat="server">
                    <asp:Panel ID="pnlReimburseItem" runat="server" CssClass="modalBox" Style="display: none;" Width="650px">
				        <div style="white-space: nowrap; text-align: center;">
                            <uc2:ReimburseItemView id="ReimburseItemView1" runat="server">
                            </uc2:ReimburseItemView>
                        </div>
			        </asp:Panel>
			        </div>
			         <%--主界面--%>
                        <uc1:ReimburseView id="ReimburseView1" runat="server">
                        </uc1:ReimburseView>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc3:Progressing id="Progressing1" runat="server">
                </uc3:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
       </ContentTemplate>

</asp:UpdatePanel>
