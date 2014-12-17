<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentTreeView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Auths.DepartmentTreeView" %>
<script language="javascript " type="text/javascript" src="../../Inc/GridViewTree.js"> 
</script>
<div width="480px">
    <div class="leftitbor2">
        设置权限范围</div>
    <asp:HiddenField ID="hfAuthID" runat="server" />
    <asp:HiddenField ID="hfBackAccountsID" runat="server" />
    <div id="tbDepartment" runat="server" class="linetablediv">
        <div class="scrollbarlist2">
            <asp:GridView GridLines="None" Width="96%" ID="gvDepartment" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="gvDepartment_RowDataBound">
                <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                <RowStyle Height="28px" CssClass="GridViewRowLink" />
                <AlternatingRowStyle CssClass="table_g" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="btnHiddenPostButton" Value='<%# Eval("DepartmentID") %>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部 门">
                        <ItemTemplate>
                            <img id="imgTree" runat="server" />
                            <input id="cbSelected" type="checkbox" runat="server" checked='<%#Eval("IfSelected")%>' />
                            <%#Eval("DepartmentName")%>
                            <asp:HiddenField ID="hfIndexFromRoot" Value='<%#Eval("IndexFromRoot")%>' runat="server" />
                            <asp:HiddenField ID="hfHasChild" Value='<%#Eval("HasChild")%>' runat="server" />
                            <asp:HiddenField ID="hfHasMemeber" Value='<%#Eval("HasMemeber")%>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门经理">
                        <ItemTemplate>
                            <%#Eval("DepartmentLeader.Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="tablebt">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="确　定" CssClass="inputbt" />
    </div>
</div>
