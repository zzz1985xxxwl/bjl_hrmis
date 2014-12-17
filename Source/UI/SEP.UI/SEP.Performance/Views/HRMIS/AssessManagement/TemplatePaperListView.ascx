<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TemplatePaperListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessManagement.TemplatePaperListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
     <script type="text/javascript" language="javascript">
     function InportClick()
     {
         if($(".fileuploaddiv").css("display")=="none")
         {$(".fileuploaddiv").show();}
         else{$(".fileuploaddiv").hide();}
     }
     
     </script>

<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div>
<div class="leftitbor2">
    设置绩效考核表</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                名称</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtPaperName" runat="server" CssClass="input1" Width="320px" />
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="Button1" runat="server" Text="查  询" OnClick="btnSearch_Click" class="inputbt" />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新  增" class="inputbt" />
    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="导  出" class="inputbt" />
      <input id="btnInport" type="button" class="inputbt showbtnIn" onclick="InportClick();"  value="导  入"/>
</div>
<div class="edittable fileuploaddiv" style="text-align:left;display:none;">
  <asp:FileUpload ID="fuExcel" runat="server" onkeydown="event.returnValue=false;"
onpaste="return false" CssClass="fileupload" />
<asp:Button ID="btnIn" runat="server" Text="确　定" CssClass="inputbt" OnClick="btnInport_Click" />
</div>
<div id="listpaper" runat="server">
    <div class="linetablediv" id="tbPaperList" runat="server">
        <asp:GridView GridLines="None" Width="100%" ID="grvPaperlist" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="grvPaperlist_PageIndexChanging" BorderStyle="None"
            OnRowCommand="grvPaperlist_RowCommand" OnRowDataBound="gvPaperlist_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessTemplatePaperID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <%#Eval("AssessTemplatePaperID")%>
                    </ItemTemplate>
                    <ItemStyle Width="0%" HorizontalAlign="Center" />
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <%#Eval("PaperName")%>
                    </ItemTemplate>
                    <ItemStyle Width="50%" HorizontalAlign="Left" />
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="绩效考核项">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnItems" runat="server" Text="绩效考核项" href='<%# string.Format("ListItemAndPaper.aspx?paperID={0}", SecurityUtil.DECEncrypt(Eval("AssessTemplatePaperID").ToString())) %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="18%" />
                        </asp:TemplateField>--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Command" runat="server"
                            CommandArgument='<%# Eval("AssessTemplatePaperID")%>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" Text="删除" runat="server" CausesValidation="false"
                            CommandArgument='<%# Eval("AssessTemplatePaperID") %>' OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                            OnCommand="btnDelete_Command" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="tbnCopy" Text="复制" OnCommand="tbnCopy_Command"
                            CommandArgument='<%# Eval("AssessTemplatePaperID") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
<%--                <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
下一页</asp:LinkButton>
                </div>--%>
        <uc1:PageTemplate ID="PageTemplate1" runat="server" />                
            </PagerTemplate>
        </asp:GridView>

    </div>
</div>
