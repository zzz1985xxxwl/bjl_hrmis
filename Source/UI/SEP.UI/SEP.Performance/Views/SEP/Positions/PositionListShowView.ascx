<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionListShowView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Positions.PositionListShowView" %>

<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js" charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../SEP/Choose/ChooseAccountView.ascx" TagName="ChooseAccountView"
    TagPrefix="uc3" %>
<div class="leftitbor">   
    <span id="lblMessage"  class="fontred"></span>           
</div>
<div class="leftitbor2">
<div style="float:left">职位列表</div>
    <div style="float:right; margin-right:5px">
         <a id="set" onclick="$('#divsearchCondition').show();">条件查询</a>
    </div>
    <div style="clear:both"></div>
</div>
<div class="fileuploaddiv" id="divsearchCondition"  style="text-align:left;display:none; margin-right:8px; margin-top:8px">
    <img alt="" src="../../image/closebt.jpg" style=" float:right; cursor:hand" onclick="$('#divsearchCondition').hide();"/>
    <div  class="edittable"  style=" margin-right:8px; margin-top:16px">
                <table width="100%" border="0">
                    <tr>
                        <td style="width: 2%;"></td>
                        <td align="left" style="width: 9%;">
                            职位名称</td>
                        <td align="left" style="width: 40%">
                              <input id="txtName" type="text"  style="width:90%"/>                          
                        </td>
                        <td align="left" style="width: 9%;">
                            职位等级</td>
                        <td align="left" style="width: 40%">
                              <input id="txtGrade" type="text" style="width:90%"/>                            
                        </td>
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
                    <tr>
                        <td></td>
                        <td align="left" colspan="4">
                            <input id="btnSearch" value="查询" class="inputbt" onclick="Search();" type="button"  /></td>
                    </tr>
                </table>
    </div>
</div>



<div id="searchTable"  class="linetablediv"> 
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
                    <td width="8%">
                        职位等级
                    </td>
                    <td width="41%">                    
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="ddlGrade" Width="60%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        岗位性质</td>
                    <td colspan="3">
                        <div class="height100scroll GrayScroll" id="dialogNature">
                            <asp:CheckBoxList ID="cblNature" CssClass="cblNature" runat="server" RepeatColumns="4" CellSpacing="0" ></asp:CheckBoxList>
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
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">上岗条件</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="10%">
                        学历</td>
                    <td width="87%">
                        <input type="text" id="dialogEducation" style="width:90%" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        专业背景</td>
                    <td>
                        <input type="text" id="dialogProfessionalBackground" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        工作经验</td>
                    <td>
                        <input type="text" id="dialogWorkExperience" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        资质要求</td>
                    <td>
                        <input type="text" id="dialogQualification" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        胜任能力</td>
                    <td>
                        <input type="text" id="dialogCompetence" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        其他要求</td>
                    <td>
                        <input type="text" id="dialogOtherRequirements" style="width:90%"  />
                    </td>
                </tr>
            </table>
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">知识与技能要求</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="16%">
                        1. 岗位知识与技能</td>
                    <td width="81%">
                        <textarea id="dialogKnowledgeAndSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        2. 相关流程</td>
                    <td>
                        <textarea id="dialogRelatedProcesses" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        3. 个人管理技能</td>
                    <td>
                        <textarea id="dialogManagementSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        4. 辅助技能</td>
                    <td>
                        <textarea id="dialogAuxiliarySkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
            </table>
        </div>
  </div> 
     <div class="tablebt">
            <input id="btnExport" value="导出" class="inputbt" type="button"              onclick="Export($dialogID.val());" />

            <input id="btnCancel" value="关闭" class="inputbt" type="button"  onclick='$("#dialog").dialog("close")' />
</div>
</div>

