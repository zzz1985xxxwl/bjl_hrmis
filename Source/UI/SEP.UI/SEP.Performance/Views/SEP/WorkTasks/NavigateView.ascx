<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigateView.ascx.cs" Inherits="SEP.Performance.Views.SEP.WorkTasks.NavigateView" %>
<style type="text/css">
.lefttitle
{
    line-height:24px; padding-left:8px; background-color:#e6efc2;
}
.leftitem
{
    line-height:28px; padding-left:20px;cursor:pointer;
}
.leftitemmouseover
{
    background-color:#f3f9da;
}
.linegreen
{
    border-top:1px solid #69ad3c
}
.linegrass
{
    border-top:1px solid #c6d980
}
.currArrowGreen
{
    background: url(../../image/currArrow.gif) no-repeat 193px 8px #e6efc2;
    height:28px; color:#28518e;
}
</style>
<div id="leftNavigate">
    <div class="lefttitle">我的工作计划</div>
    <div class="linegreen"></div>
    <div>
        <div class="leftitem" onmouseover="$(this).addClass('leftitemmouseover');" onmouseout="$(this).removeClass('leftitemmouseover');" onclick="AddShowDialog();">
            新增工作计划</div>
        <div class="leftitem" onmouseover="$(this).addClass('leftitemmouseover');" onmouseout="$(this).removeClass('leftitemmouseover');" 
        onclick="RightChange($(this),$('.LoginAccountID').html(),$('.LoginAccountName').html(),true);" id="divSearchMyWT">
            查看工作计划</div>
    </div>
    <div class="linegreen"></div>
    <div id="divTeamTask" runat="server">
        <div class="lefttitle">团队工作计划</div>
        <div class="linegreen"></div>
        <div style="margin:8px; height:80px">
            <div style="line-height:32px; height:32px">姓名 <input id="navigate_Name" type="text" class="input1" style="width:145px"/></div>
            <div style="line-height:32px; height:32px">部门 <input id="navigate_Department" type="text" class="input1" style="width:145px"/></div>
            <div style=" float:right; line-height:14px; height:14px; background:url('../../image/search.gif') no-repeat 0px 4px; 
            padding-left:18px; padding-top:5px; cursor:pointer; width:auto;" onclick="SearchTeamMember();"> 检索</div>
        </div>
        <div class="linegrass"></div>
        <div id="searchTable"  class="linetabledivfullwidth"> 
            <table id="tbTeamMember" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
            </table>
        </div>
    </div>
</div>

<script language="javascript" type="text/javascript">
function Navigate_Load(){
   $("#navigate_Department").autocomplete("../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx?type=GetDeptAndChildrenDeptByCurrAccount",{mouseovershow:false});
   $("#navigate_Department").result(function(event, data, formatted) {textChanged(event.target);});

   $("#divSearchMyWT").click();
   SearchTeamMember();
}

function textChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}
function SearchTeamMember() {
    $("#tbTeamMember").SXTable( 
    {
        colNames: ["", "姓名", "职位"],
        colWidth: ["2%"],
        colTemplates: [" <span class='hide' accountid='#AccountID#'/>", "#Name#", "#PositionName#"],
        url: '../AccountPages/GetAccountHandle.ashx',
        data: 
        {
            namelike: $("#navigate_Name").val(),
            deptlike: $("#navigate_Department").val(),
            type: "GetChargeAccountByNameAndDeptString"
        },
        pageSize: 10,
        styleclass:"simple",
        success:SuccessTeamMember
    });
}
function BindTeamMemberRowEvent(){
    $("#tbTeamMember").find("tbody").eq(0).find("tr").each(function(){
        $(this).css({"cursor":"pointer"});
        $(this).bind("click", function() {
            RightChange($(this),$(this).find("td").eq(0).find("span").eq(0).attr("accountid"),
            $(this).find("td").eq(1).html(),false);
        });
    
    });

}
function SuccessTeamMember(methods) { 
    BindTeamMemberRowEvent();
    $("#tbTeamMember").find(".pageprevbutton").eq(0).bind("click",function() {BindTeamMemberRowEvent();});
    $("#tbTeamMember").find(".pagefirstbutton").eq(0).bind("click",function() {BindTeamMemberRowEvent();});
    $("#tbTeamMember").find(".pagenextbutton").eq(0).bind("click",function() {BindTeamMemberRowEvent();});
    $("#tbTeamMember").find(".pagelastbutton").eq(0).bind("click",function() {BindTeamMemberRowEvent();});
    $("#tbTeamMember").find(".pagegobutton").eq(0).bind("click",function() {BindTeamMemberRowEvent();});
    $("#tbTeamMember").find("th").each(function(){$(this).bind("click",function() {BindTeamMemberRowEvent();});});

}
function RightChange(th,accountID,accountName,isself){
    if($("#AccountIDInRightList").html()==accountID)
    {return;}
    $("#leftNavigate").find(".currArrowGreen").each(function(){
        $(this).removeClass("currArrowGreen");
    });
    $(th).addClass("currArrowGreen");
    $("#AccountNameInRightList").html(accountName);
    $("#AccountIDInRightList").html(accountID);
    $("#CurrentAccountName").html(accountName+"的工作计划");
    $("#righttabOwnerWT").click();
    $("#righttabTeamWT").hide();
    $("#divRighttabParent").css("width","240px");    
    SearchOwnerWorkTask();
    SearchOtherWorkTask();
    //SearchTeamWorkTask
    $.ajax(
    {
        url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
        data: 
        {
            type: "GetDeptAndChildrenDeptByAccountID",
            accountID: $("#AccountIDInRightList").html()
        },
        success: function(data) {
             if(data.length>0)
             {
                $("#righttabTeamWT").show();
                $("#divRighttabParent").css("width","350px");
                SearchTeamWorkTask();
             }
        }
    });    
}
</script>