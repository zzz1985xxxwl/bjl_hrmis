<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" Codebehind="DepartmentManagementD.aspx.cs"
    Inherits="SEP.Performance.Pages.SEP.DepartmentPages.DepartmentManagement" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
<script language="javascript " type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js"></script>
 <script language="javascript " type="text/javascript" src="../../Inc/jquery.treeTable.js"></script>
<style type="text/css">
#departmentTreeTable thead tr th:first-child {
  padding-left:40px;
}
#departmentTreeTable tbody tr td:first-child {
   padding-left:40px;
}
table a
{
	color:#498929;
	cursor:hand;
}
.dropdrag 
{
   cursor:move;
}
</style>

        <div id="trMessage" class="leftitbor fontred" style="display: none;">
        </div>
        <div class="leftitbor2">
            组织架构管理
        </div>
        <div class="linetablediv" style="position:relative;">
            <table id="departmentTreeTable" width="100%" cellspacing="0" border="0" style="border-collapse: collapse;">
                <thead>
                    <tr class="headerstyleblue" height="28px">
                        <th style="width: 40%;">
                            部 门</th>
                        <th style="width: 14%;">
                            部门主管</th>
                        <th style="width: 24%;">
                        </th>
                        <th style="width: 10%;">
                        </th>
                        <th style="width: 5%;">
                        </th>
                        <th style="width: 5%;">
                        </th>
                    </tr>
                </thead>
                <tbody id="departmentTreeTabletbody">
                <tr style="height:50px"><td colspan="6"><div class="loadingImage" style="position:absolute;top:40%;left:47%;"></div></td></tr>
                </tbody>
            </table>
        </div>
        
<div id="editview" style="display:none;">       
      <div id="tbMessage"  class="leftitbor" style="display:none;">
			<span id="lblMessage" class = "fontred"></span>
	  </div>
 
<div class="edittable">
    <table width="100%" border="0" >
        <tr>                
          <td width="20px">&nbsp;</td>
          <td align="left" width="60px">
              部门<span class = "redstar">*</span></td>
            <td align="left" width="auto">
              <input type="text" style="width:150px" id="txtDepName"  class = "input1"></input>
            <span id="lblDepNameMsg" class = "psword_f"></span></td>
            <td align="left" width="60px">部门经理<span class = "redstar">*</span></td><td align="left">
                 <input type="text" id="txtLeaderName" style="width:150px" class = "input1"></input>
            <span id="lblLeaderNameMsg" class = "psword_f"></span></td>
        </tr> 
        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              电话</td>
            <td align="left" width="auto">
                <input type="text" style="width:150px" id="txtPhone" class="input1" ></input></td><td align="left" width="60px">
                传真</td><td align="left">
                <input type="text" style="width:150px" id="txtFax"class="input1" ></input></td>
		</tr>
		        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              成立时间</td>
            <td align="left" width="auto">
             <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFoundationTime" Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtFoundationTime"  runat="server" CssClass="input1 txtFoundationTime"  Width="150px"></asp:TextBox>
                <span id="lblTimeError" class = "psword_f"></span></td>
                <td align="left" width="60px"> 其他</td><td align="left">
                <input type="text" style="width:150px" id="txtOthers" class="input1" ></input></td></tr>
                		        <tr>
          <td width="20px">&nbsp;</td>
		  <td align="left" width="60px">
              地址</td>
                                    <td colspan="3" align="left">
                <input type="text" style="width:300px" id="txtAddress" class="input1"></input></td>
		</tr>
                		        <tr>
          <td width="20px" style="height: 80px" rowspan="2" valign="middle">&nbsp;&nbsp;</td>
		  <td align="left" width="60px" style="height: 80px" rowspan="2">
              描述</td>
                                    <td colspan="3" align="left" style="height: 83px" rowspan="2">
                <textarea style="width:300px;height:72px;" id="txtDescription" class="input1" ></textarea></td>
		</tr>
		                		        <tr>
		</tr>
    </table>
