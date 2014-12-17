<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceErrorListIFramePage.aspx.cs" Inherits="SEP.Performance.Views.HRMIS.SystemErrors.AttendanceErrorListAjax.AttendanceErrorListIFramePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/BaseScript.js" charset="gb2312"></script>
     <link href="../../CSS/jquery.tablesorter.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.SHjqTable.js" charset="gb2312"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.pager.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"> </asp:ScriptManager>
   <div id="AttendanceErrorMessage" class="fontred leftitbor" style="display:none;"></div>
<div class="edittable">  
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 12%;">
                员工姓名
            </td>
            <td align="left" style="width: 37%">
                <input id="txtEmployeeName" class="input1" type="text" />
            </td>
            <td align="left" style="width: 12%;">
                部门
            </td>
            <td align="left" style="width: 37%">
                <asp:DropDownList ID="ddlDepartment" CssClass="ddlDepartment" runat="server"  >
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td />   
            <td align="left" >
                查询时间
            </td>
            <td align="left"  colspan="4">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                 <asp:TextBox ID="dtpScopeFrom"  runat="server" CssClass="input1 dtpScopeFrom" ></asp:TextBox>
                ---
                 <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1 dtpScopeTo" ></asp:TextBox>
                <span id="AttendancelblScopeMsg" class="psword_f"></span>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
<input id="btnSearch" type="button" value="查　询"  class="inputbt" onclick="serachAttendanceError();" />
</div>

<div class="linetablediv" ><table id="tbAttendanceError" width="100%" ></table></div>
<div style="height:2px"/>



<script language="javascript" type="text/javascript">
$(function(){serachAttendanceError();});
function serachAttendanceError()
{
     $("#tbAttendanceError").SHjqTable({
                    colNames:["","描述","所属公司","部门","排班",""],
				    colWidth:["2%","36%","25%","25%","8%","4%"],
				    colPKIDName:'PKID',
				    colTemplates:["","#Description#","#CompanyName#","#DepartmentName#","<a  href=\"#\" onclick='window.open(\"#PlanDutyUrl#\")' >排班表</a>","<a  href=\"#\" onclick='window.open(\"#EditUrl#\")' >更正</a>"],
				    headers:{0: { sorter: false},1: { sorter: false}, 4: {sorter: false},5: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/AttendanceErrorListAjax/AttendanceErrorListAsyPage.aspx',
				    data:{type:"search",AccountID:$(".txtAccountID").val(),EmployeeName:$("#txtEmployeeName").val(),DepartmentID:$(".ddlDepartment").val(),dtpScopeFrom:$(".dtpScopeFrom").val(),dtpScopeTo:$(".dtpScopeTo").val()},
				    error:errorfunction,
				    pageLoading:true,
				    isHtml:true
    }
    )
   function errorfunction(json)
   {
        for(var i=0;i<json.length;i++){
	      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]);
        }
   }
}

</script>

    </form>
</body>
</html>
