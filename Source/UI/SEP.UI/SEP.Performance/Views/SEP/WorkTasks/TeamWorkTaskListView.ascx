<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamWorkTaskListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.WorkTasks.TeamWorkTaskListView" %>
<div style="text-align:left" class="searchCondition">
    <div>
        创建人
        <input id="teamList_CreatorName" type="text" class="input1" style="width:266px; margin-left:24px;"/> 
        <span style="margin-left:36px">所属部门</span>
        <input id="teamList_DepartmentName" type="text" class="input1" style="width:255px; margin-left:12px;"/> 
    </div>
    <div>
        任务名称 
        <input id="teamList_TaskName" type="text" class="input1" style="width:266px; margin-left:12px;"/> 
        <span style="margin-left:36px">工作计划时间</span>
        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
            TargetControlID="teamList_StartDate">
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="teamList_StartDate" runat="server" CssClass="teamList_StartDate" style="width:106px; margin-left:12px;"></asp:TextBox>
         -- 
        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
            TargetControlID="teamList_EndDate">
        </ajaxToolKit:CalendarExtender>
        <asp:TextBox ID="teamList_EndDate" runat="server" CssClass="teamList_EndDate" style="width:106px;"></asp:TextBox>
    </div>
    <div>
        优先级 
        <asp:DropDownList ID="teamList_Priority" CssClass="teamList_Priority" runat="server" style="width:130px; margin-left:24px;"></asp:DropDownList> 
        <span style="margin-left:36px">当前状态</span>
        <input type="button" class="inputbt hand" value="查询" style="margin-left:260px" onclick="SearchTeamWorkTask();"/>
        <input type="button" class="inputbt hand" value="导出" onclick="ExportTeamWorkTask();"/>        
        <div id="teamList_Statuss" style="margin-top:-30px; margin-left:300px; line-height:32px;">
        <asp:CheckBoxList ID="teamList_Status" CssClass="teamList_Status" runat="server" RepeatColumns="10" CellSpacing="0" ></asp:CheckBoxList>
        </div>
    </div>
</div> 

<div class="RowCountSpan">
    <span id="teamList_lblMessage" style="font-weight:bold"></span>
</div>
<div id="searchTable"  class="linetabledivfullwidth"> 
    <table id="tbTeamWorkTask" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>
<script language="javascript" type="text/javascript">
var $teamList_StartDate, $teamList_EndDate, $teamList_Priority,$teamList_TaskName,$teamList_Status,$teamList_CreatorName,$teamList_DepartmentName;
function TeamWorkTaskList_Load() {
    $teamList_CreatorName = $("#teamList_CreatorName");
    $teamList_DepartmentName = $("#teamList_DepartmentName");
    $teamList_StartDate = $(".teamList_StartDate");
    $teamList_EndDate = $(".teamList_EndDate");
    $teamList_Priority = $(".teamList_Priority");
    $teamList_TaskName = $("#teamList_TaskName");
    $teamList_Status = $(".teamList_Status");
    $("#teamList_DepartmentName").autocomplete("../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx?type=GetDeptAndChildrenDeptByCurrAccount",{mouseovershow:false});
    $("#teamList_DepartmentName").result(function(event, data, formatted) {textChanged(event.target);});

}

function getteamList_Status()
{
    var $ret="";
    $teamList_Status.find("input[type=checkbox]").each(function(i){
        $ret+="|"+$(this).attr("checked");
    });
    return $ret;
}
function SearchTeamWorkTask() {
    $("#tbTeamWorkTask").SXTable( 
    {
        colNames: ["",  "当前状态","创建人","任务名称", "工作内容","优先级","负责人","开始时间","完成时间","","",""],
        colWidth: ["8px","70px"],
        colTemplates: ["&nbsp;<span rowstyle='#RowStyle#'/>","#StatusNameWithStyle#", "#OwerName#", "#Title#", "#ContentAndDesc#","#PriorityName#","#ResponsiblesNameIncludeOwner#","#StartDate#","#EndDate#",
        "<a onclick=\"DetailShowDialog(#PKID#);$('#qainfolink').click();\">留言#QACount#条</a>",
        "<a onclick=\"DetailShowDialog(#PKID#)\">详情</a>"],
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            CreatorName: $teamList_CreatorName.val(),
            DeptName: $teamList_DepartmentName.val(),
            TaskName: $teamList_TaskName.val(),
            Status: getteamList_Status(),
            StartDate: $teamList_StartDate.val(),
            EndDate: $teamList_EndDate.val(),
            Priority: $teamList_Priority.val(),
            AccountID: $("#AccountIDInRightList").html(),
            type: "SearchTeamWorkTask"
        },
        pageSize: 15,
        success: SuccessTeamList
    });
}
function SuccessTeamList(methods) {    
    $("#teamList_lblMessage").next("span").eq(0).remove();
    $("#teamList_lblMessage").prev("span").eq(0).remove();
    $("<span>共查到 </span>").insertBefore("#teamList_lblMessage");
    $("<span>条记录 </span>").insertAfter("#teamList_lblMessage");
    $('#teamList_lblMessage').html(methods.allitems().length);
    
    BindListRowStyle("tbTeamWorkTask");
    $("#tbTeamWorkTask").find(".pageprevbutton").eq(0).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});
    $("#tbTeamWorkTask").find(".pagefirstbutton").eq(0).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});
    $("#tbTeamWorkTask").find(".pagenextbutton").eq(0).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});
    $("#tbTeamWorkTask").find(".pagelastbutton").eq(0).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});
    $("#tbTeamWorkTask").find(".pagegobutton").eq(0).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});
    $("#tbTeamWorkTask").find("th").each(function(){$(this).bind("click",function() {BindListRowStyle("tbTeamWorkTask");});});  
    if(methods.allitems().length>0)
    {
        $("#tbTeamWorkTask").find("th").eq(1).click();
    }  
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
function ExportTeamWorkTask(){
    location.href="WorkTaskManageHandle.ashx?type=Export&ExportSource=TeamWorkTaskList";
}
</script>