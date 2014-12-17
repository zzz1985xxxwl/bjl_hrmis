<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Positions.PositionListView" %>

<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js" charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../SEP/Choose/ChooseAccountView.ascx" TagName="ChooseAccountView"
    TagPrefix="uc3" %>
<div class="leftitbor">   
    <span id="lblMessage"  class="fontred"></span>           
</div>
<div class="leftitbor2">查询职位</div>

<div  class="edittable">
            <table width="100%" border="0">
                <tr>
                    <td style="width: 4%;"></td>
                    <td align="left" style="width: 8%;">
                        职位名称</td>
                    <td align="left" style="width: 40%">
                          <input id="txtName" type="text"  style="width:90%"/>                          
                    </td>
                      <td align="left" style="width: 8%;">
                      </td>
                    <td align="left" style="width: 40%">
                                                   
                    </td>
                  <%--  <td align="left" style="width: 8%;">
                        职位等级</td>
                    <td align="left" style="width: 40%">
                          <input id="txtGrade" type="text" style="width:90%"/>                            
                    </td>--%>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        岗位性质</td>
                    <td align="left" colspan="3">
                          <input id="txtNature" type="text"  style="width:95%"/>                          
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        适用部门</td>
                    <td align="left" colspan="3">
                          <input id="txtDepartment" type="text"  style="width:95%"/>                          
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        适用员工</td>
                    <td align="left" colspan="3">
                          <input id="txtAccountName" type="text"  style="width:95%"/>                          
                    </td>
                </tr>

            </table>
</div>

 <div class="tablebt">
            <input id="btnSearch" value="查询" class="inputbt" onclick="Search();" type="button"  />
            <input id="btnAdd" value="新增" class="inputbt" onclick="AddShowDialog();" type="button"  />
</div>


<div id="searchTable"  class="linetablediv" > 
    <table id="tb" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>

