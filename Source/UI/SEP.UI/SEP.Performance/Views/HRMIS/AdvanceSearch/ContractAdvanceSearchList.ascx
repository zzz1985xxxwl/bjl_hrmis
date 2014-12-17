<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractAdvanceSearchList.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AdvanceSearch.ContractAdvanceSearchList" %>
<%@ Register Src="../../SetColumnListView.ascx" TagName="SetColumnListView" TagPrefix="uc3" %>
<%@ Register Src="../../SetSearchConditionView.ascx" TagName="SetSearchConditionView" TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
function BindGoogleDownSearchField()
{
    $(".SearchFieldInfo").autocomplete("ContractAdvanceSearchBackCode.aspx?operation=SearchFieldInfo");
    $(".SearchFieldInfo").result(function(event, data, formatted) {btntxtSearchFieldChangeClick(event.target);});
    for(i=1;i<40;i++)
    {
        $(".FieldParaBaseId"+i).DownTableSelected("ContractAdvanceSearchBackCode.aspx?operation=ExpressionInfo&FieldParaBaseId="+i);
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
    员工合同高级查询
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
    <input type="button" id="btnExport" value="导  出" onclick="location.href='ContractAdvanceSearchBackCode.aspx?operation=Export&colshow='+getSetColumnListValue()" class="inputbt" />
</div>
<link href="../../CSS/jquery.tablesorter.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SHjqTable.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.pager.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.js" charset="gb2312"></script>
<script type="text/javascript" src="../../Inc/jquery.cookie.js"></script>
<div style="display:none">
<asp:Label CssClass="hiddenColName" id="hiddenColName" runat="server"/>
<asp:Label  CssClass ="hiddenColTemplates" id="hiddenColTemplates" runat="server"/>
</div>
<div id="divTableList" class="linetablediv">
<table id="tbTableList" width="100%" ></table>
</div>
<script language="javascript" type="text/javascript">
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
    +",\"\",\"\""
    +"]";
    return eval(strhiddenColName);
}
function GetColTemplates(strhiddenColTemplates)
{
    strhiddenColTemplates = "["+strhiddenColTemplates
+", \"<a href='../ContractPages/EmployeeContractUpdate.aspx?ContractId=#ContractNumDECEncrypt#&employeeID=#EmployeeNumDECEncrypt#' >修改</a>\""
+", \"<a href='../ContractPages/EmployeeContractDelete.aspx?ContractId=#ContractNumDECEncrypt#&employeeID=#EmployeeNumDECEncrypt#' >删除</a>\""
    +"]";
    return eval(strhiddenColTemplates);
}
function dosearch(operationType)
{
     $("#tbTableList").SHjqTable({
                    colNames:GetColName($(".hiddenColName").html()),
				    colPKIDName:'PKID',
				    colTemplates:GetColTemplates($(".hiddenColTemplates").html()),
				    url:'ContractAdvanceSearchBackCode.aspx',
				    data:{operation:operationType,condition:getSearchConditionTableValue(),colshow:getSetColumnListValue()},
				    error:contractAdvanceSearchErrorfunction,
				    pageLoading:true,
				    getrows:function(row){
			            SetTableColVisible();
			            $("#divResultMessage").html("<span class=\"font14b\">共查询到 </span><span class=\"fontred\">" + row.length + "</span><span class=\"font14b\"> 条记录</span>");
			            if(row.length==0){
			                $.cookie("contractadvancesearchlistindex",0,{expires: 500}) ;
			            }
				    },
				    pageSize:15,
				    afterchangepage:function(pageindex){
				        $.cookie("contractadvancesearchlistindex",pageindex,{expires: 500}) ;
			            SetTableColVisible();
				    },
				    pageindex:GetCookiePageIndex()
    });
    SetTableHeaderVisible();
    $("#divTableList").show();
}
function GetCookiePageIndex()
{
    if(parseInt($.cookie("contractadvancesearchlistindex")))
        return parseInt($.cookie("contractadvancesearchlistindex"));
    else
        return 0;
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
function contractAdvanceSearchErrorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).css("display","block");
    }
}
</script>


