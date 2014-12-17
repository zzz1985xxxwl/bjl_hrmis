<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionApplicationView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PositionApplications.PositionApplicationView" %>

<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js" charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/KeepConnectWithServer.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>

<%@ Register Src="../../SEP/Choose/ChooseAccountView.ascx" TagName="ChooseAccountView"
    TagPrefix="uc3" %>
 <div class="leftitbor" align="left">             
<span class="font14b">�㹲�� </span>
<span class="fontred" id="apping"> 0 </span>
<span class="font14b">��ְλ��������;&nbsp;&nbsp;&nbsp;</span> 
<span class="font14b">������ </span>
<span class="fontred" id="myapp">0</span>
<span class="font14b">��ְλ����;&nbsp;&nbsp;&nbsp;</span>
<span class="font14b">����� </span>
<span class="fontred" id="apped">0</span>
<span class="font14b">��ְλ����&nbsp;&nbsp;&nbsp;</span>
</div>                       

<div class="leftitbor2 Apping"> 
����������뵥
</div>

<div id="divPositionApping"  class="linetablediv  Apping" > 
    <table id="tbPositionApping" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>

<div class="leftitbor2"> 
�ҵ�ְλ���� <a onclick="ShowChooseType();">�������뵥</a>
</div>

<div id="divApp"  class="linetablediv" > 
    <table id="tbApp" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>

<div class="leftitbor2nopadding">
    <table width="100%" border="0">
        <tr>
            <td width="30%" align="left" style="padding-left:45px;line-height:35px;">
                �����ʷ
            </td>            
            <td width="70%" align="right">
                ������
                <input type="text" id="txtEmployeeName" width="80px" />   
                <input type="button" class="inputbtSearch" onclick="SearchPositionApped();"  />
            </td>
        </tr>      
    </table>
</div>
<div id="divPositionApped"  class="linetablediv Apped" > 
    <table id="tbPositionApped" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>
<div id="dialogChooseType" style="display:none">
    <div  class="edittable" style="width:366px">
        <%--<a onclick="AddShowDialog();$dialogAppType.val('0');"> + ��Ҫ����ְλ</a> <br /><br />
        <a onclick="$('#dialogChoosePosition').show();"> + ��Ҫ���ְλ��Ϣ</a>  <br /><br />--%>
        <div id="dialogChoosePosition" style="">
                       
����������ְλ<br /><input type="text" id="txtChangePosition" style="width:240px"/>&nbsp;&nbsp;
<input type="button" class="inputbt" value="���" style="display:none"/>
<input type="button" class="inputbt" value="���" onclick="AddForChangeShowDialog();$dialogAppType.val('1');"/>
             <br /><br />
              
        </div>
    </div>
