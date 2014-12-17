<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrPositionApplicationView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PositionApplications.HrPositionApplicationView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../SEP/Choose/ChooseAccountView.ascx" TagName="ChooseAccountView"
    TagPrefix="uc3" %>
<div class="leftitbor">   
    <span id="lblMessage"  class="fontred"></span>           
</div>
<div class="leftitbor2">查询职位申请</div>

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
                        申请人</td>
                    <td align="left" style="width: 40%">
                          <input id="txtApplicantName" type="text" style="width:90%"/>                            
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        申请状态</td>
                    <td align="left">
                          <asp:DropDownList ID="ddlStatusSearch" runat="server" CssClass="ddlStatusSearch" Width="60%"></asp:DropDownList>                                             
                    </td>
                    <td align="left">
                        是否已发布</td>
                    <td align="left">
                          <asp:DropDownList ID="ddlIsPublishSearch" runat="server" CssClass="ddlIsPublishSearch" Width="60%"></asp:DropDownList>                     
                    </td>
                </tr>

            </table>
</div>

 <div class="tablebt">
            <input id="btnSearch" value="查询" class="inputbt" onclick="Search();" type="button"  />
            <input id="Button1" value="返回职位管理" class="inputbtlong" onclick="location.href='../../SEP/PositionPages/PositionManage.aspx';" type="button"  />
</div>


<div id="searchTable"  class="linetablediv" > 
    <table id="tb" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>

<div id="dialog" style="display:none;" >
    <div id="dialogMessage" class="leftitbor" style="display:none;" >
           <span id="dialoglblMessage" class="fontred"></span>
           <input id="hfRowID" type="hidden"/>
           <input id="hfPositionID" type="hidden"/>
    </div>
  <div class="edittable" style="width:96%; background-color:#e6e6e6">   
            <div class="graytab">
                    <div class="graytabactive hand" id="basicinfolink" onclick="show(this,'basicinfo')">基本信息</div>
                    <div class="graytabnotactive hand" id="descriptioninfolink" onclick="show(this,'descriptioninfo');">职责描述</div>
                    <div class="graytabnotactive hand" id="conditioninfolink" onclick="show(this,'conditioninfo');">上岗要求</div>
                    <div class="graytabnotactive hand" id="historyinfolink" onclick="show(this,'historyinfo');GetHistory(this);" IsLoad="false">操作历史</div>
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
                      
                    </td>
                    <td width="41%">                    
                        
                    </td>
                <%--    <td width="8%">
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
                <tr class="PositionOnlyInfo">
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
                <tr class="PositionOnlyInfo">
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
                <tr class="PositionOnlyInfo">
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
</div>
</div>

<div id="dialogHistoryDetail" style="display:none;" >
    <div id="dialogHistoryDetailMessage" class="leftitbor" style="display:none;" >
           <span id="dialogHistoryDetaillblMessage" class="fontred"></span>
    </div>
  <div class="edittable" style="width:96%; background-color:#e6e6e6">   
            <div class="graytab">
                    <div class="graytabactive hand" id="HistoryDetaildescriptioninfolink" onclick="show(this,'descriptioninfo');">职责描述</div>
                    <div class="graytabnotactive hand" id="HistoryDetailconditioninfolink" onclick="show(this,'conditioninfo');">上岗要求</div>
            </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv descriptioninfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        工作概要</td>
                    <td width="90%" colspan="3">
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailSummary" style="width:90%"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        主要职责</td>
                    <td colspan="3">
                        <div class="height250scroll GrayScroll" style="min-height:30px">                    
                            <div id="dialogHistoryDetailMainDuties" style="width:90%"/>
                        </div>
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
                                    <div class="height23scroll GrayScroll" style="min-height:10px">
                                        <div id="dialogHistoryDetailReportScope" style="width:90%"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    控制范围</td>
                                <td>
                                    <div class="height23scroll GrayScroll" style="min-height:10px">
                                        <div id="dialogHistoryDetailControlScope" style="width:90%"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    内外协调关系</td>
                                <td>
                                    <div class="height23scroll GrayScroll" style="min-height:10px">
                                        <div id="dialogHistoryDetailCoordination" style="width:90%"/>
                                    </div>
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
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailAuthority" style="width:90%"/>
                        </div>
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
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailEducation" style="width:90%"/>     
                        </div> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        专业背景</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailProfessionalBackground" style="width:90%"/>   
                        </div>   
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        工作经验</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailWorkExperience" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        资质要求</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailQualification" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        胜任能力</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailCompetence" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        其他要求</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailOtherRequirements" style="width:90%"/>    
                        </div> 
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
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailKnowledgeAndSkills" style="width:90%"/>    
                        </div> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        2. 相关流程</td>
                    <td>
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailRelatedProcesses" style="width:90%"/>   
                        </div>  
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        3. 个人管理技能</td>
                    <td>
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailManagementSkills" style="width:90%"/>  
                        </div>    
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        4. 辅助技能</td>
                    <td>
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailAuxiliarySkills" style="width:90%"/>    
                        </div>  
                    </td>
                </tr>
            </table>
        </div>
  </div> 
