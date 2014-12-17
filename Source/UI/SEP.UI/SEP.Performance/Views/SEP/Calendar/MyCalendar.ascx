<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyCalendar.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.MyCalendar" %>
<%@ Register Src="../DragCalendar.ascx" TagName="DragCalendar" TagPrefix="uc4" %>
<%@ Register Src="../MyDayAttendance.ascx" TagName="MyDayAttendance" TagPrefix="uc3" %>
<%@ Register Src="DayCalendar.ascx" TagName="DayCalendar" TagPrefix="uc1" %>
<%@ Register Src="WeekCalendar.ascx" TagName="WeekCalendar" TagPrefix="uc2" %>

<link href="../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

    <ContentTemplate>
<div style=" height:550px">
<div id="ShowMenu"  runat="server" class="infotitlelist" style="text-align:left; " >
	<asp:Menu ID="Menu1"
            Width="15px" 
            runat="server" 
            Orientation="Horizontal" 
            StaticEnableDefaultPopOutImage="False"
            OnMenuItemClick="Menu1_MenuItemClick" >
            <Items>             
                <asp:MenuItem Text="" Value="0" ToolTip="Day"></asp:MenuItem>
                <asp:MenuItem Text="" Value="1" ToolTip="Week"></asp:MenuItem>
                <asp:MenuItem Text="" Value="2" ToolTip="Month"></asp:MenuItem>
                <asp:MenuItem Text="" Value="3" ToolTip="Year"></asp:MenuItem>
            </Items>
        </asp:Menu>
</div>
<div style="height:300px">
	<asp:MultiView 
            ID="MultiView1"
            runat="server">   
            <asp:View ID="Tab0" runat="server"  >           
                <uc1:DayCalendar id="DayCalendar1" runat="server">
                </uc1:DayCalendar>
                
             </asp:View>
             <asp:View ID="Tab1" runat="server"  >
                 <uc2:WeekCalendar id="WeekCalendar1" runat="server">
                 </uc2:WeekCalendar>
                 
             </asp:View>
             <asp:View ID="Tab2" runat="server"  >
                 &nbsp;<uc4:DragCalendar ID="DragCalendar1" runat="server" />
             </asp:View>
             <asp:View ID="Tab3" runat="server"  >
             </asp:View>         
           </asp:MultiView>
</div>  
</div>
 </ContentTemplate>
</asp:UpdatePanel>