<div id="dialog" style="display:none;" >
    <div id="dialogMessage" class="leftitbor" style="display:none;" >
           <span id="dialoglblMessage" class="fontred"></span>
           <input id="hfRowID" type="hidden"/>
    </div>
  <div class="edittable" style="width:96%; background-color:#e6e6e6">   
            <div class="graytab">
                    <div class="graytabactive hand" id="basicinfolink" onclick="show(this,'basicinfo')">基本信息</div>
                    <div class="graytabnotactive hand" id="descriptioninfolink" onclick="show(this,'descriptioninfo');">职责描述</div>
                    <div class="graytabnotactive hand" id="conditioninfolink" onclick="show(this,'conditioninfo');">上岗要求</div>
                    <div class="graytabnotactive hand" id="historyinfolink" onclick="show(this,'historyinfo');GetHistory(this);" IsLoad="false">历史记录</div>
            </div>

        <div style="border:solid 1px #bcbcbc; background-color:White" class="basicinfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        职位名称</td>
                    <td width="41%">
                        <input type="text" id="dialogName"  valid="title"  style="width:60%"/>
                    </td>
                     <td width="8%"> </td>
                    <td width="41%"> </td>
                    
                    <%--<td width="8%">
                        职位等级
                    </td>
                    <td width="41%">                    
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="ddlGrade" Width="60%"></asp:DropDownList>
                    </td>--%>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        岗位性质</td>
                    <td colspan="3">
                        <div class="height100scroll GrayScroll" id="dialogNature">
                            <asp:CheckBoxList ID="cblNature" CssClass="cblNature" runat="server" RepeatColumns="5" CellSpacing="0" ></asp:CheckBoxList>
                         </div>
                         <div id="dialogNatureNames"></div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        描述</td>
                    <td colspan="3">
                        <input type="text" id="dialogDescription" style="width:90%"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        编号</td>
                    <td>
                        <input type="text" id="dialogNumber" style="width:60%"/>
                    </td>
                    <td>
                        审核人
                    </td>
                    <td>                    
                        <input type="text" id="dialogReviewer" style="width:60%"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        批准/发布</td>
                    <td>
                        <asp:DropDownList ID="ddlPositionStatus" runat="server" CssClass="ddlPositionStatus" Width="60%"></asp:DropDownList>
                    </td>
                    <td>
                        版本
                    </td>
                    <td>                    
                        <input type="text" id="dialogVersion"  style="width:60%"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        生效日期</td>
                    <td>
                        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                                            TargetControlID="dialogCommencement">
                                        </ajaxToolKit:CalendarExtender>
                        <asp:TextBox ID="dialogCommencement" runat="server" CssClass="dialogCommencement" Width="60%"></asp:TextBox>                        
                    </td>
                    <td>
                        
                    </td>
                    <td>                    
                        
                    </td>
                </tr>
                <tr id="trdialogDepartment">
                    <td></td>
                    <td>
                        适用部门</td>
                    <td colspan="3">
                        <textarea id="dialogDepartment" rows="2" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr id="trdialogEmployee">
                    <td colspan="5" style="width:100%">
                        <uc3:ChooseAccountView id="ChooseAccountView1" runat="server">
                        </uc3:ChooseAccountView>  
                    </td>
                </tr>              
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv descriptioninfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        工作概要</td>
                    <td width="90%" colspan="3">
                        <textarea id="dialogSummary" rows="3" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        主要职责</td>
                    <td colspan="3">
                        <textarea id="dialogMainDuties" rows="15" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        工作关系</td>
                    <td colspan="3">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2"
                            style="text-align:left">
                            <tr>
                                <td width="14%">
                                    报告范围</td>
                                <td width="86%">
                                    <input type="text" id="dialogReportScope" style="width:90%"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    控制范围</td>
                                <td>
                                    <input type="text" id="dialogControlScope" style="width:90%" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    内外协调关系</td>
                                <td>
                                    <input type="text" id="dialogCoordination"  style="width:90%"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        权限</td>
                    <td colspan="3">
                        <textarea id="dialogAuthority" rows="3" style="width:90%"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv conditioninfo">
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">任职资格</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="97%">
                        <textarea id="dialogQualification" rows="6" style="width:90%"></textarea>
                    </td>    
                </tr>
            </table>
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">能力要求</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="16%">
                        执行能力</td>
                    <td width="81%">
                        <textarea id="dialogKnowledgeAndSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        合作能力</td>
                    <td>
                        <textarea id="dialogRelatedProcesses" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        创新与应变</td>
                    <td>
                        <textarea id="dialogManagementSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        团队领导能力</td>
                    <td>
                        <textarea id="dialogAuxiliarySkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        决策能力</td>
                    <td>
                        <textarea id="dialogCompetence" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        培养下属与授权</td>
                    <td>
                        <textarea id="dialogOtherRequirements" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv historyinfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td>
                        <div id="divHistory"  class="linetablediv" > 
                            <table id="tbhistory" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
  </div> 
     <div class="tablebt">
            <input id="btnOK" value="确定" class="inputbt" type="button"  />
            <input id="btnCancel" value="取消" class="inputbt" type="button"  onclick='$("#dialog").dialog("close")' />
            <input id="btnExport" value="导出" class="inputbt" type="button"  
            onclick="Export();" />
</div>
</div>

<script language="javascript" type="text/javascript" id="初始化" >
var $btnOK, sxTableMethods,$btnExport;
var $name,$Grade,$Nature,$Department,$AccountName;
var $dialogID, $dialogName, $dialogDescription,$dialogNumber,$dialogGrade;
var $dialogReviewer,$dialogPositionStatus,$dialogVersion,$dialogCommencement;
var $dialogSummary,$dialogMainDuties,$dialogReportScope,$dialogControlScope,$dialogcblNature;
var $dialogCoordination,$dialogAuthority;
var $dialogQualification,$dialogCompetence,$dialogOtherRequirements;
var $dialogKnowledgeAndSkills,$dialogRelatedProcesses,$dialogManagementSkills,$dialogAuxiliarySkills;
var $dialogEmployee,$dialogDepartment;
var $trdialogEmployee,$trdialogDepartment;
var $dialogNature,$dialogNatureNames;
var sxValidation = new SXValidation(
{
    valid: 
    {
        rules: 
        {
            title: 
            {
                required: true
            }
        },
        messages: 
        {
            title: 
            {
                required: "不可为空"
            }
        }
    }
});

