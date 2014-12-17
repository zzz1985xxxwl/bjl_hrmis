<%@ Control Language="C#" AutoEventWireup="true" Codebehind="WorkTaskInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.WorkTasks.WorkTaskInfoView" %>
<%@ Register Src="../Choose/ChooseAccountView.ascx" TagName="ChooseAccountView" TagPrefix="uc1" %>
<div id="dialogMessage" class="leftitbor" style="display: none;">
    <span id="dialoglblMessage" class="fontred"></span>
    <input id="hfRowID" type="hidden" />
    <input id="hfQAID" type="hidden" />
</div>
<div class="edittable" style="width: 96%; background-color: #e6e6e6;">
    <div class="graytab">
        <div class="graytabactive hand" id="basicinfolink" onclick="show(this,'basicinfo')">
            工作计划</div>
        <div class="graytabnotactive hand" id="qainfolink" onclick="show(this,'qainfo');"
            isload="false">
            留言(<span id="info_QACount">0</span>条)</div>
    </div>
    <div style="border: solid 1px #bcbcbc; background-color: White" class="basicinfo">
        <table width="100%" border="0" style="text-align: left;">
            <tr>
                <td width="1%">
                </td>
                <td width="9%">
                    任务名称</td>
                <td width="90%" colspan="3">
                    <input type="text" id="info_Title" valid="title" style="width: 90%;" />
                </td>
            </tr>
            <tr>
                <td width="1%">
                </td>
                <td width="9%">
                    开始时间</td>
                <td width="41%">
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                        TargetControlID="info_StartDate">
                    </ajaxToolKit:CalendarExtender>
                    <asp:TextBox ID="info_StartDate" valid="date" runat="server" CssClass="dialogCommencement"
                        Width="25%"></asp:TextBox>-- 完成时间
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
                        TargetControlID="info_EndDate">
                    </ajaxToolKit:CalendarExtender>
                    <asp:TextBox ID="info_EndDate" valid="date" runat="server" CssClass="dialogCommencement"
                        Width="25%"></asp:TextBox>
                </td>
                <td width="8%">
                    优先级
                </td>
                <td width="41%">
                    <asp:DropDownList ID="info_Priority" runat="server" CssClass="info_Priority" Width="60%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style=" vertical-align:top;">
                <td>
                </td>
                <td colspan="2">
                    <uc1:ChooseAccountView ID="ChooseAccountView1" runat="server" />
                </td>
                <td>
                    当前状态
                </td>
                <td>
                    <asp:DropDownList ID="info_Status" runat="server" CssClass="info_Status" Width="60%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    工作内容</td>
                <td colspan="3">
                    <textarea id="info_Content" valid="title" cols="1" rows="2" style="width: 90%"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    当前状态工作描述</td>
                <td colspan="3">
                    <textarea id="info_Description" cols="1" rows="4" style="width: 90%"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    备注</td>
                <td colspan="3">
                    <textarea id="info_Remark" cols="1" rows="2" style="width: 90%"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td colspan="3">
                    <input id="info_IfEmail" type="checkbox" />发邮件通知 <span class='fontblue2'>上级领导<asp:Label runat="server" ID="lblLeaderName"></asp:Label></span> 以及 <span class='fontblue2'>相关负责人</span> 我更新了工作计划
                </td>
            </tr>
        </table>
    </div>
    <div style="border: solid 1px #bcbcbc; background-color: White;" class="hiddenformdiv qainfo" > 
        <div id="info_AddQA" >
            <table width="100%" border="0" style="text-align: left">
                <tr>
                    <td width="1%">
                    </td>
                    <td width="9%">
                        发表留言</td>
                    <td width="90%" colspan="2">
                        <textarea id="taInfo_AddQA" cols="1" rows="2" style="width: 90%;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="width:74%">
                        <input id="ifMailAddQA" type="checkbox" />发邮件提醒 
                        <span id="info_QAAAcount" class="fontblue2"></span>&nbsp;我的留言信息
                    </td>
                    <td>
                        <input id="btnAddQA" value="留言" class="inputgraybt" type="button" onclick="AddQA();"/>
                    </td>
                </tr>
            </table>
        </div>
        <div id="info_searchTable" class="WorkTaskQA">
        </div>
    </div>
</div>
<div class="tablebt">
    <input id="btnOK" value="确定" class="inputbt" type="button" />
    <input id="btnCancel" value="取消" class="inputbt" type="button" onclick="CloseDialog();" />
</div>

