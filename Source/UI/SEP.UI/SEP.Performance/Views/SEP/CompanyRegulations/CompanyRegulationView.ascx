<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyRegulationView.ascx.cs"
    Inherits="SEP.Performance.Views.CompanyRegulationView" %>
<div class="ruleright">
    <div class="ruletitle">
        <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label></div>
    <div class="rulecon">
        <asp:Label ID="lblContent" runat="server" Text="" />
        <div id="ShowAppendix" runat="server">
            <div class="leftitbor2">
                附件下载<asp:Label ID="lblAppendixMessage" runat="server" CssClass="psword_f" Text=""></asp:Label>
            </div>
            <div class="linetablediv">
                <asp:GridView ID="gvAppendixList" runat="server" Width="100%" AutoGenerateColumns="False"
                    GridLines="None" ShowHeader="false" OnRowDataBound="gvAppendixList_RowDataBound">
                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                    <AlternatingRowStyle CssClass="table_g" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnHiddenPostButton" runat="server" Text="" Style="display: none;" />
                            </ItemTemplate>
                            <ItemStyle Height="28px" Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="FileName" HeaderText="附件列表" ItemStyle-HorizontalAlign="Left">
                            <ControlStyle Width="200px" />
                            <ItemStyle Width="60%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="下载" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <img alt="" src="../../../Pages/image/dow.gif" style="vertical-align: middle" />
                                <asp:LinkButton ID="btnDownload" runat="server" Width="70px" Text=" 下 载" CausesValidation="false"
                                    CommandArgument='<%# Eval("Directory") %>' CommandName='<%# Eval("Directory") %>'
                                    OnCommand="Download_Command" ToolTip="Download" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="list" runat="server">
        </div>
    </div>
</div>
