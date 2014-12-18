/**
 * @author Adrian
 */
var model = function(pkid, employeeID, remark, versionNumber, salaryValue) {
    this.PKID = pkid;
    this.EmployeeID = employeeID;
    this.Remark = remark;
    this.VersionNumber = versionNumber;
    this.SalaryValueList = salaryValue;
}
var valuemodel = function(itemid, itemvalue) {
    this.ItemID = itemid;
    this.ItemValue = itemvalue;
}
var SalaryTime, $lblMessage, itemList;
$(document).ready(function() {
    SalaryTime = $("#cphCenter_SetEmployeeSalary1_txtSalaryTime").val();
    $lblMessage = $("#lblMessage");
    com.Search(function() {
        $("#widthfrom").unbind("resize").resize(function() {
            var allWidth = $("#leftitbor2").outerWidth();
            $("#rightVessel").width(allWidth - 79);
            $("#colTitleWidth,#valuesHeightWidth").width(allWidth - 94);
            $("#scrollWidthDiv").width(allWidth - 94);
        })
    });
})
function btnSearch_Click() {
    com.Search();
}

function btnSelectAll_Click() {
    $("#btnSelectAll").hide();
    $("#btnClear").show();
    $("#employeeNameDiv .checkboxName").attr("checked", true);
    
}

function ShowOperation() {
    $("#HideOperationDiv").show();
    $("#showOperationDiv").hide();
    $("#operationDiv").show();
}

function HideOperation() {
    $("#HideOperationDiv").hide();
    $("#showOperationDiv").show();
    $("#operationDiv").hide();
}

function CloseSalaryShow() {
    var $divCloseSalary = $("#divCloseSalary");
    if ($divCloseSalary.css("display") == "none") {
        $divCloseSalary.show();
        $("#txtBtnClose").html("隐藏");
    }
    else {
        $divCloseSalary.hide();
        $("#txtBtnClose").html("封账");
    }
    
}

function btnClear_Click() {
    $("#btnSelectAll").show();
    $("#btnClear").hide();
    $("#employeeNameDiv .checkboxName").attr("checked", false);
}

function btnDelete_Click() {
    com.Delete();
}

function btnTempSave_Click() {
    com.TempSave();
}

function btnAdd_Click() {
    com.Add();
}

function lbUpdateSome_Click() {
    com.InitUpdateSome();
}

function btnUpdateSome_Click() {
    com.UpdateSome();
}

function btnClose_Click() {
    com.Close();
}

function btnReopen_Click() {
    com.Reopen();
}

function linkMail_Click() {
    com.Mail();
}

function btnIn_Click() {

    var data = 
    {
        "type": "Import",
        "SalaryTime": SalaryTime,
        "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val()
    }
    $("body").append("<div class='overlayAjax'></div><div id='pageloading' class='LoadingAjax'>正在读取数据...</div>");
    $.ajaxFileUpload(
    {
        url: 'SetEmployeeSalaryHandler.ashx?' + $.param(data),
        secureuri: false,
        fileElement: $("#fuExcel"),
        dataType: 'json',
        success: function(ans) {
        
            if (ans.error && ans.error.length > 0) {
                alert(ans.error)
                CommonError(ans);
                RemoveOverLayLoding();
            }
            else {
                com.Search(function() {
                    com.SetMessage("导入成功");
                    $("#operationDiv").hide();
                    RemoveOverLayLoding();
                    
                });
            }
        }
    });
    
}


function btnInitial_Click() {
    $.ajaxJson(
    {
        url: "SetEmployeeSalaryHandler.ashx",
        data: 
        {
            type: "Initial",
            "SalaryTime": SalaryTime,
            "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val(),
            "DepartmentId": $("#cphCenter_SetEmployeeSalary1_listDepartment").val()
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                com.Search();
            }
        }
    })
}

function btnExportClient_Click() {
    var data = 
    {
        "type": "Export",
        "EmployeeName": $("#cphCenter_SetEmployeeSalary1_txtName").val(),
        "SalaryTime": SalaryTime,
        "DepartmentId": $("#cphCenter_SetEmployeeSalary1_listDepartment").val(),
        "PositionId": $("#cphCenter_SetEmployeeSalary1_listPossition").val(),
        "AccountSetId": $("#cphCenter_SetEmployeeSalary1_listAccountSet").val(),
        "EmployeeType": $("#cphCenter_SetEmployeeSalary1_listEmployeeType").val(),
        "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val()
    }
    location.href = "SetEmployeeSalaryHandler.ashx?" + $.param(data);
}