</div>
<div id="dialog" style="display:none;" >
    <div id="dialogMessage" class="leftitbor" style="display:none;" >
           <span id="dialoglblMessage" class="fontred"></span>
           <input id="hfRowID" type="hidden"/>
           <input id="hfAppType" type="hidden"/>
           <input id="hfPositionID" type="hidden"/>
    </div>
  <div class="edittable" style="width:96%; background-color:#e6e6e6">   
            <div class="graytab">
                    <div class="graytabactive hand" id="basicinfolink" onclick="show(this,'basicinfo')">������Ϣ</div>
                    <div class="graytabnotactive hand" id="descriptioninfolink" onclick="show(this,'descriptioninfo');">ְ������</div>
                    <div class="graytabnotactive hand" id="conditioninfolink" onclick="show(this,'conditioninfo');">�ϸ�Ҫ��</div>
                    <div class="graytabnotactive hand" id="historyinfolink" onclick="show(this,'historyinfo');GetHistory(this);" IsLoad="false">������ʷ</div>
            </div>

        <div style="border:solid 1px #bcbcbc; background-color:White" class="basicinfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        ְλ����</td>
                    <td width="41%">
                        <input type="text" id="dialogName"  valid="title"  style="width:60%"/>
                    </td>
                    <td width="8%">
                        ְλ�ȼ�
                    </td>
                    <td width="41%">                    
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="ddlGrade" Width="60%"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ��λ����</td>
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
                        ����</td>
                    <td colspan="3">
                        <input type="text" id="dialogDescription" style="width:90%"/>
                    </td>
                </tr>
                <tr id="trdialogDepartment">
                    <td></td>
                    <td>
                        ���ò���</td>
                    <td colspan="3">
                        <textarea id="dialogDepartment" rows="2" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr id="trdialogEmployee">
                    <td></td>
                    <td>
                        ����Ա��</td>
                    <td colspan="3">
                        <textarea id="dialogEmployee" rows="2" style="width:90%"></textarea>
                    </td>
                </tr>              
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv descriptioninfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        ������Ҫ</td>
                    <td width="90%" colspan="3">
                        <textarea id="dialogSummary" rows="3" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ��Ҫְ��</td>
                    <td colspan="3">
                        <textarea id="dialogMainDuties" rows="15" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ������ϵ</td>
                    <td colspan="3">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2"
                            style="text-align:left">
                            <tr>
                                <td width="14%">
                                    ���淶Χ</td>
                                <td width="86%">
                                    <input type="text" id="dialogReportScope" style="width:90%"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ���Ʒ�Χ</td>
                                <td>
                                    <input type="text" id="dialogControlScope" style="width:90%" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ����Э����ϵ</td>
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
                        Ȩ��</td>
                    <td colspan="3">
                        <textarea id="dialogAuthority" rows="3" style="width:90%"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv conditioninfo">
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">�ϸ�����</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="10%">
                        ѧ��</td>
                    <td width="87%">
                        <input type="text" id="dialogEducation" style="width:90%" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        רҵ����</td>
                    <td>
                        <input type="text" id="dialogProfessionalBackground" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ��������</td>
                    <td>
                        <input type="text" id="dialogWorkExperience" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ����Ҫ��</td>
                    <td>
                        <input type="text" id="dialogQualification" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ʤ������</td>
                    <td>
                        <input type="text" id="dialogCompetence" style="width:90%"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ����Ҫ��</td>
                    <td>
                        <input type="text" id="dialogOtherRequirements" style="width:90%"  />
                    </td>
                </tr>
            </table>
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">֪ʶ�뼼��Ҫ��</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="16%">
                        1. ��λ֪ʶ�뼼��</td>
                    <td width="81%">
                        <textarea id="dialogKnowledgeAndSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        2. �������</td>
                    <td>
                        <textarea id="dialogRelatedProcesses" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        3. ���˹�����</td>
                    <td>
                        <textarea id="dialogManagementSkills" rows="4" style="width:90%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        4. ��������</td>
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
  <div id="remarkmessage">
  &nbsp;&nbsp;&nbsp;&nbsp;ע����ǰ���뵥�����ύ��¼������ٴα༭��ϵͳ���Զ�ȡ��֮ǰ���������̣����Ա༭�����ϢΪ׼���½��С��ݴ桱/���ύ�������� 
  </div>
     <div class="tablebt" id="submitbtn">
            <input id="btnSave" value="�ݴ�" class="inputbt" type="button"  />
            <input id="btnOK" value="�ύ" class="inputbt" type="button"  />
            <input id="btnCancel" value="ȡ��" class="inputbt" type="button"  onclick='$("#dialog").dialog("close")' />
</div>
     <div class="tablebt" id="approvebtnForSubmit">
            <input id="btnPass" value="ͨ��" class="inputbt" type="button"  />
            <input id="btnFail" value="�ܾ�" class="inputbt" type="button"  />
            <input id="Button3" value="ȡ��" class="inputbt" type="button"  onclick='$("#dialog").dialog("close")' />
</div>
     <div class="tablebt" id="approvebtnForCancel">
            <input id="btnPassCancel" value="��׼ȡ��" class="inputbt" type="button"  />
            <input id="btnFailCancel" value="�ܾ�ȡ��" class="inputbt" type="button"  />
            <input id="Button4" value="ȡ��" class="inputbt" type="button"  onclick='$("#dialog").dialog("close")' />
</div>
</div>