</div>              
      <div class="tablebt">
		   <input type="button"  id="btnOK"      value="确　定"  class="inputbt"/>
		   <input type="button"  id="btnCancel"  value="取　消"  class="inputbt"/>
      </div>
</div>

<script type="text/javascript">
  $(document).ready(function() {
   $("#editview").dialog({
        bgiframe: true,
	    autoOpen: false,
	    modal: true,
	    width:600
	    });
   $("#btnCancel").click(function(){$("#editview").dialog("close")});
  GetValue()
  });
var  $txtDepName=$("#txtDepName"),
$lblDepNameMsg=$("#lblDepNameMsg"),
$txtLeaderName=$("#txtLeaderName"),
$lblLeaderNameMsg=$("#lblLeaderNameMsg"),
$txtPhone=$("#txtPhone"),
$txtFax=$("#txtFax"),
$txtFoundationTime=$(".txtFoundationTime"),
$lblTimeError=$("#lblTimeError"),
$txtOthers=$("#txtOthers"),
$txtAddress=$("#txtAddress"),
$txtDescription =$("#txtDescription");

function GetValue()
{
$("#trMessage").hide();
var tr="<tr style='height:28px' id='#Id#' class='#CssClass#'  departmentid='#DepartmentID#'><td><span class='dropdrag' ><span>#DepartmentName#</span><span>(#CountEmployee#人)</span></span></td><td>#DepartmentLeader#</td><td><div><a  class='showdepartmentmember'>显示部门成员</a><div  style=\"display:none;z-index:10; position:relative;\"><table width=\"100%\" border=\"0\" cellspacing=\"5\" cellpadding=\"0\">#DepartmentMember#</table></div></div></td><td><a onclick=\"addchild(this);\">添加子部门</a></td><td><a  onclick=\"update(this);\">修改</a></td><td><a  onclick=\"deletedep(this);\">删除</a></td></tr>"
  $.ajax({
           type: "get",
           url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
           data:{type:"search"},
           cache:false,
           dataType:'json',
           success: function(json){  
                $("#departmentTreeTabletbody").empty();
                for(var i=0;i<json.length;i++){
                    if(json[i]["ErrorControlID"]!=null)
                    {
                       errorfunction(json);
                       return;
                    }
                }
                for(var i=0,l=json.length;i<l;i++){
            	    var t=tr;
                    for(var key in json[i]){
                	    var reg=new RegExp("#"+key+"#","g");
                	    t=t.replace(reg,json[i][key]);
                     }
                     $("#departmentTreeTabletbody").append(t); 
                }
                 $("#departmentTreeTable").treeTable();  
                 $("#node--1").toggleBranch(); 
                 $(".showdepartmentmember").each(function(){
                     if($(this).next("div").find("tr").length<=0)
                     {$(this).remove();}
                 });
                 $(".showdepartmentmember").toggle(function(){$(this).html("隐藏部门成员");$(this).next("div").show();},function(){$(this).html("显示部门成员");$(this).next("div").hide();});
                 
                 InitDragDrop();
             }
              
    });
    
              
}
function addchild(th)
{
   EmptyMessage();
$txtDepName.val("");
$txtLeaderName.val("");
$txtPhone.val("");
$txtFax.val("");
$txtFoundationTime.val("");
$txtOthers.val("");
$txtAddress.val("");
$txtDescription.val("");
  $('#editview').dialog('option', 'title', '添加部门');
  $('#editview').dialog('open');
  var parent=$(th).parent("td").parent("tr");
  $("#btnOK").unbind("click");
  $("#btnOK").bind("click",function(){
       EmptyMessage();
      var valide=false;
      if($("#txtDepName").val()=="")
      {
         $("#lblDepNameMsg").html("不能为空");
         valide=true;
      }
      if($("#txtLeaderName").val()=="")
      {
         $("#lblLeaderNameMsg").html("不能为空");
         valide=true;
      }
      if(valide){return;}
       AddOverLayLoding();
       $.ajax({
           type: "get",
           url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
           data:{type:"add",ParentDepartmentID:parent.attr("departmentid"),DepartmentName:$("#txtDepName").val(),LeaderName:$("#txtLeaderName").val(),Address:$txtAddress.val(),Phone:$txtPhone.val(),Fax:$txtFax.val(),Others:$txtOthers.val(),Description:$txtDescription.val(),FoundationTime:$txtFoundationTime.val()},
           cache:false,
           dataType:'json',
           success:function(json){
               RemoveOverLayLoding();
               if(json[0].DepartmentID)
               {
                   var node= "<tr style='height:28px' departmentid='"+json[0].DepartmentID+"'><td><span class='dropdrag' ><span>"+ $("#txtDepName").val()+"</span><span>(0人)</span></span></td><td>"+$("#txtLeaderName").val()+"</td><td></td><td><a  onclick=\"addchild(this);\">添加子部门</a></td><td><a  onclick=\"update(this);\">修改</a></td><td><a onclick=\"deletedep(this);\">删除</a></td></tr>";
	               $(node).appendNewBranchTo(parent);
	               InitDragDrop();
                   $('#editview').dialog('close');
               }
               else
               {
                    for(var i=0;i<json.length;i++){
                      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]);
                      if(json[i]["ErrorControlID"]=="lblMessage")
                      {$("#tbMessage").show();}
                    }
               }
           }
       });
       
         
     });
}
function update(th)
{
  EmptyMessage();
  var $node=$(th).parent("td").parent("tr").eq(0);
  $('#editview').dialog('option', 'title', '修改部门');
   InitDialogInfo($node);
  $("#btnOK").unbind("click");
  $("#btnOK").bind("click",function(){
      EmptyMessage();
      var valide=false;
      if($("#txtDepName").val()=="")
      {
         $("#lblDepNameMsg").html("不能为空");
         valide=true;
      }
      if($("#txtLeaderName").val()=="")
      {
         $("#lblLeaderNameMsg").html("不能为空");
         valide=true;
      }
      if(valide){return;}
       AddOverLayLoding();
       $.ajax({
           type: "get",
           url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
           data:{type:"update",DepartmentID:$node.attr("departmentid"),DepartmentName:$("#txtDepName").val(),LeaderName:$("#txtLeaderName").val(),Address:$txtAddress.val(),Phone:$txtPhone.val(),Fax:$txtFax.val(),Others:$txtOthers.val(),Description:$txtDescription.val(),FoundationTime:$txtFoundationTime.val()},
           cache:false,
           dataType:'json',
           success:function(json){
               RemoveOverLayLoding();
               if(json.length>0)
               {
                    for(var i=0;i<json.length;i++){
                      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]);
                      if(json[i]["ErrorControlID"]=="lblMessage")
                      {$("#tbMessage").show();}
                    }
               }
               else
               {
                   $node.find(".dropdrag").find("span").eq(0).html($("#txtDepName").val());
                   $node.find("td").eq(1).html($("#txtLeaderName").val());
                   $('#editview').dialog('close');
               }
           }
       });
       
  });
}
function InitDialogInfo($node)
{

      AddOverLayLoding();
      $.ajax({
           type: "get",
           url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
           data:{type:"InitDepartment",DepartmentID:$node.attr("departmentid")},
           cache:false,
           dataType:'json',
           success:function(json){
               RemoveOverLayLoding();
               for(var i=0;i<json.length;i++){
                    if(json[i]["ErrorControlID"]!=null)
                    {
                       errorfunction(json);
                       return;
                    }
                }
               $txtDepName.val(json[0].DepartmentName);
               $txtLeaderName.val(json[0].DepartmentLeader);
               $txtAddress.val(json[0].Address);
               $txtPhone.val(json[0].Phone);
               $txtFax.val(json[0].Fax);
               $txtOthers.val(json[0].Others);
               $txtDescription.val(json[0].Description);
               $txtFoundationTime.val(json[0].FoundationTime);
               $('#editview').dialog('open');
           }
       });
}
function EmptyMessage()
{
   $("#tbMessage").hide();
   $("#lblMessage").html("");
   $lblDepNameMsg.html("");
   $lblLeaderNameMsg.html("");
   $lblTimeError.html("");
     
}
function deletedep(th)
{
  EmptyMessage();
  $('#editview').dialog('option', 'title', '删除部门');
  var $node=$(th).parent("td").parent("tr").eq(0);
  InitDialogInfo($node);
  $("#btnOK").unbind("click");
  $("#btnOK").bind("click",function(){
     EmptyMessage();
     AddOverLayLoding();
     $.ajax({
           type: "get",
           url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
           data:{type:"delete",DepartmentID:$node.attr("departmentid")},
           cache:false,
           success:function(msg){
                RemoveOverLayLoding();
                if(msg=="success")
                { 
                   $(th).parent("td").parent("tr").removeBranch();
                   $('#editview').dialog('close');
                }
                else
                {
                    $("#lblMessage").html(msg);
                    $("#tbMessage").show();
                }
           }
    });
 });
}
function errorfunction(json)
{
    for(var i=0;i<json.length;i++){
      $("#"+json[i]["ErrorControlID"]).html(json[i]["ErrorMessage"]).show();;
    }
}

