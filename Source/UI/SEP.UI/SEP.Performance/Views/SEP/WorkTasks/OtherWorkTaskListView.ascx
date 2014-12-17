<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherWorkTaskListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.WorkTasks.OtherWorkTaskListView" %>
<div style="text-align:left" class="searchCondition">
    <div>
        任务名称 
        <input id="otherList_TaskName" type="text" class="input1" style="width:266px; margin-left:12px;"/> 
        <span style="margin-left:36px">工作计划时间</span>
        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
            TargetControlID="otherList_StartDate">
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="otherList_StartDate" runat="server" CssClass="otherList_StartDate" style="width:106px; margin-left:12px;"></asp:TextBox>
         -- 
        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
            TargetControlID="otherList_EndDate">
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="otherList_EndDate" runat="server" CssClass="otherList_EndDate" style="width:106px;"></asp:TextBox>
    </div>
    <div>
        优先级 
        <asp:DropDownList ID="otherList_Priority" CssClass="otherList_Priority" runat="server" style="width:130px; margin-left:24px;"></asp:DropDownList> 
        <span style="margin-left:36px">当前状态</span>
        <input type="button" class="inputbt hand" value="查询" style="margin-left:260px" onclick="SearchOtherWorkTask();"/>
        <input type="button" class="inputbt hand" value="导出" onclick="ExportOtherWorkTask();"/>
        <div id="otherList_Statuss" style="margin-top:-30px; margin-left:300px; line-height:32px;">
        <asp:CheckBoxList ID="otherList_Status" CssClass="otherList_Status" runat="server" RepeatColumns="10" CellSpacing="0" ></asp:CheckBoxList>
        </div>
    </div>
</div> 

<div class="RowCountSpan">
    <span id="otherList_lblMessage" style="font-weight:bold"></span>
</div>
<div id="searchTable"  class="linetabledivfullwidth"> 
    <table id="tbOtherWorkTask" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>
<script language="javascript" type="text/javascript">
var $otherList_StartDate, $otherList_EndDate, $otherList_Priority,$otherList_TaskName,$otherList_Status;
function OtherWorkTaskList_Load() {
    $otherList_StartDate = $(".otherList_StartDate");
    $otherList_EndDate = $(".otherList_EndDate");
    $otherList_Priority = $(".otherList_Priority");
    $otherList_TaskName = $("#otherList_TaskName");
    $otherList_Status = $(".otherList_Status");
}

function getotherList_Status()
{
    var $ret="";
    $otherList_Status.find("input[type=checkbox]").each(function(i){
        $ret+="|"+$(this).attr("checked");
    });
    return $ret;
}
function SearchOtherWorkTask() {
    $("#tbOtherWorkTask").SXTable( 
    {
        colNames: ["",  "当前状态","创建人","任务名称", "工作内容","优先级","负责人","开始时间","完成时间","","",""],
        colWidth: ["8px","70px"],
        colTemplates: ["&nbsp;<span rowstyle='#RowStyle#'/>","#StatusNameWithStyle#", "#OwerName#", "#Title#", "#ContentAndDesc#","#PriorityName#","#ResponsiblesNameIncludeOwner#","#StartDate#","#EndDate#",
        "<a onclick=\"DetailShowDialog(#PKID#);$('#qainfolink').click();\">留言#QACount#条</a>",
        "<a onclick=\"DetailShowDialog(#PKID#)\">详情</a>"],
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            TaskName: $otherList_TaskName.val(),
            Status: getotherList_Status(),
            StartDate: $otherList_StartDate.val(),
            EndDate: $otherList_EndDate.val(),
            Priority: $otherList_Priority.val(),
            AccountID: $("#AccountIDInRightList").html(),
            type: "SearchOtherWorkTask"
        },
        pageSize: 15,
        success: SuccessOtherList
    });
    
}
function SuccessOtherList(methods) {    
    $("#otherList_lblMessage").next("span").eq(0).remove();
    $("#otherList_lblMessage").prev("span").eq(0).remove();
    $("<span>共查到 </span>").insertBefore("#otherList_lblMessage");
    $("<span>条记录 </span>").insertAfter("#otherList_lblMessage");
    $('#otherList_lblMessage').html(methods.allitems().length);
    
    BindListRowStyle("tbOtherWorkTask");
    $("#tbOtherWorkTask").find(".pageprevbutton").eq(0).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});
    $("#tbOtherWorkTask").find(".pagefirstbutton").eq(0).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});
    $("#tbOtherWorkTask").find(".pagenextbutton").eq(0).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});
    $("#tbOtherWorkTask").find(".pagelastbutton").eq(0).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});
    $("#tbOtherWorkTask").find(".pagegobutton").eq(0).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});
    $("#tbOtherWorkTask").find("th").each(function(){$(this).bind("click",function() {BindListRowStyle("tbOtherWorkTask");});});

}
function ExportOtherWorkTask(){
    location.href="WorkTaskManageHandle.ashx?type=Export&ExportSource=OtherWorkTaskList";
}
</script>