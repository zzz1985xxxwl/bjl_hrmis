<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionNatureListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Positions.PositionNatureListView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js" charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery-ui-1.7.2.custom.min.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.SXTable.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.ajaxfileupload.js" charset="gb2312"></script>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>

<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>

<div class="leftitbor">   
    <span id="lblMessage"  class="fontred"></span>        
</div>
<div class="leftitbor2">
    设置岗位性质</div>
<div class="edittable">
    <table width="100%" border="0">
       <tr>
        <td align="left" style="width: 2%;">
        </td>
        <td align="left" style="width: 8%;">
            名称
        </td>
        <td align="left" style="width: 41%">
            <input type ="text" ID="txtSearchName"  Width="40%" class="input1"/>
        </td>
        <td align="left" style="width: 8%;">
        </td>
        <td align="left" style="width: 41%">
        </td>
        </tr>
    </table>
</div>
<div class="tablebt">
      <input id="btnSearch" value="查询" class="inputbt" onclick="Search();" type="button"  />
      <input id="btnAdd" value="新增" class="inputbt" onclick="AddShowDialog();" type="button"  />

</div>

<div id="searchTable"  class="linetablediv" > 
    <table id="tb" class="tbStyle" width="100%" style="border-collapse: collapse;text-align:left">
    </table>
</div>



<div id="dialog" style="display:none;" >
    <div id="dialogMessage" class="leftitbor" style="display:none;" >
           <span id="dialoglblMessage" class="fontred"></span>
           <input id="hfRowID" type="hidden"/>
    </div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="15%" align="left">
                名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left">   
                <input id = "txtName" type ="text"  valid="title"/>
               
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="15%" align="left" valign="top">
                说&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;明</td>
            <td align="left" colspan="3" valign="top">
                   <textarea id="txtDescription" rows="3" style="width:90%"></textarea>
            </td>
        </tr>
    </table>
</div>
 <div class="tablebt">
            <input id="btnOK" value="确定" class="inputbt" type="button"  />
            <input id="btnCancel" value="取消" class="inputbt" type="button"  onclick="Close()" />
</div>

</div>

<script language="javascript" type="text/javascript" id="初始化">
var  $name, $description,$searchName;
var $dialogID,$btnOK, sxTableMethods;
var sxValidation = new SXValidation(
{
    valid: 
    {
        rules: 
        {
            title: 
            {
                required: true
            }
        },
        messages: 
        {
            title: 
            {
                required: "不可为空"
            }
        }
    }
});

$(function() {
    $name = $("#txtName");
    $description = $("#txtDescription");
    $searchName = $("#txtSearchName"); 
    $dialogID = $("#hfRowID");
    $btnOK=$("#btnOK");
    $("#dialog").dialog(
    {
        autoOpen: false,
        modal: true,
        width: 400
    });
    Search();
});

function Search() 
{

    $("#tb").SXTable( 
    {
        colNames: ["", "名称", "备注","", ""],
        colWidth: ["2%", "30%", "50%","5%", "5%"],
        colTemplates: [" ", "#Name#", "#Description#", "<a onclick=\"UpdateShowDialog(#PKID#)\">修改</a>","<a onclick=\"Delete(confirm('确定要删除吗？'),#PKID#)\">删除</a>"],
        url: 'PositionNatureHandler.ashx',
        data: 
        {
            Name: $searchName.val(),
            type: "SearchPositionNature"
        },
        pageSize: 15,
        success: Success
    });
    
}



function Success(methods) {
    sxTableMethods = methods;
    MakeCount();
}

function MakeCount()
{
    $("#lblMessage").next(".font14b").eq(0).remove();
    $("#lblMessage").prev(".font14b").eq(0).remove();
    $("<span class='font14b'>共查到</span>").insertBefore("#lblMessage");
    $("<span class='font14b'>条记录</span>").insertAfter("#lblMessage");
    $('#lblMessage').html(sxTableMethods.allitems().length);
}

function AddShowDialog() {
   CleanMessage();
    $name.val("");
    $description.val("");
    $('#dialog').dialog('option', 'title', '新增岗位性质');
    $btnOK.unbind().click(function() {
        Add();
    });
    $('#dialog').dialog('open');
   
}

function UpdateShowDialog(pkid) {
     CleanMessage();
     $('#dialog').dialog('option', 'title', '修改岗位性质');
     $name.val("");
     $description.val("");
     $dialogID.val(pkid);
     $.ajaxJson(
    {
        url: 'PositionNatureHandler.ashx',
        data: 
        {
            type: "GetPositionNatureByID",
            Pkid: pkid
        
        },
          success: function(ans) {
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                  $name.val(ans.itemList.Name);
                  $description.val(ans.itemList.Description);
                  $btnOK.unbind().click(function() {
                    Update();
                });
                $('#dialog').dialog('open');
              
            }
        }
    });
}
function Update() {

    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionNatureHandler.ashx',
            data: 
            {
                type: "UpdatePositionNature",
                Pkid: $.trim($dialogID.val()),
                Name: $.trim($name.val()),
                Description: $.trim($description.val())
             
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                   CommonError(ans);
                }
                else {
                    var item=sxTableMethods.getItemByID($dialogID.val());
                     item.Name=$.trim($name.val());
                     item.Description = $description.val();
                     sxTableMethods.refresh();
                     Search();
                     Close();
                }
            }
        });
    }
    
    
}
function Add() {
    if (sxValidation.valide()) {
        $.ajaxJson(
        {
            url: 'PositionNatureHandler.ashx',
            data: 
            {
                type: "AddPositionNature",
                Name: $.trim($name.val()),
                Description: $.trim($description.val())
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    Search();
                    Close();
                }
            }
        });
    }
    
}

function Delete(Confirmed, pkid) {
    if (Confirmed) {
        $.ajaxJson(
        {
            url: 'PositionNatureHandler.ashx',
            data: 
            {
                type: "DeletePositionNature",
                Pkid: pkid
            },
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                }
                else {
                    sxTableMethods.deleteItem(pkid);    
                    MakeCount();
                }
            }
        });
    }
}
function Close()
{
    $('#dialog').dialog('close');
}
</script>