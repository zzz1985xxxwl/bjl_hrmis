<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentInfoView.ascx.cs" Inherits="SEP.Performance.Views.Departments.DepartmentInfoView" %>
<%@ Register Src="DepartmentView.ascx" TagName="DepartmentView" TagPrefix="uc3" %>
<%@ Register Src="DepartmentListView.ascx" TagName="DepartmentListView" TagPrefix="uc4" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeDepartment" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlDepartment" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlDepartment" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
            <div id="divMPEDepartment" runat="server">
	        <asp:Panel ID="pnlDepartment" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                    <uc3:DepartmentView ID="DepartmentView1" runat="server" />
		        </div>
	        </asp:Panel>
	        </div>
        <!--大界面-->
        <uc4:DepartmentListView ID="DepartmentListView1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing id="Progressing1" runat="server">
                </uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>        
    </ContentTemplate>
    </asp:UpdatePanel>