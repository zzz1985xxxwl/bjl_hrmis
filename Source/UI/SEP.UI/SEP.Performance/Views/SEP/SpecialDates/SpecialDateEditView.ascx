<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialDateEditView.ascx.cs" Inherits="SEP.Performance.Views.SEP.SpecialDates.SpecialDateEditView" %>

    <div style="vertical-align:middle"  id="ShowInfo" runat="server" visible="false" class="leftitbor">
         <asp:Label CssClass="fontred" ID="lblResultMessage" runat="server"></asp:Label>
    </div>
    <div class="leftitbor2" >
              <asp:Label ID="lbOperationType" runat="server" >设定特殊日期</asp:Label>              
              <asp:HiddenField ID="hf_SpecialDateID" runat="server" />		
		</div>
      
<div  class="edittable">
  <table width="100%" border="0">
        <tr>
          <td align="left" style="width: 80px">
              日期&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td align="left"><asp:TextBox ID="txtSpecialDate" runat="server" Width="150px" CssClass="input1" ReadOnly="True"></asp:TextBox>
              &nbsp;&nbsp;
<asp:RadioButton ID="rb_Work"
    runat="server" Checked="True" GroupName="IsWork" Text="工作日" />
<asp:RadioButton ID="rb_Rest" runat="server" GroupName="IsWork" 
    Text="休息日" />&nbsp;<asp:RadioButton ID="rb_LegalHoliday" runat="server" GroupName="IsWork" 
    Text="法定假日" /></td>
        </tr>
        <tr valign="middle">
          <td align="left" style="width: 80px">
              说明&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td align="left" valign="middle"><asp:TextBox ID="txtTitle" runat="server" Width="150px" CssClass="input1"></asp:TextBox>
          <asp:Label ID="lblValidateTitle" runat="server"  CssClass="psword_f"></asp:Label>&nbsp;
          </td>
        </tr>
        <tr >
          <td align="left" valign="top" style="width: 80px">
              详细描述&nbsp;</td>
          <td align="left" valign="top">
          <asp:TextBox ID="txtContent" runat="server" CssClass="grayborder"  Width="150px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        </table>
</div>
 <div class="tablebt">
            <asp:Button ID="btnOK" runat="server" Text="确　定" onclick="btnOK_Click" CssClass="inputbt"  />
            <asp:Button ID="btnCancel" runat="server" Text="取　消" onclick="btnCancel_Click" CssClass="inputbt"  />
</div>