<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexDayAttendance.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.IndexDayAttendance" %>
<%@ Register Assembly="EventCalendar.Web.UI" Namespace="EventCalendar.Web.UI" TagPrefix="cc2" %>
<link href="../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />

<asp:HiddenField ID="lblEmployeeID" runat="server" />
<asp:HiddenField ID="lblCurrentMonth" runat="server" />
              
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
     <tr>
            <td height="20" valign="middle"><table width="100%"  border="0" cellpadding="0" cellspacing="0" >
              <tr>
                <td height="20" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="78%" align="left" valign="middle">
                          <asp:Label ID="lblEmployeeName" runat="server" Visible="false">
                          </asp:Label><asp:Label ID="lblResultMessage" runat="server" Text="" Visible="false"></asp:Label>
                          <img src="../../image/setting.jpg" align="right" />
                        </td>
                      <td width="23%" align="center" valign="middle" >
                      
                          <asp:ImageButton ID="IbtnLast" runat="server" ImageUrl="../../../Pages/image/kqleft.png"
                          OnClick="IbtnLast_Click"  />
                          <strong><asp:Label ID="lblYearMonth" runat="server" Text="Label" Width="60px" ></asp:Label></strong>
                          <asp:ImageButton ID="IBtnNext" runat="server" ImageUrl="../../../Pages/image/kqright.png"
                          OnClick="IBtnNext_Click" />
                      </td>
            <td align="right" ><asp:ImageButton Visible="false" ID="IBtnClose" runat="server" ImageUrl="../../../Pages/image/xxx.jpg"
            OnClick="IBtnClose_Click" /></td>
                    </tr>
                </table></td>
              </tr>

            </table></td>
          </tr>
           
        
          <tr>
            <td>
            <table width="100%" border="0" cellpadding="10" cellspacing="0" class="nolinetable">
              <tr>
                <td colspan="7"  style="height: 395px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr class="weektype" height="28"  >
                    <td >星期一</td>
                    <td >星期二</td>
                    <td >星期三</td>
                    <td >星期四</td>
                    <td >星期五</td>
                    <td >星期六</td>
                    <td >星期日</td>
                  </tr>
                    <tr><td colspan="7" align="center" style="height: 105px">
                    <cc2:EventCalendar id="Calendar1" runat="server" backcolor="Transparent"  CssClass="lineBorder" daynameformat="Full" enabletheming="True"
            eventdescriptioncolumnname="" eventheadercolumnname=""
            firstdayofweek="Monday" font-names="Verdana" font-size="9pt" forecolor="Black"
            nextmonthtext="Next >" onselectionchanged="Calendar1_SelectionChanged"
            prevmonthtext="< Prev" showdescriptionastooltip="True" showgridlines="True" width="100%" Height ="100%" CellPadding="0" ShowDayHeader="False" ShowTitle="False">
             <SELECTEDDAYSTYLE BackColor="Azure" ForeColor="Navy" /><SELECTORSTYLE BorderColor="#404040" BorderStyle="Solid" />
             <TODAYDAYSTYLE BackColor="LightYellow" /><OTHERMONTHDAYSTYLE ForeColor="#999999" />
             <DAYSTYLE   Font-Names="黑体" Font-Size="10pt" ForeColor="#294EA3" Font-Underline="False" Wrap="True" 
             VerticalAlign="Top" HorizontalAlign="Right" Font-Bold="True" CssClass="calanderBack dayStyle lineBorder" BorderStyle="Solid"  />
             <NEXTPREVSTYLE Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" Font-Bold="True" HorizontalAlign="Left" />
             <DAYHEADERSTYLE BackColor="#A6D0E8"  Font-Names="宋体" Font-Size="9pt" ForeColor="White" Height="25px" HorizontalAlign="Center" 
             Font-Bold="False" CssClass="lineBorder"/>
             <TITLESTYLE BackColor="Transparent" BorderColor="Transparent" Font-Names="微软雅黑" Font-Size="Small" ForeColor="Black" BorderStyle="None" 
             VerticalAlign="Middle" HorizontalAlign="Left" Font-Bold="False" Height="40px" />
            <WeekendDayStyle  CssClass="dayStyle lineBorder" />
        </cc2:EventCalendar></td>
  </tr>
                </table>
                </td>
                </tr>
                
            </table>
            </td>
          </tr>
        </table>