<script type="text/javascript" language="javascript" id="初始化">
var $btnOK, ifOwner=0;
var $info_ID, $info_Title, $info_StartDate, $info_EndDate,$info_Priority,$info_Responsibles;
var $info_Status,$info_Content,$info_Description,$info_Remark,$info_IfEmail;
var $info_QAAAcount,$taInfo_AddQA,$ifMailAddQA,$info_QAID;

function FlushMyWorkTaskInfo(){
    if($("#AccountIDInRightList").html()==$(".LoginAccountID").html())
    {SearchOwnerWorkTask();}
}

function InfoLoad() {
    $btnOK = $("#btnOK");
    $info_searchTable = $("#info_searchTable");
    
    $info_ID = $("#hfRowID");
    $info_QAID = $("#hfQAID");
    $info_Title =  $("#info_Title");
    $info_StartDate = $("#cphCenter_WorkTaskInfoView1_info_StartDate");
    $info_EndDate = $("#cphCenter_WorkTaskInfoView1_info_EndDate");
    $info_Priority = $(".info_Priority");
    $info_Responsibles = $(".txtAccount");
    $info_Status = $(".info_Status");
    $info_Content = $("#info_Content");
    $info_Description = $("#info_Description");
    $info_Remark = $("#info_Remark");
    $info_IfEmail = $("#info_IfEmail");
    
    $info_QAAAcount = $("#info_QAAAcount");
    $taInfo_AddQA = $("#taInfo_AddQA");
    $ifMailAddQA = $("#ifMailAddQA");
    
    $("#dialog").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 800
    });
}

function InitDialog() {
    $("#ChooseAccoutTable tr:eq(0) td:eq(0)").attr("width","17%");
    $("#ChooseAccoutTable tr:eq(0) td:eq(1)").attr("width","83%");

    InfoLoad();
    CleanMessage();
    $info_searchTable.empty();
    $("#info_QACount").text(0);
    
    $info_ID.val(0);
    $info_QAID.val(0);
    $info_Status.val(0);  
    $info_Priority.val(0);
    $info_Title.val("");
    $info_StartDate.val("");
    $info_EndDate.val("");
    $info_Responsibles.val("");
    $info_Content.val("");
    $info_Description.val("");
    $info_Remark.val("");
    $info_IfEmail.find("input[type=checkbox]").each(function(i){$(this).attr("checked",false);});
    
    $info_QAAAcount.text("");
    $taInfo_AddQA.val("");
    $ifMailAddQA.find("input[type=checkbox]").each(function(i){$(this).attr("checked",false);});
    
    $("#basicinfolink").click();
}

function show(th,showdivclass)
{
    $(th).parent("div").next("div").hide();
    $(th).parent("div").next("div").next("div").hide();
    $(th).parent("div").next("div").next("div").next("div").hide();
    $(th).parent("div").next("div").next("div").next("div").next("div").hide();
    $(th).parent("div").parent("div").find("."+showdivclass).eq(0).show();
    $(th).parent("div").find(".graytabactive").each(function(i){RemoveClass($(this),"graytabactive");AddClass($(this),"graytabnotactive");});
    RemoveClass($(th),"graytabnotactive");
    AddClass($(th),"graytabactive");
}

var sxValidation = new SXValidation(
{
    valid: 
    {
        rules: 
        {
            title: 
            {
                required: true
            },
            date: 
            {
                date: true
            }
        },
        messages: 
        {
            title: 
            {
                required: "不可为空"
            },
            date: 
            {
                date: "时间格式错误"
            }
        }
    }
});

function Enable(enabled){
    $info_Title.attr("disabled",enabled);
    $info_StartDate.attr("disabled",enabled);
    $info_EndDate.attr("disabled",enabled);
    $info_Priority.attr("disabled",enabled);
    $info_Responsibles.attr("disabled",enabled);
    $("#SearchImg").attr("disabled",enabled);
    $info_Status.attr("disabled",enabled);
    $info_Content.attr("disabled",enabled);
    $info_Description.attr("disabled",enabled);
    $info_Remark.attr("disabled",enabled);
    $info_IfEmail.attr("disabled",enabled);
}
</script>

<script type="text/javascript" language="javascript" id="增">
 
function AddShowDialog() {
    $('#dialog').dialog('option', 'title', '新增工作计划');
    InitDialog();
    Enable(false);
    $btnOK.unbind().click(function() {
        Add();
    });
    document.getElementById("info_AddQA").style.display = "none";
    $('#dialog').dialog('open');
}

function CloseDialog(){
$("#dialog").dialog("close")
}

