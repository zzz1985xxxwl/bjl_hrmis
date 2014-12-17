<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OwnerWorkTaskListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.WorkTasks.OwnerWorkTaskListView" %>
<div style="text-align:left" class="searchCondition">
    <div>
        任务名称 
        <input id="ownerList_TaskName" type="text" class="input1" style="width:266px; margin-left:12px;"/> 
        <span style="margin-left:36px">工作计划时间</span>
        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
            TargetControlID="ownerList_StartDate">
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="ownerList_StartDate" runat="server" CssClass="ownerList_StartDate" style="width:106px; margin-left:12px;"></asp:TextBox>
         -- 
        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
            TargetControlID="ownerList_EndDate" >
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="ownerList_EndDate" runat="server" CssClass="ownerList_EndDate" style="width:106px;"></asp:TextBox>
    </div>
    <div>
        优先级 
        <asp:DropDownList ID="ownerList_Priority" CssClass="ownerList_Priority" runat="server" style="width:130px; margin-left:24px;"></asp:DropDownList> 
        <span style="margin-left:36px">当前状态</span>
        <input type="button" class="inputbt hand" value="查询" style="margin-left:260px" onclick="SearchOwnerWorkTask();"/>
        <input type="button" class="inputbt hand" value="导出" onclick="ExportOwnerWorkTask();"/>
        <div id="ownerList_Statuss" style="margin-top:-30px; margin-left:300px; line-height:32px;">
        <asp:CheckBoxList ID="ownerList_Status" CssClass="ownerList_Status" runat="server" RepeatColumns="10" CellSpacing="0" ></asp:CheckBoxList>
        </div>
    </div>
</div> 

<div class="RowCountSpan">
    <span id="ownerList_lblMessage" style="font-weight:bold"></span>
</div>
<div id="searchTable"  class="linetabledivfullwidth"> 
    <table id="tbOwnerWorkTask" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>
<script language="javascript" type="text/javascript">
var $ownerList_StartDate, $ownerList_EndDate, $ownerList_Priority,$ownerList_TaskName,$ownerList_Status;
function OwnerWorkTaskList_Load() {
    $ownerList_StartDate = $(".ownerList_StartDate");
    $ownerList_EndDate = $(".ownerList_EndDate");
    $ownerList_Priority = $(".ownerList_Priority");
    $ownerList_TaskName = $("#ownerList_TaskName");
    $ownerList_Status = $(".ownerList_Status");
}

function getownerList_Status()
{
    var $ret="";
    $ownerList_Status.find("input[type=checkbox]").each(function(i){
        $ret+="|"+$(this).attr("checked");
    });
    return $ret;
}
function SearchOwnerWorkTask() {
    if($("#AccountIDInRightList").html()==$(".LoginAccountID").html())
    {
        $("#tbOwnerWorkTask").SXTable( 
        {
            colNames: ["","当前状态", "任务名称", "工作内容","优先级","负责人","开始时间","完成时间", "","",""],
            colWidth: ["8px","70px"],
            colTemplates: ["&nbsp;<span rowstyle='#RowStyle#'/>","#StatusNameWithStyle#", "#Title#", "#ContentAndDesc#","#PriorityName#","#ResponsiblesNameIncludeOwner#","#StartDate#","#EndDate#",
            "<a onclick=\"UpdateShowDialog(#PKID#)\">修改</a>","<a onclick=\"Delete(confirm('确定要删除吗？'),#PKID#)\">删除</a>",
            "<a onclick=\"DetailShowDialog(#PKID#);$('#qainfolink').click();\">留言#QACount#条</a>"],
            url: 'WorkTaskManageHandle.ashx',
            data: 
            {
                TaskName: $ownerList_TaskName.val(),
                Status: getownerList_Status(),
                StartDate: $ownerList_StartDate.val(),
                EndDate: $ownerList_EndDate.val(),
                Priority: $ownerList_Priority.val(),
                AccountID: $("#AccountIDInRightList").html(),
                type: "SearchOwnerWorkTask"
            },
            pageSize: 15,
            success: SuccessOwnerList
        });
    }
    else
    {
        $("#tbOwnerWorkTask").SXTable( 
        {
            colNames: ["","当前状态", "任务名称", "工作内容","优先级","负责人","开始时间","完成时间", "",""],
            colWidth: ["8px","70px"],
            colTemplates: ["&nbsp;<span rowstyle='#RowStyle#'/>","#StatusNameWithStyle#", "#Title#", "#ContentAndDesc#","#PriorityName#","#ResponsiblesNameIncludeOwner#","#StartDate#","#EndDate#",
            "<a onclick=\"DetailShowDialog(#PKID#);$('#qainfolink').click();\">留言#QACount#条</a>",
            "<a onclick=\"DetailShowDialog(#PKID#)\">详情</a>"],
            url: 'WorkTaskManageHandle.ashx',
            data: 
            {
                TaskName: $ownerList_TaskName.val(),
                Status: getownerList_Status(),
                StartDate: $ownerList_StartDate.val(),
                EndDate: $ownerList_EndDate.val(),
                Priority: $ownerList_Priority.val(),
                AccountID: $("#AccountIDInRightList").html(),
                type: "SearchOwnerWorkTask"
            },
            pageSize: 15,
            success: SuccessOwnerList
        });
    }
}
function SuccessOwnerList(methods) {    
    $("#ownerList_lblMessage").next("span").eq(0).remove();
    $("#ownerList_lblMessage").prev("span").eq(0).remove();
    $("<span>共查到 </span>").insertBefore("#ownerList_lblMessage");
    $("<span>条记录 </span>").insertAfter("#ownerList_lblMessage");
    $('#ownerList_lblMessage').html(methods.allitems().length);
    
    BindListRowStyle("tbOwnerWorkTask");
    $("#tbOwnerWorkTask").find(".pageprevbutton").eq(0).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});
    $("#tbOwnerWorkTask").find(".pagefirstbutton").eq(0).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});
    $("#tbOwnerWorkTask").find(".pagenextbutton").eq(0).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});
    $("#tbOwnerWorkTask").find(".pagelastbutton").eq(0).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});
    $("#tbOwnerWorkTask").find(".pagegobutton").eq(0).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});
    $("#tbOwnerWorkTask").find("th").each(function(){$(this).bind("click",function() {BindListRowStyle("tbOwnerWorkTask");});});

}
function BindListRowStyle(tbname){
    $("#"+tbname).find("tbody").eq(0).find("tr").each(function(){
        $(this).addClass($(this).find("td").eq(0).find("span").eq(0).attr("rowstyle"));
        $(this).bind("mouseover",function(){
            $(this).removeClass($(this).find("td").eq(0).find("span").eq(0).attr("rowstyle"));
            $(this).addClass("tablerow_mouseover1");
        });
        $(this).bind("mouseout",function(){
            $(this).addClass($(this).find("td").eq(0).find("span").eq(0).attr("rowstyle"));
            $(this).removeClass("tablerow_mouseover1");
        });
    });

}
function ExportOwnerWorkTask(){
    location.href="WorkTaskManageHandle.ashx?type=Export&ExportSource=OwnerWorkTaskList";
}
</script>