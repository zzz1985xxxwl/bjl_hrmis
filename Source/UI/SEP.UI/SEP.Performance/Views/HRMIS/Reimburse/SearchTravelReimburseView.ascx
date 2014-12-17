<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchTravelReimburseView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.SearchTravelReimburseView" %>
 <script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
 <link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />    
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
       <ContentTemplate>
<script type="text/javascript" language="javascript">
function BindAutoCompleteCustormer()
{
 if($(".IsAutoCustomer").val()=="1")
   {
    $(".customerinfo").autocomplete("../../../Pages/HRMIS/ReimbursePages/GoogleDownBackCode.aspx");
   }
}
</script>  
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
<input id="IsAutoCustomer" class="IsAutoCustomer" type="hidden" runat="server" />
<div class="leftitbor2">
    报销查询</div>
<div class="edittable">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                员工姓名</td>
            <td align="left" style="width: 41%">
                <asp:TextBox CssClass="input1" ID="txtEmployeeName" runat="server" Width="70%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                客户名称 <img  alt=""  style="display:none;" src="../../../../../Pages/image/btbg.jpg" onload="BindAutoCompleteCustormer();" />
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox CssClass="input1 customerinfo" ID="txtCustomerName"  runat="server" Width="70%"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td align="left" style="width: 2%;">
                </td>
                                        <td align="left" style="width: 8%;">
                报销类型
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlReimburseCategories" runat="server" Width="70%" AutoPostBack="true" OnSelectedIndexChanged="ddlReimburseCategories_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        <td align="left" style="width: 8%;">备注</td>
       <td align="left" style="width: 41%" ><asp:TextBox CssClass="input1" ID="txtRemark" runat="server" Width="70%" ></asp:TextBox></td>

        </tr>
        <tr id="trTravel" runat="server" style="display:none">           
         <td align="left" style="width: 2%;"></td>
            <td align="left" style="width: 8%;">
                出差地点</td>
            <td align="left" style="width: 46%">
                <asp:TextBox CssClass="input1" ID="txtDestinations" runat="server" Width="70%"></asp:TextBox>
            </td>
                        <td align="left" style="width: 8%;">
                出差项目
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox CssClass="input1" ID="txtProjectName" runat="server" Width="70%"></asp:TextBox>
            </td>
            </tr>
             <tr >           
         <td align="left" style="width: 2%;"></td>
            <td align="left" style="width: 8%;">
                部门</td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddDepartment" runat="server" Width="70%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">所属公司</td>
             <td align="left" style="width: 41%">
              <asp:DropDownList ID="ddCompany" runat="server" Width="70%">
                </asp:DropDownList>
             </td>
            </tr>
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                消费时间
            </td>
            <td colspan="5" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpApplyDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpApplyDateTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="dtpApplyDateFrom" runat="server" Width="170px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="dtpApplyDateTo" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lblApplyDateMsg" runat="server" CssClass="psword_f"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>           
        </tr>
         <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                记账时间
            </td>
            <td colspan="5" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBillingFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtBillingTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="txtBillingFrom" runat="server" Width="170px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="txtBillingTo" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lblBillingMsg" runat="server" CssClass="psword_f"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>           
        </tr>
    </table>
</div>

<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="inputbt" OnClick="btnSearch_Click" />
    <asp:Button ID="btnExport" runat="server" Text="导  出" CssClass="inputbt" OnClick="btnExport_Click" />
</div>



 <div id="tbSearch" runat="server" class="marginepx" >

         <table width="100%" cellpadding="0" cellspacing="0">
	        <tr><td>
	            <table cellpadding="0"  cellspacing="0" class="linetablepart" border="0" width="100%" height="28">
		          <tr class="tittdbagbg">
		            <td class="kqtop">
                        报销查询结果</td>
		          </tr>
		        </table>
	        </td></tr>
            <tr>
            <td width="100%" height="402px" valign="top" align="left">
              <img  alt="" style="display:none;" src="../../../../../Pages/image/btbg.jpg" onload="makewidth2(this);" />
            <div class="FixedGridViewDiv400" onscroll="fixColumn(this);">
