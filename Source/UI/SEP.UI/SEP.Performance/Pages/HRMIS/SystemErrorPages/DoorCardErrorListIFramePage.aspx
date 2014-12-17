<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoorCardErrorListIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.SystemErrorPages.DoorCardErrorListIFramePage" %>

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
  <div id="doorcardErrorMessage" class="fontred leftitbor" style="display:none;"></div>
<div class="linetabledivNoMargin">
<table id="tbDoorCardErrorList" width="100%" ></table>
</div>
<input id="HiddenDoorCardErrorShowIgnore" type="hidden" value="false" />
<script language="javascript" type="text/javascript">
$(function(){serachDoorCardError();});
function serachDoorCardError(showhid)
{

     var $inputcol=$("<span><a id='showignorelink'  onclick='serachDoorCardError(true);'>显示忽略</a></span>");
     if(showhid)
     {
       if($("#HiddenDoorCardErrorShowIgnore").val()=="true" )
           {
               $inputcol.find("a").html("显示忽略");
                $("#showignorelink").html("显示忽略");
               $("#HiddenDoorCardErrorShowIgnore").val("false");
           }
       else
           {
               $inputcol.find("a").html("隐藏忽略") ; 
                $("#showignorelink").html("隐藏忽略");
               $("#HiddenDoorCardErrorShowIgnore").val("true");
           }
     }
     $("#tbDoorCardErrorList").SHjqTable({
                    colNames:["","描述","所属公司","部门",$inputcol.html(),""],
				    colWidth:["2%","35%","25%","25%","9%","4%"],
				    colPKIDName:'PKID',
				    colTemplates:["","#Description#","#CompanyName#","#DepartmentName#","<a  href=\"#\" onclick='window.open(\"#EditUrl#\")' >更正</a>","<a href=\"#\" onclick='IgnoreDoorCardError(#MarkID#,#ErrorTypeID#,this)'>#ErrorStatus#</a>"],
				    headers:{0: { sorter: false},1: { sorter: false}, 4: {sorter: false}, 5: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/DoorCardErrorListAjax/DoorCardErrorListAsyPage.aspx',
				    data:{type:"search",AccountID:$(".txtAccountID").val(),ShowIgnore:$("#HiddenDoorCardErrorShowIgnore").val()},
				    error:DoorCardErrorfunction,
				    pageLoading:true
    });
    
    
}
function DoorCardErrorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).css("display","block");
    }
}

function IgnoreDoorCardError(markID,errorTypeID,th)
{
 AddOverLayLoding();
   $.ajax({
     url:'../../../Views/HRMIS/SystemErrors/DoorCardErrorListAjax/DoorCardErrorListAsyPage.aspx',
     data:{type:"ignoreDoorCardError",MarkID:markID,ErrorTypeID:errorTypeID},
     dataType:'json',
     cache:false,
     success:function(json){
      RemoveOverLayLoding();
         if(json==null||json==""||json.length<=0)
         {
            if($("#HiddenDoorCardErrorShowIgnore").val()=="true")
            {
               $(th).html()=="显示" ? $(th).html("忽略"):$(th).html("显示");
            }
            else
            {
               serachDoorCardError(); 
            }
         }
         else
         {
           DoorCardErrorfunction(json);
         }
     }
   });
}

    
</script>


    </form>
</body>
</html>