<div id="dialogHistoryDetail" style="display:none;" >
    <div id="dialogHistoryDetailMessage" class="leftitbor" style="display:none;" >
           <span id="dialogHistoryDetaillblMessage" class="fontred"></span>
    </div>
  <div class="edittable" style="width:96%; background-color:#e6e6e6">   
            <div class="graytab">
                    <div class="graytabactive hand" id="HistoryDetaildescriptioninfolink" onclick="show(this,'descriptioninfo');">ְ������</div>
                    <div class="graytabnotactive hand" id="HistoryDetailconditioninfolink" onclick="show(this,'conditioninfo');">�ϸ�Ҫ��</div>
            </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv descriptioninfo">
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="1%"></td>
                    <td width="9%">
                        ������Ҫ</td>
                    <td width="90%" colspan="3">
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailSummary" style="width:90%"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ��Ҫְ��</td>
                    <td colspan="3">
                        <div class="height250scroll GrayScroll" style="min-height:30px">                    
                            <div id="dialogHistoryDetailMainDuties" style="width:90%"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ������ϵ</td>
                    <td colspan="3">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2"
                            style="text-align:left">
                            <tr>
                                <td width="14%">
                                    ���淶Χ</td>
                                <td width="86%">
                                    <div class="height23scroll GrayScroll" style="min-height:10px">
                                        <div id="dialogHistoryDetailReportScope" style="width:90%"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ���Ʒ�Χ</td>
                                <td>
                                    <div class="height23scroll GrayScroll" style="min-height:10px">
                                        <div id="dialogHistoryDetailControlScope" style="width:90%"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ����Э����ϵ</td>
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
                        Ȩ��</td>
                    <td colspan="3">
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailAuthority" style="width:90%"/>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:solid 1px #bcbcbc; background-color:White" class="hiddenformdiv conditioninfo">
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">�ϸ�����</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="10%">
                        ѧ��</td>
                    <td width="87%">
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailEducation" style="width:90%"/>     
                        </div> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        רҵ����</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailProfessionalBackground" style="width:90%"/>   
                        </div>   
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ��������</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailWorkExperience" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ����Ҫ��</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailQualification" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ʤ������</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailCompetence" style="width:90%"/>     
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        ����Ҫ��</td>
                    <td>
                        <div class="height23scroll GrayScroll" style="min-height:10px">
                            <div id="dialogHistoryDetailOtherRequirements" style="width:90%"/>    
                        </div> 
                    </td>
                </tr>
            </table>
            <div style="margin-top:8px; padding-left:20px; line-height:24px; background-color:#ffe0d1;">֪ʶ�뼼��Ҫ��</div>
            <table width="100%" border="0" style="text-align:left">
                <tr>
                    <td width="3%"></td>
                    <td width="16%">
                        1. ��λ֪ʶ�뼼��</td>
                    <td width="81%">
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailKnowledgeAndSkills" style="width:90%"/>    
                        </div> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        2. �������</td>
                    <td>
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailRelatedProcesses" style="width:90%"/>   
                        </div>  
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        3. ���˹�����</td>
                    <td>
                        <div class="height50scroll GrayScroll" style="min-height:30px">
                            <div id="dialogHistoryDetailManagementSkills" style="width:90%"/>  
                        </div>    
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        4. ��������</td>
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


<script language="javascript" type="text/javascript" id="��ʼ��" >
var $btnOK,$btnSave, sxtbAppMethods,sxtbAppingMethods,sxtbAppedMethods,$txtChangePosition,sxtbAppHistoryMethods;
var $dialogID,$dialogAppType,$dialogPositionID, $dialogName, $dialogDescription,$dialogGrade;
var $dialogSummary,$dialogMainDuties,$dialogReportScope,$dialogControlScope,$dialogcblNature;
var $dialogCoordination,$dialogAuthority,$dialogEducation,$dialogProfessionalBackground;
var $dialogWorkExperience,$dialogQualification,$dialogCompetence,$dialogOtherRequirements;
var $dialogKnowledgeAndSkills,$dialogRelatedProcesses,$dialogManagementSkills,$dialogAuxiliarySkills;
var $dialogEmployee,$dialogDepartment;
var $trdialogEmployee,$trdialogDepartment;
var $dialogNature,$dialogNatureNames;
var $btnPass,$btnFail,$btnPassCancel,$btnFailCancel;

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
                required: "����Ϊ��"
            }
        }
    }
});