</div>
</div>

<script language="javascript" type="text/javascript" id="初始化" >
var $btnOK, sxTableMethods,$btnExport,sxtbAppHistoryMethods;
var $name,$Applicantname,$ddlStatusSearch,$ddlIsPublishSearch;
var $dialogAppID, $dialogName,$dialogPositionID, $dialogDescription,$dialogNumber,$dialogGrade;
var $dialogReviewer,$dialogPositionStatus,$dialogVersion,$dialogCommencement;
var $dialogSummary,$dialogMainDuties,$dialogReportScope,$dialogControlScope,$dialogcblNature;
var $dialogCoordination,$dialogAuthority,$dialogEducation,$dialogProfessionalBackground;
var $dialogWorkExperience,$dialogQualification,$dialogCompetence,$dialogOtherRequirements;
var $dialogKnowledgeAndSkills,$dialogRelatedProcesses,$dialogManagementSkills,$dialogAuxiliarySkills;
var $dialogEmployee,$dialogDepartment;
var $trdialogEmployee,$trdialogDepartment;
var $dialogNature,$dialogNatureNames;

var $dialogHistoryDetailSummary;
var $dialogHistoryDetailMainDuties;
var $dialogHistoryDetailReportScope;
var $dialogHistoryDetailControlScope;
var $dialogHistoryDetailCoordination;
var $dialogHistoryDetailAuthority;
var $dialogHistoryDetailEducation;
var $dialogHistoryDetailProfessionalBackground;
var $dialogHistoryDetailWorkExperience;
var $dialogHistoryDetailQualification;
var $dialogHistoryDetailCompetence;
var $dialogHistoryDetailOtherRequirements;
var $dialogHistoryDetailKnowledgeAndSkills ;
var $dialogHistoryDetailRelatedProcesses;
var $dialogHistoryDetailManagementSkills;
var $dialogHistoryDetailAuxiliarySkills ;

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
    $Applicantname = $("#txtApplicantName");    
    $ddlStatusSearch = $(".ddlStatusSearch");    
    $ddlIsPublishSearch = $(".ddlIsPublishSearch");
    
    $dialogAppID = $("#hfRowID");
    $dialogPositionID = $("#hfPositionID");    
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
    $btnOK = $("#btnOK");
    $btnExport = $("#btnExport");
    $trdialogEmployee = $("#trdialogEmployee");
    $trdialogDepartment = $("#trdialogDepartment");    
    $dialogNature = $("#dialogNature");    
    $dialogNatureNames = $("#dialogNatureNames");    
    
    

$dialogHistoryDetailSummary=$("#dialogHistoryDetailSummary");
$dialogHistoryDetailMainDuties=$("#dialogHistoryDetailMainDuties");
$dialogHistoryDetailReportScope=$("#dialogHistoryDetailReportScope");
$dialogHistoryDetailControlScope=$("#dialogHistoryDetailControlScope");
$dialogHistoryDetailCoordination=$("#dialogHistoryDetailCoordination");
$dialogHistoryDetailAuthority=$("#dialogHistoryDetailAuthority");
$dialogHistoryDetailEducation=$("#dialogHistoryDetailEducation");
$dialogHistoryDetailProfessionalBackground=$("#dialogHistoryDetailProfessionalBackground");
$dialogHistoryDetailWorkExperience=$("#dialogHistoryDetailWorkExperience");
$dialogHistoryDetailQualification=$("#dialogHistoryDetailQualification");
$dialogHistoryDetailCompetence=$("#dialogHistoryDetailCompetence");
$dialogHistoryDetailOtherRequirements=$("#dialogHistoryDetailOtherRequirements");
$dialogHistoryDetailKnowledgeAndSkills =$("#dialogHistoryDetailKnowledgeAndSkills ");
$dialogHistoryDetailRelatedProcesses=$("#dialogHistoryDetailRelatedProcesses");
$dialogHistoryDetailManagementSkills=$("#dialogHistoryDetailManagementSkills");
$dialogHistoryDetailAuxiliarySkills =$("#dialogHistoryDetailAuxiliarySkills ");


    $("#dialogHistoryDetail").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 850
    });
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
}
function textChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}

</script>
<script language="javascript" type="text/javascript" id="新增修改删除查询导出" >

