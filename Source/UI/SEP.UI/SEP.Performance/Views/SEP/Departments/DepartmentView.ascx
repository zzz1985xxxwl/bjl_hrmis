<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentView.ascx.cs" Inherits="SEP.Performance.Views.Departments.DepartmentView" %>
<div id="tbMessage" runat="server" class="leftitbor">
			<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
	    </div>
<asp:HiddenField ID="hfParentID" runat="server" />
<div class="leftitbor2" >
              <asp:Label ID="lblOperation" runat="server" >  
		     </asp:Label>
              &nbsp;
           <asp:HiddenField ID="Operation" runat="server" />        <%--<asp:HiddenField ID="hf_Operator" runat="server" /><asp:HiddenField ID="hf_OperatorID" runat="server" />--%>
		</div>
 
<div class="edittable">
	<table width="100%" border="0" >
        <tr>                
          <td width="20px">&nbsp;</td>
          <td align="left" width="60px" valign="middle">部门编号</td>
            <td align="left" width="auto">
              <asp:TextBox ID="txtDepID" runat="server" Width="150px" CssClass = "input1" ReadOnly="true"/>&nbsp;<span class = "redstar"></span>
            </td>
        </tr> 
        <tr>                
          <td width="20px">&nbsp;</td>
          <td align="left" width="60px">
              部门<span class = "redstar">*</span></td>
            <td align="left" width="auto">
              <asp:TextBox ID="txtDepName" runat="server" Width="150px" CssClass = "input1"></asp:TextBox>
            <asp:Label ID="lblDepNameMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td align="left" width="60px">部门经理<span class = "redstar">*</span></td><td align="left">            <asp:TextBox ID="txtLeaderName" runat="server" Width="150px" CssClass = "input1"></asp:TextBox>
            <asp:Label ID="lblLeaderNameMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr> 
        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              电话</td>
            <td align="left" width="auto">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="input1" Width="150px"></asp:TextBox></td><td align="left" width="60px">
                传真</td><td align="left">
                <asp:TextBox ID="txtFax" runat="server" CssClass="input1" Width="150px"></asp:TextBox></td>
		</tr>
		        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              成立时间</td>
            <td align="left" width="auto">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFoundationTime" Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtFoundationTime" runat="server" CssClass="input1" Width="150px"></asp:TextBox> <asp:Label ID="lblTimeError" runat="server" CssClass = "psword_f"></asp:Label></td>
                <td align="left" width="60px"> 其他</td><td align="left">
                <asp:TextBox ID="txtOthers" runat="server" CssClass="input1" Width="150px"></asp:TextBox></td></tr>
                		        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              地址</td>
                                    <td colspan="3" align="left">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="input1" Width="300px"></asp:TextBox></td>
		</tr>
                		        <tr>
          <td width="20px" style="height: 80px" rowspan="2" valign="middle">&nbsp;&nbsp;</td>
		  <td align="left" width="60px" style="height: 80px" rowspan="2">
              描述</td>
                                    <td colspan="3" align="left" style="height: 83px" rowspan="2">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="input1" TextMode="MultiLine" Width="300px" Height="72px"></asp:TextBox></td>
		</tr>
		                		        <tr>
		</tr>
    </table>
</div>              
<div class="tablebt">
		   <asp:Button  Text="确  定" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
           <asp:Button  Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
          </div>





  