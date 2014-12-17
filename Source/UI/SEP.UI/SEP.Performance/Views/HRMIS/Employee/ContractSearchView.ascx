<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ContractSearchView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.ContractSearchView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="tbNoDataMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    ��ѯԱ����ͬ</div>
<%--<div  class="linetabledivbg"> 
 <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="8%" align="left">
                Ա������</td>
            <td width="20%" align="left">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox></td>
            <td width="12%" align="left">
                ��ͬ��ʼʱ��</td>
            <td width="48%" colspan="2" align="left">
                <asp:TextBox ID="txtStartFrom" runat="server" CssClass="input1"></asp:TextBox>&nbsp;--&nbsp;<asp:TextBox
                    ID="txtStartTo" runat="server" CssClass="input1"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="8%" align="left">
                ��ͬ����</td>
            <td width="20%" align="left">
                <asp:DropDownList ID="listContractType" runat="server" Width="162px">
                </asp:DropDownList></td>
            <td width="12%" align="left">
                ��ͬ����ʱ��</td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtEndFrom" runat="server" CssClass="input1"></asp:TextBox>&nbsp;--&nbsp;<asp:TextBox
                    ID="txtEndTo" runat="server" CssClass="input1"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtEndTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
            </td>
        </tr>
                        <tr>
            <td width="2%" align="right">
            </td>
            <td width="8%" align="left">
                Ա��״̬</td>
            <td width="20%" align="left">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="162px">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="1"></asp:ListItem>
                </asp:DropDownList></td>
            <td width="12%" align="left"></td>
            <td align="left" colspan="2">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <div id="tdExport" runat="server" style=" display:inline;">
        <input id="btnExportClient" type="button" value="������" onclick="document.getElementById('cphCenter_btnExportServer').click();"
            class="inputbt" /></div>
</div>
<div id="tbSearch" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="grvcontract" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="grvcontract_PageIndexChanging" OnRowDataBound="grvcontract_RowDataBound">
        <HeaderStyle Height="28px" HorizontalAlign="Center" CssClass="headerstyleblue" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="���" DataField="ContractID" HeaderStyle-Width="5%" />
            <asp:TemplateField HeaderText="Ա�����" HeaderStyle-Width="0px" Visible="false">
                <ItemTemplate>
                    <%# Eval("EmployeeID")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Ա������" DataField="EmployeeName" HeaderStyle-Width="8%" />
              <asp:BoundField HeaderText="������˾" DataField="CompanyName" HeaderStyle-Width="8%" />
            <asp:TemplateField HeaderText="��ͬ����" HeaderStyle-Width="8%">
                <ItemTemplate>
                    <%# Eval("ContractType.ContractTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StartDate" HeaderText="��ͬ��ʼʱ��" DataFormatString="{0:yyyy/MM/dd}"
                HtmlEncode="false" HeaderStyle-Width="10%" />
<%--            <asp:BoundField DataField="EndDate" HeaderText="��ͬ����ʱ��" DataFormatString="{0:yyyy/MM/dd}"
                HtmlEncode="false" HeaderStyle-Width="10%" />--%>
                  <asp:TemplateField HeaderText="��ͬ����ʱ��" HeaderStyle-Width="10%" >
                <ItemTemplate>
                <%#Eval("EndDate", "{0:yyyy-MM-dd}").Equals("2999-12-31") ? "" : Eval("EndDate", "{0:yyyy-MM-dd}")%>
                </ItemTemplate> 
            </asp:TemplateField>      
            <asp:BoundField HeaderText="��ע" DataField="Remark" HeaderStyle-Width="30%" />
            <asp:TemplateField HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDownLoad" runat="server" Text="��ͬ����" CausesValidation="false"
                        CommandArgument='<%# Eval("ContractID") %>' OnCommand="DownLoad_Command" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" Text="�޸�" CausesValidation="false" CommandArgument='<%# Eval("EmployeeID")+"&" +Eval("ContractID") %>'
                        OnCommand="Update_Command" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="ɾ��" CausesValidation="false"
                        CommandArgument='<%# Eval("EmployeeID")+"&" +Eval("ContractID") %>' OnCommand="Delete_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <SelectedRowStyle BackColor="#F7F3FF" />
       <PagerTemplate>
 <%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>--%>
     
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />    </PagerTemplate>       
    </asp:GridView>

</div>
