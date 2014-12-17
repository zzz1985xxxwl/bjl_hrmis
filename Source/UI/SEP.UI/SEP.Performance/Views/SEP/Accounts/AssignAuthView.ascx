<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignAuthView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Accounts.AssignAuthView" %>
 <script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
 <link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<style type="text/css">
/* common styling */
.childAuth {
padding:0px 0px 0px 0px; height:28px; width:140px; valign:absmiddle;
}
/* common styling */
.checkboxlist li{
	float:left;width:150px;height:26px;
}
</style>
 
<script type ="text/jscript">
function SelectChildren(ParentID)
{
    var ctrlname ="cphCenter_AssignSEPAuthInfoView1_AssignAuthView1_";
    var ParentCtrl = document.getElementById(ctrlname+ParentID);
    if(ParentID == "cb1")
    {
        document.getElementById(ctrlname+"cb101").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb102").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb103").checked=ParentCtrl.checked;
    }
    else if(ParentID == "cb2")
    {
        document.getElementById(ctrlname+"cb201").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb202").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb203").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb204").checked=ParentCtrl.checked;
        
    }
    else if(ParentID == "cb3")
    {
        document.getElementById(ctrlname+"cb301").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb302").checked=ParentCtrl.checked;
    }
    else if(ParentID == "cb4")
    {
        document.getElementById(ctrlname+"cb401").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb402").checked=ParentCtrl.checked;
    }
    else if(ParentID == "cb5")
    {
        document.getElementById(ctrlname+"cb501").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb502").checked=ParentCtrl.checked;
        document.getElementById(ctrlname+"cb503").checked=ParentCtrl.checked;
    }
    else if(ParentID == "cb6")
    {
        document.getElementById(ctrlname+"cb601").checked=ParentCtrl.checked;
    }
}

function SelectParent(ParentID)
{
    var ctrlname ="cphCenter_AssignSEPAuthInfoView1_AssignAuthView1_";
    var ParentCtrl = document.getElementById(ctrlname+ParentID);
    if(ParentID == "cb1")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb101").checked &&
        document.getElementById(ctrlname+"cb102").checked &&
        document.getElementById(ctrlname+"cb103").checked;
    }
    else if(ParentID == "cb2")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb201").checked &&
        document.getElementById(ctrlname+"cb202").checked &&
        document.getElementById(ctrlname+"cb203").checked&&
        document.getElementById(ctrlname+"cb204").checked;
    }
    else if(ParentID == "cb3")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb301").checked &&
        document.getElementById(ctrlname+"cb302").checked;
    }
    else if(ParentID == "cb4")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb401").checked &&
        document.getElementById(ctrlname+"cb402").checked;
    }
    else if(ParentID == "cb5")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb501").checked &&
        document.getElementById(ctrlname+"cb502").checked &&
        document.getElementById(ctrlname+"cb503").checked;
    }
    else if(ParentID == "cb6")
    {
        ParentCtrl.checked = 
        document.getElementById(ctrlname+"cb601").checked;
    }
}
function BinGoogledown()
{
   $(".txtAccount").autocomplete("../../../Pages/SEP/AuthPages/AssignAuthGooldownPage.aspx",{mouseovershow:false});
   $(".txtAccount").result(function(event, data, formatted) {txtAccountChanged(event.target);});
}
function txtAccountChanged(th)
{
   $(th).next("input").eq(0).trigger("click");
}
$(function(){
BinGoogledown();
});
</script>

<div id="divMessage" class="leftitbor" runat="server" >
    <asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>

<div class="leftitbor2" >����Ȩ��</div>

<div class="edittable">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
   <td align="left" style="width: 2%;">
                </td>
                    <td valign="middle" align="left" style="width: 8%">�ʡ���</td>
                    <td valign="middle" align="left" style="width: 41%">
                    <asp:TextBox ID="txtAccount" CssClass="txtAccount" runat="server" ></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server"  style="display:none;" OnClick="btnSearch_Click"  />
                    <asp:Label ID="lbAccountMsg" runat="server" CssClass = "psword_f"></asp:Label></td>                   
                    <td align="left" style="width: 8%;"></td>
                    <td align="left" style="width: 41%"></td>
                  </tr>

    </table>
