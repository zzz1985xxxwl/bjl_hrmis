<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="SEP.Performance.Pages.SearchEmployee" %>
<%@ Import Namespace="ShiXin.Security" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeTableView.ascx" TagName="EmployeeTableView"
    TagPrefix="uc4" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeListView.ascx" TagName="EmployeeListView"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="server">
<script type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.lightbox-0.5.js"></script>
<link href="../../CSS/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
<div class="leftitbor">
        <span id="lblMessage" class="fontred"></span>
    </div>
<div class="leftitbor2">
   <div style="float: left;">
    <span >查询员工</span></div>
    <div style="clear:both;"></div>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 25%">
               <input type="text" id="txtName" class="input1" style="width:40%;"/>
            </td>
            <td align="left" style="width: 8%;">
                职位
            </td>
            <td align="left" style="width: 25%">
                <select id="listPossition"  style=" width:40%; height:24px;"></select>
            </td>
            <td align="left" style="width: 8%;">
                职系
            </td>
            <td align="left" style="width: 25%">
                <select id="ddGrades"  style=" width:40%; height:24px;"></select>
            </td>
        </tr>
        <tr>
            <td align="left" >
            </td>
            <td align="left">
                员工类型
            </td>
            <td align="left" >
                <select id="listEmployeeType"  style=" width:40%; height:24px;"></select>
            </td>
            <td align="left" >
                部门
            </td>
            <td align="left" >
                <select id="listDepartment"  style=" width:40%; height:24px;"></select>
                <input type="checkbox" id="cbRecursionDepartment" checked="checked" />包括子部门
            </td>
            <td align="left">
                司龄
            </td>
            <td align="left">
                <input type="text" id="txtCompanyAgeFrom" class="input1" style="width:18%;"/>---
                <input type="text" id="txtCompanyAgeTo" class="input1" style="width:18%;"/>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                员工状态
            </td>
            <td align="left">
                <select id="ddlEmployeeStatus"  style=" width:40%; height:24px;">
                <option value="-1" ></option>
                <option value="0" selected="selected">在职</option>
                <option value="1">离职</option>
                </select>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <input type="button" id="btnSearch" value="查　询" class="inputbt" onclick="" />
</div>
<div class="linetablediv">
<table id="grid" class="tbStyle" width="100%" style="border-collapse: collapse;
            text-align: left"></table>
</div>
<script language="javascript" type="text/javascript" >
    $(document).ready(function () {
        Init();
        $("#btnSearch").click(function () {
            Search();
        });
    });
    function Init() {
        $.ajaxJson(
    {
        url: 'SearchEmployee.ashx',
        data:
        {
            type: "Init"
        },
        success: function (ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else if (ans.item != null) {
                if (ans.item.PossitionList && ans.item.PossitionList.length > 0) {
                    $("#listPossition").empty();
                    for (var i = 0; i < ans.item.PossitionList.length; i++) {
                        var item = ans.item.PossitionList[i];
                        $("#listPossition").append("<option value='" + item.PKID + "' >" + item.Name + "</option>");
                    }
                }
                if (ans.item.DepartmentList && ans.item.DepartmentList.length > 0) {
                    $("#listDepartment").empty();
                    for (var i = 0; i < ans.item.DepartmentList.length; i++) {
                        var item = ans.item.DepartmentList[i];
                        $("#listDepartment").append("<option value='" + item.PKID + "' >" + item.Name + "</option>");
                    }
                }
                if (ans.item.EmployeeTypeList && ans.item.EmployeeTypeList.length > 0) {
                    $("#listEmployeeType").empty();
                    for (var i = 0; i < ans.item.EmployeeTypeList.length; i++) {
                        var item = ans.item.EmployeeTypeList[i];
                        $("#listEmployeeType").append("<option value='" + item.PKID + "' >" + item.Name + "</option>");
                    }
                }
                if (ans.item.GradesTypeList && ans.item.GradesTypeList.length > 0) {
                    $("#ddGrades").empty();
                    for (var i = 0; i < ans.item.GradesTypeList.length; i++) {
                        var item = ans.item.GradesTypeList[i];
                        $("#ddGrades").append("<option value='" + item.PKID + "' >" + item.Name + "</option>");
                    }
                }
                Search();
            }
        }
    });
    }
    function Search() {
        $("#grid").SXTable(
    {
        colNames: ["", "员工姓名", "员工类型", "所属部门", "所属公司", "职位", "入职时间"],
        colWidth: ["2%", "15%", "10%", "20%", "20%", "15%", "18%"],
        colTemplates: [" ", "#EmployeeName#", "#EmployeeType#", "#Department#", "#Company#", "#Position#", "#WorkTime#"],
        url: 'SearchEmployee.ashx',
        data:
        {
            type: "Search",
            EmployeeName: $("#txtName").val(),
            employeeType: $("#listEmployeeType").val(), 
            positionID:$("#listPossition").val(),            
            departmentID : $("#listDepartment").val(),
            recursionDepartment: $("#cbRecursionDepartment").attr("checked"),
            gradesID:$("#ddGrades").val(),
            ageFrom:$("#txtCompanyAgeFrom").val(),
            ageTo:$("#txtCompanyAgeTo").val(),
            EmployeeStatusId: $("#ddlEmployeeStatus").val()
        },
        pageSize: 10,
        success: Success
    });

}
function Success(methods) {
    sxTableMethods = methods;
    MakeCount();
    $("#grid").find(".info").each(function () {
        $(this).click(function () {
            window.open('../../HRMIS/EmployeePages/EmployeeViewDetail.aspx?employeeID=' + $(this).attr("pkid"), 'PopupWindow');
        });
    });
    $("#grid").find("tbody tr").each(function () {
        $(this).css("cursor", "pointer");
        $(this).click(function () {
            window.open('../../HRMIS/EmployeePages/EmployeeViewDetail.aspx?employeeID=' + $(this).find(".info").attr("pkid"), 'PopupWindow');
        });
    });
}
function MakeCount() {
    $("#lblMessage").next(".font14b").eq(0).remove();
    $("#lblMessage").prev(".font14b").eq(0).remove();
    $("<span class='font14b'>共查到</span>").insertBefore("#lblMessage");
    $("<span class='font14b'>条记录</span>").insertAfter("#lblMessage");
    $('#lblMessage').html(sxTableMethods.allitems().length);
}
</script>
</asp:Content>
