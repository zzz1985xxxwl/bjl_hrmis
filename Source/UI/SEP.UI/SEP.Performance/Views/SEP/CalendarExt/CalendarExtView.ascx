<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarExtView.ascx.cs" Inherits="SEP.Performance.Views.SEP.CalendarExt.CalendarExtView" %>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../../Inc/BaseScript.js" charset="gb2312"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.tab.js"></script>
<script language="javascript" type="text/javascript" src="../../Inc/datePicker.js" charset="gb2312"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.cookie.js" charset="gb2312"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.json-2.2.js"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.SXDateControl.js" charset="gb2312"></script>
<script language="javascript" type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<link rel="stylesheet" type="text/css" media="screen" href="../../CSS/datePicker.css" />
<link rel="stylesheet" type="text/css" media="screen" href="../../CSS/calendarEXT.css" />
<link rel="stylesheet" type="text/css" media="screen" href="../../CSS/style.css" />
<link rel="stylesheet" type="text/css" media="screen" href="../../CSS/jquery.autocomplete.css" />

<div class="calendarLoading" style="display:none;">���ڶ�ȡ����...</div>
<div class="infoborder" style="display:none;border:0;" >
<div  class="leftitbor" style="display:none;">
                <span id="lblShowDetailMessage" class="fontred"></span>
            </div>
    <div class="infoicon" style="text-align:left; height:20px;">
        <div style="float:left; font-size: 14px"><img height="20" align="absmiddle" width="20" src="../../image/infoicon.gif"/>�鿴��Ϣ <span id = "displayDate" class = "benma_ui_tab"></span></div>
        <div id="closeDetail" onclick='$(".infoborder").dialog("close")'></div>
    </div>
    <div id="tab_list" style="width:700px">
    </div>
    <div style="height:12px">
    </div>