</div>
<div class="tablebt">
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="ȷ����" CssClass = "inputbt"/>
</div>
<div class="nolinetablediv">
            <table width="100%" height="100%"  cellpadding="0" cellspacing="0"  class="linetable">  
              <tr>
                <td align="left"  style="padding:0px;">

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left" style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb1" runat="server" Text=" �û�����"  onclick="SelectChildren('cb1');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul1" class="checkboxlist">
                      <li><asp:CheckBox ID="cb101" runat="server" Text=" �����û�" onclick = "SelectParent('cb1')"/></li>
                      <li><asp:CheckBox ID="cb102" runat="server" Text=" ��ѯ�û�" onclick = "SelectParent('cb1')"/></li>
                      <li><asp:CheckBox ID="cb103" runat="server" Text=" ����Ȩ��" onclick = "SelectParent('cb1')"/></li>
                    </ul></td>
                  </tr>
                </table></td>
              </tr>
              <tr class="table_g" >
                <td align="left"  style="padding:0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left" style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb2" runat="server" Text=" ��֯�ܹ�����" onclick="SelectChildren('cb2');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul2" class="checkboxlist">
                      <li><asp:CheckBox ID="cb201" runat="server" Text=" ��֯�ܹ�����" onclick = "SelectParent('cb2')"/></li>
                      <li><asp:CheckBox ID="cb202" runat="server" Text=" ְλ����" onclick = "SelectParent('cb2')"/></li>
                      <li><asp:CheckBox ID="cb203" runat="server" Text=" ְλ�ȼ�����" onclick = "SelectParent('cb2')"/></li>
                      <li><asp:CheckBox ID="cb204" runat="server" Text=" ��λ���ʹ���" onclick = "SelectParent('cb2')"/></li>
                    </ul></td>
                  </tr>
                </table></td>
              </tr>
              <tr>

                <td align="left"  style="padding:0px;">

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left"  style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb3" runat="server" Text=" �������"  onclick="SelectChildren('cb3');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul5" class="checkboxlist">
                      <li><asp:CheckBox ID="cb301" runat="server" Text=" ��������" onclick = "SelectParent('cb3')"/></li>
                      <li><asp:CheckBox ID="cb302" runat="server" Text=" ��ѯ����" onclick = "SelectParent('cb3')"/>
                        <asp:ImageButton ID="ib302" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                        OnClick="btnLink_Click"  /></li>
                    </ul></td>
                  </tr>
                </table></td>
              </tr>
              <tr class="table_g">
                <td align="left"  style="padding:0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left" style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb4" runat="server" Text=" ��˾Ŀ�����"  onclick="SelectChildren('cb4');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul6" class="checkboxlist">
                      <li><asp:CheckBox ID="cb401" runat="server" Text=" ������˾Ŀ��" onclick = "SelectParent('cb4')"/></li>
                      <li><asp:CheckBox ID="cb402" runat="server" Text=" ��ѯ��˾Ŀ��" onclick = "SelectParent('cb4')"/></li>
                    </ul></td>
                  </tr>
                </table></td>
              </tr>
              <tr>

                <td align="left"  style="padding:0px;">

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left"  style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb5" runat="server" Text=" ��ҵ�Ļ�"  onclick="SelectChildren('cb5');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul8" class="checkboxlist">
                      <li><asp:CheckBox ID="cb501" runat="server" Text=" ���ù�˾����" onclick = "SelectParent('cb5')"/></li>
                      <li><asp:CheckBox ID="cb502" runat="server" Text=" �����Զ���������" onclick = "SelectParent('cb5')"/></li>
                      <li><asp:CheckBox ID="cb503" runat="server" Text=" ��������ʱ��" onclick = "SelectParent('cb5')"/></li>
                    </ul></td>
                  </tr>
                </table></td>
              </tr> 
              <tr class="table_g">
                <td align="left" style="padding:0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td colspan="2" align="left"  style="height:26px; vertical-align:middle;">
                    <strong><asp:CheckBox ID="cb6" runat="server" Text=" ��������"  onclick="SelectChildren('cb6');"/></strong></td>
                  </tr>
                  <tr>
                    <td width="10" style="height:26px; vertical-align:middle;">&nbsp;</td>
                    <td align="left" valign="top"><ul id="Ul12" class="checkboxlist">
                      <li><asp:CheckBox ID="cb601" runat="server" Text=" �鿴��������" onclick = "SelectParent('cb6')"/>
                    </ul></td>
                  </tr>
                </table></td>
              </tr> 
          </table>
        </div>
              