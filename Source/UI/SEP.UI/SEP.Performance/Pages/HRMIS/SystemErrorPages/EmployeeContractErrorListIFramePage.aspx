<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeContractErrorListIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.SystemErrorPages.EmployeeContractErrorListIFramePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
   <div id="EmployeeContractErrorMessage" class="fontred leftitbor" style="display:none;"></div>
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
    </table>
</div>
<div class="tablebt">
<input id="btnSearch" type="button" value="查　询"  class="inputbt" onclick="serachEmployeeContractError();" />
</div>

<div class="linetablediv" id="divTableList"><table id="tbEmployeeContractError" width="100%" ></table></div>
<div style="height:2px"/>



<script language="javascript" type="text/javascript">
$("#divTableList").hide();
function serachEmployeeContractError()
{
     $("#tbEmployeeContractError").SHjqTable({
                    colNames:["","描述","所属公司","部门",""],
				    colPKIDName:'PKID',
				    colTemplates:["","#Description#","#CompanyName#","#DepartmentName#","<a  href=\"#\" onclick='window.open(\"#EditUrl#\")' >更正</a>"],
				    headers:{0: { sorter: false},1: { sorter: false}, 4: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/EmployeeContractErrorListAjax/EmployeeContractErrorListAsyPage.aspx',
				    data:{type:"search",AccountID:$(".txtAccountID").val(),EmployeeName:$("#txtEmployeeName").val(),DepartmentID:$(".ddlDepartment").val()},
				    error:errorfunction,
				    pageLoading:true
    }
    )
   function errorfunction(json)
   {
        for(var i=0;i<json.length;i++){
	      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]);
        }
   }
   
    $("#divTableList").show();
}

</script>

    </form>
</body>
</html>