<asp:DataGrid ID="dgSearchReimburse"  runat="server" CssClass="FixedGridViewTable" GridLines="None" Width="100%" 
 OnItemDataBound="dgSearchReimburse_RowDataBound" PageSize="20" AllowPaging="True"> 
 <AlternatingItemStyle  CssClass="table_g"/>
                        <ItemStyle Height = "28px" HorizontalAlign="Center"/>
         <HeaderStyle Height="28px" HorizontalAlign="Center"/> 
         <PagerStyle Visible="false" />
                    </asp:DataGrid> 
                    </div>
            </td>
            </tr>
        </table>
<div class="pages">
                     
		    共&nbsp;<asp:Label ID="lblAllPage" runat="server" Text="1" ></asp:Label>&nbsp;页&nbsp;
		    第&nbsp; <asp:Label ID="lblCurrentPageIndex" runat="server" Text="1"></asp:Label>&nbsp;页&nbsp;
		    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CssClass="pagefirstbutton" OnCommand="Page_Command" CommandArgument="First" CommandName="Page" >
		    首页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" OnCommand="Page_Command" CommandArgument="Prev" CommandName="Page" >
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" OnCommand="Page_Command" CommandArgument="Next" CommandName="Page" >
		    下一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CssClass="pagelastbutton" OnCommand="Page_Command" CommandArgument="Last" CommandName="Page"  >
		    末页</asp:LinkButton>
		    转到&nbsp;<asp:TextBox ID="txtGoPage" runat="server" CssClass="input1" Width="20px"></asp:TextBox>&nbsp;页
		    <asp:LinkButton ID="LinkButtonGoPage" runat="server" CssClass="pagegobutton" OnClick="LinkButtonGoPage_Click">GO</asp:LinkButton> 
		    
		   
		 <%--   <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" 
                                                CommandName="Page"  OnClick="LinkButtonPreviousPage_Click">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"
                                                OnClick="LinkButtonNextPage_Click">
		    下一页</asp:LinkButton>--%>
</div>     
</div>


<div class="nolinetablediv "  style="color: #c41313;" >
    <table cellspacing="0" style="width: 100%; border-collapse: collapse; text-align:left ">
                                <tr>
                <td  height = "28px" Width="4%"></td>
                <td  Width="8%" style=" font-weight:bold">统计汇总</td>
                <td  Width="8%" style=" font-weight:bold">长途</td>
                <td  Width="8%" style=" font-weight:bold">短途</td>
                <td  Width="8%" style=" font-weight:bold">住宿</td>
                <td  Width="8%" style=" font-weight:bold">交际应酬</td>
                <td  Width="8%" style=" font-weight:bold">市内交通费</td>  
                <td  Width="8%" style=" font-weight:bold">餐费</td>                                 
                <td  Width="8%" style=" font-weight:bold">其他</td>
                <td  Width="8%" style=" font-weight:bold">出差补贴</td>           
                <td  Width="8%" style=" font-weight:bold">小计</td>
              </tr>
              <tr>
                <td  height = "28px" Width="4%"></td>
                <td>总计</td>
                <td><asp:label ID="lblLongTripTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblShortTripTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblLodgingTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblEntertainmentTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblCityTraffic" runat="server"></asp:label></td>             
                <td><asp:label ID="lblMeal" runat="server"></asp:label></td>                   
                <td><asp:label ID="lblOtherTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblOutCityAllowanceTotal" runat="server"></asp:label></td>
                <td><asp:label ID="lblTotal" runat="server"></asp:label></td>
              </tr>

    </table>
</div>

       </ContentTemplate>
     <Triggers>
         <asp:PostBackTrigger ControlID="btnExport" />
     </Triggers>
</asp:UpdatePanel>