function Add() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'WorkTaskManageHandle.ashx',
            data: 
            {
                type: "AddWorkTask",
                info_Title: $.trim($info_Title.val()),
                info_StartDate: $.trim($info_StartDate.val()),
                info_EndDate: $.trim($info_EndDate.val()),
                info_Priority: $info_Priority.val(),
                info_Responsibles: $.trim($info_Responsibles.val()),
                info_Status: $info_Status.val(),
                info_Content: $.trim($info_Content.val()),
                info_Description: $.trim($info_Description.val()),
                info_Remark: $.trim($info_Remark.val()),
                info_IfEmail: $("#info_IfEmail").attr("checked")
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    alert("操作成功");                
                    $('#dialog').dialog('close');
                    FlushMyWorkTaskInfo();
                }
            }
        });
    }
}

</script>

<script type="text/javascript" language="javascript" id="改">
function UpdateShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '修改工作计划');
    InitDialog();
    Enable(false);
    $info_ID.val(pkid);
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "GetWorkTaskByID",
            Pkid: pkid
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $info_Title.val(ans.item.Title);
                $info_StartDate.val(ans.item.StartDate);
                $info_EndDate.val(ans.item.EndDate);
                $info_Responsibles.val(ans.item.ResponsiblesName);
                $info_Content.val(ans.item.Content);
                $info_Description.val(ans.item.Description);
                $info_Remark.val(ans.item.Remark);
                $info_Status.val(ans.item.Status);  
                $info_Priority.val(ans.item.Priority);
                $info_QAAAcount.append(ans.item.OwerName);
                
                if(ans.item.OwerID == $('.LoginAccountID').html())
                {
                    ifOwner = 1;
                    document.getElementById("info_AddQA").style.display = "none";
                }
                else
                {
                    ifOwner = 0;
                    document.getElementById("info_AddQA").style.display = "block";
                }
                $btnOK.unbind().click(function() {
                    Update();
                });
                $('#dialog').dialog('open');
            }
        }
    });
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "GetWorkTaskQAByWorkTaskID",
            Pkid: pkid
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else 
            {
                $("#info_QACount").text(ans.item.length); 
                if(ans.item == null || ans.item.length == 0)
                {
                    document.getElementById("info_searchTable").style.display = "none";
                } 
                if (ans.item && ans.item.length >= 0)
                { 
                    document.getElementById("info_searchTable").style.display = "block";
                    itemArray = ans.item;
                    BuildTable(itemArray);
                }
            }
        }
    });
}

function Update() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'WorkTaskManageHandle.ashx',
            data: 
            {
                type: "UpdateWorkTask",
                Pkid: $.trim($info_ID.val()),
                info_Title: $.trim($info_Title.val()),
                info_StartDate: $.trim($info_StartDate.val()),
                info_EndDate: $.trim($info_EndDate.val()),
                info_Priority: $info_Priority.val(),
                info_Responsibles: $.trim($info_Responsibles.val()),
                info_Status: $info_Status.val(),
                info_Content: $.trim($info_Content.val()),
                info_Description: $.trim($info_Description.val()),
                info_Remark: $.trim($info_Remark.val()),
                info_IfEmail: $("#info_IfEmail").attr("checked")
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                   CommonError(ans);
                }
                else {
                    alert("操作成功");
                    $('#dialog').dialog('close');
                    FlushMyWorkTaskInfo();
                }
            }
        });
    }
}
</script>

<script type="text/javascript" language="javascript" id="删">

function Delete(Confirmed, pkid) {
    if (Confirmed) {
        $.ajaxJson(
        {
            url: 'WorkTaskManageHandle.ashx',
            data: 
            {
                type: "DeleteWorkTask",
                Pkid: pkid
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    alert("操作成功");
                    FlushMyWorkTaskInfo();
                }
            }
        });
    }
}

</script>

