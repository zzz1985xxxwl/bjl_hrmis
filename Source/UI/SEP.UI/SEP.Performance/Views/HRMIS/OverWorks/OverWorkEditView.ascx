<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorkEditView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.OverWorkEditView" %>
<%@ Register Src="../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc1" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <div id="divResultMessage" runat="server" style="display:none; " class="leftitbor">
        <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
    </div>
<div class="leftitbor2">    
      <asp:Label ID="lbOperationType" runat="server"></asp:Label>
      <asp:HiddenField ID="hfEmployeeID" runat="server" />
</div> 
<%--<div id="tbPositionView" runat="server" class="linetabledivbg">
                                    <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
                                    <div class="edittable">
                <table width="100%" border="0">
                                        <tr>
                                            <td align="right" style="width: 2%">
                                            </td>
                                            <td align="left" style="width: 10%;">
                                                员工姓名</td>
                                            <td align="left" style="width: 39%">
                                                <strong>
                                                    <asp:Label ID="lbEmployeeName" runat="server"></asp:Label></strong></td>
                                            <td align="left" style="width: 10%;">
                                                加班时间段</td>
                                            <td align="left" style="width: 39%">
                                                <strong>
                                                    <asp:Label ID="lbDate" runat="server"></asp:Label></strong></td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left">
                                                加班项目&nbsp;<span class="redstar">*</span></td>
                                            <td align="left"> 
                                                    <asp:TextBox ID="txtProjectName" CssClass="input1"  runat="server"></asp:TextBox><asp:Label ID="lbProjectNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                                            <td align="left">
                                                加班时间</td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lbCostTime" runat="server"></asp:Label></strong>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left" valign="top">
                                                邮件抄送</td>
                                            <td align="left" colspan="3" valign="top">
                                                <asp:TextBox runat="server" ID="txtMailCC" CssClass="input1" 
                                                    Width="85%" onfocus="btnChooseMailCCClick();"></asp:TextBox>
                                               </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left" valign="top">
                                                加班理由&nbsp;<span class="redstar">*</span></td>
                                            <td align="left" colspan="3" valign="top">
                                                <asp:TextBox runat="server" ID="tbReason" CssClass="grayborder" Height="70px" TextMode="MultiLine"
                                                    Width="85%"></asp:TextBox>
                                                <asp:Label ID="lbReasonMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left" colspan="6" valign="top">                            
                                              <asp:GridView GridLines="None" Width="100%" ID="gvOverWork" runat="server"
                                                                AutoGenerateColumns="false" CssClass="linetable"  OnRowDataBound="gvLeaveRequestItemList_RowDataBound">
                                                                <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                                                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                                                <AlternatingRowStyle CssClass="table_g" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                                                                                runat="server" Text="" Style="display: none;" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="2%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="编号">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("ItemID").ToString() != "-1" ? Eval("ItemID").ToString() : "*"%>'>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="5%" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="开始时间">
                                                                        <ItemTemplate>
                                                                            <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbStart"
                                                                                Format="yyyy-MM-dd">
                                                                            </ajaxToolKit:CalendarExtender>
                                                                            <asp:TextBox ID="tbStart" runat="server" Width="90%" CssClass="input1  fromdate"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="时">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlStartHour" runat="server" CssClass="fromhour">
                                                                                <asp:ListItem>0</asp:ListItem>
                                                                                <asp:ListItem>1</asp:ListItem>
                                                                                <asp:ListItem>2</asp:ListItem>
                                                                                <asp:ListItem>3</asp:ListItem>
                                                                                <asp:ListItem>4</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>6</asp:ListItem>
                                                                                <asp:ListItem>7</asp:ListItem>
                                                                                <asp:ListItem>8</asp:ListItem>
                                                                                <asp:ListItem>9</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>11</asp:ListItem>
                                                                                <asp:ListItem>12</asp:ListItem>
                                                                                <asp:ListItem>13</asp:ListItem>
                                                                                <asp:ListItem>14</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                <asp:ListItem>16</asp:ListItem>
                                                                                <asp:ListItem>17</asp:ListItem>
                                                                                <asp:ListItem>18</asp:ListItem>
                                                                                <asp:ListItem>19</asp:ListItem>
                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                <asp:ListItem>21</asp:ListItem>
                                                                                <asp:ListItem>22</asp:ListItem>
                                                                                <asp:ListItem>23</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            时
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="8%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="分">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlStartMinute" runat="server" CssClass="fromminute" >
                                                                                <asp:ListItem>0</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                <asp:ListItem>25</asp:ListItem>
                                                                                <asp:ListItem>30</asp:ListItem>
                                                                                <asp:ListItem>35</asp:ListItem>
                                                                                <asp:ListItem>40</asp:ListItem>
                                                                                <asp:ListItem>45</asp:ListItem>
                                                                                <asp:ListItem>50</asp:ListItem>
                                                                                <asp:ListItem>55</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            分
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="8%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <ItemTemplate>
                                                                             <asp:Label ID="bb" runat="server" Text = "～"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="2%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="结束时间">
                                                                        <ItemTemplate>
                                                                            <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbEnd"
                                                                                Format="yyyy-MM-dd">
                                                                            </ajaxToolKit:CalendarExtender>
                                                                            <asp:TextBox ID="tbEnd" runat="server"  Width="90%" CssClass="input1 todate"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="时">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlEndHour"  CssClass="tohour" runat="server">
                                                                                <asp:ListItem>0</asp:ListItem>
                                                                                <asp:ListItem>1</asp:ListItem>
                                                                                <asp:ListItem>2</asp:ListItem>
                                                                                <asp:ListItem>3</asp:ListItem>
                                                                                <asp:ListItem>4</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>6</asp:ListItem>
                                                                                <asp:ListItem>7</asp:ListItem>
                                                                                <asp:ListItem>8</asp:ListItem>
                                                                                <asp:ListItem>9</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>11</asp:ListItem>
                                                                                <asp:ListItem>12</asp:ListItem>
                                                                                <asp:ListItem>13</asp:ListItem>
                                                                                <asp:ListItem>14</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                <asp:ListItem>16</asp:ListItem>
                                                                                <asp:ListItem>17</asp:ListItem>
                                                                                <asp:ListItem>18</asp:ListItem>
                                                                                <asp:ListItem>19</asp:ListItem>
                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                <asp:ListItem>21</asp:ListItem>
                                                                                <asp:ListItem>22</asp:ListItem>
                                                                                <asp:ListItem>23</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            时
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="8%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="分">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlEndMinute" CssClass="tominute" runat="server">
                                                                                <asp:ListItem>0</asp:ListItem>
                                                                                <asp:ListItem>5</asp:ListItem>
                                                                                <asp:ListItem>10</asp:ListItem>
                                                                                <asp:ListItem>15</asp:ListItem>
                                                                                <asp:ListItem>20</asp:ListItem>
                                                                                <asp:ListItem>25</asp:ListItem>
                                                                                <asp:ListItem>30</asp:ListItem>
                                                                                <asp:ListItem>35</asp:ListItem>
                                                                                <asp:ListItem>40</asp:ListItem>
                                                                                <asp:ListItem>45</asp:ListItem>
                                                                                <asp:ListItem>50</asp:ListItem>
                                                                                <asp:ListItem>55</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            分
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="8%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="加班小时">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtCostTime" Text='<%# Eval("CostTime").ToString()%>' runat="server" Enabled ="false"  CssClass="input1 answer" Style="width: 90%" Rows="1"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="7%"/>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="加班类型">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbOverWorkTypeName" Text='<%# Eval("OverWorkTypeName").ToString()%>' runat="server"  CssClass="type"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="7%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="tbStatusName" runat="server" Text='<%# Eval("Status.Name")%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="8%" />
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="调休">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlAdjust" runat="server"   Enabled="false">
                                                                                <asp:ListItem>是</asp:ListItem>
                                                                                <asp:ListItem>否</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="6%" />
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="换休小时" Visible="false">
                                                                        <ItemTemplate>
                                                                            <%# Eval("AdjustHour")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="7%" />
                                                                      </asp:TemplateField>
                                                                          
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <img src="../../../Pages/image/loading_js.gif"  class="lording" id="imgResultCaculate" runat="server" style="display: none" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="3%" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbAddItem" Text="<img src=../../../Pages/image/file_new.gif border=0>" runat="server" OnCommand="lbAddItem_Command" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="3%"  HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbDeleteItem" Text="<img src=../../../Pages/image/file_cancel.gif border=0>" runat="server" OnCommand="lbDeleteItem_Command" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="3%" HorizontalAlign="Left"  />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                         </div>
            <asp:Label ID="lblRemind" runat="server" Visible="false"></asp:Label>
  <div class="tablebt">
         <asp:Button ID="BtnOK" OnClick="BtnOK_Click" Text="暂  存" OnClientClick="return judgeTime();" runat="server" class="inputbt" />
          <asp:Button ID="BtnSubmit" OnClick="BtnSubmit_Click" Text="提  交" runat="server" OnClientClick="return judgeTime();" class="inputbt" />
