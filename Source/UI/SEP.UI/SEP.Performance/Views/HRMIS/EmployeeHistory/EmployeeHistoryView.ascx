<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeHistoryView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeHistory.EmployeeHistoryView" %>
<%@ Register Src="../EmployeeInformation/FileCargoInformation/FileCargosInfoView.ascx"
    TagName="FileCargosInfoView" TagPrefix="uc6" %>
<%@ Register Src="../EmployeeInformation/DimissionInformation/DimissionBasicView.ascx"
    TagName="DimissionBasicView" TagPrefix="uc7" %>
<%@ Register Src="../EmployeeInformation/ResumeInformation/EmployeeResumeView.ascx"
    TagName="EmployeeResumeView" TagPrefix="uc8" %>
<%@ Register Src="../EmployeeInformation/FamilyInformation/EmployeeFamilyView.ascx" TagName="EmployeeFamilyView"TagPrefix="uc5" %>
<%@ Register Src="../EmployeeInformation/WelfareInformation/EmployeeWelfareView.ascx" TagName="EmployeeWelfareView"TagPrefix="uc3" %>
<%@ Register Src="../EmployeeInformation/ResumeInformation/EmployeeResumeView.ascx" TagName="EmployeeResumeView"TagPrefix="uc4" %>
<%@ Register Src="../EmployeeInformation/BasicInformation/EmployeeBasicView.ascx" TagName="EmployeeBasicView"TagPrefix="uc1" %>
<%@ Register Src="../EmployeeInformation/WorkInformation/EmployeeWorkView.ascx" TagName="EmployeeWorkView"TagPrefix="uc2" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<script language= "javascript " type="text/javascript" src="../../Inc/BaseScript.js"> 
</script>

<div id="tbMessage" runat="server">
 <asp:Label ID="MsgMessage" runat="server"></asp:Label>
</div>  

<div class="leftitbor2">
<span style="float:left; position:relative;">
              <asp:Label ID="lblTitle" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
              (#<asp:Label ID="lblNo" runat="server" Text=""></asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="hPositionID" runat="server" CssClass="hPositionID"/>
              <asp:Label ID="lblDepart" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblComeDate" runat="server" Text=""></asp:Label>
</span>
                <a href=<%=companyMailTo%>>
                <asp:Label ID="lbMailToHR"  runat="server" Text="������ϢҪ�޸�"></asp:Label>
               </a>
 <div style="clear:both;" ></div>               
</div>
        
  
<div class="lefttable">
        <div class="tabbgstyle">
	        <asp:Menu ID="Menu1"
            Width="168px"
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
            </Items>
        </asp:Menu>
	    </div>
        <asp:HiddenField ID="hfCurrentTab" runat="server" />
          <div class="employeeedittable">
	<asp:MultiView ID="MultiView1" runat="server">
	<asp:View id="Tab1" runat="server"><uc1:EmployeeBasicView id="EmployeeBasicView1" runat="server"></uc1:EmployeeBasicView>
    </asp:View> 
    <asp:View id="Tab2" runat="server"><uc2:EmployeeWorkView id="EmployeeWorkView1" runat="server"></uc2:EmployeeWorkView></asp:View> 
    <asp:View id="Tab3" runat="server"><uc3:EmployeeWelfareView id="EmployeeWelfareView1" runat="server"></uc3:EmployeeWelfareView></asp:View> 
    <asp:View id="Tab4" runat="server"></asp:View> 
    <asp:View id="Tab5" runat="server"><uc4:EmployeeResumeView id="EmployeeResumeView1" runat="server"></uc4:EmployeeResumeView></asp:View> 
    <asp:View id="Tab6" runat="server"><uc5:EmployeeFamilyView id="EmployeeFamilyView1" runat="server"></uc5:EmployeeFamilyView></asp:View> 
    <asp:View id="Tab7" runat="server">
        <uc7:DimissionBasicView id="DimissionBasicView1" runat="server">
        </uc7:DimissionBasicView>
        <%--<uc6:DimissionView id="DimissionView1" runat="server"></uc6:DimissionView>--%></asp:View> 
          <asp:View id="Tab8" runat="server">  <uc6:FileCargosInfoView id="FileCargosInfoView1" runat="server">
        </uc6:FileCargosInfoView></asp:View>
    </asp:MultiView>
   </div> 
</div>   
<div class="tablebt">
<asp:Button ID="btnConfirm" runat="server" CssClass="inputbt"  Text="ȷ  ��" OnClick="btnConfirm_Click" />
<asp:Button ID="Button1" runat="server" CssClass="inputbt"  Text="��  ��" OnClick="btnExport_Click" />
</div>