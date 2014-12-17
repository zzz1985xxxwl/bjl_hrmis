<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneMessageListIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.SystemErrorPages.PhoneMessageListIFramePage" %>

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
      <div id="PhoneMessageErrorMessage" class="fontred leftitbor" style="display:none;"></div>
<div class="edittable">  
    <table width="100%" border="0">
        <tr>
           <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 12%;">
                姓名
            </td>
            <td align="left" style="width: 37%">
                <input type="text" id="txtemployeeName" ></input>
            </td>
             <td align="left" style="width: 12%;">
                状态
            </td>
            <td align="left" style="width: 37%;">
                 <asp:DropDownList ID="ddlStatus"  runat="server" Width="50%" CssClass="ddlStatus" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
<input id="btnSearch" type="button" value="查　询"  class="inputbt" onclick="serachPhoneMessageError();" />
</div>
<div class="linetablediv"><table id="tbPhoneMessageError" width="100%" ></table></div>
<div style="height:2px"/>
<script language="javascript" type="text/javascript">
$(function(){serachPhoneMessageError();})
function serachPhoneMessageError()
{
     $("#PhoneMessageErrorMessage").hide();
     $("#tbPhoneMessageError").SHjqTable({
                    colNames:["","姓名","内容","","所属公司","部门",""],
				    colWidth:["2%","10%","34%","1%","23%","23%","7%"],
				    colPKIDName:'PKID',
				    colTemplates:["","#EmployeeName#","#Description#","","#CompanyName#","#DepartmentName#","#Finish#"],
				    headers:{0: { sorter: false},2: {sorter: false},3: {sorter: false} },
				    url:'../../../Views/HRMIS/SystemErrors/PhoneMessageErrorListAjax/PhoneMessageErrorListAsyPage.aspx',
				    data:{type:"search",Status:$(".ddlStatus").val(),EmployeeName:$("#txtemployeeName").val()},
				    error:PhoneMessageErrorfunction,
				    pageLoading:true
    }
    )

}
function PhoneMessageErrorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).show();
    }
}

function FinishPhoneMessageByPKID(pkid)
{
    AddOverLayLoding();
   $.ajax({
     url:'../../../Views/HRMIS/SystemErrors/PhoneMessageErrorListAjax/PhoneMessageErrorListAsyPage.aspx',
     data:{type:"finishPhoneMessageByPKID",PKID:pkid},
     dataType:'json',
     cache:false,
     success:function(json){
          RemoveOverLayLoding();
         if(json==null||json==""||json.length<=0)
         {   
               serachPhoneMessageError(); 
         }
         else
         {
           PhoneMessageErrorfunction(json);
         }
     }
   });
}

</script>
    </form>
</body>
</html>
