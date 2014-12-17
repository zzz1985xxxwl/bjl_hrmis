<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AssessAnswerView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.AssessAnswerView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>

<script type="text/javascript">
var IsNextExecute = true;
function showdescription(strID)
{
    strID = "Item"+strID ;
    if(!IsNextExecute)
    {
        return;
    }
    var currtr = document.getElementById(strID);
    for(i   =   0;   i   <   document.all.length;   i++)
    {  
        if(document.all(i).tagName.toUpperCase()=="DIV" 
        && document.all(i).id!="" 
        && document.all(i).id.substring(0,4)=="Item" 
        && document.all(i).id!=strID)
        {
            document.all(i).style.display = "none";
        }
    }
    if(currtr==null)
    {
        return;
    }
    if (currtr.style.display=="none")
    {
	    currtr.style.display = "inline"; //展开
    }
    else
    { 
	    currtr.style.display = "none"; //收缩
    } 
}
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div onclick="javascript:showdescription('');IsNextExecute = true;">
            <div id="tbResponsibility" runat="server">
                <div class="leftitbor2">
                    职责
                </div>
                <div class="linetabledivbg">
                    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse:separate;">
                        <tr>
                            <td>
                                <asp:Label ID="lblResponsibility" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="tbPersonalGoal" runat="server" >
                <div class="leftitbor2">
                    个人目标</div>
                <div class="linetabledivbg">
                    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse:separate;">
                        <tr>
                            <td>
                                <asp:Label ID="lblPersonalGoal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            
            <div id="tbAttendanceStatistics" runat="server" visible="false">
                <div class="leftitbor2">考勤记录      
                    <asp:HiddenField ID="hfEmployeeID" runat="server" /></div> 
                 <div class="marginepx">                                                     
               <table cellpadding="0" cellspacing="0" class="linetablepart green1 " border="0"
                width="100%" height="28">
                <tr class="tittdbagbg">
                    <td width="33%">
                    </td>
                    <td class="kqtop" width="34%">
                       <asp:Label ID="lblScopeDateFrom" runat="server"></asp:Label>至<asp:Label ID="lblScopeDateTo"
                    runat="server"></asp:Label>考勤统计
                    </td>
                    <td width="28%" align="right">
                        <span class="kqtop">显示方式&nbsp;&nbsp;</span>
                    </td>
                    <td width="5%" align="left" nowrap>
                        <img id="ibHour" alt="" title="按小时为单位" style="cursor:pointer;" src="../../image/hour.png"  onclick="javascript:employeeAttendance('ibHour');" />
                        <img id="ibDay" alt="" title="按天为单位" style="cursor:pointer;"  src="../../image/day.png"  onclick="javascript:employeeAttendance('ibDay');" />
                    </td>                    
                </tr>         
            </table>
            <div class="" id="divAttendanceData">
                    
                </div>
               </div>
                <div>
                     <div class="leftitbor2">评分标准参考      
                     </div>              
                </div>
                <div class="linetabledivbg">
                    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse:separate; padding-left:20px">
                        <tr>
                            <td>
                                <a href="../../../Pages/HRMIS/Template/关键任务绩效打分对应表.doc" style=" padding-left:20px; line-height:18px; background:url('../../image/iconword.png') no-repeat"> 关键任务绩效打分对应表.doc</a>
                                <br />
                                <a href="../../../Pages/HRMIS/Template/能力与态度打分对应表.doc" style=" padding-left:20px; line-height:18px;background:url('../../image/iconword.png') no-repeat"> 能力与态度打分对应表.doc</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>   
                      
            <div class="leftitbor" id="tbMessage" runat="server">
                <span class="fontred">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label></span><a href="#" class="fontreda"></a>
            </div>
            <div class="leftitbor2">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </div>
            <div class="edittable" runat="server" id="divSalary">
            <div class="marginepx">
                <table width="100%" border="0" runat="server" id="tableSalaryNow" cellpadding="6" cellspacing="0">
                    <tr>
                        <td width="12%" align="left" >
                            <strong>目前工资&nbsp;</strong>&nbsp;<span class="redstar" runat="server" visible="false" id="nowSalaryStar">*</span>
                         </td>
                        <td width="88%" align="left">
                                <asp:TextBox ID="txtSalaryNow" runat="server" CssClass="input1" ></asp:TextBox>
                                <asp:Label ID="lblSalaryNow" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    </table>
                    <table width="100%" border="0" runat="server" id="tableSalaryChange" cellpadding="6" cellspacing="0">
                    <tr>
                        <td width="12%" align="left">
                            <strong><asp:Label ID="lblSalaryName" runat="server" Text="调薪工资"></asp:Label>&nbsp;</strong>
                         </td>
                        <td width="88%" align="left">
                                <asp:TextBox ID="txtSalaryChange" runat="server" CssClass="input1" ></asp:TextBox>
                                <asp:Label ID="lblSalaryChange" runat="server" CssClass="psword_f"></asp:Label>
                                <strong>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblManageSalary" runat="server" ></asp:Label></strong>
                        </td>
                    </tr>
               </table>
               </div>
            </div>
            <div id="tblAssessItem" runat="server">
                <asp:Repeater ID="rptQuesItems" runat="server">
                    <ItemTemplate>
                    <div class="lefttable" align="center">
                        <div class="edittable" style=" background-color:White">
                            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                <tr>
                                    <td width="15%" height="27" align="right" runat="server" id="tdOther">
                                        <strong> <asp:Label ID="lblType" runat="server" Text='<%# Eval("Classfication") %>'></asp:Label>考核指标项</strong>&nbsp;&nbsp;</td>
                                    <td width="15%" height="27" align="right" runat="server" id="tdOpen">
                                        <strong>个人总结项</strong>&nbsp;&nbsp;</td>
                                    <td width="15%" height="27" align="right" runat="server" id="td360">
                                        <strong>360度考核项</strong>&nbsp;&nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="lblQuestion" runat="server"><%# Eval("Question")%></asp:Label>
                                        &nbsp;&nbsp; <a href="javascript:showdescription('<%# Eval("Question")%>');">
                                            <img src="../../image/icon01.gif" align="absmiddle" border="0" /></a>
                                        <div id="<%# "Item"+Eval("Question")%>" style="display: none; background-color: #FFFFFF;
                                            z-index: 10; position: absolute;">
                                            <table onclick="javascript:IsNextExecute = false;" width="450px" class="linetable_3"
                                                border="1" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="28"  class="tdbg02bg">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="8%" height="23" align="center">
                                                                    <img src="../../image/icon04.jpg" /></td>
                                                                <td width="84%" align="left">
                                                                    <strong style="color: #FFFFFF">
                                                                        <%# Eval("Question")%>
                                                                        详细说明</strong></td>
                                                                <td width="8%" align="center">
                                                                    <a href="javascript:showdescription('<%# Eval("Question")%>');">
                                                                        <img src="../../image/xxx.jpg" border="0" /></a></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                            <tr>
                                                                <td height="100" align="center" valign="top">
                                                                    <table width="98%" height="93" border="0" cellpadding="5"  style="border-collapse:separate;" cellspacing="6">
                                                                        <tr>
                                                                            <td width="97%" class="fonttable_2" align="left" valign="top" height="100">
                                                                                <%# Eval("Description")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trOption" runat="server">
                                    <td align="right" valign="middle">
                                        <asp:Label  ID="lblAssessScore" runat="server" Text="评 定"></asp:Label>&nbsp;&nbsp;</td>
                                    <td align="left">
                                        <asp:DropDownList  ID="ddlScore" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trScore" runat="server">
                                    <td align="right" valign="middle">
                                        打 分&nbsp;<span class="redstar">*</span>&nbsp;&nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtScore" runat="server" CssClass="input1"  Width="50px"></asp:TextBox>
                                         &nbsp;&nbsp;<asp:Label ID="lblRange"   runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                 <tr id="trFormula" runat="server">
                                    <td align="right" valign="middle">
                                       公 式&nbsp;&nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFormulaAnswer" CssClass="input1" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trRemark">
                                    <td align="right" valign="top">
                                        <asp:Label ID="lblremarkoranswer" runat="server"></asp:Label>&nbsp;<span class="redstar">*</span>&nbsp;&nbsp;</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="grayborder" Width="90%"
                                            Height="120px" Text='<%# Eval("Note")%>'></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="tblComment" runat="server" class="edittable" >
            <div class="marginepx">
                <table width="100%" border="0" cellpadding="6" cellspacing="0">
                    <tr  >
                        <td width="10%" valign="top">
                            <strong>总 评&nbsp;<asp:Label id="lblStar" runat="server" CssClass="redstar">*</asp:Label>&nbsp;&nbsp;</strong></td>
                        <td width="90%" align="left">
                            <label>
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" 
                                    CssClass="grayborder" Height="100px"  Width="80%"></asp:TextBox>
                                <asp:Label ID="lblCommentMsg" runat="server" CssClass="psword_f"></asp:Label></label></td>
                    </tr>
                </table>
            </div>
            <div id="tblIntentioin" runat="server" class="marginepx">
                <table width="100%" border="0" cellpadding="6" cellspacing="0">
                    <tr>
                        <td width="10%" valign="top">
                            <strong>意 向&nbsp;<span class="redstar">*</span>&nbsp;&nbsp;</strong></td>
                        <td width="30%" valign="top" align="left">
                            <asp:RadioButtonList ID="rbIntention" runat="server">
                            </asp:RadioButtonList></td>
                        <td width="60%" valign="bottom" align="left">
                            <asp:Label ID="lblIntentionMsg" runat="server" CssClass="psword_f"></asp:Label></td>
                    </tr>
                </table>
            </div>
            </div>
            <div class="tablebt">
                <asp:Button ID="btnSave" runat="server" CssClass="inputbt" Text="保　存" OnClick="btnSave_Click" />
                <asp:Button ID="btnSubmit" runat="server" CssClass="inputbt" Text="提　交" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing ID="Progressing1" runat="server"></uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
$(function(){
if($("#cphCenter_AssessAnswerView1_tbAttendanceStatistics").length>0)
{
employeeAttendance("ibHour");
}
})
function employeeAttendance(showType)
{
    $.ajax({
                   type: "get",
                   url: "AssessAttendance.aspx",
                   data: {Type:showType,EmployeeID:$("#cphCenter_AssessAnswerView1_hfEmployeeID").val(),FromDate:$("#cphCenter_AssessAnswerView1_lblScopeDateFrom").html(),ToDate:$("#cphCenter_AssessAnswerView1_lblScopeDateTo").html()},
                   cache:false,
                   success: function(data){
                       $("#divAttendanceData").html(data);
                        }
      });
}
</script>