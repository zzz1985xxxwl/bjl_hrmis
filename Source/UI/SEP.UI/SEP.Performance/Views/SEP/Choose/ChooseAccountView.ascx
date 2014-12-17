<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChooseAccountView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Choose.ChooseAccountView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
    <input type="hidden" runat="server" id="isShowImg" class="isShowImg" />
    <table width="100%" border="0" style="text-align:left">
        <tr>
          <td width="11%" valign="top" align="left" >
          <asp:Label ID="lblTitle" runat="server" Text="Label" >员工</asp:Label>
          <a onclick="OpenAccountSearch();" style="padding: 2px 0px 2px 20px; background-image:url(../../../pages/image/group.png); background-repeat:no-repeat; width:16px; height:16px; " title="查询员工">&nbsp;</a>
          </td>
          <td width="89%">
          <textarea id="txtAccount" rows="5" runat="server" style=" width:90%" class="txtAccount"></textarea></td>
        </tr>
        <tr>
          <td></td>
          <td>注：员工之间用分号“;”隔开</td>
        </tr>
        
    </table>
<input type="hidden" id="hpPowerID" runat="server" class="hpPowerID" />            
<div class="searchAccount" style="display:none;">
    <div id="edittbMessage" class="leftitbor" style="display:none">
        <span id="editlblMessage" class="fontred"></span>
    </div>
    <table width="100%">
        <tr>
            <td>
                    <div class="edittable6">
                        <table border="0">
                            <tr>
                              <td style="width:6%">姓名</td>
                              <td style="width:18%"><asp:TextBox ID="txtEmployeeName" runat="server" Width="90%" CssClass="txtNameAccountView"></asp:TextBox></td>
                              <td style="width:6%">部门</td>
                              <td style="width:30%"><asp:DropDownList ID="ddlDepartment" runat="server" Width="98%" CssClass="ddlDepartmentAccountView"></asp:DropDownList></td>
                              <td style="width:6%">职位</td>
                              <td style="width:30%"><asp:DropDownList ID="ddlPosition" runat="server" Width="98%" CssClass="ddlPositionAccountView"></asp:DropDownList></td>
                              <td style="width:4%"><input type="button" class="inputbtSearch" onclick="SearchAccount();"/></td>
                            </tr>                            
                        </table>
                        <div id="divAccountEmployeeList" class="linetablediv" >
                            <label id="lblAllAccount" class="lblAllAccount" style="display:none"></label>
                            <table id="tbAccountEmployeeList" width="100%" ></table>
                        </div>
                    </div>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" id="CutomerContact">
var $tbAccountEmployeeList=$("#tbAccountEmployeeList");
var $txtNameAccountView = $(".txtNameAccountView");
var $ddlDepartmentAccountView = $(".ddlDepartmentAccountView");
var $ddlPositionAccountView = $(".ddlPositionAccountView");
var $txtAccount = $(".txtAccount");
var $lblAllAccount = $(".lblAllAccount");
var $divAccountSearch =  $(".searchAccount");
var $divAccountEmployeeList =$("#divAccountEmployeeList");
var $hpPowerID=  $(".hpPowerID");
var rows=5;

$(function(){
	  $divAccountSearch.dialog({
	    autoOpen: false,
	    modal: true,
	    width:750
	    });	
	  $divAccountEmployeeList.hide();	   
	});
function OpenAccountSearch()
{
    if($(".isShowImg").val()=="True")
    {
        return;
    }
    $divAccountSearch.dialog('option', 'title', "查询员工");
    $divAccountSearch.dialog('open');
    ClearMsg(); 
}
function SearchAccount()
{
    $divAccountEmployeeList.show();
    $lblAllAccount.val("");
     $tbAccountEmployeeList.SXTable({
                    colNames:["","姓名","部门","职位","Email1","Email2","<a onclick='ChooseAccountGroup();'>全选</a>"],
                    headers: {6: {sorter: false} },
				    colTemplates:["","#Name#","#DeptName#","#PositionName#","#Email1#","#Email2#","<a onclick='ChooseAccount(\"#Name#\");'>选择</a>"],
                    url: '../../../Views/SEP/Choose/ChooseAccount.ashx',
                    data: 
                    {
                        type: "GetAccountsByAuth",
                        accountname:$txtNameAccountView.val(),
                        departmentid:$ddlDepartmentAccountView.val(),
                        positionid:$ddlPositionAccountView.val(),
                        powerID : $hpPowerID.val()           
                    },
                    getrows:function(rows){
                        for(var i=0;i<rows.length;i++)
                        {
                            if($lblAllAccount.val()=="")
                            {
                                $lblAllAccount.val(rows[i]["Name"]);
                            }
                            else
                            {
                                $lblAllAccount.val($lblAllAccount.val()+";"+rows[i]["Name"]);
                            }                           
                        }                    
                    },
				    pageSize:10
    });
}
function ChooseAccountGroup()
{
    var members = $lblAllAccount.val();
    var memberArray = members.split(";");
    for(var i=0;i<memberArray.length;i++)　
    {　
        ChooseAccount(memberArray[i]);
    }
}
function ChooseAccount(name)
{   
    $txtAccount.val($txtAccount.val().replace(" ","").replace("　","").replace("；",";"))
    var names = $txtAccount.val().split(";");
    for(var i=0;i<names.length;i++)　
    {　
        if(name==names[i])
        {
            return;
        }　
    }
    if($txtAccount.val()=="" )
    {
        $txtAccount.val(name);
    }
    else  if($txtAccount.val().substring($txtAccount.val().length-1)==";")
    {     
        $txtAccount.val($txtAccount.val()+name);
    }
    else
    {      
        $txtAccount.val($txtAccount.val()+";"+name);
    }
}
function ClearMsg()
{   
    $("#editlblMessage").val("");
    $("#edittbMessage").hide();
}
</script>