</div>

        <div id="noteEdit" style="display:none;border:0;">
            <div id="tbNotesMessage" class="leftitbor" style="display:none;">
                <span id="lblNotesMessage" class="fontred"></span>
            </div>
            <div class="leftitbor2" style="padding-right:2px;">
                <div style="float:left" id="noteEditTitle">
                    ������ǩ
                </div>
                <div style="float:right">
                    <div class="closeNote" style="float:right" onclick='$("#noteEdit").dialog("close");if($theNewNote){$theNewNote.remove();};'>
                        �ر�
                    </div>
                    <div class="saveNote" style="float:right">
                        ����
                    </div>
                    <div style="clear:both;">
                    </div>
                </div>
                <div style="clear:both;">
                </div>
            </div>
            <div class="lefttable">
                <table width="100%">
                    <tr>
                        <td>
                            <div id="tabtitle">
                                <div id="floatbt1" class="floatbtbg">
                                    <a href="#" onclick="conshowmenutext(1);return false;">������Ϣ</a>
                                </div>
                                <div id="floatbt2" class="floatsetbt">
                                    <a href="#" onclick="conshowmenutext(2);return false;">���ù���</a>
                                </div>
                            </div>
                            <div id="floatdiv1">
                                <div class="edittable6"><div class="dheight">
                                    <table width="100%" border="0">
                                        <tr>
                                            <td style="width: 2%;">
                                            </td>
                                            <td style="width: 15%;" align="left">
                                                ����ģʽ
                                            </td>
                                            <td style="width: 83%;" align="left">
                                                <asp:DropDownList ID="ddlType" runat="server" Width="100">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trno">
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                ʱ��
                                            </td>
                                            <td align="left">
                                                <input id="tbStartDate" class="noteDatePicker"  style="width:70px;" />
                                                <select name="starthour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="startMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��~
                                               <input id="tbEndDate" class="noteDatePicker"  style="width:70px;" />
                                                <select name="endhour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="endMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��
                                            </td>
                                        </tr>
                                        <tr id="trdayrepeat" style="display:none;">
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                ʱ��
                                            </td>
                                            <td align="left">
                                                <select name="starthour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="startMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��~
                                                <select name="endhour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="endMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��
                                                <div style="margin:5px 0 5px 0;">
                                                    ��<input id="dayrepeatstart" class="noteDatePicker"  style="width:70px;" />
                                                    ��<input id="dayrepeatend" class="noteDatePicker"  style="width:70px;" />  
                                                </div>
                                                <div>
                                                    <input type="radio" value="1" name="day" />ÿ<input name="everyday" style="width:15px;"/>��һ��
                                                </div>
                                                <div>
                                                    <input type="radio" value="2" name="day" />ÿ��������
                                                </div>
                                                <div>
                                                    <input type="radio" value="3" name="day" />ÿ����Ϣ��
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trweekrepeat" style="display:none;">
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                ʱ��
                                            </td>
                                            <td align="left">
                                                <select name="starthour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="startMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��~
                                                <select name="endhour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="endMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��
                                                <div style="margin:5px 0 5px 0;">
                                                    ��<input id="tbweekstart" class="noteDatePicker"  style="width:70px;" />
                                                  ��<input id="tbweekend" class="noteDatePicker"  style="width:70px;" />
                                                </div>
                                                <div style="margin:5px 0 5px 0;">
                                                    ÿ<input type="text" style="width:15px;" name="everyweek" />�ܵ�
                                                </div>
                                                <div>
                                                    <input type="checkbox" value="1"/>����һ<input type="checkbox" value="2"/>���ڶ�<input type="checkbox" value="3"/>������<input type="checkbox" value="4"/>������<input type="checkbox" value="5"/>������<input type="checkbox" value="6"/>������<input type="checkbox" value="0"/>������
                                                </div>
                                            </td>
                                        </tr>
                                         <tr id="trmonthrepeat" style="display:none;">
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                ʱ��
                                            </td>
                                            <td align="left">
                                                <select name="starthour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="startMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��~
                                                <select name="endhour">
                                                    <option value='0'>0</option>
                                                    <option value='1'>1</option>
                                                    <option value='2'>2</option>
                                                    <option value='3'>3</option>
                                                    <option value='4'>4</option>
                                                    <option value='5'>5</option>
                                                    <option value='6'>6</option>
                                                    <option value='7'>7</option>
                                                    <option value='8'>8</option>
                                                    <option value='9'>9</option>
                                                    <option value='10'>10</option>
                                                    <option value='11'>11</option>
                                                    <option value='12'>12</option>
                                                    <option value='13'>13</option>
                                                    <option value='14'>14</option>
                                                    <option value='15'>15</option>
                                                    <option value='16'>16</option>
                                                    <option value='17'>17</option>
                                                    <option value='18'>18</option>
                                                    <option value='19'>19</option>
                                                    <option value='20'>20</option>
                                                    <option value='21'>21</option>
                                                    <option value='22'>22</option>
                                                    <option value='23'>23</option>
                                                </select>ʱ
                                                <select name="endMinute">
                                                    <option value='0'>0</option>
                                                    <option value='5'>5</option>
                                                    <option value='10'>10</option>
                                                    <option value='15'>15</option>
                                                    <option value='20'>20</option>
                                                    <option value='25'>25</option>
                                                    <option value='30'>30</option>
                                                    <option value='35'>35</option>
                                                    <option value='40'>40</option>
                                                    <option value='45'>45</option>
                                                    <option value='50'>50</option>
                                                    <option value='55'>55</option>
                                                </select>��
                                                <div style="margin:5px 0 5px 0;">
                                                    ��<input id="monthRepeatStart" class="noteDatePicker"  style="width:70px;" />
                                                  ��<input id="monthRepeatEnd" class="noteDatePicker"  style="width:70px;" />
                                                </div>
                                                <div style="margin:5px 0 5px 0;">
                                                    ÿ<input type="text" style="width:15px;" name="everymonth" />���µ�
                                                    <asp:DropDownList ID="ddlNDayMonthEnum" runat="server">
                                                    </asp:DropDownList><asp:DropDownList ID="ddlMonthDayTypeEnum" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                ����<span class="redstar"> *</span>
                                            </td>
                                            <td align="left">
                                                <textarea rows="6" id="notecontent" style="width:400px;">
                                                </textarea>
                                            </td>
                                        </tr>
                                    </table>
                                </div></div>
                            </div>
                            <div id="floatdiv2" class="hiddendiv" >
                                <div class="edittable6" ><div class="dheight">
                                <div style="padding-left:10px;padding-right:10px;">
                                         <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="12%" align="left">
                                                    ������
                                                </td>
                                                <td align="left">
                                                    <input id="txtAllSharer" type="text" name="������" class="input1 txtAllSharer" style="width:100%;" title="����֮������Ӣ�ķֺ�;����" /><span id="lblMessage" class="error"></span>
                                                </td>
                                            </tr>
                                            </table>
                                            <table style="border:1px solid #bcbcbc;" >
                                            <tr >
                                                <td width="12%" align="left">
                                                    ����
                                                </td>
                                                <td align="left" style="width: 20%;">
                                                    <input id="txtShareAccountName" class="input1" type="text" />
                                                </td>
                                                <td width="12%" align="left">
                                                    ����
                                                </td>
                                                <td align="left" style="width: 25%;">
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ddlDepartment" Style="width: 160px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" >
                                                    <input type="button" value="��ѯ" id="btnSearchShare" class="searchbtn" />
                                                </td>
                                            </tr>
                                        </table>
                                    <div id="divAccountTable" class="linetablediv divAccountTable" style="margin:8px 0 8px 0;">
                                        <table id="searchShareTable" width="100%">
                                        </table>
                                    </div>
                                    </div>
                                </div></div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>



