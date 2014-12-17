<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReadHistoryListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.ReadDataInfo.ReadHistoryListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_ImportResult" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    ��ȡAccess��������
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td style="width: 25%;">
                ��ȡ���ڿ�ʼʱ��
            </td>
            <td style="width: 30%;">
                <asp:TextBox ID="txtDay1" runat="server" CssClass="input1" Width="90%"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDay1"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
            </td>
            <td style="width: 15%;">
                <asp:DropDownList ID="listHour1" runat="server">
                </asp:DropDownList>
                ʱ
            </td>
            <td style="width: 15%;">
                <asp:DropDownList ID="listMinutes1" runat="server">
                </asp:DropDownList>
                ��
            </td>
            <td style="width: 15%;">
                <asp:DropDownList ID="listSecond1" runat="server">
                </asp:DropDownList>
                ��
            </td>
        </tr>
        <tr>
            <td>
                ��ȡ���ڽ���ʱ��
            </td>
            <td>
                <asp:TextBox ID="txtDay2" runat="server" CssClass="input1" Width="90%"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDay2"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
            </td>
            <td>
                <asp:DropDownList ID="listHour2" runat="server">
                </asp:DropDownList>
                ʱ
            </td>
            <td>
                <asp:DropDownList ID="listMinutes2" runat="server">
                </asp:DropDownList>
                ��
            </td>
            <td>
                <asp:DropDownList ID="listSecond2" runat="server">
                </asp:DropDownList>
                ��
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnRead" runat="server" Text="��Access����" CssClass="inputbtlong" OnClick="btnRead_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="ȡ  ��" CssClass="inputbt" OnClick="btnCancel_Click" />
</div>
<div id="tbReadHistory" runat="server" class="linetable">
    <asp:GridView GridLines="None" Width="100%" ID="gvReadHistory" PageSize="8" runat="server"
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvLeaveRequestType_PageIndexChanging">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ȡʱ��">
                <ItemTemplate>
                    <%#Eval("ReadTime")%>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ȡ���">
                <ItemTemplate>
                    <asp:Label ID="lblReadResult" runat="server" Text='<%# Eval("ReadResult") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="24%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--                        <div class="pages">
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                        </div>--%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
