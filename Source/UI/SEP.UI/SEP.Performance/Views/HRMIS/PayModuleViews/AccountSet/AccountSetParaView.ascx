<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AccountSetParaView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.AccountSetParaView" %>

<script type="text/javascript">
function showBindItem(ddlFieldAttribute,BindFieldID,divBindItem1,divBindItem2)
{
    var ddlFieldAttributeCtrl = document.getElementById(ddlFieldAttribute);
    var divBindItem1 = document.getElementById(divBindItem1);
    var divBindItem2 = document.getElementById(divBindItem2);
    if(ddlFieldAttributeCtrl.value==BindFieldID)
    {
        divBindItem1.style.display="block";
        divBindItem2.style.display="block";
    }
    else
    {
        divBindItem1.style.display="none";
        divBindItem2.style.display="none";
    }
}
</script>

<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div id="tbResultMessage" runat="server" class="leftitbor">
    <asp:Label ID="LabResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="AccountSetParaOperation" runat="server">
    </asp:Label>
    <asp:Label ID="lblAccountSetParaId" runat="server" Text="" Visible="false"></asp:Label>
    <asp:HiddenField ID="Operation" runat="server" />
</div>
              
<div  class="edittable">
  <table width="100%" border="0">
                    <tr>
                        <td align="left" style="width: 100px">
                            ���ײ������� <span style="color: Red">*</span></td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="TxtName" Width="68%" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;<asp:Label
                                ID="lblValidateName" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            ���ײ�������</td>
                        <td align="left" colspan="3">
                            <asp:TextBox runat="server" ID="TxtDescrition" Width="68%" CssClass="grayborder" Height="61px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            Ԥ����������</td>
                        <td align="left" style="width: 25%">
                            <asp:DropDownList ID="ddlFieldAttribute" runat="server" Width="130px">
                            </asp:DropDownList></td>
                        <td align="left" style="width: 10%">
                            <div id="divBindItem1" runat="server">
                                ����</div>
                        </td>
                        <td align="left">
                            <div id="divBindItem2" runat="server" style="display: none;">
                                <asp:DropDownList ID="ddlBindItem" runat="server" Width="45%">
                                </asp:DropDownList>&nbsp;
                                <asp:Label ID="lblValidateBindItem" runat="server" CssClass="psword_f"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100px">
                            Ԥ��β������</td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddlMantissaRound" runat="server" Width="130px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left">
                            </td>
                        <td align="left" colspan="3">
                            <asp:CheckBox ID="cbIsVisibleToEmployee" runat="server" Text="�ò�����Ա���ɼ�" Checked="true"/>
                            <asp:CheckBox ID="cbIsVisibleWhenZero" runat="server" Text="��ֵΪ0ʱ����ʾ�ò���" Checked="true"/></td>
                    </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="BtnOK" OnClick="BtnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="ȡ����" ID="BtnCancel" OnClick="BtnCancel_Click" runat="server" class="inputbt" />
</div>