var com = 
{
    Search: function(success) {
        $("#btnSearch").attr("disabled", true);
        $("body").append("<div class='overlayAjax'></div><div id='pageloading' class='LoadingAjax'>正在读取数据...</div>");
        $("#colEmployeeName,#rightVessel").hide();
        $.ajax(
        {
            url: "SetEmployeeSalaryHandler.ashx",
            cache: false,
            data: 
            {
                "type": "Search",
                "EmployeeName": $("#cphCenter_SetEmployeeSalary1_txtName").val(),
                "SalaryTime": SalaryTime,
                "DepartmentId": $("#cphCenter_SetEmployeeSalary1_listDepartment").val(),
                "PositionId": $("#cphCenter_SetEmployeeSalary1_listPossition").val(),
                "AccountSetId": $("#cphCenter_SetEmployeeSalary1_listAccountSet").val(),
                "EmployeeType": $("#cphCenter_SetEmployeeSalary1_listEmployeeType").val(),
                "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val()
            
            },
            dataType: "json",
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    com.Salary(ans);
                    RemoveOverLayLoding();
                    $("#btnSearch").attr("disabled", false);
                    if (success) {
                        success();
                    }
                }
            }
        })
    },
    Salary: function(ans) {
        itemList = ans.itemList;
        function Init() {
            com.AllCount();
            if (itemList.length > 0) {
                InitWidth();
                CreateTable();
                BindScrollEvent();
            }
            com.SetStatus(ans.status);
        }
        
        function CreateTable() {
            var $employeeName = $("#employeeNameDiv");
            var $colTitle = $("#colTitle");
            var $valuesDiv = $("#valuesDiv");
            var $emptyDiv = $("<div></div>");
            var $tbTitleHiddenSet = $("#tbTitleHiddenSet");
            $employeeName.empty();
            $colTitle.empty();
            $valuesDiv.empty();
            $tbTitleHiddenSet.empty();
            //title
            var titles = new Array();
            titles.push("帐套名称");
            
            $colTitle.append("<div id='title_0' style='border-left:none;width:120px;' class='coltitle' >帐套名称</div>");
            $.each(itemList[0].SalaryValueList, function(i, item) {
                $colTitle.append("<div  id='title_" + (i + 1) + "' class='coltitle' title='" + item.ItemName + "'>" + item.ItemName + "</div>");
                titles.push(item.ItemName);
            })
            $colTitle.append("<div id='title_" + (itemList[0].SalaryValueList.length + 1) + "'  style='width:119px;' class='coltitle'>备注</div>");
            titles.push("备注");
            //checkbox 用于哪行显示不显示
            for (var i = 0; i < Math.ceil(titles.length / 5); i++) {
            
                var $tb_tr = $("<tr></tr>");
                for (var j = 0; j < 5; j++) {
                    var tindex = i * 5 + j;
                    if (tindex < titles.length) {
                        $tb_tr.append("<td><input onclick='ShowHideTitle(" + tindex + ",this)' type='checkbox' checked='checked' /> " + titles[tindex] + "</td>");
                    }
                    else {
                        $tb_tr.append("<td></td>");
                    }
                }
                $tbTitleHiddenSet.append($tb_tr);
            }
            
            $.each(itemList, function(i, item) {
                //name
                $employeeName.append("<div class='nametr' id='trName_" + item.PKID + "'  pkid='" + item.PKID + "' employeeID='" + item.EmployeeID + "' index='" + i + "' ><input type='checkbox' class='checkboxName' />" + item.EmployeeName + "</div>");
                //value	
                var $tr = $("<div class='valuetr'  id='trValue_" + i + "' VersionNumber='" + item.VersionNumber + "' AccountSetID='" + item.AccountSetID + "'><div class='value_0 values'   style='border-left:none;width:120px;padding-top:6px;height:17px;' valign='middle'><span title='" + item.AccountSetName + "' class='accountName'>" + item.AccountSetName + "</span></div></div>");
                $.each(item.SalaryValueList, function(j, sv) {
                    var editable = "";
                    if (!sv.Editable) {
                        editable = "disabled=disabled";
                    }
                    $tr.append("<div style='width:85px;' class='value_" + (j + 1) + " values'><input itemid='" + sv.ItemID + "' " + editable + " type='text' value='" + sv.ItemValue + "'/></div>");
                });
                $tr.append("<div class='value_" + (item.SalaryValueList.length + 1) + " values' style='width:119px;' valign='middle'><input class='remark' type='text' value='" + item.Remark + "' /></div>");
                $emptyDiv.append($tr);
            })
            $valuesDiv.html($emptyDiv.html());
            $("#employeeNameDiv .nametr:even,#valuesDiv .valuetr:even").addClass("GridViewRowLink");
            $("#employeeNameDiv .nametr:odd,#valuesDiv .valuetr:odd").addClass("table_g");
            $("#colEmployeeName,#rightVessel").show();
            $("#scrollHeight").height($("#employeeNameDiv").height() + 30);
        }
        
        function InitWidth() {
            if ($.browser.msie && $.browser.version == "7.0") {
                $("#colTitleTr").height(27);
            }
            var allWidth = $("#leftitbor2").outerWidth();
            $("#rightVessel").width(allWidth - 79);
            $("#colTitleWidth,#valuesHeightWidth").width(allWidth - 94);
            $("#scrollWidthDiv").width(allWidth - 94);
            var width = itemList[0].SalaryValueList.length * 85 + 240 + itemList[0].SalaryValueList.length;
            $("#valuesDiv,#colTitle,#scrollWidth").width(width);
            
        }
        
        function BindScrollEvent() {
            $("#scrollHeightDiv").scroll(function(event) {
                $("#valuesHeightWidth,#EmployeeNameHeight").scrollTop($(this).scrollTop());
            })
            $("#scrollWidthDiv").scroll(function(event) {
                $("#valuesHeightWidth,#colTitleWidth").scrollLeft($(this).scrollLeft());
            })
        }
        Init();
        
    },
    AllCount: function() {
        $lblMessage.next(".font14b").eq(0).remove();
        $lblMessage.prev(".font14b").eq(0).remove();
        $("<span class='font14b'>共查到</span>").insertBefore($lblMessage);
        $("<span class='font14b'>条记录</span>").insertAfter($lblMessage);
        $lblMessage.html(itemList.length);
    },
    TempSave: function() {
        com.AllCount();
        var vallist = new Array();
        var $this, $tr, index, $valueTr;
        $("#employeeNameDiv .checkboxName").each(function() {
            $this = $(this);
            if ($this.attr("checked")) {
                $tr = $this.closest(".nametr");
                index = $tr.attr("index");
                $valueTr = $("#trValue_" + index);
                var vs = new Array()
                $valueTr.find("input[class!=remark]").each(function() {
                    vs.push(new valuemodel($(this).attr("itemid"), $(this).val()));
                })
                vallist.push(new model($tr.attr("pkid"), $tr.attr("employeeid"), $valueTr.find(".remark").val(), $valueTr.attr("VersionNumber"), vs));
            }
        })
        if (vallist.length > 0) {
            $.ajaxJson(
            {
                url: "SetEmployeeSalaryHandler.ashx",
                data: 
                {
                    type: "TempSave",
                    values: $.toJSON(vallist),
                    "SalaryTime": SalaryTime
                },
                success: function(ans) {
                    com.ReturnMessage(ans, function($trv, item) {
                        $.each(item.SalaryValueList, function(j, sv) {
                            $trv.find("input[itemid =" + sv.ItemID + "]").val(sv.ItemValue);
                        });
                    });
                    if (ans.error.length < 1 && ans.errorItem.length < 1) {
                        alert("保存成功");
                    }
                }
            })
        }
        else {
            com.SetMessage("没有要保存的记录");
        }
        
    },
    
    Delete: function() {
        com.AllCount();
        var vallist = new Array();
        var $this, $tr, index, $valueTr;
        $("#employeeNameDiv .checkboxName").each(function() {
            $this = $(this);
            if ($this.attr("checked")) {
                $tr = $this.closest(".nametr");
                index = $tr.attr("index");
                $valueTr = $("#trValue_" + index);
                vallist.push(new model($tr.attr("pkid"), $tr.attr("employeeid"), $valueTr.find(".remark").val(), $valueTr.attr("VersionNumber"), new Array()));
            }
        })
        if (vallist.length > 0) {
            $.ajaxJson(
            {
                url: "SetEmployeeSalaryHandler.ashx",
                data: 
                {
                    type: "Delete",
                    values: $.toJSON(vallist),
                    "SalaryTime": SalaryTime
                },
                success: function(ans) {
                    com.ReturnMessage(ans, function($trv) {
                        $trv.find("input[class!=remark]").each(function() {
                            $(this).val("");
                        })
                    });
                    if (ans.error.length < 1 && ans.errorItem.length < 1) {
                        alert("删除成功");
                    }
                }
            })
        }
        else {
            com.SetMessage("没有要删除的记录");
        }
    },
    Add: function() {
        com.AllCount();
        var vallist = new Array();
        var $this, $tr, index, $valueTr, checkedBox = $("#employeeNameDiv .checkboxName:checked"),idlist=new Array();
        checkedBox.each(function() {
            $this = $(this);
            $tr = $this.closest(".nametr");
			idlist.push($tr.attr("id"));
            index = $tr.attr("index");
            $valueTr = $("#trValue_" + index);
            vallist.push(new model($tr.attr("pkid"), $tr.attr("employeeid"), $valueTr.find(".remark").val(), $valueTr.attr("VersionNumber"), new Array()));
        })
        if (vallist.length > 0) {
            $.ajaxJson(
            {
                url: "SetEmployeeSalaryHandler.ashx",
                data: 
                {
                    type: "Add",
                    values: $.toJSON(vallist),
                    "SalaryTime": SalaryTime
                },
                success: function(ans) {
                    if (ans.error.length < 1 && ans.errorItem.length < 1) {
                        com.Search(function() {
                            com.ReturnMessage(ans);
							$.each(idlist,function(i,item){
								$("#"+item).children(".checkboxName").attr("checked",true);
							})
                            alert("新增成功");
                        })
                    }
                    else {
                        com.ReturnMessage(ans);
                    }
                }
            })
        }
        else {
            com.SetMessage("没有要新增的记录");
        }
        
    },
    UpdateSomeTR: new Array(),
    InitUpdateSome: function() {
        if ($("#UpdateSomeDiv").css("display") == "none") {
            $("#txtResultMessage").html("");
            $("#UpdateSomeDiv").hide();
            com.UpdateSomeTR = new Array();
            var vallist = new Array();
            var $this, $tr, index, $valueTr, accountsetID = 0, isSameAccount = true, checkedCount = 0;
            $("#employeeNameDiv .checkboxName").each(function() {
                $this = $(this);
                if ($this.attr("checked")) {
                    checkedCount++;
                    $tr = $this.closest(".nametr");
                    index = $tr.attr("index");
                    $valueTr = $("#trValue_" + index);
                    com.UpdateSomeTR.push($valueTr);
                    if (accountsetID == 0) {
                        accountsetID = $valueTr.attr("AccountSetID");
                    }
                    else 
                        if (accountsetID != $valueTr.attr("AccountSetID")) {
                            com.SetMessage("请选择同一个帐套");
                            isSameAccount = false;
                            return false;
                        }
                }
            })
            if (checkedCount < 1) {
                com.SetMessage("请选择一个员工");
            }
            if (checkedCount > 0 && isSameAccount) {
                com.AllCount();
                $.ajaxJson(
                {
                    url: "SetEmployeeSalaryHandler.ashx",
                    data: 
                    {
                        type: "BindddlAccountSetItem",
                        "accountSetID": accountsetID
                    },
                    success: function(ans) {
                        if (ans.error && ans.error.length > 0) {
                            CommonError(ans);
                        }
                        else {
                            $("#ddlAccountSetItem").empty();
                            $.each(ans.itemList, function(i, item) {
                                $("#ddlAccountSetItem").append("<option value='" + item.value + "'>" + item.Text + "</option>");
                            })
                            $("#UpdateSomeDiv").show();
                            $("#txtUpdateSome").html("隐藏修改");
                        }
                    }
                })
            }
        }
        else {
            $("#txtUpdateSome").html("批量修改");
            $("#UpdateSomeDiv").hide();
        }
    },
    UpdateSome: function() {
        $("#txtResultMessage").html("");
        var itemid = $("#ddlAccountSetItem").val();
        var value = $("#txtResult").val();
        if (/^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(value)) {
            $.each(com.UpdateSomeTR, function(i, item) {
                item.find("input[itemid =" + itemid + "]").val(value);
            });
            $("#UpdateSomeDiv").hide();
            alert("修改成功");
        }
        else {
            $("#txtResultMessage").html("格式错误");
        }
    },
    Close: function() {
        $.ajaxJson(
        {
            url: "SetEmployeeSalaryHandler.ashx",
            data: 
            {
                type: "Close",
                "SalaryTime": SalaryTime,
                "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val(),
                "IsSendEmail": $("#cbIsSendEmail").attr("checked"),
                "DepartmentId": $("#cphCenter_SetEmployeeSalary1_listDepartment").val()
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    com.SetStatus("closed");
                    $("#divCloseSalary").hide();
                    
                }
            }
        })
        
    },
    Reopen: function() {
        $.ajaxJson(
        {
            url: "SetEmployeeSalaryHandler.ashx",
            data: 
            {
                type: "Reopen",
                "SalaryTime": SalaryTime,
                "CompanyId": $("#cphCenter_SetEmployeeSalary1_hfCompanyID").val(),
                "DepartmentId": $("#cphCenter_SetEmployeeSalary1_listDepartment").val()
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    com.SetStatus("reopen");
                    com.Search(function() {
                        com.SetMessage("本月工资已解封");
                    });
                }
            }
        })
    },
    Mail: function() {
        var vallist = new Array();
        var $this, $tr;
        $(".checkboxName").each(function() {
            $this = $(this);
            if ($this.attr("checked")) {
                $tr = $this.closest(".nametr");
                vallist.push($tr.attr("employeeid"));
            }
        })
        if (vallist.length > 0) {
            $.ajaxJson(
            {
                url: "SetEmployeeSalaryHandler.ashx",
                data: 
                {
                    type: "Mail",
                    "SalaryTime": SalaryTime,
                    "EmployeeIDs": $.toJSON(vallist)
                },
                success: function(ans) {
                    if (ans.error && ans.error.length > 0) {
                        CommonError(ans);
                    }
                    else {
                        com.SetMessage("邮件发送成功");
                    }
                }
            })
        }
        else {
            com.SetMessage("没有要发送的邮件");
        }
        
    },
    ReturnMessage: function(ans, otherf) {
        $("#employeeNameDiv .nametr:even,#valuesDiv .valuetr:even").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("GridViewRowLink");
        $("#employeeNameDiv .nametr:odd,#valuesDiv .valuetr:odd").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("table_g");
        if (ans.error && ans.error.length > 0) {
            CommonError(ans);
        }
        if (ans.errorItem.length > 0) {
            $.each(ans.errorItem, function(i, item) {
                var $tr = $("#trName_" + item.PKID);
                $tr.removeClass("table_g").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("errorTR");
                var $trv = $("#trValue_" + $tr.attr("index"));
                $trv.removeClass("table_g").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("errorTR");
            })
        }
        if (ans.successItem.length > 0) {
            $.each(ans.successItem, function(i, item) {
                var $tr = $("#trName_" + item.PKID);
                $tr.removeClass("table_g").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("successTR");
                var $trv = $("#trValue_" + $tr.attr("index"));
                $trv.attr("VersionNumber", item.VersionNumber);
                $trv.removeClass("table_g").removeClass("GridViewRowLink").removeClass("successTR").removeClass("errorTR").addClass("successTR");
                if (otherf) {
                    otherf($trv, item);
                }
            })
        }
    },
    SetMessage: function(ans) {
        $lblMessage.next(".font14b").eq(0).remove();
        $lblMessage.prev(".font14b").eq(0).remove();
        $lblMessage.html(ans);
    },
    SetStatus: function(status) {
        if (status == "noRecord") {
            $("#btnInitial").attr("disabled", false);
            $("#btnClose,#btnReopen,#btnTempSave,#btnDelete,#btnAdd,#lbUpdateSome,#btnSelectAll,#btnClear,#linkMail").attr("disabled", true);
        }
        else 
            if (status == "closed") {
                $("#btnReopen,#linkMail").attr("disabled", false);
                $("#btnInitial,#btnClose,#btnTempSave,#btnDelete,#btnAdd,#lbUpdateSome,#btnSelectAll,#btnClear").attr("disabled", true);
                com.SetMessage("本月工资已封帐");
            }
            /*
         else if(status=="reopen"){
         $("#btnReopen,#linkMail").attr("disabled",true);
         $("#btnInitial,#btnClose,#btnTempSave,#btnDelete,#btnAdd,#lbUpdateSome,#btnSelectAll,#btnClear").attr("disabled",false);
         }
         */
            else {
                $("#btnReopen,#linkMail").attr("disabled", true);
                $("#btnInitial,#btnClose,#btnTempSave,#btnDelete,#btnAdd,#lbUpdateSome,#btnSelectAll,#btnClear").attr("disabled", false);
            }
    }
    
}
function showsearchform(th, showboolean) {
    if (showboolean == 1) {
        $(th).attr("class", "salarybtbg");
    }
    else {
        $(th).attr("class", "salarybtbg0");
    }
}

function ShowHideTitle(index, th) {
    if ($(th).attr("checked")) {
        $("#title_" + index).show();
        $("#valuesDiv .value_" + index).show();
    }
    else {
        $("#title_" + index).hide();
        $("#valuesDiv .value_" + index).hide();
    }
    
}
