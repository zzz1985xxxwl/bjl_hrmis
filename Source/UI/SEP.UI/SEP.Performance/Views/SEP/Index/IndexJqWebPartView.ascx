<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexJqWebPartView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Index.IndexJqWebPartView" %>
<%@ Register Src="IndexEditView.ascx" TagName="IndexEditView" TagPrefix="uc1" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jQuery-1.3.2.js"></script>
<script type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript" src="../../Inc/jquery.webpart.js" charset="gb2312"></script>
<script type="text/javascript" src="../../Inc/jquery.cookie.js"></script>
<script type="text/javascript" src="../../Inc/jquery.json-2.2.js"></script>
<div id="EmptyPage" style="display:none; ">
      <table class="linetable"  width="98%" border="0">
          <tr>
            <td height="28px" class="headerstyleblue"><strong>&nbsp;&nbsp;&nbsp;&nbsp;欢迎使用SEP系统</strong></td>
          </tr>
          <tr>
                <td align="center" >
                <p><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" 
                width="750" height="560">
                  <param name="movie" value="../../../Pages/image/spiral2.swf" />
                  <param name="quality" value="high" />
                  <param name="wmode" value="Opaque">
                  <embed src="../../../Pages/image/spiral2.swf" wmode="Opaque" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" 
                  width="750" height="560" ></embed>
                </object>
              </p></td>
          </tr>
      </table>
</div>
<div id="columns">
    <ul id="column1" class="column">
    </ul>
    <ul id="column2" class="column">
    </ul>
</div>

<uc1:IndexEditView ID="IndexEditView1" runat="server" />
<script type="text/javascript" language="javascript">	
	$(function(){
	  
	    $("#editwebpart").dialog({
	    autoOpen: false,
	    modal: true,
	    width:500
	    });
		iNettuts.init();
		Flash();
		
	});
function CloseEdit()
{
   $('#editwebpart').dialog('close');
}
function Flash()
{
        if($(".widget").length==0)
	    {
	       $("#EmptyPage").show();
	       $("#columns").hide();
	    }
	    else
	    {
	      $("#EmptyPage").hide();
	       $("#columns").show(); 
	    }
}
function ShowEdit()
{
  $('#editwebpart').find("input[type='checkbox']").attr("checked",false);
  $('#editwebpart').dialog('open');
}
function AddWebPart()
{
   
    $('#editwebpart').dialog('close');
    $('#editwebpart').find("input[type='checkbox']").each(
        function(){
            $this=$(this);
            if($this.attr("checked"))
            {  
              var viewLocation=$this.parent("span").attr("viewLocation");
              var viewName=$this.parent("span").attr("viewName");
              var webPartLocation=$this.parent("span").attr("webPartLocation");
              iNettuts.AddDashBoard(viewName,viewLocation,webPartLocation);
            }
        }
    );
}	
	
</script>