<script type="text/javascript" language="javascript" id="详情">
function DetailShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '工作计划详情');
    InitDialog();
    $info_ID.val(pkid);
    Enable(true);
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "GetWorkTaskByID",
            Pkid: pkid
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $info_Title.val(ans.item.Title);
                $info_StartDate.val(ans.item.StartDate);
                $info_EndDate.val(ans.item.EndDate);
                $info_Responsibles.val(ans.item.ResponsiblesName);
                $info_Content.val(ans.item.Content);
                $info_Description.val(ans.item.Description);
                $info_Remark.val(ans.item.Remark);
                $info_Status.val(ans.item.Status);  
                $info_Priority.val(ans.item.Priority);
                $info_QAAAcount.append(ans.item.OwerName);
                
                if(ans.item.OwerID == $('.LoginAccountID').html())
                {
                    ifOwner = 1;
                    document.getElementById("info_AddQA").style.display = "none";
                }
                else
                {
                    ifOwner = 0;
                    document.getElementById("info_AddQA").style.display = "block";
                }
                $btnOK.unbind().click(function() {
                    CloseDialog();
                });
                $('#dialog').dialog('open');
            }
        }
    });
    GetWorkTaskQAByWorkTaskID(pkid);
}
function GetWorkTaskQAByWorkTaskID(pkid)
{
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "GetWorkTaskQAByWorkTaskID",
            Pkid: pkid
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else 
            {
                $("#info_QACount").text(ans.item.length); 
                if(ans.item == null || ans.item.length == 0)
                {
                    document.getElementById("info_searchTable").style.display = "none";
                } 
                if (ans.item && ans.item.length >= 0)
                { 
                    document.getElementById("info_searchTable").style.display = "block";
                    itemArray = ans.item;
                    BuildTable(itemArray);
                }
            }
        }
    });

}
function BuildTable(items)
{
    $info_searchTable.empty();
    for (var i = 0; i < items.length; i++) 
    {      
        var item = items[i];
        var s ="<div style='margin-left:20px; margin-top:10px; width:90%;'><div>"
        +"<p class='fontblue2'>"+item.QAccount+"<span class='fontgray2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;于"+item.QuestionDate+"&nbsp;&nbsp;的留言</span>";
        if(ifOwner == 0 && item.QAccountID == $('.LoginAccountID').html())
        {
            s += "&nbsp;&nbsp;<span id='EditQASpan"+item.PKID+"' class='fontgray2' style=' cursor:pointer;' onclick='ShowUpdateQA("+item.PKID+");'>编辑</span>";
        }
        else if(ifOwner == 1&&item.AAccount.length==0)
        {
            s += "&nbsp;&nbsp;<span id='AnswerQASpan"+item.PKID+"' class='fontgray2' style=' cursor:pointer;' "
            +"onclick='ShowAnswerQA("+item.PKID+");'>回复留言</span>";
        }
        s += "</p></div>"
        +"<div style='padding-top:5px;'><div id='SpanUpdateQA"+item.PKID+"'>"+item.Question+"</div>"
        +"<div id='DivUpdateQA"+item.PKID+"' style='display:none'>"
        +"<table width='100%' border='0' style='text-align: left'>"
        +"<tr><td width='90%' colspan='2'><textarea id='Info_UpdateQA"+item.PKID+"' cols='1' rows='2' style='width: 99%;'></textarea></td></tr>"
        +"<tr><td width='80%'><input id='ifMailAddQA"+item.PKID+"' type='checkbox' />发邮件提醒"
        +" <span id='info_QAAAcount' class='fontblue2'>"+$info_QAAAcount.text()+"</span> 我的留言信息</td><td width='18%'>"
        +"<input id='btnUpdateQA"+item.PKID+"' value='留言' class='inputgraybt' type='button' onclick='UpdateQA("+item.PKID+");'/>"
        +"<input id='btnCloseUpdateQA"+item.PKID+"'value='取消' class='inputgraybt' type='button' onclick='CloseUpdateQA("+item.PKID+");'/></td></tr></table></div></div>" 
        +"<div style='margin-left:45px;margin-top: 10px; '>";
        
        if(item.AAccount.length>0)
        {
            s +="<div><p class='fontblue2'>"+ item.AAccount+"<span class='fontgray2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;于"+item.AnswerDate+"&nbsp;&nbsp;的回复";
            if(ifOwner == 1)
            {
                s += "&nbsp;&nbsp;<span id='AnswerQASpan"+item.PKID+"' class='fontgray2' style=' cursor:pointer;' "
                +"onclick='ShowAnswerQA("+item.PKID+");'>编辑</span>";
            }
            s+= "</span></p></div>";
        }
         
        s +="<div id='SpanAnswerQA"+item.PKID+"'>"+item.Answer+"</div>";
        
        s +="<div id='DivAnswerQA"+item.PKID+"' style='display:none'>"
        +"<table width='100%' border='0' style='text-align: left'>"
        +"<tr><td width='9%'>回复</td>"
        +"<td width='90%' colspan='2'><textarea id='Info_AnswerQA"+item.PKID+"' cols='1' rows='2' style='width: 99%;'></textarea></td></tr>"
        +"<tr><td></td><td width='68%'><input id='ifMailAnswerQA"+item.PKID+"' type='checkbox' />发邮件提醒"
        +" <span class='fontblue2'>"+item.QAccount+"</span> 我的回复信息</td><td>"
        +"<input id='btnAnswerQA"+item.PKID+"' value='回复' class='inputgraybt' type='button' onclick='AnswerQA("+item.PKID+");'/>"
        +"<input id='btnCloseAnswerQA"+item.PKID+"'value='取消' class='inputgraybt' type='button' onclick='CloseAnswerQA("+item.PKID+");'/></td></tr></table></div>" 
        
        s += "</div>";
        if(i<items.length-1)
        {
            s +="<div style='border-bottom:1px dotted #bcbcbc;height:5px'></div>"
        }
        $info_searchTable.append(s); 
    }
}
</script>

