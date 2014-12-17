<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSkillView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.SkillInfomation.EmployeeSkillView" %>


<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>     

<div class="edittable">
      <table width="100%" border="0" style=" text-align:left">
          <tr>
              <td width="14%">技能类型<span class = "redstar">*</span></td>
              <td width="35%">&nbsp;
                  <asp:DropDownList ID="ddlSkillType" runat="server"  Width="55%" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                      &nbsp;&nbsp; &nbsp;<asp:Label ID="SkillTypeMsg" runat="server" CssClass="psword_f"></asp:Label>
              </td>
              <td width="12%">技能<span class = "redstar">*</span>&nbsp;
                  <asp:DropDownList ID="ddlSkill" runat="server"  Width="50%">
                  </asp:DropDownList>
                  <asp:Label ID="SkillMsg" runat="server" CssClass="psword_f"></asp:Label></td>
          </tr>
          <tr>
              <td width="14%">技能等级<span class = "redstar">*</span></td>
              <td width="35%">&nbsp;
                  <asp:DropDownList ID="ddlSkillLevel" runat="server" Width="55%"></asp:DropDownList>
              &nbsp;&nbsp;&nbsp;<asp:Label ID="SkillLevelMsg" runat="server" CssClass="psword_f"></asp:Label> </td> 
              <td style="width:43%; height: 36px;"  >&nbsp; &nbsp;&nbsp;
                  <asp:Label ID="lblID" runat="server" Visible="False" ></asp:Label></td>
          </tr>
          <tr>
              <td width="14%">分数</td>
              <td colspan="2">&nbsp;
                  <asp:TextBox ID="txtScore" runat="server" Width="70%">0</asp:TextBox>
                  <asp:Label ID="lblScoreMsg" runat="server" CssClass="psword_f"></asp:Label>
              </td> 
          </tr>
          <tr>
              <td width="14%">备注</td>
              <td colspan="2">&nbsp;
                  <asp:TextBox ID="txtRemark" runat="server" Width="70%" TextMode="MultiLine" Rows="5">
                  </asp:TextBox>
              </td> 
          </tr>

      </table>
</div>
<div class="tablebt">
	 <input id="btnOK" type="submit" runat ="server" value="确  定" class="inputbt" onserverclick="btnOK_ServerClick" />
     <input id="btnCancel" type="button" runat ="server" value="取　消" class="inputbt" onserverclick="btnCancel_ServerClick"/>
</div>   