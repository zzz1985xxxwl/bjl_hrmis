<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestTypeView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.LeaveRequestTypes.LeaveRequestTypeView" %>
<div id="tbMessage" runat="server" class="leftitbor" >
<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
  <asp:Label ID="lblOperation" runat="server" >  
 </asp:Label>
  &nbsp;
<asp:HiddenField ID="Operation" runat="server" />        
</div>
<%--<div  class="linetabledivbg">
<table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>

<div  class="edittable">
  <table width="100%" border="0">
            <tr>
              <td width="2%" align="right" ></td>
              <td width="15%" align="left" >
             ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;<span class = "redstar">*</span>
              </td> 
              <td align="left"  >
              <asp:TextBox  runat="server" ID="txtName" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;&nbsp;
              <asp:Label runat="server" ID="lblNameMsg" CssClass="psword_f"></asp:Label>
                  &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                  <asp:CheckBox ID="chIncludeRestDay" runat="server" Text="�Ƿ������Ϣ��" Width="135px" />
                  <asp:CheckBox ID="chIncludeLegalHoliday" runat="server" Text="�Ƿ������������" Width="156px" />
                  </td>
			  </tr>
	        <tr>
              <td width="2%" align="right" ></td>
              <td width="15%" align="left" >
             ��С��λ&nbsp;<span class = "redstar">*</span>
              </td> 
              <td align="left"  >
              <asp:TextBox  runat="server" ID="txtLeastHour" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;&nbsp;
              <asp:Label runat="server" ID="lbLeastHourMsg" CssClass="psword_f"></asp:Label>
               </td>
			  </tr>
			  		  
            <tr>
              <td width="2%" align="right" ></td>
              <td width="15%" align="left" valign="top" >˵&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</td>
              <td align="left" colspan="3" valign="top" >
              <asp:TextBox  runat="server" ID="txtDescription" CssClass="grayborder" TextMode="MultiLine" Height="97px" Width="328px"></asp:TextBox>		  
              <asp:TextBox  runat="server" ID="txtID" visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
              </td> 
			  </tr>
          </table>
</div>	 
<div class="tablebt">
   <asp:Button  Text="ȷ  ��" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
   <asp:Button  Text="ȡ����" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>