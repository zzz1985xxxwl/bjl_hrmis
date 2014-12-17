<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AssignHrmisAuthInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Auths.AssignHrmisAuthInfoView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc3" %>
<%@ Register Src="DepartmentTreeView.ascx" TagName="DepartmentTreeView" TagPrefix="uc1" %>
<%@ Register Src="AssignHrmisAuthView.ascx" TagName="AssignHrmisAuthView" TagPrefix="uc2" %>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeDepartment" runat="server" Drag="true" PopupDragHandleControlID="pnlDepartment"
            BackgroundCssClass="modalBackground" PopupControlID="pnlDepartment" TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <asp:Panel ID="pnlDepartment" runat="server" CssClass="modalBox" Style="display: none;"
            Width="500px">
            <div style="white-space: nowrap; text-align: center;">
                <uc1:DepartmentTreeView ID="DepartmentTreeView1" runat="server"></uc1:DepartmentTreeView>
            </div>
        </asp:Panel>
        <!--大界面-->
        <uc2:AssignHrmisAuthView ID="AssignHrmisAuthView1" runat="server"></uc2:AssignHrmisAuthView>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc3:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
