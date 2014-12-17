<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyDayAttendance.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.MyDayAttendance" %>
<%@ Register Assembly="EventCalendar.Web.UI" Namespace="EventCalendar.Web.UI" TagPrefix="cc1" %>
<link href="../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />

<asp:HiddenField ID="lblEmployeeID" runat="server" />
<asp:HiddenField ID="lblCurrentMonth" runat="server" />
<div class="leftitbor2">
<div style="float:left;">
<asp:Label ID="lblEmployeeName" runat="server"  Visible="false"></asp:Label>日历
<asp:Label ID="lblResultMessage" runat="server" Text="" Width="113px"></asp:Label>
</div>
<div style="float:right;padding-right:8px;">
   <asp:ImageButton ID="IbtnLast" runat="server" ImageUrl="../../../Pages/image/prev.gif"
            OnClick="IbtnLast_Click"  />
        <asp:Label ID="lblYearMonth" runat="server" Text="Label"  ></asp:Label>
        <asp:ImageButton ID="IBtnNext" runat="server"  ImageUrl="../../../Pages/image/next.gif"
            OnClick="IBtnNext_Click" />
<asp:ImageButton Visible="false" ID="IBtnClose" runat="server"  ImageUrl="../../../Pages/image/closebt.jpg"
OnClick="IBtnClose_Click" />
</div><div style="clear:both;" ></div>
</div>
<div class="nolinetablediv">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="7" >
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr class="weektype" height="28"  >
                    <td>星期一</td>
                    <td>星期二</td>
                    <td>星期三</td>
                    <td>星期四</td>
                    <td>星期五</td>
                    <td>星期六</td>
                    <td>星期日</td>
                  </tr>
                    <tr><td colspan="7" align="center" style="height: 105px">
                    <cc1:EventCalendar id="Calendar1" runat="server" backcolor="Transparent" CssClass="lineBorder" daynameformat="Full" enabletheming="True"
            eventdescriptioncolumnname="" eventheadercolumnname=""
            firstdayofweek="Monday" font-names="Verdana" font-size="9pt" forecolor="Black"
            nextmonthtext="Next >" onselectionchanged="Calendar1_SelectionChanged"
            prevmonthtext="< Prev" showdescriptionastooltip="True" showgridlines="True" width="100%" Height ="100%" CellPadding="0" ShowDayHeader="False" ShowTitle="False">
            <SELECTEDDAYSTYLE BackColor="Azure" ForeColor="Navy" />
            <SELECTORSTYLE BorderColor="#404040" BorderStyle="Solid" />
            <TODAYDAYSTYLE BackColor="LightYellow" /><OTHERMONTHDAYSTYLE ForeColor="#999999" />
            <DAYSTYLE Font-Names="黑体" Font-Size="10pt" ForeColor="#294EA3" 
            Font-Underline="False" Wrap="True" VerticalAlign="Top" HorizontalAlign="Right" Font-Bold="True" 
             CssClass="calanderBack dayStyle lineBorder" BorderStyle="Solid"  />
            <NEXTPREVSTYLE Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" Font-Bold="True" HorizontalAlign="Left" />
            <DAYHEADERSTYLE   Font-Names="宋体" Font-Size="9pt" ForeColor="White" Height="25px"
             HorizontalAlign="Center" Font-Bold="False"  CssClass="lineBorder"/>
             <TITLESTYLE BackColor="Transparent" BorderColor="Transparent" Font-Names="微软雅黑" Font-Size="Small"
              ForeColor="Black" BorderStyle="None" VerticalAlign="Middle" HorizontalAlign="Left" Font-Bold="False" Height="40px" />
            <WeekendDayStyle CssClass="dayStyle lineBorder" />
        </cc1:EventCalendar></td>
  </tr>
                </table></td>
                </tr>
                
            </table>

</div>