$(function() {
    $name = $("#txtName");
    //$Grade = $("#txtGrade");
    $Nature = $("#txtNature");
    $Department = $("#txtDepartment");
    $AccountName = $("#txtAccountName");
    
    $dialogID = $("#hfRowID");
    $dialogDescription =  $("#dialogDescription");
    $dialogName = $("#dialogName");
    $dialogNumber = $("#dialogNumber");
    $dialogReviewer = $("#dialogReviewer");
    $dialogPositionStatus = $(".ddlPositionStatus");
    $dialogVersion = $("#dialogVersion");
    $dialogCommencement = $(".dialogCommencement");
    $dialogSummary = $("#dialogSummary");
    $dialogMainDuties = $("#dialogMainDuties");
    $dialogReportScope = $("#dialogReportScope");
    $dialogControlScope = $("#dialogControlScope");
    $dialogCoordination = $("#dialogCoordination");
    $dialogAuthority = $("#dialogAuthority");
    $dialogQualification = $("#dialogQualification");
    $dialogCompetence = $("#dialogCompetence");
    $dialogOtherRequirements = $("#dialogOtherRequirements");
    $dialogKnowledgeAndSkills = $("#dialogKnowledgeAndSkills");
    $dialogRelatedProcesses = $("#dialogRelatedProcesses");
    $dialogManagementSkills = $("#dialogManagementSkills");
    $dialogAuxiliarySkills = $("#dialogAuxiliarySkills");
//    $dialogGrade ="";
    $dialogcblNature=$(".cblNature");
    $dialogEmployee=$(".txtAccount");
    $dialogDepartment=$("#dialogDepartment");
    $btnOK = $("#btnOK");
    $btnExport = $("#btnExport");
    $trdialogEmployee = $("#trdialogEmployee");
    $trdialogDepartment = $("#trdialogDepartment");    
    $dialogNature = $("#dialogNature");    
    $dialogNatureNames = $("#dialogNatureNames");    
    $("#dialog").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 800
    });
    Search();
    BindGoogledown();

});
function BindGoogledown()
{
   $dialogReviewer.autocomplete("../../../Pages/SEP/AuthPages/AssignAuthGooldownPage.aspx",{mouseovershow:false});
   $dialogReviewer.result(function(event, data, formatted) {textChanged(event.target);});

   //$dialogDepartment.autocomplete("../../../Pages/HRMIS/AuthPages/AssignAuthGooldownPage.aspx",{mouseovershow:false});
   $dialogDepartment.result(function(event, data, formatted) {textChanged(event.target);});
   $dialogDepartment.DownTableSelected("../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx?type=GetAllDepartment");
   $Department.result(function(event, data, formatted) {textChanged(event.target);});
   $Department.DownTableSelected("../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx?type=GetAllDepartment");
//   $Grade.result(function(event, data, formatted) {textChanged(event.target);});
//   $Grade.DownTableSelected("../../../Pages/SEP/PositionPages/PositionHandler.ashx?type=GetAllPositionGrade",{mouseovershow:false});
   $Nature.result(function(event, data, formatted) {textChanged(event.target);});
   $Nature.DownTableSelected("../../../Pages/SEP/PositionPages/PositionHandler.ashx?type=GetAllPositionNature",{mouseovershow:false});
}
function textChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}

