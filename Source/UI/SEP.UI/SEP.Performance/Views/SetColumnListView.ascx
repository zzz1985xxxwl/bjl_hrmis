<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetColumnListView.ascx.cs" Inherits="SEP.Performance.Views.SetColumnListView" %>

<div class="marginepx">
<div class="edittable5">
<span style="float:left;">设置查询结果列</span>
 <img style="float:right; margin-top:9px;cursor:hand;" src="../../image/shid1.gif" id="hiddenSetColumnList" 
 onmouseover="AddClass(this,'AdvanceViewButtonAlter');"  onmouseout="RemoveClass(this,'AdvanceViewButtonAlter');" class="hiddensetdiv" 
onclick="ShowOrHideForm('divSetColumnList','showSetColumnList','hiddenSetColumnList',0)"/>
 <img style="float:right; margin-top:9px;cursor:hand;" src="../../image/shid2.gif" id="showSetColumnList" 
 onmouseover="AddClass(this,'AdvanceViewButtonAlter');"  onmouseout="RemoveClass(this,'AdvanceViewButtonAlter');" class="showsetdiv" 
onclick="ShowOrHideForm('divSetColumnList','showSetColumnList','hiddenSetColumnList',1)"/>
 <div style="clear:both;"></div>
</div>

<div id="divSetColumnList" class="hiddensetdiv" >
<div class="edittable4">
    <table width="100%" border="0">
        <tr id="tbCheckBox" runat="server">
        <td align="left" colspan="4" style=" padding:0px">
            <asp:Panel ID="checkboxlist" runat="server" CssClass="SetColumnList">
            </asp:Panel>
            </td>
        </tr>
    </table>
</div>
</div>
</div>
<script type="text/javascript" language="javascript">
function getSetColumnListValue()
{
  var s="";
      var i=0;
      $(".SetColumnList").find("input[type='checkbox']").each(function(){
        if($(this).attr("checked")){
            s+=i+"|"
        }
        i=i+1;
      });
  return s;
}
</script>

