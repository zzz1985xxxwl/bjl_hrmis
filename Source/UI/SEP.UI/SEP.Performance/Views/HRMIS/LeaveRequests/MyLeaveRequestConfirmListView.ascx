<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyLeaveRequestConfirmListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.MyLeaveRequestConfirmListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<script type="text/javascript">
var IsNextExecute = true;

//IsImgOnClickExe��Ŀ����Ϊ�� if else�жϵ�ǰ�¼���img.onclick����������row.onclick����
//false��ʾ����img.onclick����,true��ʾ��img.onclick
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
	    currtr.style.display = "inline"; //չ��
    }
    else
    { 
	    currtr.style.display = "none"; //����
    } 
    IsImgOnClickExe=true;
}
</script>

<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbLeaveRequest" runat="server" onclick="javascript:showdescription('');IsNextExecute = true;">
<div class="leftitbor2"><asp:Label ID="lbOperationType" runat="server" >����˵���ٵ�</asp:Label></div>

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
                                            <asp:TemplateField HeaderText="Ա������">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="����">
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
                                                                                    ��ϸ˵��</strong></td>
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
                                            <asp:BoundField DataField="FromDate" HeaderText="��ʼʱ��" ItemStyle-Width="14%" />
                                            <asp:BoundField DataField="ToDate" HeaderText="����ʱ��" ItemStyle-Width="15%" />
                                            <asp:BoundField DataField="CostTime" HeaderText="���Сʱ" ItemStyle-Width="7%" />
                                            <asp:TemplateField HeaderText="��ϸ��">
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                                        <%#Eval("LeaveRequestItemsShow")%>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="33%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDetail" runat="server" Text="��ϸ" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Detail_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle  Width="4%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnQuickPass" runat="server" Text="����ͨ��" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="QuickPass_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle  Width="7%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnApprove" runat="server" Text="���" CausesValidation="false"
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
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>    --%>                      
                    </PagerTemplate>
                                    </asp:GridView> 
</div>
                   
</div>
