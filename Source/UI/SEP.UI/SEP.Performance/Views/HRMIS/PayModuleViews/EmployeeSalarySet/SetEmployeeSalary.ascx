<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetEmployeeSalary.ascx.cs" EnableViewState="false"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.SetEmployeeSalary" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.json-2.2.js"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.ajaxfileupload.js"></script>
<script language="javascript " type="text/javascript" src="../../Inc/SetEmployeeSalary.js" charset="gb2312"></script>
<asp:HiddenField ID="hfCompanyID" runat="server" />
<div id="tbMessage" class="leftitbor" > <span id="lblMessage"  class="fontred"></span>
</div>
<div class="leftitbor2" id="leftitbor2">
  <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
  <asp:Label ID="lblSalaryTime" runat="server"></asp:Label>
  ---
  <asp:Label
          ID="lblSalaryEndTime" runat="server"></asp:Label>
  员工薪资 </div>
<div class="nolinetablediv" >
  <table width="100%"  border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td width="20%" align="center" style="padding-right:2px;"><table width="100%"  class="salarytable">
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="salarytd1"><table width="100%" border="0">
                      <tr>
                        <td height="40" align="center" valign="bottom"><div id="btnInitial" onclick="btnInitial_Click();"  style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table width="100%" border="0">
                              <tr>
                                <td height="30" align="center" valign="bottom"><a> <img src="../../image/salarybt1_01.gif" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">发放</span></a></td>
                              </tr>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div id="btnClose" onclick='CloseSalaryShow();'  style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table width="100%" border="0">
                              <tr>
                                <td align="center" valign="bottom"><a > <img src="../../image/salarybt1_02.gif" border="0" align="middle"><br />
                                    <span id="txtBtnClose" style="vertical-align:middle;color:#3f68a6">封帐</span></a></td>
                              </tr>
                              <%--          <tr>
                              <td height="30" align="center" valign="top">封帐</td>
                            </tr>--%>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div  id="btnReopen" onclick="btnReopen_Click();"  style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table width="100%" border="0">
                              <tr>
                                <td align="center" valign="bottom"><a> <img src="../../image/salarybt1_03.gif" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">解封</span></a></td>
                              </tr>
                              <%--              <tr>
                              <td height="28" align="center" valign="top">解封</td>
                            </tr>--%>
                            </table>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td class="salarytd2"> 工资设置</td>
                </tr>
              </table></td>
          </tr>
        </table></td>
      <td width="12%" align="center" style="padding-right:2px;"><table width="100%"  class="salarytable">
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="salarytd1"><table width="100%" border="0">
                      <tr>
                        <td align="center"><div id="salarybt4" style="width: 100%;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table width="100%" border="0">
                              <tr>
                                <td align="center" valign="bottom"><div style="text-align: center">
                                    <label id="showSet" style="cursor:pointer;"  class="showsetdiv" onclick="ShowOrHideForm('searchConditionView','showSet','hiddenSet',1)"> <img src="../../image/salarybt2_01.jpg" align="middle"><br />
                                      显示搜索条件</label>
                                    <label id="hiddenSet"  style="cursor:pointer;" class="hiddensetdiv" onclick="ShowOrHideForm('searchConditionView','showSet','hiddenSet',0)"> <img src="../../image/salarybt2_02.jpg" align="middle"><br />
                                      <span style="vertical-align: middle">隐藏搜索条件</span></label>
                                  </div></td>
                              </tr>
                              <%--                <tr>
                              <td height="30" align="center" valign="top">显示搜索条件</td>
                            </tr>--%>
                            </table>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td class="salarytd2"> 设置搜索条件</td>
                </tr>
              </table></td>
          </tr>
        </table></td>
      <td width="12%" align="center" style="padding-right:2px;"><table  width="100%"  class="salarytable">
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="salarytd1"><div id="salarybt5" style="width: 100%;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                      <table width="100%" border="0">
                        <tr>
                          <td align="center" valign="bottom"><div style="text-align: center">
                              <label id="ShowCheckDiv" style="cursor:pointer;" class="showsetdiv" onclick="ShowOrHideForm('CheckBoxDiv','ShowCheckDiv','HideCheckDiv',1)"> <img src="../../image/salarybt3_01.gif" border="0"
                                                                                align="middle"><br />
                                显示设置列</label>
                              <label id="HideCheckDiv"  style="cursor:pointer;"  class="hiddensetdiv" onclick="ShowOrHideForm('CheckBoxDiv','ShowCheckDiv','HideCheckDiv',0)"> <img src="../../image/salarybt3_02.gif" border="0"
                                                                                align="middle"><br />
                                隐藏设置列</label>
                            </div></td>
                        </tr>
                        <%--            <tr>
                        <td height="30" align="center" valign="top">显示设置列</td>
                      </tr>--%>
                      </table>
                    </div></td>
                </tr>
                <tr>
                  <td class="salarytd2"> 设置显示/隐藏列</td>
                </tr>
              </table></td>
          </tr>
        </table></td>
      <td width="42%" align="center" style="padding-right:2px;"><table  width="100%" class="salarytable">
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="salarytd1"><table width="100%" border="0">
                      <tr>
                        <td height="40" align="center" valign="bottom"><div ID="btnTempSave" onclick="btnTempSave_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table width="100%" border="0">
                              <tr>
                                <td align="center" valign="bottom"><a> <img src="../../image/salarybt4_01.gif" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">保存</span></a></td>
                              </tr>

                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div  id="btnDelete" onclick="btnDelete_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td align="center" valign="bottom"><a> <img src="../../image/salarybt4_03.gif" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">删除</span></a></td>
                              </tr>
                              <tr>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div id="btnAdd" onclick="btnAdd_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td align="center" valign="bottom"><a> <img src="../../image/salarybt4_02.gif" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">新增</span></a></td>
                              </tr>
                              <%--                            <tr>
                              <td align="center">新增选中<br>
