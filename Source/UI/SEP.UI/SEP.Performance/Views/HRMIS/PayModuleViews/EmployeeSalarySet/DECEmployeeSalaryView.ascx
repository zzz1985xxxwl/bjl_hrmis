<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DECEmployeeSalaryView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.DECEmployeeSalaryView" %>

<script language="javascript " type="text/javascript" src="../../Inc/UsbKey.js"></script>

<div id="tbMessage" runat="server" class="leftitbor">
    <span class="fontred">
        <asp:Label ID="lblMessage" runat="server"></asp:Label></span>
</div>
<div class="leftitbor2">
    ���ܹ��ʵ�
</div>

<div class="edittable">
    <table width="100%" border="0">

                    <tr>
                        <td width="15%" align="right" valign="top">
                            ���ܹ��ʵ��ַ���&nbsp;<span style="color: Red">*</span></td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtEmployeeSalaryCode" runat="server" TextMode="MultiLine" CssClass="grayborder"
                                Width="550px" Height="118px" Wrap="true"></asp:TextBox>
                            <asp:Label ID="lblEmployeeSalaryCodeMsg" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                      <td align="right" valign="top">&nbsp;</td>
                      <td align="left" >�뽫���ʵ��ʼ��еļ����ַ������Ƶ����ֿ���</td>
                    </tr>
                </table>
</div>
<div class="tablebt">
  <asp:Button ID="btnDECEmployeeSalary" runat="server" OnClientClick='GetUsbKey();return true;'
                                    Text="���ܹ��ʵ�" CssClass="inputbt" OnClick="btnDECEmployeeSalary_Click" />
</div>
<div  class="marginepx">
    <table id="tbResult" runat="server" width="100%"  cellpadding="10" cellspacing="0"   class="linetable2" >
    </table>
</div>
<input id="lbUsbKeyCount" class="UsbKeyCount" type="hidden" runat="server" />
<input id="lbUsbKey" class="UsbKey" type="hidden" runat="server" />