<script type="text/javascript" language="javascript" id="ShowQA">
function ShowUpdateQA(pkid){
    $info_QAID.val(pkid);
    var spanID = "SpanUpdateQA"+pkid;
    document.getElementById(spanID).style.display = "none";
    var divID = "DivUpdateQA"+pkid;
    document.getElementById(divID).style.display = "block";
    var info_UpdateQA = "#Info_UpdateQA"+pkid;
    $(info_UpdateQA).attr("value",$("#"+spanID).text());
}

function CloseUpdateQA(pkid){
    $info_QAID.val(pkid);
    var spanID = "SpanUpdateQA"+pkid;
    document.getElementById(spanID).style.display = "block";
    var divID = "DivUpdateQA"+pkid;
    document.getElementById(divID).style.display = "none";
}

function ShowAnswerQA(pkid){
    var spanID = "SpanAnswerQA"+pkid;
    document.getElementById(spanID).style.display = "none";
    var divID = "DivAnswerQA"+pkid;
    document.getElementById(divID).style.display = "block"; 
    var Info_AnswerQA = "#Info_AnswerQA"+pkid;
    $(Info_AnswerQA).attr("value",$("#"+spanID).text());
}

function CloseAnswerQA(pkid){
    var spanID = "SpanAnswerQA"+pkid;
    document.getElementById(spanID).style.display = "block";
    var divID = "DivAnswerQA"+pkid;
    document.getElementById(divID).style.display = "none";
}

</script>

<script type="text/javascript" language="javascript" id="AnswerQA">
function AnswerQA(pkid) {
    if($("#Info_AnswerQA"+pkid).val()=="")
    {
        alert("回复不能为空");
        return;
    }
    
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "AnswerQA",
            Pkid: pkid,
            info_Answer: $("#Info_AnswerQA"+pkid).val(),
            info_IfQAEmail: $("#ifMailAnswerQA"+pkid).attr("checked")
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                alert("操作成功");
                //$('#dialog').dialog('close');
                GetWorkTaskQAByWorkTaskID($.trim($info_ID.val()));
            }
        }
    });
}

</script>

<script type="text/javascript" language="javascript" id="AddQA">
function AddQA() {
    if($("#taInfo_AddQA").val()=="")
    {
        alert("留言不能为空");
        return;
    }
    
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "AddWorkTaskQA",
            Pkid: $.trim($info_ID.val()),
            info_Question: $.trim($taInfo_AddQA.val()),
            info_IfQAEmail: $("#ifMailAddQA").attr("checked")
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                alert("操作成功");
                //$('#dialog').dialog('close');
                GetWorkTaskQAByWorkTaskID($.trim($info_ID.val()));
                $(".divWT").each(function(i){
                    if($(this).css("display")=="block")
                    {
                        $(this).find("input[value=\"查询\"]").eq(0).click();
                    }
                });                                
            }
        }
    });
}

</script>

<script type="text/javascript" language="javascript" id="UpdateQA">

function UpdateQA(pkid) {
    if($("#Info_UpdateQA"+pkid).val()=="")
    {
        alert("留言不能为空");
        return;
    }
    
    $.ajaxJson(
    {
        url: 'WorkTaskManageHandle.ashx',
        data: 
        {
            type: "UpdateWorkTaskQA",
            Pkid: pkid,
            info_Question: $("#Info_UpdateQA"+pkid).val(),
            info_IfQAEmail: $("#ifMailAddQA"+pkid).attr("checked")
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                alert("操作成功");
                //$('#dialog').dialog('close');
                GetWorkTaskQAByWorkTaskID($.trim($info_ID.val()));
            }
        }
    });
}

</script>