<div class='addItemDiv' id='addItemDiv'><div style="margin-top:8px;">��Ҫ���</div><a title="notes">+ ��ǩ</a></div>



  <div style="height:553px;">
       <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td width="25px"  valign="top">
            <div style="padding-top:56px; height:100%; ">
                <div id="namelist">
                    <div id="selfname" class="nametabon self" runat="server" >
                    </div>
                </div>
                <div id="updownvessel">
                    <div id="nameup" class="nameupdisable" >
                    </div>
                    <div id="namedown" class="namedown">
                    </div>
                </div>
            </div>
        </td>
        <td>
            <div style="height:28px;position:relative;z-index:100;">
                <div id="monthview" class="ctapon" style="left:0;">
                    ����ͼ
                </div>
                <div id="dayview" class="ctap" style="left:75px;">
                    ����ͼ
                </div>
                <div style="float:right;padding-top:6px;" class="hovernone">
                    <a id="prev">&nbsp;</a>
                    <input id="nowDate" type="text" class="date-pick" onchange ="ChangeDate()" readonly ="readonly"/><a id="next">&nbsp;</a>
                    <a id="set">&nbsp;</a>
                    <a id="addother">&nbsp;</a>
                </div>
                <div id="typeDiv" class="popdiv" style="display:none;">
                    <div class="title">
                        ������ʾ��
                    </div>
                    <ul id="typeUL" style="padding-left:25px;margin-top:5px;" runat="server">
                    </ul>
                    <div style="margin:10px 5px 5px 80px">
                        <a style="margin-right:20px;" id="btnSaveSet" >ȷ��</a>
                        <a  id="btnHideSet">ȡ��</a>
                    </div>
                </div>
                <div id="addotherDiv"  class="popdiv" style="display:none;">
                    <div class="title">
                        �����������
                    </div>
                    <div style="padding:5px;"><div class="inputdiv"><input  type="text" /><a id ="btnaddanother" class="btnaddanother">&nbsp;</a></div></div>
                </div>
            </div>
            <div id="calendarlist">
                <div name="self" class="calendaron">
                    <div class="monthCalendar">
                        <table class="calendar" cellspacing="0" cellpadding="0" width="100%">
                        </table>
                    </div>
                    <div class="dayCalendar" style="display:none; ">
                        <div class="toDayWeek fontBlackStrong">
                        </div>
                        <div class="thedaycontainer">
                        <div class="theday">
                        </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </td>
    </tr>
</table>
<div id='hideforwidth' style='width:100%;height:0;border:0;'>
            </div>
</div>


