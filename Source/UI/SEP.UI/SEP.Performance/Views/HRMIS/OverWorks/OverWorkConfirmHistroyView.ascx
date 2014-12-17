<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorkConfirmHistroyView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.OverWorkConfirmHistroyView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />

<div runat="server" id="divDisplaySearchCondition">
<div class="leftitbor2nopadding">
    <table width="100%" border="0">
        <tr>
            <td width="26%" align="left" style="padding-left:45px;line-height:35px;">
                <asp:Label ID="lbOperationType" runat="server">��˼Ӱ൥��ʷ</asp:Label>
            </td>            
            <td width="8%" align="right">
                Ա������
            </td>
            <td width="16%" align="right">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
            <td width="8%" align="right">
                �Ƿ����
            </td>
            <td width="8%" align="right">
                <asp:DropDownList ID="ddlAdjust" runat="server" Width="95%">
                    <asp:ListItem Value="-1"> ȫ��</asp:ListItem>
                    <asp:ListItem Value="0">������</asp:ListItem>
                    <asp:ListItem Value="1">���� </asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="8%" align="right">
                ʱ�䷶Χ
            </td>
            <td width="30%" align="right">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                --
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="input1" Width="40%"></asp:TextBox><asp:Label
                    ID="lblDateMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateTo"
                Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender>
            <td width="6%">     
                <asp:Button ID="Button1" runat="server" Text="" CssClass="inputbtSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>      
    </table>
</div>
<div id="divOverWork" runat="server" >
   <div class="linetablediv" >
        <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
                   <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                   <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                   <AlternatingRowStyle CssClass="table_g" />
                   <Columns>
                       <asp:TemplateField>
                           <ItemTemplate><asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate>
                           <ItemStyle Width="2%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Ա������">
                            <ItemTemplate>
                                <%# Eval("Account.Name") %>
                            </ItemTemplate>         
                           <ItemStyle Width="10%" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="FromDate" HeaderText="��ʼʱ��" ItemStyle-Width="16%" />
                       <asp:BoundField DataField="ToDate" HeaderText="����ʱ��" ItemStyle-Width="16%" />
                       <asp:BoundField DataField="CostTime" HeaderText="�Ӱ�Сʱ" ItemStyle-Width="8%" />
                       <asp:TemplateField HeaderText="��ϸ��">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                <%#Eval("OutItemsShow")%>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="48%" HorizontalAlign="Left" />
                      </asp:TemplateField>
                   </Columns>
                    <PagerTemplate> 
                     <uc1:PageTemplate id="PageTemplate1" runat="server">
       </uc1:PageTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>     --%>                     
                    </PagerTemplate>
               </asp:GridView>
     </div>  
</div>
</div>