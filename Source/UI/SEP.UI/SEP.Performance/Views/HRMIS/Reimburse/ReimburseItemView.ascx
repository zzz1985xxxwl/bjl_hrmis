<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimburseItemView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseItemView" %>
<asp:HiddenField ID="hfOperationType" runat="server" />
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
</div>
<%--	<div  class="linetabledivbg">
          <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="right" style="height: 24px; width: 2%;">
            </td>
            <td align="left" style="height: 24px; width: 12%;">
                ���
            </td>
            <td align="left" style="height: 24px; width: 35%;">
                <asp:TextBox runat="server" ID="txtID" CssClass="input1" Width="105px" ReadOnly="true"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" style="height: 24px; width: 12%;">
                �������
            </td>
            <td align="left" style="height: 24px; width: 39%;">
                <asp:DropDownList ID="ddlReimburseType" runat="server" Width="116px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trAddress" runat="server">
            <td align="right" style="height: 24px;">
            </td>
            <td align="left" style="height: 24px">
                ���&nbsp;&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" style="height: 24px;">
                <asp:TextBox runat="server" ID="txtTotalCost" CssClass="input1" Width="105px"></asp:TextBox>
                <asp:Label ID="lblTotalCostMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td id="tdConsumePlacelb" runat="server" align="left" style="height: 24px;">
                ���ѵص�
            </td>
            <td id="tdConsumePlace" runat="server" align="left" style="height: 24px;">
                <asp:TextBox runat="server" ID="txtConsumePlace" CssClass="input1" Width="110px"></asp:TextBox>
                <%--                  <asp:TextBox  runat="server" ID="txtProjectName" CssClass="input1" Width="105px" Visible = "false"></asp:TextBox>--%>
            </td>
        </tr>
        <%--            <tr>
              <td align="right" style="height: 24px; width: 2%;" ></td>
              <td align="left" style="height: 24px; width: 18%;" >
                  ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(��)&nbsp;&nbsp;<span class = "redstar">*</span></td>
              <td align="left" style="height: 24px; width: 37%;"  >
              <asp:TextBox  runat="server" ID="txtTotalCost" CssClass="input1" Width="105px"></asp:TextBox>
                  <asp:Label ID="lblTotalCostMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
              <td align="left" style="height: 24px; width: 37%;" >
              </td> 

              <td align="left" style="height: 24px; width: 37%;"  >
</td>
			  </tr>--%>
        <tr>
            <td align="right" style="height: 24px;">
            </td>
            <td align="left" style="height: 24px">
                �ͻ����(SAP)
            </td>
            <td align="left" colspan="3" style="height: 24px">
                <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="input1" Width="105px"
                    OnTextChanged="txtCustomerCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:HiddenField ID="txtCustomerID" runat="server" />
                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                <asp:Label ID="lblCustomerNameError" runat="server" CssClass="psword_f"></asp:Label>
                <br />
                ����д�ͻ���SAP��ţ����ϵͳ�޷����ݱ�ż��أ����������Ա�������ϵ��</td>
        </tr>
        <tr>
            <td align="right" style="height: 24px;">
            </td>
            <td align="left" style="height: 24px">
                ����&nbsp;&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" colspan="3" style="height: 24px">
                <asp:TextBox ID="txtReason" runat="server" CssClass="grayborder" Height="100px" Width="85%"
                    TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="lblReasonMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="ȡ����" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>

