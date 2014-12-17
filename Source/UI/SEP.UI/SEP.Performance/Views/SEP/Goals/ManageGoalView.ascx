<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageGoalView.ascx.cs" Inherits="SEP.Performance.Views.ManageGoalView" %>
    <div id="ShowInfo" runat="server" class="leftitbor">
              <asp:Label CssClass="fontred" ID="lblResultMessage" runat="server"></asp:Label>
    </div>

<div class="leftitbor2" >目标管理
            <asp:TextBox ID="txtID" runat="server" style="display:none;"></asp:TextBox>     
		</div>

<div class="edittable">
	<table width="100%" border="0">
      <tr>
          <td align="right" style="width: 2%" ></td>
          <td align="left" style="width:10%;">标题&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td align="left" colspan="2">
                 <asp:TextBox ID="txtTitle" runat="server" Width="350px" CssClass="input1"></asp:TextBox>
                 <asp:Label ID="lblValidateTitle" runat="server"  CssClass="psword_f"></asp:Label>
          </td>
      </tr>
       <tr>
          <td align="right" style="width: 2%" ></td>
          <td align="left" style="width:10%;">内容</td>
          <td align="left" colspan="2">
                 <asp:TextBox ID="txtContent" runat="server" CssClass="grayborder"  Width="650px" Height="105px" TextMode="MultiLine"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td align="right" style="width: 2%" ></td>
          <td align="left" style="width:10%;">设定时间&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td align="left" colspan="2">
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpSetTime" Format="yyyy-MM-dd">
          </ajaxToolKit:CalendarExtender>
         <asp:TextBox  CssClass="input1" ID="dtpSetTime" Width="350px" runat="server" ></asp:TextBox>
            <asp:Label ID="lblValidateSetTime" CssClass="psword_f" runat="server"></asp:Label>
          </td>
      </tr>
    </table>
</div>             
<div class="tablebt">
		   <asp:Button  Text="确  定" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
          <input ID="btnCancle" type="button" runat="server" value="取　消" onclick="javascript :history.back(-1)" class="inputbt"  />
           </div>