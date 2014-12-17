<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"  CodeBehind="WorkTaskManage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.WorkTaskPages.WorkTaskManage" %>
<%@ Register Src="../../../Views/SEP/WorkTasks/TeamWorkTaskListView.ascx" TagName="TeamWorkTaskListView"
    TagPrefix="uc5" %>
<%@ Register Src="../../../Views/SEP/WorkTasks/NavigateView.ascx" TagName="NavigateView"
    TagPrefix="uc4" %>

<%@ Register Src="../../../Views/SEP/WorkTasks/OtherWorkTaskListView.ascx" TagName="OtherWorkTaskListView"
    TagPrefix="uc2" %>
<%@ Register Src="../../../Views/SEP/WorkTasks/OwnerWorkTaskListView.ascx" TagName="OwnerWorkTaskListView"
    TagPrefix="uc3" %>

<%@ Register Src="../../../Views/SEP/WorkTasks/WorkTaskInfoView.ascx" TagName="WorkTaskInfoView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
<style type="text/css">
.righttab
{
width:117px; padding-left:11px; margin-top:7px; padding-top:4px;position:relative; cursor:pointer; height:20px;line-height:20px
}
.righttabselect
{
background:url('../../image/greensolidtablong.gif') no-repeat 0px 0px; z-index:30; font-weight:bold
}
.righttabnotselect
{
background:url('../../image/greensolidtablong.gif') no-repeat 0px -30px;  z-index:20; 
}
.searchCondition
{
    margin-left:30px;margin-top:10px;margin-bottom:10px; line-height:32px;
}
</style>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXPage.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
<script language="javascript " type="text/javascript" src="../../Inc/KeepConnectWithServer.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>  
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js" charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />

<asp:Label ID="lblLoginAccountName" runat="server" CssClass="hidden LoginAccountName"></asp:Label>
<asp:Label ID="lblLoginAccountID" runat="server" CssClass="hidden LoginAccountID"></asp:Label>
<label id="AccountNameInRightList" class="hidden"></label>
<label id="AccountIDInRightList" class="hidden"></label>

<table style="width:98%; text-align:left; border:1px solid #69ad3c; margin-top:8px; height:504px; background-color:White;" 
cellpadding="0" cellspacing="0">
    <tr style="vertical-align:top;">
        <td style="width:198px">
            <uc4:NavigateView id="NavigateView1" runat="server">
            </uc4:NavigateView>
        </td>
        <td style="width:7px; background-color: #69ad3c">
        </td>
        <td style="width:auto;">
            <div style="background-color:#e6efc2; height:28px; border-bottom:1px solid #69ad3c; padding-left:5px;">
                <div style="float:left; width:240px" id="divRighttabParent">
                    <div id="righttabTeamWT" style="float:right; margin-left:-18px;" class="righttab righttabnotselect hidden" onclick="righttabclick(this,'divTeamWT');">团队工作计划</div>
                    <div style="float:right; margin-left:-18px;" class="righttab righttabnotselect" onclick="righttabclick(this,'divOtherWT');">其他相关计划</div>
                    <div id="righttabOwnerWT" style="float:right;" class="righttab righttabselect" onclick="righttabclick(this,'divOwnerWT');">个人工作计划</div> 
                    <div style="clear:both"></div>
                </div>
                <div style="float:right; line-height:28px; font-size:14px; color:#28518e; padding-right:15px; font-weight:bold" id="CurrentAccountName">工作计划</div>  
                <div style="clear:both"></div>
            </div>
            <div id="divOwnerWT" class="divWT">
                <uc3:OwnerWorkTaskListView id="OwnerWorkTaskListView1" runat="server">
                </uc3:OwnerWorkTaskListView>
            </div> 
            <div id="divOtherWT" class="divWT" style=" display:none;">
                <uc2:OtherWorkTaskListView id="OtherWorkTaskListView1" runat="server">
                </uc2:OtherWorkTaskListView> 
            </div> 
            <div id="divTeamWT" class="divWT" style=" display:none;">
                <uc5:TeamWorkTaskListView ID="TeamWorkTaskListView1" runat="server" />
            </div>             
        </td>
    </tr>
</table>
<div id="dialog" style="display: none;">
<uc1:WorkTaskInfoView id="WorkTaskInfoView1" runat="server">
</uc1:WorkTaskInfoView>
</div>
<script type="text/javascript" language="javascript"> 
$(function() {
    HideTheAuth();  
    $("#dialog").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 800
    });
    OwnerWorkTaskList_Load();
    OtherWorkTaskList_Load();
    TeamWorkTaskList_Load();    
    Navigate_Load();
})  

function righttabclick(th,divcurr){
    $(".righttab").each(function(i){
        $(this).removeClass("righttabselect");
        $(this).addClass("righttabnotselect");
    });
    $(th).removeClass("righttabnotselect");
    $(th).addClass("righttabselect");
    
    $(".divWT").each(function(i){
        $(this).hide();
    });
    $("#"+divcurr).show();
}
</script>

</asp:Content>
