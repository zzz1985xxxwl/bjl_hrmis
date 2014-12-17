<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.EmployeeView1" %>
<%@ Register Src="DimissionInformation/DimissionBasicView.ascx" TagName="DimissionBasicView"
    TagPrefix="uc6" %>
<%@ Register Src="FileCargoInformation/FileCargosInfoView.ascx" TagName="FileCargosInfoView"
    TagPrefix="uc9" %>
<%@ Register Src="../Vacation/VacationView.ascx" TagName="VacationView" TagPrefix="uc7" %>
<%@ Register Src="FamilyInformation/EmployeeFamilyView.ascx" TagName="EmployeeFamilyView"TagPrefix="uc5" %>

<%@ Register Src="WelfareInformation/EmployeeWelfareView.ascx" TagName="EmployeeWelfareView"TagPrefix="uc3" %>
<%@ Register Src="ResumeInformation/EmployeeResumeView.ascx" TagName="EmployeeResumeView"TagPrefix="uc4" %>
<%@ Register Src="BasicInformation/EmployeeBasicView.ascx" TagName="EmployeeBasicView"TagPrefix="uc1" %>
<%@ Register Src="WorkInformation/EmployeeWorkView.ascx" TagName="EmployeeWorkView"TagPrefix="uc2" %>
<%@ Register Src="SkillInfomation/EmployeeSkillInfoView.ascx" TagName="EmployeeSkillInfoView" TagPrefix="uc8" %>

<script language= "javascript " type="text/javascript" src="../../Inc/BaseScript.js"> 
</script>


<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<div id="tbMessage" runat="server" class="leftitbor">
 <asp:Label ID="MsgMessage" runat="server" CssClass="fontred"></asp:Label>
</div>


<div class="leftitbor2" > 
 <span style="float:left; position:relative;">
  <asp:Label ID="lblTitle"  runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lblName"  runat="server" Text="" CssClass="lblName"></asp:Label>
  (#<asp:Label ID="lblNo"  runat="server" CssClass="lblNo" Text=""></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lblDepart"  runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="hPositionID" runat="server" CssClass="hPositionID"/>
  <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lblComeDate"  runat="server" Text=""></asp:Label>
</span>
  <a href=<%=companyMailTo%> style="float:right; position:relative; padding-right:8px;">
    <asp:Label ID="lbMailToHR"  ForeColor="black" runat="server" Text="������ϢҪ�޸�"></asp:Label>
  </a>
 <div style="clear:both;" ></div>
</div>
     

<div class="lefttable">
        <div class="tabbgstyle">
            <asp:Menu ID="Menu1"
            runat="server" 
            Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick">
            <Items > 
                <asp:MenuItem Text="" Value="1" ToolTip="������Ϣ"></asp:MenuItem>
                <asp:MenuItem Text="" Value="2" ToolTip="������Ϣ"></asp:MenuItem>
                <asp:MenuItem Text="" Value="3" ToolTip="����"></asp:MenuItem>
                <asp:MenuItem Text="" Value="4" ToolTip="����"></asp:MenuItem>
                <asp:MenuItem Text="" Value="5" ToolTip="����"></asp:MenuItem>
                <asp:MenuItem Text="" Value="6" ToolTip="��ͥ��Ϣ"></asp:MenuItem>
                <asp:MenuItem Text="" Value="7" ToolTip="��ְ��Ϣ"></asp:MenuItem>
                <asp:MenuItem Text="" Value="8" ToolTip="������Ϣ"></asp:MenuItem>
                <asp:MenuItem Text="" Value="9" ToolTip="������Ϣ"></asp:MenuItem>
            </Items>
            </asp:Menu>
        </div>
        <asp:HiddenField ID="hfCurrentTab" runat="server" />
          <div class="employeeedittable">
	            <asp:MultiView ID="MultiView1" runat="server">
	            <asp:View id="Tab1" runat="server"><uc1:EmployeeBasicView id="EmployeeBasicView1" runat="server"></uc1:EmployeeBasicView></asp:View> 
                <asp:View id="Tab2" runat="server"><uc2:EmployeeWorkView id="EmployeeWorkView1" runat="server"></uc2:EmployeeWorkView></asp:View> 
                <asp:View id="Tab3" runat="server"><uc3:EmployeeWelfareView id="EmployeeWelfareView1" runat="server"></uc3:EmployeeWelfareView></asp:View> 
                <asp:View id="Tab4" runat="server"><uc7:VacationView ID="VacationView1" runat="server" /></asp:View> 
                <asp:View id="Tab5" runat="server"><uc4:EmployeeResumeView id="EmployeeResumeView1" runat="server"></uc4:EmployeeResumeView></asp:View> 
                <asp:View id="Tab6" runat="server"><uc5:EmployeeFamilyView id="EmployeeFamilyView1" runat="server"></uc5:EmployeeFamilyView></asp:View> 
                <asp:View id="Tab7" runat="server">
                    <uc6:DimissionBasicView id="DimissionBasicView1" runat="server">
                    </uc6:DimissionBasicView>
                </asp:View> 
                <asp:View id="Tab8" runat="server"><uc8:EmployeeSkillInfoView id="EmployeeSkillInfoView1" runat="server"></uc8:EmployeeSkillInfoView></asp:View> 
                           <asp:View id="Tab9" runat="server">
                               <uc9:FileCargosInfoView id="FileCargosInfoView1" runat="server">
                               </uc9:FileCargosInfoView>
                           </asp:View> 
                </asp:MultiView>
           </div> 
</div>
<div class="tablebt">
<asp:Button ID="btnConfirm" runat="server" CssClass="inputbt"  Text="ȷ  ��" OnClick="btnConfirm_Click" />
<asp:Button ID="Button1" runat="server" CssClass="inputbt"  Text="��  ��" OnClick="btnExport_Click" />
<input id="btnExportPosition" value="����ְλ˵����" class="inputbtlong" type="button"  
            onclick="location.href='../../SEP/PositionPages/PositionHandler.ashx?type=ExportEmployee&Pkid='+$('.hPositionID').html()+'&EmployeeName='+$('.lblName').html()+'&AccountID='+$('.lblNo').html()" />
 </div>