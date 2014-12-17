<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInformationMain.aspx.cs" Inherits="WebControlClient.ClientInformationMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 449px; height: 21px">
            欢迎光临HRMIS短信客户服务管理中心</div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="当前服务状态"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="grvClientInformation" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="系统标识" SortExpression="PKID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PKID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PKID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客户标识" SortExpression="HrmisId">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("HrmisId") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("HrmisId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客户描述" SortExpression="CompanyDescription">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("CompanyDescription") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CompanyDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否认证" SortExpression="IsPermitted">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("IsPermitted") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsPermitted") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblDescript" OnCommand="lblDescript_Click" CommandArgument='<%# Eval("PKID") %>'>更新客户信息
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblOpenClient" OnCommand="lblOpenClient_Click" OnClientClick= "javascript:return   confirm('您确定吗？');" CommandArgument='<%# Eval("PKID") %>'>开启服务
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblCloseClient" OnCommand="lblCloseClient_Click" OnClientClick= "javascript:return   confirm('您确定吗？');" CommandArgument='<%# Eval("PKID") %>'>关闭服务
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblManage" OnCommand="lblManage_Click" CommandArgument='<%# Eval("PKID") %>'>管理地址
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        
        </asp:GridView>
        <asp:Label ID="Label5" runat="server" Text="当前监视的客户端系统标识为"></asp:Label>
        <asp:Label ID="lblSystemId" runat="server"></asp:Label><br />
        <asp:GridView ID="grvListenAddress" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="PKID" HeaderText="系统标识" ReadOnly="True"  Visible="False" SortExpression="PKID" />
                <asp:BoundField DataField="ListenAddress" HeaderText="监听地址" ReadOnly="True" SortExpression="ListenAddress" />
                <asp:BoundField DataField="IsPermitted" HeaderText="是否允许" SortExpression="IsPermitted" />
                <asp:BoundField DataField="IsActivited" HeaderText="是否激活" ReadOnly="True" SortExpression="IsActivited" />
                <asp:BoundField DataField="LastTryActivitedTime" HeaderText="最后一次激活时间" ReadOnly="True" SortExpression="LastTryActivitedTime" />
                 <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblOpenAddress" OnCommand="lblOpenAddress_Click" OnClientClick= "javascript:return   confirm('您确定吗？');" CommandArgument='<%# Eval("PKID") %>'>允许信道
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                 <ItemTemplate>
				  		    <asp:LinkButton runat="server" ID="lblCloseAddress" OnCommand="lblCloseAddress_Click" OnClientClick= "javascript:return   confirm('您确定吗？');" CommandArgument='<%# Eval("PKID") %>'>禁止信道
				  		    </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        新增一个认证的客户<br />
        <asp:Panel ID="Panel1" runat="server" Height="31px" Width="836px">
            <asp:Label ID="Label2" runat="server" Text="Hrmis标识"></asp:Label>
            <asp:TextBox ID="txtHrmisIdForAdd" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="客户信息"></asp:Label>&nbsp;
            <asp:TextBox ID="txtCompanyDescriptionForAdd" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnAdd" runat="server" Text="确定" OnClick="btnAdd_Click" /></asp:Panel>
        <br />
        &nbsp;更新客户信息<asp:Panel ID="Panel2" runat="server" Height="61px" Width="837px">
            <asp:Label ID="Label8" runat="server" Text="系统标识"></asp:Label>&nbsp;
            <asp:TextBox ID="txtClientId" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" Text="Hrmis标识"></asp:Label>
            <asp:TextBox ID="txtHrmisIdForUpdate" runat="server" ReadOnly="True"></asp:TextBox><br />
            <asp:Label ID="Label7" runat="server" Text="客户信息"></asp:Label>&nbsp;
            <asp:TextBox ID="txtCompanyDescriptionForUpdate" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnUpdate" runat="server" Text="确定" OnClick="btnUpdate_Click" /></asp:Panel>
        <br />
    </form>
</body>
</html>
