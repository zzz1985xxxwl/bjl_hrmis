<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvancedEmployeeStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.AdvancedEmployeeStatistics.AdvancedEmployeeStatisticsView" %>
<%@ Register Src="SetScopeView.ascx" TagName="SetScopeView"
    TagPrefix="uc1" %>
<%@ Register Src="SetItemView.ascx" TagName="SetItemView"
    TagPrefix="uc2" %>
<%@ Register Src="SetGroupView.ascx" TagName="SetGroupView"
    TagPrefix="uc3" %>

<script type="text/javascript">
function showorhideformSet(tableid, showbuttonid, hidebuttonid, showboolean, viewname)
{
    ShowOrHideForm(tableid, showbuttonid, hidebuttonid, showboolean);
	if(showboolean==1){
    document.getElementById('tbSet'+viewname+'Title').className='linetablepart';
    document.getElementById('tbSet'+viewname).className='linetable';
	 } 
	 else{
    document.getElementById('tbSet'+viewname+'Title').className='linetable';
	 }
}

var IsNextExecute = true;
function showdescription(strID)
{
    strID = "Item"+strID ;
    if(!IsNextExecute)
    {
        return;
    }
    var currtr = document.getElementById(strID);
    for(i   =   0;   i   <   document.all.length;   i++)
    {  
        if(document.all(i).tagName.toUpperCase()=="DIV" 
        && document.all(i).id!="" 
        && document.all(i).id.substring(0,4)=="Item" 
        && document.all(i).id!=strID)
        {
            document.all(i).style.display = "none";
        }
    }
    if(currtr==null)
    {
        return;
    }
    if (currtr.style.display=="none")
    {
	    currtr.style.display = "block"; //展开
    }
    else
    { 
	    currtr.style.display = "none"; //收缩
    } 
}

</script>
<table width="100%" border="0" cellpadding="0" cellspacing="5" onclick ="javascript:showdescription('');IsNextExecute = true;">
<tr>
    <td>
    <uc1:SetScopeView id="SetScopeView1" runat="server">
    </uc1:SetScopeView>
    </td>
</tr>
<tr>
    <td>
    <uc2:SetItemView id="SetItemView1" runat="server">
    </uc2:SetItemView>
    </td>
</tr>
<tr>
    <td>
    <uc3:SetGroupView id="SetGroupView1" runat="server">
    </uc3:SetGroupView>
    </td>
</tr>
<tr>
    <td style=" text-align:center">
        <asp:Button ID="btnStatistics" runat="server" Text="开始统计" CssClass = "inputbt" OnClick="btnStatistics_Click"/>
    </td>
</tr>
</table>    
