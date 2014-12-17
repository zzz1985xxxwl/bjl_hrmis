<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    CodeBehind="EmployeeSalaryHistoryStatistics.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.EmployeeSalaryHistoryStatistics" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <script language="javascript " type="text/javascript" src="../../Inc/jquery-ui-min.js"
        charset="gb2312"></script>
    <link href="../../Inc/FixTable/jquery.FixTable.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.json-2.2.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/FixTable/jquery.FixTable.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/handlebars-1.0.rc.1-min.js"></script>
    <div class="leftitbor2">
        <span>员工薪资统计</span>
    </div>
    <div class="edittable" id="searchDiv">
        <table width="100%" border="0">
            <tr>
                <td style="width: 2%;">
                </td>
                <td align="left" style="width: 8%;">
                    员工姓名
                </td>
                <td align="left" style="width: 20%;">
                    <input type="text" name="EmployeeName" />
                </td>
                <td align="left" style="width: 8%;">
                    发薪月份
                </td>
                <td align="left" style="width: 60%;">
                    <input type="text" name="DateTimeFrom" />--<input type="text" name="DateTimeTo" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    帐套项
                </td>
                <td colspan="3" align="left">
                    <input type="text" name="AccountParam" style="width: 75%" />
                    &nbsp;
                    <input type="button" class="inputbt" value="查　询" id="btnSearch" />
                    &nbsp;
                    <input type="button" class="inputbt" value="保存条件" id="btnSaveSearch" />
                </td>
            </tr>
        </table>
    </div>
    <div id="gridDiv" class="fixGridMainDiv" style="margin: 0 8px;">
    </div>
    <script id="grid-template" type="text/x-handlebars-template">
       <table id="grid">
            <thead>
                <tr>
                    <th>
                        <div style='width: 60px'>
                            发薪月份</div>
                    </th>
                    <th>
                        <div style='width: 120px'>
                            帐套</div>
                    </th>
                     {{#each 0.AccountSetItem}}
                      <th>
                            <div style='width: 100px'>
                                {{Name}}</div>
                      </th>
                     {{/each}}
                     <th>  
                        <div style='width: 100px'></div>
                     </th>
                     <th>  
                        <div style='width: 100px'></div>
                     </th>
                      <th>  
                        <div style='width: 100px'></div>
                     </th>
                      <th>  
                        <div style='width: 100px'></div>
                     </th>
                      <th>  
                        <div style='width: 100px'></div>
                     </th>
                      <th>  
                        <div style='width: 100px'></div>
                     </th>
                      <th>  
                        <div style='width: 100px'></div>
                     </th>
                </tr>
            </thead>
            <tbody>
                {{#each this}}
                <tr>
                    <td>  {{SalaryDate}}
                    </td>
                    <td> {{AccountSetName}}
                    </td>
                    {{#each AccountSetItem}}
                      <td>
                           {{Value}}
                      </td>
                     {{/each}}
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                </tr>
                 {{/each}}
            </tbody>
        </table>
    </script>
    <script type="text/javascript">
        var searchParam = app.util.getEditParam($("#searchDiv")),
        tableHtml = $("#grid-template").html(),
        $gridDiv = $("#gridDiv");
        $(document).ready(function () {
            searchParam.EmployeeName.autocomplete("../../GoogleDown.ashx?type=AllAccount", { mouseovershow: false, mustMatch: true });
            searchParam.AccountParam.autocomplete("../../GoogleDown.ashx?type=AccountSetPara", { mouseovershow: false,mustMatch:true ,multiple:true,multipleSeparator:";"});
            searchParam.DateTimeFrom.datepicker({ dateFormat: 'yy-mm' });
            searchParam.DateTimeTo.datepicker({ dateFormat: 'yy-mm' });
            if (app.util.storage.get("eshs_info")) {
                var s = $.evalJSON(app.util.storage.get("eshs_info"));
                for (var key in s) {
                    searchParam[key].val(s[key]);
                }
            }
            $("#btnSaveSearch").click(function(){
                var sp = app.util.serializeParamArray(searchParam);
                app.util.storage.set("eshs_info", $.toJSON(sp));
                alert("查询条件保存成功");
            })
            $("#btnSearch").click(function () {
                Search();
            });
            if (searchParam.EmployeeName.val() != "") {
                Search();
            }

            function Search() {
                if (searchParam.EmployeeName.val() == "") {
                    alert("员工姓名不可为空");
                    return;
                }
                if (searchParam.AccountParam.val() == "") {
                    alert("帐套项不可为空");
                    return;
                }
                var searchParams = app.util.serializeParamArray(searchParam);
                $.ajaxJson({
                    url: "EmployeeSalaryHistoryStatisticsHandler.ashx?type=Search",
                    data: searchParams,
                    success: function (ans) {
                        if (ans.Error) {
                            alert(ans.Error);
                        }
                        var template = Handlebars.compile(tableHtml);
                        $gridDiv.empty().append(template(ans));
                        $("#grid").FixTable({ columnIndex: 2 });
                        $gridDiv.find("div.fixTableLeftDiv tr:last").addClass("fblue");
                        $gridDiv.find("div.fixTableBodyDiv tr:last").addClass("fblue");
                    }
                })
            }
        })
    </script>
</asp:Content>