员工工资</td>
                            </tr>--%>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div id="lbUpdateSome"  onclick="lbUpdateSome_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td height="25" align="center" valign="bottom"><a> <img src="../../image/salarybt4_06.gif" border="0" align="middle"><br />
                                  <span id="txtUpdateSome" style="vertical-align:middle;color:#3f68a6;">批量修改</span></a>
                              </tr>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div id="salarybt9" style="width: 100%;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td height="25" align="center" valign="bottom"><a id="btnSelectAll" onclick="btnSelectAll_Click();"> <img src="../../image/salarybt4_04.gif"  border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">全选</span></a> <a id="btnClear"  onclick="btnClear_Click()" style="display:none;"> <img src="../../image/salarybt4_05.gif"  border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6;">清除</span></a></td>
                              </tr>
                              <%--           <tr>
                              <td height="30" align="center" valign="top">全选</td>
                            </tr>--%>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div  id="linkMail"  onclick="linkMail_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td height="25" align="center" valign="bottom"><a> <img src="../../image/salarybt5_05.gif" width="29" height="28" border="0" align="middle"><br />
                                  <span style="vertical-align:middle;color:#3f68a6">工资邮件</span></a></td>
                              </tr>
                              <%--           <tr>
                              <td height="30" align="center" valign="top">全选</td>
                            </tr>--%>
                            </table>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td class="salarytd2"> 员工薪资操作</td>
                </tr>
              </table></td>
          </tr>
        </table></td>
      <td width="20%" align="center"><table  width="100%"  class="salarytable">
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="salarytd1"><table width="100%" border="0">
                      <tr>
                        <td height="40" align="center" valign="bottom"><div id="salarybt12" style="width: 100%;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td align="center" valign="bottom"><div style="text-align: center">
                                    <label  style="cursor:pointer;" id="showOperationDiv" class="showsetdiv" onclick="ShowOperation();"> <img src="../../image/salarybt5_01.gif" width="30" height="28" border="0"
                                                                                            align="middle"><br />
                                      导入</label>
                                    <label  style="cursor:pointer;" id="HideOperationDiv" class="hiddensetdiv" onclick="HideOperation();"> <img src="../../image/salarybt5_02.gif" width="30" height="28" border="0"
                                                                                            align="middle"><br />
                                      隐藏</label>
                                  </div></td>
                              </tr>
                              <%--                            <tr>
                              <td height="30" align="center" valign="top">导入</td>
                            </tr>--%>
                            </table>
                          </div></td>
                        <td align="center" valign="bottom"><div id="btnExportClient"  onclick="btnExportClient_Click()" style="width: 100%;cursor:pointer;" onmouseover="showsearchform(this,1);" onmouseout="showsearchform(this,0);">
                            <table border="0" width="100%">
                              <tr>
                                <td align="center" valign="bottom"><a> <span style="vertical-align:middle;color:#3f68a6"> <img src="../../image/salarybt5_03.gif" width="30" height="30" border="0"><br />
                                  导出</span></a></td>
                              </tr>
                              <%--             <tr>
                              <td height="30" align="center" valign="top">导出</td>
                            </tr>--%>
                            </table>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
                <tr>
                  <td class="salarytd2"> 导入/导出设置</td>
                </tr>
              </table></td>
          </tr>
        </table></td>
    </tr>
  </table>
