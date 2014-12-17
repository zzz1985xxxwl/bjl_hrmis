<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiyProcessErrorListIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.SystemErrorPages.DiyProcessErrorListIFramePage" %>

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
     <div id="DiyProcessErrorMessage" class="fontred leftitbor" style="display:none;"></div>
<div class="edittable">  
    <table width="100%" border="0">
        <tr>
           <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 12%;">
                类型
            </td>
            <td align="left" style="width: 37%">
                 <asp:DropDownList ID="ddlErrorType"  runat="server" CssClass="ddlErrorType" >
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 49%;">
                <input id="showIgnore" type="checkbox" />显示忽略
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
<input id="btnSearch" type="button" value="查　询"  class="inputbt" onclick="serachDiyProcessError();" />
</div>
<div class="linetablediv"><table id="tbDiyProcessError" width="100%" ></table></div>
<div style="height:2px"/>
<script language="javascript" type="text/javascript">
$(function(){serachDiyProcessError();})
function serachDiyProcessError()
{
     AddOverLayLoding();
     $("#tbDiyProcessError").SHjqTable({
                    colNames:["","描述","所属公司","部门","",""],
				    colWidth:["2%","40%","25%","25%","4%","4%"],
				    colPKIDName:'PKID',
				    colTemplates:["","#Description#","#CompanyName#","#DepartmentName#","<a  href=\"#\" onclick='window.open(\"#EditUrl#\")' >更正</a>","<a href=\"#\"  onclick='IgnoreDiyProcessError(#MarkID#,#ErrorTypeID#,this)' >#ErrorStatus#</a>"],
				    headers:{0: { sorter: false},1: { sorter: false}, 4: {sorter: false},5: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/DiyProcessErrorListAjax/DiyProcessErrorListAsyPage.aspx',
				    data:{type:"search",ErrorType:$(".ddlErrorType").val(),ShowIgnore:$("#showIgnore").attr("checked")},
				    error:DiyProcessErrorfunction,
				    pageLoading:true,
				    isHtml:true
    }
    )

}
function DiyProcessErrorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]);
    }
}

function IgnoreDiyProcessError(markID,errorTypeID,th)
{
    AddOverLayLoding();
   $.ajax({
     url:'../../../Views/HRMIS/SystemErrors/DiyProcessErrorListAjax/DiyProcessErrorListAsyPage.aspx',
     data:{type:"ignoreDiyProcessError",MarkID:markID,ErrorTypeID:errorTypeID},
     dataType:'json',
     cache:false,
     success:function(json){
          RemoveOverLayLoding();
         if(json==null||json==""||json.length<=0)
         {
            if($("#showIgnore").attr("checked"))
            {
               $(th).html()=="显示" ? $(th).html("忽略"):$(th).html("显示");
            }
            else
            {
               serachDiyProcessError(); 
            }
         }
         else
         {
           DiyProcessErrorfunction(json);
         }
     }
   });
}

</script>

    </form>
</body>
</html>
