<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DutyClassErrorListIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.SystemErrorPages.DutyClassErrorListIFramePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/BaseScript.js" charset="gb2312"></script>
     <link href="../../CSS/jquery.tablesorter.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.SHjqTable.js" charset="gb2312"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.pager.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.tablesorter.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="DutyClassErrorMessage" class="fontred leftitbor" style="display:none;"></div>
<div class="linetabledivNoMargin"><table id="tbDutyClassErrorList" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse:separate;" ></table></div>
<input id="HiddenDutyClassErrorShowIgnore" type="hidden" value="false" />
<script language="javascript" type="text/javascript">
$(function(){serachDutyClassError();});
function serachDutyClassError(showhid)
{
      var $inputcol=$("<span><a id='showignorelink'  onclick='serachDutyClassError(true);'>显示忽略</a></span>");
     if(showhid)
     {
       if($("#HiddenDutyClassErrorShowIgnore").val()=="true" )
           {
               $inputcol.find("a").html("显示忽略");
               $("#showignorelink").html("显示忽略");
               $("#HiddenDutyClassErrorShowIgnore").val("false");
           }
       else
           {
               $inputcol.find("a").html("隐藏忽略") ; 
                $("#showignorelink").html("隐藏忽略");
               $("#HiddenDutyClassErrorShowIgnore").val("true");
           }
     }
     $("#tbDutyClassErrorList").SHjqTable({
                    colNames:["","描述","所属公司","部门",$inputcol.html(),""],
				    colWidth:["2%","35%","25%","25%","9%","4%"],
				    colPKIDName:'PKID',
				    colTemplates:["","#Description#","#CompanyName#","#DepartmentName#","<a  href=\"#\" onclick='window.open(\"#EditUrl#\")' >更正</a>","<a href=\"#\"  onclick='IgnoreDutyClassError(#MarkID#,#ErrorTypeID#,this)' >#ErrorStatus#</a>"],
				    headers:{0: { sorter: false},1: { sorter: false}, 4: {sorter: false}, 5: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/DutyClassErrorListAjax/DutyClassErrorListAsyPage.aspx',
				    data:{type:"search",AccountID:$(".txtAccountID").val(),ShowIgnore:$("#HiddenDutyClassErrorShowIgnore").val()},
				    error:DutyClassErrorfunction,
				    pageLoading:true
    });
    
    
 

}

  function DutyClassErrorfunction(json)
   {
        for(var i=0;i<json.length;i++){
	      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).css("display","block");
        }
   }
   
function IgnoreDutyClassError(markID,errorTypeID,th)
{
   AddOverLayLoding();
   $.ajax({
     url:'../../../Views/HRMIS/SystemErrors/DutyClassErrorListAjax/DutyClassErrorListAsyPage.aspx',
     data:{type:"ignoreDutyClassError",MarkID:markID,ErrorTypeID:errorTypeID},
     dataType:'json',
     cache:false,
     success:function(json){
          RemoveOverLayLoding();
         if(json==null||json==""||json.length<=0)
         {
            if($("#HiddenDutyClassErrorShowIgnore").val()=="true")
            {
               $(th).html()=="显示" ? $(th).html("忽略"):$(th).html("显示");
            }
            else
            {
               serachDutyClassError(); 
            }
         }
         else
         {
           DutyClassErrorfunction(json);
         }
     }
   });
}
    
</script>
    </form>
</body>
</html>