</div>
<div id="searchConditionView" class="hiddenformdiv" >
  <div class="edittable" style="margin-top:0px;">
    <table width="100%" border="0">
      <tr>
        <td width="9%" align="right"> 发薪时间</td>
        <td width="22%" align="left"><asp:TextBox ReadOnly="true" ID="txtSalaryTime" runat="server" CssClass="input1" Width="94%"></asp:TextBox>
          <%--                  <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM"
                      TargetControlID="txtSalaryTime"> </ajaxToolKit:CalendarExtender> --%>
          <asp:Label ID="lblTimeSalaryMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        <td width="8%" align="right"> 职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位</td>
        <td width="22%" align="left"><asp:DropDownList ID="listPossition" runat="server" Width="98%"> </asp:DropDownList></td>
        <td width="9%" align="right"> 工资帐套</td>
        <td width="22%" align="left"><asp:DropDownList ID="listAccountSet" runat="server" Width="98%"> </asp:DropDownList></td>
        <td width="8%" align="left"></td>
      </tr>
      <tr>
        <td align="right"> 员工姓名 </td>
        <td align="left"><asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="94%"></asp:TextBox></td>
        <td align="right"> 部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门</td>
        <td align="left"><asp:DropDownList ID="listDepartment" runat="server" Width="98%" > </asp:DropDownList></td>
        <td align="right"> 员工类型</td>
        <td align="left"><asp:DropDownList ID="listEmployeeType" runat="server" Width="98%" > </asp:DropDownList></td>
        <td align="left">&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
          <input id="btnSearch" type="button"
                                value="查　询" onclick="btnSearch_Click()" class="inputbt" /></td>
      </tr>
    </table>
  </div>
</div>
<div id="CheckBoxDiv" class="hiddenformdiv" >
  <div class="edittable">
    <table width="100%" id="tbTitleHiddenSet" style="text-align:left;" border="0" cellpadding="0" cellspacing="0">
    </table>
  </div>
</div>
<div id="operationDiv" class="hiddenformdiv" >
  <div  class="edittable" style="margin-top:0px;">
    <table width="100%" border="0">
      <tr>
        <td width="2%" align="right"></td>
        <td align="left" colspan="2">&nbsp;&nbsp;
           <input type="file" id="fuExcel" name="fuExcel" onkeydown="event.returnValue=false;" style="width:500px;" onpaste="return false" class="fileupload" />
          &nbsp;&nbsp; &nbsp;
          <input id="btnIn" value="确　定" class="inputbt" onclick="btnIn_Click()" type="button" /></td>
      </tr>
    </table>
  </div>
</div>
<div id="UpdateSomeDiv" class="hiddenformdiv" >
  <div class="edittable" style="margin-top:0px;">
    <table width="100%" border="0">
      <tr>
        <td width="10%" align="right"> 帐套项 </td>
        <td width="30%" align="left"><select id="ddlAccountSetItem" style="width:160px;"></select></td>
        <td width="10%" align="right"> 数值</td>
        <td width="30%" align="left"><input id="txtResult" type="text" class="input1" /><span id="txtResultMessage" class='error'></span></td>
        <td width="8%" align="right">&nbsp;</td>
        <td width="20%" align="left"></td>
        <td align="left"><input id="btnUpdateSome" type="button" value="确　定" onclick="btnUpdateSome_Click();"
                                class="inputbt" /></td>
      </tr>
    </table>
  </div>