function InitDragDrop()
{
   $("#departmentTreeTable ").find("tr[departmentid]:even").addClass("GridViewRowLink").bind("mouseover",function(){$(this).addClass("tablerow_mouseover");})
	        .bind("mouseout",function(){$(this).removeClass("tablerow_mouseover");});
    $("#departmentTreeTable ").find("tr[departmentid]:odd").addClass("table_g").bind("mouseover",function(){$(this).removeClass("table_g");$(this).addClass("tablerow_mouseover");})
	        .bind("mouseout",function(){$(this).removeClass("tablerow_mouseover");$(this).addClass("table_g");});
   $("#departmentTreeTable .dropdrag").draggable({
                                                      helper: "clone",
                                                      opacity: .75,
                                                      refreshPositions: true, // Performance?
                                                      revert: "invalid",
                                                      revertDuration: 300,
                                                      scroll: true
                                                    });
                                                                            
                $("#departmentTreeTable .dropdrag").each(function() {
                                                              $($(this).parents("tr")[0]).droppable({
                                                                accept: ".dropdrag",
                                                                drop: function(e, ui) { 
                                                                   th=this;
                                                                 
                                                                  $("#trMessage").html("");
                                                                  var departmentid=$($(ui.draggable).parents("tr")[0]).attr("departmentid"),pareDepartmentID=$(th).attr("departmentid");
                                                                  if(departmentid!=pareDepartmentID)
                                                                  { AddOverLayLoding();
                                                                      $.ajax({
                                                                               type: "get",
                                                                               url: '../../../Views/SEP/Departments/DepartmentMenagementDragableAsyPage.aspx',
                                                                               data:{type:"move",DepartmentID:departmentid,ParentDepartmentID:pareDepartmentID},
                                                                               cache:false,
                                                                               dataType:'json',
                                                                               success:function(json){
                                                                                    RemoveOverLayLoding();
                                                                                       if(json.length>0)
                                                                                       {
                                                                                            errorfunction(json);
                                                                                       }
                                                                                       else
                                                                                       {
                                                                                            $($(ui.draggable).parents("tr")[0]).appendBranchTo(th);
                                                                                       }
                                                                               }
                                                                        });
                                                                  }
                                                                  else
                                                                  {
                                                                     $($(ui.draggable).parents("tr")[0]).appendBranchTo(th);
                                                                  }
                                                                        
                                                                 
                                                                },
                                                                hoverClass: "accept",
                                                                over: function(e, ui) {
                                                                  if(this.id != ui.draggable.parents("tr")[0].id && !$(this).is(".expanded")) {
                                                                    $(this).expand();
                                                                  }
                                                               }
                    
                  });
                  });
}
</script>



</asp:Content>

