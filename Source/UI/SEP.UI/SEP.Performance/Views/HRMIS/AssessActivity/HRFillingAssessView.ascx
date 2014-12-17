<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HRFillingAssessView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.HRFillingAssessView" %>
<div class="leftitbor">
    <span class="font14b">���� </span><span class="fontred">
        <%Response.Write(AssessActivitys.Count.ToString()); %>
    </span><span class="font14b">����Ч���˴���д</span>
</div>
<div id="tbAssess" runat="server">
    <div class="leftitbor2">
        ��������Դ����д��Ч����
    </div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvHRFillingAssess" runat="server"
            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvHRFillingAssess_PageIndexChanging"
            OnRowCommand="gvHRFillingAssess_RowCommand" OnRowDataBound="gvHRFillingAssess_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��Ч���˶���">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��  ��">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Dept.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��Ч��������">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnFillAssess" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'
                            CommandName="FillAssess" CausesValidation="false" Text="��д��Ч����" OnCommand="btnFillAssess_Command" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle Width="19%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                </div>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