</div>
<div class="hiddenformdiv" id="divCloseSalary" >
  <div class="edittable" style="margin-top:0px;">
    <table width="100%" border="0">
      <tr>
        <td width="20%" align="left"><input type="checkbox" id="cbIsSendEmail" />发送工资邮件</td>
        <td width="80%" align="left"><input id="btnCloseSalary" type="button"   onclick="btnClose_Click()" class="inputbt" value="封帐" /><span style="margin-left:20px;color:#f00;">注：封帐之前请确保所有的更改已保存</span></td>
      </tr>
    </table>
  </div>
</div>
<div id="salaryDiv" >
  <div id="colEmployeeName">
    <div id="leftTitle">
    </div>
    <div id="EmployeeNameHeight">
      <div id="employeeNameDiv">
      </div>
    </div>
  </div>
  <div id="rightVessel">
    <div id="scrollHeightDiv" class="yelloScrollbar">
      <div id="scrollHeight"> </div>
    </div>
    <div id="scrollWidthDiv" class="yelloScrollbar">
      <div id="scrollWidth"> </div>
    </div>
    <div id="colTitleWidth">
      <div id="colTitle">
      </div>
    </div>
    <div id="valuesHeightWidth">
      <div id="valuesDiv">   
      </div>
    </div>
  </div>
</div>
<style type="text/css" media="screen">
        #salaryDiv {
            border: 1px solid #69AD3C;
            margin: 8px;
            height: 409px;
            position:relative;
        }
        
        #valuesHeightWidth {
            height: 363px;
            overflow: hidden;
        }
        
        #EmployeeNameHeight {
            height: 363px;
            overflow: hidden;
        }
        
        #scrollHeightDiv {
            position: absolute;
            top: 0;
            right: 0;
            width: 18px;
            height: 391px;
            overflow-y: scroll;
            z-index: 5;
        }
        
        
        #scrollWidthDiv {
            position: absolute;
            left: 0;
            bottom: 1px;
            height: 18px;
            overflow-x: scroll;
            z-index: 5;
        }
        
        #scrollWidth {
            height: 18px;
        }
        
        #rightVessel {
            float: left;
            position: relative;
            padding-bottom: 18px;
            text-align:left;
        }
        
        #colTitleWidth {
            overflow: hidden;
        }
        
        #colEmployeeName {
            float: left;
			z-index:100;
        }   
        #leftTitle {
            background-color: #9AD075;
            height:27px;
            width: 75px;
            background-color: #9AD075;
            border-bottom: 1px solid #69AD3C;
	        border-right:1px solid #69AD3C;
        }
        .checkboxName {
            margin-right: 3px;
        }
        
        #employeeNameDiv .nametr {
            height: 23px;
            width:75px;
            border-bottom: 1px solid #69AD3C;
			border-right:1px solid #69AD3C;
			overflow:hidden;
        }
        
        
        #employeeNameDiv {   
            text-align: left;
        }
        
        #employeeNameDiv,#valuesDiv{
        	padding-bottom:2px;
        }
           
        .coltitle{
            width:85px;
            height:19px;
            overflow:hidden;
            float:left;
            padding-top:8px;
            white-space:nowrap;
            text-overflow:ellipsis;
            border-left: 1px solid #69AD3C;
            border-bottom: 1px solid #69AD3C;
        }
        .values{
            width:85px;
            height:20px;
            padding-top:3px;
            float:left;
            border-left: 1px solid #69AD3C;
            border-bottom: 1px solid #69AD3C;
        }
        .valuetr{
            height:24px;
        }
        .accountName{
            width:110px;
            overflow:hidden;
            white-space:nowrap;
            text-overflow:ellipsis;
            display:block;
        }
        .values input {
            width: 94%;
            border: none;
            background-color: transparent;
        }
        
        #colTitle {
            background-color: #9AD075;
            text-align: center;
            height:28px;
        }
        .errorTR{
            background-color:#FE8571;
        }
        .successTR{
             background-color:#DFFBAB;
        }
</style>

