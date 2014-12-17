<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetScopeView.ascx.cs" Inherits="SEP.Performance.Views.AdvancedEmployeeStatistics.SetScopeView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="center">
        <table id="tbSetScopeTitle" width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0" style="background-color:White">
          <tr>
              <td class="headerstyleblue" style="text-align:left; font-weight:bold">
                 &nbsp;&nbsp;自定义统计范围</td>
              <td class="headerstyleblue" style="font-weight:bold;" width="30px">
<label id="showSetScope" class="hiddensetdiv" 
onclick="showorhideformSet('tbSetScope','showSetScope','hiddenSetScope',1,'Scope');"><<</label>
<label id="hiddenSetScope" class="showsetdiv" 
onclick="showorhideformSet('tbSetScope','showSetScope','hiddenSetScope',0,'Scope');">>></label>
              </td>
         </tr>
         </table>
        <table width="100%" class="linetable" cellpadding="0" cellspacing="10" style="background-color:White;text-align:left;border-collapse:separate;" 
        id="tbSetScope">
          <tr>
            <td width = "10px">
            </td>
            <td width = "60px" >
                 员工类型
            </td>
            <td align="left" >
                当前统计范围：全部 筛选
            </td>
          </tr>
          <tr>
            <td width = "10px">
            </td>
            <td>
                员工性别
            </td>
            <td align="left">
                当前统计范围：全部 
                   <a href="javascript:showdescription('GenderScope');">筛选</a>
                   <div id="ItemGenderScope" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                        <table onclick ="javascript:IsNextExecute = false;" width="200px" class="linetable_3" 
                        cellpadding="0" cellspacing="0" >
                          <tr>
                            <td height="28"  class="tdbg02bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="16%" height="23" align="center"><img src="../../image/icon04.jpg" /></td>
                                <td width="68%" align="left"><strong style="color:#FFFFFF">员工性别</strong></td>
                                <td width="16%" align="center"><a href="#">
                                <img src="../../image/xxx.jpg" border="0" onclick="javascript:showdescription('GenderScope');"  /></a></td>
                              </tr>
                            </table></td>
                          </tr>
                          <tr>
                            <td>
                                 <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                   <tr>
                                     <td align="center" valign="top"><table width="98%" border="0" 
                                     cellpadding="5" cellspacing="6" style="border-collapse:separate;">
                                        <tr>
                                            <td width="97%" class="fonttable_2" align="left" valign="top" height="50px">
                                                <asp:CheckBoxList ID="cblGender" runat="server">
                                                    <asp:ListItem Text="男" Value="0">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="女" Value="1">
                                                    </asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                       </table></td>
                                   </tr>
                                 </table></td>
                          </tr>
                          </table>
                    </div>

            </td>
          </tr>
        </table>
    </td>
</tr>
</table>