</script>
<script language="javascript" type="text/javascript" id="获取历史" >
function GetHistory()
{
    if($("#historyinfolink").attr("IsLoad")=="true")
    {
        return;
    }
    $("#tbhistory").SXTable( 
    {
        colNames: ["", "名称", "描述","操作人","操作时间",""],
        colWidth: ["2%"],
        colTemplates: [" ", "#Name#","#Description#","#OperateName#","#OperateTime#", "<a onclick=\"HistoryDetailShowDialog(#PKID#,#HistoryID#)\">详情</a>"],
        url: 'PositionHandler.ashx',
        data: 
        {
            Pkid: $.trim($dialogID.val()),
            type: "GetPositionHistory"
        },
        pageSize: 10,
        success: SuccessHistory
    });
}
function SuccessHistory(methods) {
    $("#historyinfolink").attr("IsLoad","true");
}
function HistoryDetailShowDialog(positionid,historyid) {
    $('#dialog').dialog('option', 'title', '职位历史');
    InitDialog();
    $('#historyinfolink').hide();    
    $trdialogEmployee.hide();
    $trdialogDepartment.hide();
    $dialogNature.hide();
    $dialogNatureNames.show(); 
    $dialogID.val(positionid);
    
    $.ajaxJson(
    {
        url: 'PositionHandler.ashx',
        data: 
        {
            type: "GetPositionHistoryByID",
            HistoryId: historyid
        
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $dialogName.val(ans.item.Name);
                $dialogDescription.val(ans.item.Description);
                $dialogNumber.val(ans.item.Number);
                $dialogReviewer.val(ans.item.Reviewer);
                $dialogPositionStatus.val(ans.item.PositionStatus);
                $dialogVersion.val(ans.item.Version);
                $dialogCommencement.val(ans.item.Commencement);
                $dialogSummary.val(ans.item.Summary);
                $dialogMainDuties.val(ans.item.MainDuties);
                $dialogReportScope.val(ans.item.ReportScope);
                $dialogControlScope.val(ans.item.ControlScope);
                $dialogCoordination.val(ans.item.Coordination);
                $dialogAuthority.val(ans.item.Authority);
                $dialogQualification.val(ans.item.Qualification);
                $dialogCompetence.val(ans.item.Competence);
                $dialogOtherRequirements.val(ans.item.OtherRequirements);
                $dialogKnowledgeAndSkills.val(ans.item.KnowledgeAndSkills);
                $dialogRelatedProcesses.val(ans.item.RelatedProcesses);
                $dialogManagementSkills.val(ans.item.ManagementSkills);
                $dialogAuxiliarySkills.val(ans.item.AuxiliarySkills);
//                $dialogGrade.val(ans.item.Grade);    
                $dialogEmployee.val(ans.item.Members);  
                $dialogDepartment.val(ans.item.Depts);
                var ids = ans.item.NatureIDs.split("|");
                for(var index=0;index<ids.length;index++)
                {
                    $dialogcblNature.find("input[type=checkbox]").each(function(i){
                        if($(this).parent("span").attr("val")==ids[index]){
                            $(this).attr("checked",true);
                        }
                    });
                }
                
                $dialogNatureNames.html(ans.item.NatureNames);
                $btnOK.unbind().click(function() {
                    UpdateShowDialog(positionid);
                });
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
</script>
<script language="javascript" type="text/javascript" id="新增修改删除查询导出" >

function Export()
{
    location.href='PositionHandler.ashx?type=Export&Pkid='+$dialogID.val();
}
function Search() {
    $("#tb").SXTable( 
    {
        colNames: ["", "名称", "岗位性质","适用部门","适用员工","", ""],
        colWidth: ["2%", "", "20%","20%","30%","5%", "5%"],
        colTemplates: [" ", "#Name#", "#NatureNames#","#Depts#","#Members#", "<a onclick=\"UpdateShowDialog(#PKID#)\">修改</a>","<a onclick=\"Delete(confirm('确定要删除吗？'),#PKID#)\">删除</a>"],
        url: 'PositionHandler.ashx',
        data: 
        {
            Name: $name.val(),
            //Grade: $Grade.val(),
            Nature: $Nature.val(),
            Department: $Department.val(),
            AccountName: $AccountName.val(),
            type: "SearchPosition"
        },
        pageSize: 15,
        success: Success
    });
    
}

function Success(methods) {
    sxTableMethods = methods;
    MakeCount();
}

function MakeCount()
{
    $("#lblMessage").next(".font14b").eq(0).remove();
    $("#lblMessage").prev(".font14b").eq(0).remove();
    $("<span class='font14b'>共查到</span>").insertBefore("#lblMessage");
    $("<span class='font14b'>条记录</span>").insertAfter("#lblMessage");
    $('#lblMessage').html(sxTableMethods.allitems().length);
}
function Delete(Confirmed, pkid) {
    if (Confirmed) {
        $.ajaxJson(
        {
            url: 'PositionHandler.ashx',
            data: 
            {
                type: "DeletePosition",
                Pkid: pkid
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    sxTableMethods.deleteItem(pkid);
                    MakeCount();
                }
            }
        });
    }
}



function InitDialog() {
    CleanMessage();
    $dialogID.val(0);
    $dialogName.val("");
    $dialogDescription.val("");
    $dialogNumber.val("");
    $dialogReviewer.val("");
    $dialogPositionStatus.val("");
    $dialogVersion.val("");
    $dialogCommencement.val("");
    $dialogSummary.val("");
    $dialogMainDuties.val("");
    $dialogReportScope.val("");
    $dialogControlScope.val("");
    $dialogCoordination.val("");
    $dialogAuthority.val("");
    $dialogQualification.val("");
    $dialogCompetence.val("");
    $dialogOtherRequirements.val("");
    $dialogKnowledgeAndSkills.val("");
    $dialogRelatedProcesses.val("");
    $dialogManagementSkills.val("");
    $dialogAuxiliarySkills.val("");
    $dialogEmployee.val("");
    $dialogDepartment.val("");
    $dialogcblNature.find("input[type=checkbox]").each(function(i){$(this).attr("checked",false);});
    //$("#tbhistory").html("");
    $('#historyinfolink').show();
    $("#historyinfolink").attr("IsLoad","false");
    $btnExport.hide();
    
    $trdialogEmployee.show();
    $trdialogDepartment.show();

    $dialogNature.show();
    $dialogNatureNames.hide();
}
function AddShowDialog() {
    $('#dialog').dialog('option', 'title', '新增职位');
    InitDialog();
    $btnOK.unbind().click(function() {
        Add();
    });
    $('#dialog').dialog('open');
    $('#basicinfolink').click();
}

function UpdateShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '修改职位');
    InitDialog();
    $btnExport.show();
    $dialogID.val(pkid);
    $.ajaxJson(
    {
        url: 'PositionHandler.ashx',
        data: 
        {
            type: "GetPositionByID",
            Pkid: pkid
        
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $dialogName.val(ans.item.Name);
                $dialogDescription.val(ans.item.Description);
                $dialogNumber.val(ans.item.Number);
                $dialogReviewer.val(ans.item.Reviewer);
                $dialogPositionStatus.val(ans.item.PositionStatus);
                $dialogVersion.val(ans.item.Version);
                $dialogCommencement.val(ans.item.Commencement);
                $dialogSummary.val(ans.item.Summary);
                $dialogMainDuties.val(ans.item.MainDuties);
                $dialogReportScope.val(ans.item.ReportScope);
                $dialogControlScope.val(ans.item.ControlScope);
                $dialogCoordination.val(ans.item.Coordination);
                $dialogAuthority.val(ans.item.Authority);
                $dialogQualification.val(ans.item.Qualification);
                $dialogCompetence.val(ans.item.Competence);
                $dialogOtherRequirements.val(ans.item.OtherRequirements);
                $dialogKnowledgeAndSkills.val(ans.item.KnowledgeAndSkills);
                $dialogRelatedProcesses.val(ans.item.RelatedProcesses);
                $dialogManagementSkills.val(ans.item.ManagementSkills);
                $dialogAuxiliarySkills.val(ans.item.AuxiliarySkills);
                //$dialogGrade.val(ans.item.Grade);    
                $dialogEmployee.val(ans.item.Members);  
                $dialogDepartment.val(ans.item.Depts);
                var ids = ans.item.NatureIDs.split("|");
                for(var index=0;index<ids.length;index++)
                {
                    $dialogcblNature.find("input[type=checkbox]").each(function(i){
                        if($(this).parent("span").attr("val")==ids[index]){
                            $(this).attr("checked",true);
                        }
                    });
                }
                
                $btnOK.unbind().click(function() {
                    Update();
                });
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
function Update() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionHandler.ashx',
            data: 
            {
                type: "UpdatePosition",
                Pkid: $.trim($dialogID.val()),
                dialogName: $.trim($dialogName.val()),
                dialogDescription: $.trim($dialogDescription.val()),
                dialogNumber: $.trim($dialogNumber.val()),
                dialogReviewer: $.trim($dialogReviewer.val()),
                dialogPositionStatus: $.trim($dialogPositionStatus.val()),
                dialogVersion: $.trim($dialogVersion.val()),
                dialogCommencement: $.trim($dialogCommencement.val()),
                dialogSummary: $.trim($dialogSummary.val()),
                dialogMainDuties: $.trim($dialogMainDuties.val()),
                dialogReportScope: $.trim($dialogReportScope.val()),
                dialogControlScope: $.trim($dialogControlScope.val()),
                dialogCoordination: $.trim($dialogCoordination.val()),
                dialogAuthority: $.trim($dialogAuthority.val()),
                dialogEducation: "",//$.trim($dialogEducation.val()),
                dialogProfessionalBackground: "",//$.trim($dialogProfessionalBackground.val()),
                dialogWorkExperience: "",//$.trim($dialogWorkExperience.val()),
                dialogQualification: $.trim($dialogQualification.val()),
                dialogCompetence: $.trim($dialogCompetence.val()),
                dialogOtherRequirements: $.trim($dialogOtherRequirements.val()),
                dialogKnowledgeAndSkills: $.trim($dialogKnowledgeAndSkills.val()),
                dialogRelatedProcesses: $.trim($dialogRelatedProcesses.val()),
                dialogManagementSkills: $.trim($dialogManagementSkills.val()),
                dialogAuxiliarySkills: $.trim($dialogAuxiliarySkills.val()),
                //dialogGrade : $dialogGrade.val(),
                dialogcblNature : getNatureID(),
                dialogEmployee : $dialogEmployee.val(),
                dialogDepartment : $dialogDepartment.val()
             
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                   CommonError(ans);
                }
                else {
                    var item=sxTableMethods.getItemByID($dialogID.val());
                     item.Name=$.trim($dialogName.val());
//                     item.GradeName=$(".ddlGrade").find("option:selected").text();
                     item.NatureNames=getNatureName();
                     item.Depts=$.trim($dialogDepartment.val());
                     item.Members=$.trim($dialogEmployee.val());
                     sxTableMethods.refresh();
                    $('#dialog').dialog('close');
                }
            }
        });
    }
    
    
}
function getNatureName()
{
    var $ret="";
    $dialogcblNature.find("input[type=checkbox]").each(function(i){
        if($(this).attr("checked")){
            if($ret=="")
            {
                $ret+=$(this).next("label").html();
            }
            else
            {
                $ret+=";"+$(this).next("label").html();
            }
        }                    
    });
    return $ret;
}
function getNatureID()
{
    var $ret="";
    $dialogcblNature.find("input[type=checkbox]").each(function(i){
        if($(this).attr("checked")){
                $ret+="|"+$(this).parent("span").attr("val");
        }                    
    });
    return $ret;
}
function Add() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionHandler.ashx',
            data: 
            {
                type: "AddPosition",
                dialogName: $.trim($dialogName.val()),
                dialogDescription: $.trim($dialogDescription.val()),
                dialogNumber: $.trim($dialogNumber.val()),
                dialogReviewer: $.trim($dialogReviewer.val()),
                dialogPositionStatus: $.trim($dialogPositionStatus.val()),
                dialogVersion: $.trim($dialogVersion.val()),
                dialogCommencement: $.trim($dialogCommencement.val()),
                dialogSummary: $.trim($dialogSummary.val()),
                dialogMainDuties: $.trim($dialogMainDuties.val()),
                dialogReportScope: $.trim($dialogReportScope.val()),
                dialogControlScope: $.trim($dialogControlScope.val()),
                dialogCoordination: $.trim($dialogCoordination.val()),
                dialogAuthority: $.trim($dialogAuthority.val()),
                dialogEducation: "",//$.trim($dialogEducation.val()),
                dialogProfessionalBackground:"",// $.trim($dialogProfessionalBackground.val()),
                dialogWorkExperience:"",// $.trim($dialogWorkExperience.val()),
                dialogQualification: $.trim($dialogQualification.val()),
                dialogCompetence: $.trim($dialogCompetence.val()),
                dialogOtherRequirements: $.trim($dialogOtherRequirements.val()),
                dialogKnowledgeAndSkills: $.trim($dialogKnowledgeAndSkills.val()),
                dialogRelatedProcesses: $.trim($dialogRelatedProcesses.val()),
                dialogManagementSkills: $.trim($dialogManagementSkills.val()),
                dialogAuxiliarySkills: $.trim($dialogAuxiliarySkills.val()),
                //dialogGrade : $dialogGrade.val(),
                dialogcblNature : getNatureID(),
                dialogEmployee : $dialogEmployee.val(),
                dialogDepartment : $dialogDepartment.val()   
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    Search();
                    $('#dialog').dialog('close');
                }
            }
        });
    }
    
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


</script>
