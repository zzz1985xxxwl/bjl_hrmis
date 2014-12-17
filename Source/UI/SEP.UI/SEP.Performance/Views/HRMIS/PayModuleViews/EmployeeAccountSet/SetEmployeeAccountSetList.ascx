<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetEmployeeAccountSetList.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.SetEmployeeAccountListSet" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
     <script type="text/javascript" language="javascript">
     function InportClick()
     {
         if($(".fileuploaddiv").css("display")=="none")
         {$(".fileuploaddiv").show();}
         else{$(".fileuploaddiv").hide();}
     }
     function ExportClick()
     {
         location.href="SetEmployeeAccountSetList.aspx?type=Export&txtName="+$(".txtName").val()
         +"&listPosition="+$(".listPosition").val()
         +"&listEmployeeType="+$(".listEmployeeType").val()
         +"&cbRecursionDepartment="+$(".cbRecursionDepartment").find("input[type='checkbox']").attr("checked")
         +"&listDepartment="+$(".listDepartment").val()
         +"&ddlEmployeeStatus="+$(".ddlEmployeeStatus").val();
     }
     
     </script>

<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    ����Ա������</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1 txtName" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ְλ
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listPosition" runat="server" Width="40%" CssClass="listPosition">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա������
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%" CssClass="listEmployeeType">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                ����
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%"  CssClass="listDepartment"></asp:DropDownList>
                <asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" CssClass="cbRecursionDepartment" Text="�����Ӳ���" />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա��״̬
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" CssClass="ddlEmployeeStatus" Width="40%">
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
    <input id="btnExport" type="button" value="������" class="inputbt" onclick="ExportClick();"  />
    <input id="btnInport" type="button" class="inputbt showbtnIn" onclick="InportClick();"  value="��  ��"/>
</div>
<div class="edittable fileuploaddiv" style="text-align:left;display:none;">
  <asp:FileUpload ID="fuExcel" runat="server" onkeydown="event.returnValue=false;"
onpaste="return false" CssClass="fileupload" />
<asp:Button ID="btnIn" runat="server" Text="ȷ����" CssClass="inputbt"  OnClick="btnInport_Click"/>
</div>
<div id="tbEmployeeGridView" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="grvcontractlist" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="grvcontractlist_PageIndexChanging" PageSize="20"
        OnRowDataBound="grvcontractlist_RowDataBound">
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Employee.Account.Id") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա������" HeaderStyle-Width="8%">
                <ItemTemplate>
                    <%# Eval("Employee.Account.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" HeaderStyle-Width="19%">
                <ItemTemplate>
                    <%# Eval("Employee.Account.Dept.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ְλ" HeaderStyle-Width="14%">
                <ItemTemplate>
                    <%#Eval("Employee.Account.Position.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա������" HeaderStyle-Width="14%">
                <ItemTemplate>
                    <asp:Label ID="lblEmployeeType" runat="server" Text='<%# EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("Employee.EmployeeType")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������" HeaderStyle-Width="19%">
                <ItemTemplate>
                    <%#Eval("AccountSet.AccountSetName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" Text="��������" CausesValidation="false" CommandArgument='<%# Eval("Employee.Account.Id") %>'
                        OnCommand="Update_Command" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAdjustSalaryHistory" runat="server" Text="��н��ʷ" CausesValidation="false" CommandArgument='<%# Eval("Employee.Account.Id") %>'
                        OnCommand="AdjustSalaryHistory_Command" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEmployeeSalaryHistory" runat="server" Text="��н��ʷ" CausesValidation="false" CommandArgument='<%# Eval("Employee.Account.Id") %>'
                        OnCommand="EmployeeSalaryHistory_Command" />
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
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>

</div>
