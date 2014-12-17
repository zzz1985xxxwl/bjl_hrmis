<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorkOperationView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.OverWorkOperationView" %>
<div id="tbResultMessage" runat="server" class="leftitbor" >
  <span class="fontred"><asp:Label ID="lbResultMessage" runat="server"></asp:Label></span>
</div>
<div class="leftitbor2" >
 <asp:Label ID="lbOperationType" runat="server" ></asp:Label>
</div>    
<%--<div id = "tbPositionView" runat="server"   class="linetabledivbg">
        <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
        <div class="edittable">
                <table width="100%" border="0">
            <tr style="display:none;">
              <td width="20px" align="right" ></td>
              <td width="8%" align="left" >操作号</td>
              <td width="30%" align="left">
                <asp:TextBox  runat="server" ID="tbID" CssClass="input1" ReadOnly="True"></asp:TextBox> </td> 
                <td width="12%" align="left">
                    编号</td>
                <td align="left">
                    <asp:TextBox ID="tbOverWorkID" runat="server" CssClass="input1" ReadOnly="True"></asp:TextBox>
                </td>
			  </tr>
              <tr>
              <td align="right"></td>
              <td align="left">
                  操作者</td>
              <td align="left">
              <asp:TextBox  runat="server" ID="tbName" CssClass="input1" ReadOnly="True"></asp:TextBox></td>
              <td align="left">
                  操作</td>
                  <td align="left">
                      <asp:DropDownList ID="ddlStatus" runat="server" Width="160px">
                      </asp:DropDownList></td>
			  </tr> 
			  <tr>
              <td align="right"></td>
              <td align="left" valign ="top">
                  备&nbsp;&nbsp;&nbsp;&nbsp;注</td>
                  <td align="left" colspan="3" valign ="top">
                <asp:TextBox  runat="server" ID="tbRemark" CssClass="grayborder" Height="100px" TextMode="MultiLine" Width="390px"></asp:TextBox> 
                      <asp:Label ID="lbRemarkMessage" runat="server" CssClass="psword_f"></asp:Label></td>
			  </tr> 
          </table>   
    </div>
<div class="tablebt">
   <asp:Button  Text="确  定" ID="BtnOK"  OnClick="btnOK_Click" runat="server" CssClass="inputbt"/>
   <asp:Button  Text="取　消" ID="BtnSubmit" runat="server" CssClass="inputbt" />
</div>     