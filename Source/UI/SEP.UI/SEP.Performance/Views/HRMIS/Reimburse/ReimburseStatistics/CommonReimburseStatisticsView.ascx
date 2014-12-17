<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonReimburseStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics.CommonReimburseStatisticsView" %>
<%@ Register Src="EmployeeCommonStatisticsView.ascx" TagName="EmployeeCommonStatisticsView"
    TagPrefix="uc2" %>
<%@ Register Src="CommonStatisticsView.ascx" TagName="CommonStatisticsView" TagPrefix="uc1" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc111" %>

<style type="text/css">
#floatsetting{
	height:28px;margin:0px auto;width:98%;padding:8px 0px 0px 0px;background:url(../../image/linebg.jpg) repeat-x bottom;
}
#floatsetting .floatbtbg{
	float:left;height:28px;width:88px;margin-left:10px;font-size:14px;font-weight:bold;line-height:28px;background:url(../../image/setbtbg.jpg) no-repeat;text-align:center;
}
#floatsetting .floatsetbt{
	float:left;line-height:24px;width:80px;text-align:center;margin:2px 0px 0px 10px;background:#e6efc2;border:1px solid #279616;
}
.hiddendiv{
	display:none;
}
.showdiv{
	display:block;
}
</style>
<script type="text/javascript">
	   function conshowmenutext(num) {
        for(i   =   0;   i   <   document.all.length;   i++)
        {  
            if(document.all(i).tagName.toUpperCase()=="DIV" 
            && document.all(i).id!="" 
            && document.all(i).id.substring(0,7)=="floatbt")
            {
                var index = document.all(i).id.replace("floatbt","");
		         if(index==num) {
		           document.getElementById('floatbt'+index).className='floatbtbg'
		           document.getElementById('floatdiv'+index).className='showdiv'
		       } else {
		           document.getElementById('floatbt'+index).className='floatsetbt'
		           document.getElementById('floatdiv'+index).className='hiddendiv'
		   		    }
            }
        }
        	 
	   }
</script>
<div id="floatsetting">
	                    <div id="floatbt1" class="floatbtbg"><a href="#" onclick="conshowmenutext(1)">部门统计</a></div>
	                    <div id="floatbt2" class="floatsetbt"><a href="#" onclick="conshowmenutext(2)">员工统计</a></div>
                    </div>
<div id="floatdiv1">
<uc1:CommonStatisticsView ID="CommonStatisticsView1" runat="server" /></div>
<div id="floatdiv2" class="hiddendiv">
<uc2:EmployeeCommonStatisticsView id="EmployeeCommonStatisticsView1" runat="server">
</uc2:EmployeeCommonStatisticsView>
</div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc111:Progressing id="Progressing1" runat="server">
                </uc111:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>

<%--    <asp:Button ID="btnDepartmentExport" CssClass="btnDepartmentExport" runat="server" Text="" OnClick="btnDepartmentExport_Click"  style="display:none;"/>
    <asp:Button ID="btnEmployeeExport"  CssClass="btnEmployeeExport" runat="server" Text="" OnClick="btnEmployeeExport_Click"  style="display:none;"/>--%>
