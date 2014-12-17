<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetSpecialDateView.ascx.cs" Inherits="SEP.Performance.Views.SEP.SpecialDates.SetSpecialDateView" %>
<%@ Register Assembly="EventCalendar.Web.UI" Namespace="EventCalendar.Web.UI" TagPrefix="cc2" %>
<div id="table1" runat="server" class="leftitbor2" >设定特殊日期</div>
<div class="nolinetablediv">
  <table width="100%"  cellpadding="0" cellspacing="0">
    <tr><td colspan="7" align="left">
        <asp:ImageButton ID="IbtnLast" runat="server" ImageUrl="../../../pages/image/prev.gif"
            OnClick="IbtnLast_Click" />
        <asp:Label ID="lblYearMonth" runat="server" Text="Label" Width="60px"></asp:Label>
        <asp:ImageButton ID="IBtnNext" runat="server" ImageUrl="../../../pages/image/next.gif"
            OnClick="IBtnNext_Click"/>
        <asp:HiddenField ID="lblCurrentDay" runat="server" />
            </td></tr>
    <tr class="weektype" height="28" >
              <td>星期一</td>
              <td>星期二</td>
              <td>星期三</td>
              <td>星期四</td>
              <td>星期五</td>
              <td>星期六</td>
              <td>星期日</td>
        </tr>
  <tr><td colspan="7" align="center">
  <cc2:EventCalendar id="Calendar1" runat="server" backcolor="Transparent" CssClass="lineBorder" daynameformat="Full" enabletheming="True"
            eventdescriptioncolumnname="" eventheadercolumnname=""
            firstdayofweek="Monday" font-names="Verdana" font-size="9pt" forecolor="Black"
            nextmonthtext="Next >" onselectionchanged="Calendar1_SelectionChanged"
            prevmonthtext="< Prev" showdescriptionastooltip="True" showgridlines="True" width="100%" 
            Height ="100%" CellPadding="0" ShowDayHeader="False" ShowTitle="False"> 
  <SELECTEDDAYSTYLE BackColor="Azure" ForeColor="Navy" /><SELECTORSTYLE BorderColor="#404040" 
    BorderStyle="Solid" />
  <TODAYDAYSTYLE BackColor="LightYellow" />
  <OTHERMONTHDAYSTYLE ForeColor="#999999" />
  <DAYSTYLE  Font-Names="黑体" Font-Size="10pt" ForeColor="#294EA3" 
    Font-Underline="False" Wrap="True" VerticalAlign="Top" HorizontalAlign="Right" Font-Bold="True" 
    CssClass="calanderBack lineBorder dayStyle"  BorderStyle="Solid" />
  <NEXTPREVSTYLE Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" Font-Bold="True" 
    HorizontalAlign="Left" /><DAYHEADERSTYLE CssClass="lineBorder "  BackColor="#A6D0E8"   Font-Names="宋体" 
    Font-Size="9pt" ForeColor="White" Height="25px" HorizontalAlign="Center" Font-Bold="False" />
    <TITLESTYLE BackColor="Transparent" BorderColor="Transparent" Font-Names="微软雅黑" 
    Font-Size="Small" ForeColor="Black" BorderStyle="None" VerticalAlign="Middle" HorizontalAlign="Left" 
    Font-Bold="False" Height="40px" />
  <WeekendDayStyle  CssClass="dayStyle lineBorder" />
        </cc2:EventCalendar></td>
  </tr></table>
  </div>