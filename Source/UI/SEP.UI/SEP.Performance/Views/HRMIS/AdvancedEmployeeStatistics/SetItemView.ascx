<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetItemView.ascx.cs" Inherits="SEP.Performance.Views.AdvancedEmployeeStatistics.SetItemView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="center">
        <table id="tbSetItemTitle" width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0" style="background-color:White">
          <tr>
              <td class="headerstyleblue" style="text-align:left; font-weight:bold">
                 &nbsp;&nbsp;�Զ���ͳ����</td>
              <td class="headerstyleblue" style="font-weight:bold;" width="30px">
<label id="showSetItem" class="hiddensetdiv" 
onclick="showorhideformSet('tbSetItem','showSetItem','hiddenSetItem',1,'Item');"><<</label>
<label id="hiddenSetItem" class="showsetdiv" 
onclick="showorhideformSet('tbSetItem','showSetItem','hiddenSetItem',0,'Item');">>></label>
              </td>
         </tr>
         </table>
        <table width="100%" class="linetable" cellpadding="0" cellspacing="10" style="background-color:White;text-align:left;border-collapse:separate;" 
        id="tbSetItem">
          <tr>
            <td width = "10px">
            </td>
            <td width = "60px">
                 Ա������
            </td>
            <td align="left">
                ��ǰͳ����� 
                   <a href="javascript:showdescription('EmployeeTypeItem');">ɸѡ</a>
                   <div id="ItemEmployeeTypeItem" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                        <table onclick ="javascript:IsNextExecute = false;" width="200px" class="linetable_3"  cellpadding="0" cellspacing="0" >
                          <tr>
                            <td height="28" class="tdbg02bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td width="16%" height="23" align="center"><img src="../../image/icon04.jpg" /></td>
                                <td width="68%" align="left"><strong style="color:#FFFFFF">Ա������</strong></td>
                                <td width="16%" align="center"><a href="#">
                                <img src="../../image/xxx.jpg" border="0" onclick="javascript:showdescription('EmployeeTypeItem');"  /></a></td>
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
                                                    <asp:ListItem Text="ʵϰ" Value="0">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="����" Value="1">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="��ʽ" Value="2">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="��ְ" Value="3">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="��ְ" Value="4">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="����" Value="5">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="����" Value="6">
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
          <tr>
            <td width = "10px">
            </td>
            <td>
                Ա���Ա�
            </td>
            <td align="left">
                ��ǰͳ�����</td>
          </tr>
        </table>
    </td>
</tr>
</table>
