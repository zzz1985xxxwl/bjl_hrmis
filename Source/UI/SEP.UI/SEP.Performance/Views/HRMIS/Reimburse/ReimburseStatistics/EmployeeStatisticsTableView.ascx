<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeStatisticsTableView.ascx.cs" 
Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics.EmployeeStatisticsTableView" %>

<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr id="trStatistics" runat="server">
    <td height="68">
        <table width="100%" cellpadding="0" cellspacing="0">
	        <tr><td>
	            <table cellpadding="0"  cellspacing="0" class="linetablepart" border="0" width="100%" height="28">
		          <tr class="tittdbagbg">
		            <td class="kqtop">
                        按员工统计报销</td>
		          </tr>
		        </table>
	        </td></tr>
            <tr>
            <td width="100%" height="276px" valign="top">
              <img  alt="" style="display:none;" src="../../../../../Pages/image/btbg.jpg" onload="makewidth(this);" />
            <div class="FixedGridViewDiv" onscroll="fixColumn(this);">
<asp:DataGrid ID="dgEmployeeStatisticsTable"  runat="server" CssClass="FixedGridViewTable" GridLines="None" Width="100%" 
 OnItemDataBound="dgEmployeeStatisticsTable_RowDataBound"> 
 <AlternatingItemStyle  CssClass="table_g"/>
                        <ItemStyle Height = "28px" HorizontalAlign="Center"/>
         <HeaderStyle Height="28px" HorizontalAlign="Center"/> 
                    </asp:DataGrid> 
                    </div>
            </td>
            </tr>
        </table>
     </td>
  </tr>
</table>