$(function() {
    KeepConnect("PositionApplicationHandler.ashx");
    $txtChangePosition = $("#txtChangePosition");

    $dialogID = $("#hfRowID");
    $dialogAppType = $("#hfAppType");
    $dialogPositionID = $("#hfPositionID");
    $dialogDescription =  $("#dialogDescription");
    $dialogName = $("#dialogName");
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
    $dialogEmployee=$("#dialogEmployee");
    $dialogDepartment=$("#dialogDepartment");
    $btnOK = $("#btnOK");
    $btnSave = $("#btnSave");
    $btnPass = $("#btnPass");
    $btnFail = $("#btnFail");
    $btnPassCancel = $("#btnPassCancel");
    $btnFailCancel = $("#btnFailCancel");
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
    $("#dialogChooseType").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 400
    });
    
    SearchApp();
    SearchPositionApping();
    SearchPositionApped();
    BindGoogledown();

});
function BindGoogledown()
{
   $txtChangePosition.autocomplete("../../GoogleDown.ashx?type=PositionByLeaderID",{mouseovershow:false});
   $txtChangePosition.result(function(event, data, formatted) {textChanged(event.target);});
   //$dialogDepartment.autocomplete("../../../Pages/HRMIS/AuthPages/AssignAuthGooldownPage.aspx",{mouseovershow:false});
   $dialogDepartment.result(function(event, data, formatted) {textChanged(event.target);});
   $dialogDepartment.DownTableSelected("../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx?type=GetAllDepartment");
}
function textChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}

