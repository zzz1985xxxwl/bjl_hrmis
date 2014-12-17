<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"
    CodeBehind="ProjectInfo.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.ProjectInfoPages.ProjectInfo" %>

<%@ Register Src="../../../Views/PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender ID="mpeInfo" runat="server" Drag="false" BackgroundCssClass="modalBackground"
                PopupControlID="pnlRule" TargetControlID="btnHiddenPostButton">
            </ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <div class="leftitbor">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <div class="leftitbor2">
                设置项目信息
            </div>
            <div class="edittable">
                <table width="100%" border="0">
                    <tr>
                        <td align="left" style="width: 10%; padding-left: 35px;">
                            项目名称
                        </td>
                        <td align="left" style="width: 90%;">
                            <asp:TextBox ID="txtProjectName" runat="server" Width="150px" class="input1"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebt">
                <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
                <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
            </div>
            <div class="nolinetablediv">
                <asp:GridView CssClass="linetable" GridLines="None" Width="100%" ID="gvProjectInfo"
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvProjectInfo_PageIndexChanging"
                    OnRowCommand="gvProjectInfo_RowCommand" OnRowDataBound="gvProjectInfo_RowDataBound">
                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                    <AlternatingRowStyle CssClass="table_g" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                                    runat="server" Text="" Style="display: none;" /></ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="项目名称">
                            <ItemTemplate>
                                <%#Eval("ProjectName")%>
                            </ItemTemplate>
                            <ItemStyle Width="75%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                                    CommandArgument='<%# Eval("PKID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="删除" OnClientClick="return confirm('确定要删除吗？')"
                                    OnCommand="btnDelete_Click" runat="server" CommandArgument='<%# Eval("PKID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                    </PagerTemplate>
                </asp:GridView>
            </div>
            <!--小界面-->
            <div id="divMPE">
                <asp:Panel ID="pnlRule" runat="server" CssClass="modalBox" Style="display: none;"
                    Width="600px">
                    <div style="white-space: nowrap; text-align: center;">
                        <div id="tbMessage" runat="server" class="leftitbor">
                            <asp:Label ID="lblDialogMessage" runat="server" CssClass="fontred"></asp:Label>
                        </div>
                        <div class="leftitbor2">
                            <asp:Label ID="lblOperation" runat="server">  
                            </asp:Label>
                            <asp:HiddenField ID="hfOperation" runat="server" />
                            <asp:HiddenField ID="hfPKID" runat="server" />
                        </div>
                        <div class="edittable">
                            <table width="100%" border="0">
                                <tr>
                                    <td align="left">
                                        项目名称&nbsp; <span class="redstar" style="padding-right: 10px">*</span>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtDialogProjectName" CssClass="input1" Style="width: 350px;"></asp:TextBox>
                                        <asp:Label ID="lblNameMessage" runat="server" CssClass="psword_f"></asp:Label>
                                        <p>
                                            格式：类型字母-项目号 + 空格 + 项目名称，项目号不可重复。如“A-S000 标准话功能块”。</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="tablebt">
                            <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" />
                            <asp:Button Text="取　消" ID="btnCancel" runat="server" CssClass="inputbt" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
