<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyLeaveRequestConfirmListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.MyLeaveRequestConfirmListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<script type="text/javascript">
var IsNextExecute = true;

//IsImgOnClickExe的目的是为了 if else判断当前事件是img.onclick触发，还是row.onclick触发
//false表示不是img.onclick触发,true表示是img.onclick
var IsImgOnClickExe = false;
function showdescription(strID)
{
    strID = "Item"+strID ;
    if(!IsNextExecute)
    {
        return;
    }
    var currtr = document.getElementById(strID);
    for(i   =   0;   i   <   document.all.length;   i++)
    {  
        if(document.all(i).tagName.toUpperCase()=="DIV" 
        && document.all(i).id!="" 
        && document.all(i).id.substring(0,4)=="Item" 
        && document.all(i).id!=strID)
        {
            document.all(i).style.display = "none";
        }
    }
    if(currtr==null)
    {
        return;
    }
    if (currtr.style.display=="none")
    {
	    currtr.style.display = "inline"; //展开
    }
    else
    { 
	    currtr.style.display = "none"; //收缩
    } 
    IsImgOnClickExe=true;
}
</script>

<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbLeaveRequest" runat="server" onclick="javascript:showdescription('');IsNextExecute = true;">
<div class="leftitbor2"><asp:Label ID="lbOperationType" runat="server" >待审核的请假单</asp:Label></div>

 <div  class="linetablediv" >                  
            <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand"
                                        OnRowDataBound="grd_RowDataBound">
                                        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                        <RowStyle Height="28px"  CssClass="GridViewRowLink"  HorizontalAlign="Left"/>
                                        <AlternatingRowStyle CssClass="table_g" />
                                        <Columns>
                                          <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                                                runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="员工姓名">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="类型">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("LeaveRequestType.Name") %>'></asp:Label>
                                                    <a href="#">
                                                        <img src="../../image/icon01.gif" align="absmiddle" border="0" onclick="javascript:showdescription('<%# Eval("PKID")%>');" />
                                                    </a>
                                                    <div id="<%# "Item"+Eval("PKID")%>" style="display: none; background-color: #FFFFFF;
                                                        z-index: 10; position: absolute;">
                                                        <table onclick="javascript:IsNextExecute = false;IsImgOnClickExe=true;" width="450px"
                                                            class="linetable_3"  cellpadding="0" cellspacing="0" >
                                                            <tr>
                                                                <td height="28" class="tdbg02bg">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="8%" height="23" align="center">
                                                                                <img src="../../image/icon04.jpg" /></td>
                                                                            <td width="84%" align="left">
                                                                                <strong style="color: #FFFFFF">
                                                                                    <%# Eval("LeaveRequestType.Name")%>
                                                                                    详细说明</strong></td>
                                                                            <td width="8%" align="center">
                                                                                <a href="#">
                                                                                    <img src="../../image/xxx.jpg" border="0" onclick="javascript:showdescription('<%# Eval("PKID")%>');" /></a></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                                        <tr>
                                                                            <td height="100" align="center" valign="top">
                                                                                <table width="98%" height="93" border="0" cellpadding="5" style="border-collapse:separate;" cellspacing="6">
                                                                                    <tr>
                                                                                        <td width="97%" class="fonttable_2" align="left" valign="top" height="100">
                                                                                            <%# Eval("LeaveRequestType.Description")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="6%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FromDate" HeaderText="开始时间" ItemStyle-Width="14%" />
                                            <asp:BoundField DataField="ToDate" HeaderText="结束时间" ItemStyle-Width="15%" />
                                            <asp:BoundField DataField="CostTime" HeaderText="请假小时" ItemStyle-Width="7%" />
                                            <asp:TemplateField HeaderText="详细项">
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                                        <%#Eval("LeaveRequestItemsShow")%>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="33%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDetail" runat="server" Text="详细" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Detail_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle  Width="4%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnQuickPass" runat="server" Text="快速通过" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="QuickPass_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle  Width="7%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnApprove" runat="server" Text="审核" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Approve_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle  Width="4%"/>
                                            </asp:TemplateField>
                                        </Columns>
                    <PagerTemplate>
      <uc1:PageTemplate id="PageTemplate1" runat="server">
     </uc1:PageTemplate>                   
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>    --%>                      
                    </PagerTemplate>
                                    </asp:GridView> 
</div>
                   
</div>
