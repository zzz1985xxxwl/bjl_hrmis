<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdvanceSearchList.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AdvanceSearch.EmployeeAdvanceSearchList" %>
<%@ Register Src="../../SetColumnListView.ascx" TagName="SetColumnListView" TagPrefix="uc3" %>
<%@ Register Src="../../SetSearchConditionView.ascx" TagName="SetSearchConditionView" TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
function BindGoogleDownSearchField()
{
    $(".SearchFieldInfo").autocomplete("EmployeeAdvanceSearchBackCode.aspx?operation=SearchFieldInfo");
    $(".SearchFieldInfo").result(function(event, data, formatted) {btntxtSearchFieldChangeClick(event.target);});
    for(i=1;i<100;i++)
    {
        $(".FieldParaBaseId"+i).DownTableSelected("EmployeeAdvanceSearchBackCode.aspx?operation=ExpressionInfo&FieldParaBaseId="+i);
    }
}
</script>
<div class="leftitbor">
    <div id="divResultMessage">
        <span class="font14b">共查询到 </span>
        <span class="fontred">0</span>
        <span class="font14b"> 条记录</span>
    </div>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="leftitbor2">
    员工高级查询
</div>
<uc2:SetSearchConditionView ID="SetSearchConditionView1" runat="server" />
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <uc1:Progressing ID="Progressing1" runat="server" />
    </ProgressTemplate>
</asp:UpdateProgress>
</ContentTemplate>
</asp:UpdatePanel>
<uc3:SetColumnListView id="SetColumnListView1" runat="server"/>
<div class="tablebt">
    <input type="button" id="btnSearch" value="查  询" onclick="dosearch('Search');" class="inputbt" />
    <input type="button" id="btnExport" value="导  出" onclick="location.href='EmployeeAdvanceSearchBackCode.aspx?operation=Export&colshow='+getSetColumnListValue()" class="inputbt" />
</div>
<link href="../../CSS/jquery.tablesorter.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script type="text/javascript" src="../../Inc/jquery.cookie.js"></script>
<div style="display:none">
<asp:Label CssClass="hiddenColName" id="hiddenColName" runat="server"/>
<asp:Label  CssClass ="hiddenColTemplates" id="hiddenColTemplates" runat="server"/>
</div>
<div id="divTableList" class="linetablediv">
<table id="tbTableList" width="100%" ></table>
</div>
<script language="javascript" type="text/javascript">
var sxTableMethods;
$("#divTableList").hide();
$(function(){dosearch("Initial");});
function columnHeaderShowOrHide(columnIndex,checked)
{
      //设置行头显示
        var item = $("#tbTableList tr").eq(0).find("th").eq(columnIndex);
        if(item.length>0){
            if(checked){
                item.show();
            }
            else{
                item.hide();
            }
        }
}
function columnColShowOrHide(columnIndex,checked)
{
      //设置数据显示
      $("#tbTableList tr").each(function(){
            var item = $(this).find("td").eq(columnIndex);
            if(item.length>0){
                if(checked){
                    item.show();
                }
                else{
                    item.hide();
                }
            }
      });
}
function GetColName(strhiddenColName)
{
    strhiddenColName = "["+strhiddenColName
    +",\"\",\"\",\"\",\"\""
    +"]";
    return eval(strhiddenColName);
}
function GetColTemplates(strhiddenColTemplates)
{
    strhiddenColTemplates = "["+strhiddenColTemplates
+", \"<a href='../EmployeePages/EmployeeUpdate.aspx?employeeID=#NumDECEncrypt#' >修改详情</a>\""
+", \"<a href='../EmployeePages/EmplyeeHistoryList.aspx?employeeID=#NumDECEncrypt#' >查看历史</a>\""
+", \"<a href='../EmployeePages/EmployeeUpdate.aspx?employeeID=#NumDECEncrypt#&EmployeeVacationOperation=#DECEncrypt4#' >年假管理</a>\""
+", \"<a href='../ContractPages/EmployeeContractList.aspx?employeeID=#NumDECEncrypt#' >合同管理</a>\""
    +"]";
    return eval(strhiddenColTemplates);
}

function dosearch(operationType)
{
     $("#tbTableList").SXTable({
                    colNames:GetColName($(".hiddenColName").html()),
				    colTemplates:GetColTemplates($(".hiddenColTemplates").html()),
				    url:'EmployeeAdvanceSearchBackCode.aspx',
				    data:{operation:operationType,condition:getSearchConditionTableValue(),colshow:getSetColumnListValue()},
				    success:Success,
				    pageSize:15,
				    afterChangePage:function(pageindex){
				        $.cookie("employeeadvancesearchlistindex",pageindex,{expires: 500}) ;
			            SetTableColVisible();
				    },
				    currentPage:GetCookiePageIndex()
    });
    SetTableHeaderVisible();
    $("#divTableList").show();
}
function Success(methods)
{
    sxTableMethods=methods;
    SetTableColVisible();
    $("#divResultMessage").html("<span class=\"font14b\">共查询到 </span><span class=\"fontred\">" + sxTableMethods.allitems().length + "</span><span class=\"font14b\"> 条记录</span>");
    if(sxTableMethods.allitems().length==0){
        $.cookie("employeeadvancesearchlistindex",1,{expires: 500}) ;
    }
}
function GetCookiePageIndex()
{
    if(parseInt($.cookie("employeeadvancesearchlistindex")))
        return parseInt($.cookie("employeeadvancesearchlistindex"));
    else
        return 1;
}
function SetTableColVisible()
{
      var i=1;
      $(".SetColumnList").find("input[type='checkbox']").each(function(){
              columnColShowOrHide(i,$(this).attr("checked"));
        i=i+1;
      });
}
function SetTableHeaderVisible()
{
     var i=1;
      $(".SetColumnList").find("input[type='checkbox']").each(function(){
              columnHeaderShowOrHide(i,$(this).attr("checked"));
        i=i+1;
      });
}
function employeeAdvanceSearchErrorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).css("display","block");
    }
}
</script>


