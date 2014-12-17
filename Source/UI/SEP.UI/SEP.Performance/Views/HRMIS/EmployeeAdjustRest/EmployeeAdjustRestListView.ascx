<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdjustRestListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.EmployeeAdjustRest.EmployeeAdjustRestListView" %>
<div class="leftitbor" runat="server" id="divResult">
    <asp:Label ID="lblResult" runat="server" Text="" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
</div>
<div class="leftitbor2">
    ��ѯԱ������
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ְλ
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                Ա������
            </td>
            <td align="left">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left">
                ����
            </td>
            <td align="left">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList><asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="�����Ӳ���" />
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                Ա��״̬
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnSave" runat="server" Text="������" OnClick="btnSave_Click" CssClass="inputbt" />
    <asp:Button ID="btnExport" runat="server" Text="������" OnClick="btnExport_Click" CssClass="inputbt" />
</div>
<div id="Result" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvEmployeeAdjustRest" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" PageSize="15"
        OnPageIndexChanging="gvEmployeeAdjustRest_PageIndexChanging" 
        OnRowDataBound="gvEmployeeAdjustRest_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("AdjustRestID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                    <asp:HiddenField ID="hfAccountID" runat="server" Value='<%# Eval("Employee.Account.Id") %>'/>
                    <asp:HiddenField ID="hfAdjustRestID" runat="server" Value='<%# Eval("AdjustRestID") %>'/>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա������">
                <ItemTemplate>
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Name")%></span>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="������Ч��">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("AdjustYear.Year")%></span>
                </ItemTemplate>
                    <ItemStyle Width="8%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Ա������">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%#EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("Employee.EmployeeType"))%></span>
                </ItemTemplate>
                    <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate> 
                   <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Dept.Name")%></span>
                </ItemTemplate>
                    <ItemStyle Width="11%"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ְλ">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Position.Name")%></span>
                </ItemTemplate>
                    <ItemStyle Width="11%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ְʱ��">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%#string.Format("{0:yyyy-MM-dd}", Eval("Employee.EmployeeDetails.Work.ComeDate"))%></span>
                </ItemTemplate>
                    <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʣ�����">
                <ItemTemplate>
                    <asp:TextBox ID="txtSurplusHours" Width="83%" runat="server" Text='<%# Eval("SurplusHours")%>' CssClass="input1"></asp:TextBox>
                    <asp:HiddenField ID="hfOldSurplusHours" runat="server" Value='<%# Eval("SurplusHours")%>'></asp:HiddenField>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�޸�ԭ��">
                <ItemTemplate>
                    <asp:TextBox ID="txtReason" Width="95%" runat="server" CssClass="input1"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="28%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
           <asp:LinkButton ID="lbDetail" runat="server" Text="�鿴����" CommandArgument='<%# Eval("Employee.Account.Id") %>' OnCommand="lbDetail_Click"/>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
        		<div class="pages">
		    ��&nbsp;<%# ((GridView)Container.NamingContainer).PageCount %>&nbsp;ҳ&nbsp;
		    ��&nbsp;<%# ((GridView)Container.NamingContainer).PageIndex+1 %>&nbsp;ҳ&nbsp;
		    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CssClass="pagefirstbutton" CommandArgument="First" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ��ҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CssClass="pagelastbutton" CommandArgument="Last" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ĩҳ</asp:LinkButton>
		    ת��&nbsp;<asp:TextBox ID="txtGoPage" runat="server" CssClass="input1" Width="20px"></asp:TextBox>&nbsp;ҳ
		    <asp:LinkButton ID="LinkButtonGoPage" runat="server" CssClass="pagegobutton" OnClick="LinkButtonGoPage_Click" OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">GO</asp:LinkButton>
		</div>       
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>"
                    OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>"
                    OnClientClick="return confirm('��ҳ�󣬱�ҳ�޸���Ϣ����ʧ���Ƿ�Ҫ������');">
		    ��һҳ</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>
</div>
