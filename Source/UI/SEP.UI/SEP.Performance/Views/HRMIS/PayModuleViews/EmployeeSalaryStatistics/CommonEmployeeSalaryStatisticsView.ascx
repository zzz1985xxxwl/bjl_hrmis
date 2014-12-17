<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonEmployeeSalaryStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.CommonEmployeeSalaryStatisticsView" %>
<%@ Register Src="AverageStatistics/CommonStatisticsView.ascx" TagName="CommonStatisticsView"
    TagPrefix="uc2" %>
<%@ Register Src="SummaryStatistics/CommonStatisticsView.ascx" TagName="CommonStatisticsView"
    TagPrefix="uc1" %>

    <%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc111" %>



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
	                    <div id="floatbt1" class="floatbtbg"><a href="#" onclick="conshowmenutext(1)">综合统计</a></div>
	                    <div id="floatbt2" class="floatsetbt"><a href="#" onclick="conshowmenutext(2)">人均统计</a></div>
                    </div>
<div id="floatdiv1">
    <uc1:CommonStatisticsView ID="CommonStatisticsView1" runat="server" />
</div>
<div id="floatdiv2" class="hiddendiv">
    <uc2:CommonStatisticsView id="CommonStatisticsView2" runat="server"/>
</div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc111:Progressing id="Progressing1" runat="server">
                </uc111:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>