</script>
<script language="javascript" type="text/javascript" id="��ȡ��ʷ" >
function GetHistory()
{
    if($("#historyinfolink").attr("IsLoad")=="true")
    {
        return;
    }
    $("#tbhistory").SXTable( 
    {
        colNames: ["", "����ID", "������","����ʱ��","��������","��ע",""],
        colWidth: ["2%"],
        colTemplates: [" ", "#PKID#", "#OperatorName#","#OperationTime#","#FlowStatusName#","#Remark#","<a onclick=\"FlowDetailShowDialog(#PKID#)\">����</a>"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            Pkid: $.trim($dialogID.val()),
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
function FlowDetailShowDialog(pkid){
    $('#dialogHistoryDetail').dialog('option', 'title', 'ְλ������ʷ');
    var item=sxtbAppHistoryMethods.getItemByID(pkid);
                $dialogHistoryDetailSummary.html(item.Summary.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailMainDuties.html(item.MainDuties.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailReportScope.html(item.ReportScope.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailControlScope.html(item.ControlScope.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailCoordination.html(item.Coordination.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailAuthority.html(item.Authority.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailEducation.html(item.Education.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailProfessionalBackground.html(item.ProfessionalBackground.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailWorkExperience.html(item.WorkExperience.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailQualification.html(item.Qualification.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailCompetence.html(item.Competence.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailOtherRequirements.html(item.OtherRequirements.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailKnowledgeAndSkills.html(item.KnowledgeAndSkills.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailRelatedProcesses.html(item.RelatedProcesses.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailManagementSkills.html(item.ManagementSkills.replace(/\n/g,"<br/>"));
                $dialogHistoryDetailAuxiliarySkills.html(item.AuxiliarySkills.replace(/\n/g,"<br/>"));
    $('#dialogHistoryDetail').dialog('open');
    $('#HistoryDetaildescriptioninfolink').click();
                
}
</script>

<script id="ѡ�����" type="text/javascript" language="javascript">
function ShowChooseType() {
    $('#dialogChooseType').dialog('option', 'title', 'ѡ������ְλ');
    $('#dialogChooseType').dialog('open');
}
</script>
<script language="javascript" type="text/javascript" id="���" >
function ApproveShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '���ְλ����');
    InitDialog();    
    IsableDialog(false);
    $dialogID.val(pkid);
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
                if(ans.item.StatusID=="1"||ans.item.StatusID=="7")
                {
                    $("#approvebtnForSubmit").show();
                    $btnPass.unbind().click(function() {
                        Approve(3);
                    });
                    $btnFail.unbind().click(function() {
                        Approve(2);
                    });
                }
                if(ans.item.StatusID=="4"||ans.item.StatusID=="8")
                {
                    $("#approvebtnForCancel").show();
                    $btnPassCancel.unbind().click(function() {
                        Approve(6);
                    });
                    $btnFailCancel.unbind().click(function() {
                        Approve(5);
                    });
                }
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
function Approve(requeststatus)
{
        $.ajaxJson(
        {
            url: 'PositionApplicationHandler.ashx',
            data: 
            {
                type: "ApprovePositionApp",                
                dialogRequestStatus:requeststatus,
                Pkid: $.trim($dialogID.val()),
                
                dialogPositionID:$.trim($dialogPositionID.val()),
                dialogName: $.trim($dialogName.val()),
                dialogDescription: $.trim($dialogDescription.val()),
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
                    $('#dialog').dialog('close');
                    $('#dialogChooseType').dialog('close');
                    SearchPositionApping();
                }
            }
        });
}
</script>
<script language="javascript" type="text/javascript" id="�б��ѯ" >
function SearchApp() {
    $("#tbApp").SXTable( 
    {
        colNames: ["", "����", "����״̬","����","", ""],
        colWidth: ["2%", "","","30%","5%", "5%"],
        colTemplates: [" ", "#Name#", "#StatusName#","#Description#"
        , "<a onclick=\"UpdateShowDialog(#PKID#)\">�༭</a>"
        ,"#DeleteLink#"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "SearchMyPositionApp"
        },
        pageSize: 15,
        success: SuccessApp
    });
    
}
function SearchPositionApping() {
    $("#tbPositionApping").SXTable( 
    {
        colNames: ["", "����","������", "����״̬", "����",""],
        colWidth: ["2%", "","","","30%","5%"],
        colTemplates: [" ", "#Name#","#ApplicantName#", "#StatusName#","#Description#", "<a onclick=\"ApproveShowDialog(#PKID#)\">���</a>"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "SearchPositionApping"
        },
        pageSize: 15,
        success: SuccessApping
    });
    
}
function SearchPositionApped() {
    $("#tbPositionApped").SXTable( 
    {
        colNames: ["", "����","������", "����״̬", "����",""],
        colWidth: ["2%", "","", "","30%","5%"],
        colTemplates: [" ", "#Name#","#ApplicantName#","#StatusName#","#Description#", "<a onclick=\"DetailShowDialog(#PKID#)\">����</a>"],
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "SearchPositionApped",
            ApplicantName:$("#txtEmployeeName").val()
        },
        pageSize: 15,
        success: SuccessApped
    });
    
}

function SuccessApp(methods) {
    sxtbAppMethods = methods;
    $("#myapp").html(sxtbAppMethods.allitems().length);
}
function SuccessApping(methods) {
    sxtbAppingMethods = methods;
    $("#apping").html(sxtbAppingMethods.allitems().length);
    if(sxtbAppingMethods.allitems().length==0)
    {
        $(".Apping").hide();
    }
    else
    {
        $(".Apping").show();
    }
}
function SuccessApped(methods) {
    sxtbAppedMethods = methods;
    $("#apped").html(sxtbAppedMethods.allitems().length);
        if(sxtbAppedMethods.allitems().length==0)
    {
        $(".Apped").hide();
    }
    else
    {
        $(".Apped").show();
    }
}
</script>

<script language="javascript" type="text/javascript" id="�����޸�ɾ��" >

function Cancel(Confirmed, pkid) {
    if (Confirmed) {
        $.ajaxJson(
        {
            url: 'PositionApplicationHandler.ashx',
            data: 
            {
                type: "CancelPositionApp",
                Pkid: pkid
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    alert(CommonErrorString(ans));
                }
                else {
                    SearchApp();
                }
            }
        });
    }
}
function Delete(Confirmed, pkid) {
    if (Confirmed) {
        $.ajaxJson(
        {
            url: 'PositionApplicationHandler.ashx',
            data: 
            {
                type: "DeletePositionApp",
                Pkid: pkid
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    alert(CommonErrorString(ans));
                }
                else {
                    sxtbAppMethods.deleteItem(pkid);
                    $("#myapp").html(sxtbAppMethods.allitems().length);
                }
            }
        });
    }
}



function InitDialog() {
    CleanMessage();
    IsableDialog(false);
    $dialogID.val(0);
    $dialogAppType.val("-1");
    $dialogPositionID.val(0);
    $dialogName.val("");
    $dialogDescription.val("");
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
    
    $trdialogEmployee.show();
    $trdialogDepartment.show();

    $dialogNature.show();
    $dialogNatureNames.hide();
    
    $("#submitbtn").hide();
    $("#approvebtnForSubmit").hide();
    $("#approvebtnForCancel").hide();
    $("#remarkmessage").hide();
}
function IsableDialog(isable)
{
    $dialogName.attr("disabled",true);
    $dialogDescription.attr("disabled",true);
    $dialogSummary.attr("disabled",isable);
    $dialogMainDuties.attr("disabled",isable);
    $dialogReportScope.attr("disabled",isable);
    $dialogControlScope.attr("disabled",isable);
    $dialogCoordination.attr("disabled",isable);
    $dialogAuthority.attr("disabled",isable);
    $dialogEducation.attr("disabled",isable);
    $dialogProfessionalBackground.attr("disabled",isable);
    $dialogWorkExperience.attr("disabled",isable);
    $dialogQualification.attr("disabled",isable);
    $dialogCompetence.attr("disabled",isable);
    $dialogOtherRequirements.attr("disabled",isable);
    $dialogKnowledgeAndSkills.attr("disabled",isable);
    $dialogRelatedProcesses.attr("disabled",isable);
    $dialogManagementSkills.attr("disabled",isable);
    $dialogAuxiliarySkills.attr("disabled",isable);
    $dialogEmployee.attr("disabled",true);
    $dialogDepartment.attr("disabled",true);
    $dialogGrade.attr("disabled",true);
    $dialogcblNature.find("input[type=checkbox]").each(function(i){$(this).attr("checked",false).attr("disabled",true);});
}
function AddShowDialog() {
    $('#dialog').dialog('option', 'title', '����ְλ����');
    InitDialog();    
    $("#submitbtn").show();
    $btnOK.unbind().click(function() {
        Add(1);
    });
    $btnSave.unbind().click(function() {
        Add(0);
    });
    $('#dialog').dialog('open');
    $('#basicinfolink').click();
}
function AddForChangeShowDialog() {
    $('#dialog').dialog('option', 'title', '����ְλ����');
    InitDialog();
    $("#submitbtn").show();
    $.ajaxJson(
    {
        url: 'PositionApplicationHandler.ashx',
        data: 
        {
            type: "GetPositionByName",
            Name: $txtChangePosition.val()
        
        },
        success: function(ans) {

            if (ans.error && ans.error.length > 0) {
                 alert(CommonErrorString(ans));
            }
            else {
                $dialogPositionID.val(ans.item.PKID);
                $dialogName.val(ans.item.Name);
                $dialogDescription.val(ans.item.Description);
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
                
                $btnOK.unbind().click(function() {
                    Add(1);
                });
                $btnSave.unbind().click(function() {
                    Add(0);
                });
                
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
function UpdateShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', '�޸�ְλ����');
    InitDialog();
    $("#submitbtn").show();
    $dialogID.val(pkid);
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
                 alert(CommonErrorString(ans));
            }
            else {
                $dialogPositionID.val(ans.item.PositionID);
                $dialogName.val(ans.item.Name);
                $dialogDescription.val(ans.item.Description);
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
                if(ans.item.StatusID!="0")
                {                    
                    $("#remarkmessage").show();
                }
                $btnOK.unbind().click(function() {
                    Update(1);
                });
                $btnSave.unbind().click(function() {
                    Update(0);
                });
                $('#dialog').dialog('open');
                $('#basicinfolink').click();
            }
        }
    });
}
function DetailShowDialog(pkid) {
    $('#dialog').dialog('option', 'title', 'ְλ��������');
    InitDialog();    
    IsableDialog(true);
    $dialogID.val(pkid);
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
                 alert(CommonErrorString(ans));
            }
            else {
                $dialogPositionID.val(ans.item.PositionID);
                $dialogName.val(ans.item.Name);
                $dialogDescription.val(ans.item.Description);
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
function Update(requeststatus) {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionApplicationHandler.ashx',
            data: 
            {
                type: "UpdatePositionApp",                
                dialogRequestStatus:requeststatus,
                dialogPositionID:$.trim($dialogPositionID.val()),
                Pkid: $.trim($dialogID.val()),
                dialogName: $.trim($dialogName.val()),
                dialogDescription: $.trim($dialogDescription.val()),
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
                    SearchApp();
                    $('#dialog').dialog('close');
                    $('#dialogChooseType').dialog('close');
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
function Add(requeststatus) {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionApplicationHandler.ashx',
            data: 
            {
                type: "AddPositionApp",
                dialogRequestStatus:requeststatus,
                dialogAppType: $.trim($dialogAppType.val()),
                dialogPositionID:$.trim($dialogPositionID.val()),
                dialogName: $.trim($dialogName.val()),
                dialogDescription: $.trim($dialogDescription.val()),
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
                    SearchApp();
                    $('#dialog').dialog('close');
                    $('#dialogChooseType').dialog('close');
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