<script language="javascript" type="text/javascript" id="初始化" >
var sxTableMethods,$btnExport;
var $name,$Grade,$Nature,$Department,$AccountName;
var $dialogID, $dialogName, $dialogDescription,$dialogNumber,$dialogGrade;
var $dialogReviewer,$dialogPositionStatus,$dialogVersion,$dialogCommencement;
var $dialogSummary,$dialogMainDuties,$dialogReportScope,$dialogControlScope,$dialogcblNature;
var $dialogCoordination,$dialogAuthority,$dialogEducation,$dialogProfessionalBackground;
var $dialogWorkExperience,$dialogQualification,$dialogCompetence,$dialogOtherRequirements;
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
    HideTheAuth();
    $name = $("#txtName");
    $Grade = $("#txtGrade");
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
    $dialogEducation = $("#dialogEducation");
    $dialogProfessionalBackground = $("#dialogProfessionalBackground");
    $dialogWorkExperience = $("#dialogWorkExperience");
    $dialogQualification = $("#dialogQualification");
    $dialogCompetence = $("#dialogCompetence");
    $dialogOtherRequirements = $("#dialogOtherRequirements");
    $dialogKnowledgeAndSkills = $("#dialogKnowledgeAndSkills");
    $dialogRelatedProcesses = $("#dialogRelatedProcesses");
    $dialogManagementSkills = $("#dialogManagementSkills");
    $dialogAuxiliarySkills = $("#dialogAuxiliarySkills");
    $dialogGrade = $(".ddlGrade");
    $dialogcblNature=$(".cblNature");
    $dialogEmployee=$(".txtAccount");
    $dialogDepartment=$("#dialogDepartment");
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
   $Grade.result(function(event, data, formatted) {textChanged(event.target);});
   $Grade.DownTableSelected("../../../Pages/SEP/PositionPages/PositionHandler.ashx?type=GetAllPositionGrade",{mouseovershow:false});
   $Nature.result(function(event, data, formatted) {textChanged(event.target);});
   $Nature.DownTableSelected("../../../Pages/SEP/PositionPages/PositionHandler.ashx?type=GetAllPositionNature",{mouseovershow:false});
}
function textChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}

</script>
<script language="javascript" type="text/javascript" id="新增修改删除查询导出" >

function Export()
{
    location.href='../../SEP/PositionPages/PositionHandler.ashx?type=Export&Pkid='+$dialogID.val();
}
function Export(id)
{
    location.href='../../SEP/PositionPages/PositionHandler.ashx?type=Export&Pkid='+id;
}
function Search() {
    $("#tb").SXTable( 
    {
        colNames: ["", "名称", "等级","岗位性质","适用部门","适用员工",""],
        colWidth: ["2%", "13%", "15%","15%","25%","25%","5%"],
        colTemplates: [" ", "#Name#", "#GradeName#","#NatureNames#","#Depts#","#Members#","<a onclick=\"Export(#PKID#)\">导出</a>"],
        url: '../../SEP/PositionPages/PositionHandler.ashx',
        data: 
        {
            Name: $name.val(),
            Grade: $Grade.val(),
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
    $dialogEducation.val("");
    $dialogProfessionalBackground.val("");
    $dialogWorkExperience.val("");
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
    $btnExport.hide();
    
    $trdialogEmployee.show();
    $trdialogDepartment.show();

    $dialogNature.show();
    $dialogNatureNames.hide();
}
function DetailShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '职位详情');
    InitDialog();
    $btnExport.show();
    $dialogID.val(pkid);
    $.ajaxJson(
    {
        url: '../../SEP/PositionPages/PositionHandler.ashx',
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
                $dialogEducation.val(ans.item.Education);
                $dialogProfessionalBackground.val(ans.item.ProfessionalBackground);
                $dialogWorkExperience.val(ans.item.WorkExperience);
                $dialogQualification.val(ans.item.Qualification);
                $dialogCompetence.val(ans.item.Competence);
                $dialogOtherRequirements.val(ans.item.OtherRequirements);
                $dialogKnowledgeAndSkills.val(ans.item.KnowledgeAndSkills);
                $dialogRelatedProcesses.val(ans.item.RelatedProcesses);
                $dialogManagementSkills.val(ans.item.ManagementSkills);
                $dialogAuxiliarySkills.val(ans.item.AuxiliarySkills);
                $dialogGrade.val(ans.item.Grade);    
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
                
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
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
function show(th,showdivclass)
{
    $(th).parent("div").next("div").hide();
    $(th).parent("div").next("div").next("div").hide();
    $(th).parent("div").next("div").next("div").next("div").hide();
    $(th).parent("div").parent("div").find("."+showdivclass).eq(0).show();
    $(th).parent("div").find(".graytabactive").each(function(i){RemoveClass($(this),"graytabactive");AddClass($(this),"graytabnotactive");});
    RemoveClass($(th),"graytabnotactive");
    AddClass($(th),"graytabactive");
}


</script>