</div>
    <ajaxToolKit:ModalPopupExtender ID="mpeChooseEmployee" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlChooseEmployee" TargetControlID="btnChooseEmployeeHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnChooseEmployeeHidden" runat="Server" Style="display: none" />
		<div id="divMPEReimburse" runat="server">        
        <asp:Panel ID="pnlChooseEmployee" runat="server" CssClass="modalBox" Style="display: none;"
            Width="700px">
            <div style="white-space: nowrap; text-align: center;">
                <uc1:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
            </div>
        </asp:Panel>
        </div>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
function btnChooseMailCCClick()
{
$("#cphCenter_OverWorkEditView1_btnChooseEmployeeHidden").trigger("click");
}
    function AjaxCount(obj)
    {   
       var eventHandle=$(obj);
       var $tr=$(obj).parent("td").parent("tr");
       var $td=$tr.children("td");
       var $FromDate=$td.children(".fromdate");
       var $FromHour=$td.children(".fromhour");
       var $FromMinute=$td.children(".fromminute");
       var $ToDate=$td.children(".todate");
       var $ToHour=$td.children(".tohour");
       var $ToMinute=$td.children(".tominute");
       var $Answer=$td.children(".answer");
       var $Type=$td.children(".type");
       var $Lording= $td.children(".lording");
       $Lording.attr("src","../../../Pages/image/loading_js.gif").css("display","block");
       $.ajax({
       url:"../OverWorkPages/CalculateOverWork.aspx",
       cache: false,
       type:"get", 
       data: "FromDate="+$FromDate.val()+"&FromHour="+$FromHour.val()+"&FromMinute="+$FromMinute.val()+"&ToDate="+$ToDate.val()+"&ToHour="+$ToHour.val()+"&ToMinute="+$ToMinute.val()+"&AccountID="+$("#cphCenter_OverWorkEditView1_hfEmployeeID").val(),          
       success:function(data){ if(GetHour(data)=="error"){$Lording.attr("src","../../../Pages/image/wrong_icon.gif").css("display","block");$Answer.val("0");}
       else{$Lording.css("display","none");$Answer.val(GetHour(data));$Type.html(GetType(data));} AllCount();GetCountMonth();judgeTime(); }
       });
    }
    function GetHour(data)
    { var a=data.split('#'); return a[0];}
    function GetType(data)
    { var a=data.split('#'); return a[1];} 
    function GetCountMonth()
    {
        var fromMax=CountMonth("from","min");  var toMax=CountMonth("to","max");
        $("#cphCenter_OverWorkEditView1_lbDate").html(ReplaceCh(fromMax.toLocaleString())+" ～ "+ReplaceCh(toMax.toLocaleString()));
    }
    
    function ReplaceCh(tm)
    { tm=tm.replace("年","-"); tm=tm.replace("月","-"); tm=tm.replace("日","");  return tm; }
    function AllCount()
    { 
     var count=0;   $(".answer").each(function(){count=Number(count)+Number($(this).val());});    $("#cphCenter_OverWorkEditView1_lbCostTime").html(Number(count)+"小时");
    }
    
    function CountMonth(fot,maxormin)
    {
        var allDate=new Array();
        $("."+fot+"date").each(function(){
          var $tr=$(this).parent("td").parent("tr");
          var $td=$tr.children("td");
          var fotDate=$(this).val();
          var fotHour=$td.children("."+fot+"hour").val();
          var fotMinute=$td.children("."+fot+"minute").val();
          if(fotDate.isDate())
          {
           var dtstring=fotDate.replace(/-/g,"/")+" "+fotHour+":"+fotMinute+":00";
           var dt=new Date(dtstring);
           allDate.push(dt);
          }
        });
        var max;
        for(var i=0;i<allDate.length;i++)
        {
           if(!max)
           {
             max=allDate[i];
           }
           if(maxormin=="max")
           {
             if(max<allDate[i])
             {
                max=allDate[i];
             }
           }
           else
           { if(max>allDate[i])  { max=allDate[i]; } }
          
        }
        return max;
    }
     String.prototype.isDate = function()
     {
         var t= this.replace(/-/g,"/");
         var r = t.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/); 
         if(r==null)
         return false; 
         var d = new Date(r[1], r[3]-1, r[4]); 
         return (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]);
     }
     function judgeTime()
     {
        var  time=true;
        $(".fromdate,.todate").each(function(){if(!($(this).val().isDate()))time=false;});
        if(!time)
        {$("#cphCenter_OverWorkEditView1_divResultMessage").show(); 
        $("#cphCenter_OverWorkEditView1_lbResultMessage").html("<span class='fontred'>时间格式错误</span>");}
        else {$("#cphCenter_OverWorkEditView1_divResultMessage").hide();}
        return time;
     }
    </script>
