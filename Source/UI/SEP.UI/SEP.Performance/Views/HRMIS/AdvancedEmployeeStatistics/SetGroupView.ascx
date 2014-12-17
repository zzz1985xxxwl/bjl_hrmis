<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetGroupView.ascx.cs" Inherits="SEP.Performance.Views.AdvancedEmployeeStatistics.SetGroupView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="center">
        <table id="tbSetGroupTitle" width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0" style="background-color:White">
          <tr>
              <td class="headerstyleblue" style="text-align:left; font-weight:bold">
                 &nbsp;&nbsp;自定义分组统计</td>
              <td class="headerstyleblue" style="font-weight:bold;" width="30px">
<label id="showSetGroup" class="hiddensetdiv" 
onclick="showorhideformSet('tbSetGroup','showSetGroup','hiddenSetGroup',1,'Group');"><<</label>
<label id="hiddenSetGroup" class="showsetdiv" 
onclick="showorhideformSet('tbSetGroup','showSetGroup','hiddenSetGroup',0,'Group');">>></label>
              </td>
         </tr>
         </table>
        <table width="100%" class="linetable" cellpadding="0" cellspacing="10" style="background-color:White;text-align:left;border-collapse:separate;" 
        id="tbSetGroup">
          <tr>
            <td width = "10px">
            </td>
            <td width = "100px">
                 第1层分组统计
            </td>
            <td align="left" >
                <asp:DropDownList ID="ddlGroupList" runat="server" Width="200px">
                <asp:ListItem Text="按文化程度分组统计" Value="0"></asp:ListItem>
                </asp:DropDownList></td>
          </tr>
        </table>
    </td>
</tr>
</table>
