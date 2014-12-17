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
    ���ø�λ����</div>
<div class="edittable">
    <table width="100%" border="0">
       <tr>
        <td align="left" style="width: 2%;">
        </td>
        <td align="left" style="width: 8%;">
            ����
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
      <input id="btnSearch" value="��ѯ" class="inputbt" onclick="Search();" type="button"  />
      <input id="btnAdd" value="����" class="inputbt" onclick="AddShowDialog();" type="button"  />

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
                ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left">   
                <input id = "txtName" type ="text"  valid="title"/>
               
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="15%" align="left" valign="top">
                ˵&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</td>
            <td align="left" colspan="3" valign="top">
                   <textarea id="txtDescription" rows="3" style="width:90%"></textarea>
            </td>
        </tr>
    </table>
</div>
 <div class="tablebt">
            <input id="btnOK" value="ȷ��" class="inputbt" type="button"  />
            <input id="btnCancel" value="ȡ��" class="inputbt" type="button"  onclick="Close()" />
</div>

</div>

<script language="javascript" type="text/javascript" id="��ʼ��">
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
                required: "����Ϊ��"
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
        colNames: ["", "����", "��ע","", ""],
        colWidth: ["2%", "30%", "50%","5%", "5%"],
        colTemplates: [" ", "#Name#", "#Description#", "<a onclick=\"UpdateShowDialog(#PKID#)\">�޸�</a>","<a onclick=\"Delete(confirm('ȷ��Ҫɾ����'),#PKID#)\">ɾ��</a>"],
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
    $("<span class='font14b'>���鵽</span>").insertBefore("#lblMessage");
    $("<span class='font14b'>����¼</span>").insertAfter("#lblMessage");
    $('#lblMessage').html(sxTableMethods.allitems().length);
}

function AddShowDialog() {
   CleanMessage();
    $name.val("");
    $description.val("");
    $('#dialog').dialog('option', 'title', '������λ����');
    $btnOK.unbind().click(function() {
        Add();
    });
    $('#dialog').dialog('open');
   
}

function UpdateShowDialog(pkid) {
     CleanMessage();
     $('#dialog').dialog('option', 'title', '�޸ĸ�λ����');
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