function Search() {
    $("#tb").SXTable( 
    {
        colNames: ["", "名称","申请人","申请类型", "申请状态", " 岗位性质","适用部门","是否已发布","", ""],
        colWidth: ["2%","", "", "","","","40%","","5%", "5%"],
        colTemplates: [" ", "#Name#", "#ApplicantName#","#AppTypeName#","#StatusName#","#NatureNames#","#Depts#","#IsPublish#", "<a onclick=\"PublishShowDialog(#PKID#)\">#PublishLink#</a>","<a onclick=\"DetailShowDialog(#PKID#)\">详情</a>"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            Name: $name.val(),
            ApplicantName:$Applicantname.val(),
            Status: $ddlStatusSearch.val(),
            IsPublish: $ddlIsPublishSearch.val(),
            type: "SearchPositionApp"
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
    $dialogAppID.val(0);
    $dialogPositionID.val(0);    
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
    $('#historyinfolink').show();
    $("#historyinfolink").attr("IsLoad","false");
    $btnExport.hide();
    
    $trdialogEmployee.show();
    $trdialogDepartment.show();

    $dialogNature.show();
    $dialogNatureNames.hide();
    
    $(".PositionOnlyInfo").show();
}
function DetailShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '职位申请详情');
    InitDialog();
    $dialogAppID.val(pkid);
    $(".PositionOnlyInfo").hide();
    $.ajaxJson(
    {
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "GetPositionAppByID",
            Pkid: pkid
        
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $dialogPositionID.val(ans.item.PositionID);
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
                
                $btnOK.unbind().click(function() {
                    $('#dialog').dialog('close');
                });
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}

function PublishShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '发布职位');
    InitDialog();
    $btnExport.show();
    $dialogAppID.val(pkid);
    $.ajaxJson(
    {
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "GetPositionAppByID",
            Pkid: pkid
        
        },
        success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $dialogPositionID.val(ans.item.PositionID);
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
                
                $btnOK.unbind().click(function() {
                    Publish();
                });
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
function Publish() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: '../../SEP/PositionPages/PositionHandler.ashx',
            data: 
            {
                type: "PublishPosition",
                Pkid:  $.trim($dialogPositionID.val()),
                dialogPositionAppID:$.trim($dialogAppID.val()),
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
                dialogEducation: $.trim($dialogEducation.val()),
                dialogProfessionalBackground: $.trim($dialogProfessionalBackground.val()),
                dialogWorkExperience: $.trim($dialogWorkExperience.val()),
                dialogQualification: $.trim($dialogQualification.val()),
                dialogCompetence: $.trim($dialogCompetence.val()),
                dialogOtherRequirements: $.trim($dialogOtherRequirements.val()),
                dialogKnowledgeAndSkills: $.trim($dialogKnowledgeAndSkills.val()),
                dialogRelatedProcesses: $.trim($dialogRelatedProcesses.val()),
                dialogManagementSkills: $.trim($dialogManagementSkills.val()),
                dialogAuxiliarySkills: $.trim($dialogAuxiliarySkills.val()),
                dialogGrade : $dialogGrade.val(),
                dialogcblNature : getNatureID(),
                dialogEmployee : $dialogEmployee.val(),
                dialogDepartment : $dialogDepartment.val()
             
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                   CommonError(ans);
                }
                else {
                    var item=sxTableMethods.getItemByID($dialogAppID.val());
                     item.IsPublish="已发布";
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
<script language="javascript" type="text/javascript" id="获取历史" >
function FlowDetailShowDialog(pkid){
    $('#dialogHistoryDetail').dialog('option', 'title', '职位申请历史');
    var item=sxtbAppHistoryMethods.getItemByID(pkid);
                $dialogHistoryDetailSummary.html(item.Summary);
                $dialogHistoryDetailMainDuties.html(item.MainDuties);
                $dialogHistoryDetailReportScope.html(item.ReportScope);
                $dialogHistoryDetailControlScope.html(item.ControlScope);
                $dialogHistoryDetailCoordination.html(item.Coordination);
                $dialogHistoryDetailAuthority.html(item.Authority);
                $dialogHistoryDetailEducation.html(item.Education);
                $dialogHistoryDetailProfessionalBackground.html(item.ProfessionalBackground);
                $dialogHistoryDetailWorkExperience.html(item.WorkExperience);
                $dialogHistoryDetailQualification.html(item.Qualification);
                $dialogHistoryDetailCompetence.html(item.Competence);
                $dialogHistoryDetailOtherRequirements.html(item.OtherRequirements);
                $dialogHistoryDetailKnowledgeAndSkills.html(item.KnowledgeAndSkills);
                $dialogHistoryDetailRelatedProcesses.html(item.RelatedProcesses);
                $dialogHistoryDetailManagementSkills.html(item.ManagementSkills);
                $dialogHistoryDetailAuxiliarySkills.html(item.AuxiliarySkills);
    $('#dialogHistoryDetail').dialog('open');
    $('#HistoryDetaildescriptioninfolink').click();
                
}
function GetHistory()
{
    if($("#historyinfolink").attr("IsLoad")=="true")
    {
        return;
    }
    $("#tbhistory").SXTable( 
    {
        colNames: ["", "操作ID", "操作人","操作时间","操作内容","备注",""],
        colWidth: ["2%"],
        colTemplates: [" ", "#PKID#", "#OperatorName#","#OperationTime#","#FlowStatusName#","#Remark#","<a onclick=\"FlowDetailShowDialog(#PKID#)\">详情</a>"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            Pkid: $.trim($dialogAppID.val()),
            type: "GetPositionAppHistoryByID"
        },
        pageSize: 10,
        success: SuccessHistory
    });
}
function SuccessHistory(methods) {
    $("#historyinfolink").attr("IsLoad","true");
    sxtbAppHistoryMethods = methods;
}
</script>
