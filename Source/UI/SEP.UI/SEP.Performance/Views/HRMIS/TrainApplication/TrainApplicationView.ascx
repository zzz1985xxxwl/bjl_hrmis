<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainApplicationView.ascx.cs" 
Inherits="SEP.Performance.Views.HRMIS.TrainApplication.TrainApplicationView" %>
 <%@ Register Src="../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc1" %>
<script language="javascript">
var btnMailHidden = '<%= btnMailHidden.ClientID %>';
function EmployeeHiddenBtnClick()
{
document.getElementById(btnMailHidden).click();
}
</script> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>   
<div id="tbMessage" runat="server"  class="leftitbor" >
			<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <asp:HiddenField ID="hf_PKID" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="14%" align="left">
            课程名称<span class = "redstar">*</span></td>
            <td align="left" colspan="3">
            <asp:TextBox ID="txtCourseName" runat="server" CssClass="input1" Width="484px"></asp:TextBox> &nbsp;
            <asp:Label ID="lblCourseNameMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">培训开始时间<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtActualST" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualSTMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtActualST" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
            <td align="left">培训结束时间<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtActualET" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualETMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtActualET" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
        </tr>
            <tr>
            <td align="left">
            被培训人<span class = "redstar">*</span></td>
            <td colspan="3" align="left">
            <asp:TextBox ID="txtTrainee" runat="server" Width="484px" CssClass="input1" ReadOnly="True"></asp:TextBox>&nbsp;
            <asp:Label ID="lblTraineeMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>        
        <tr>
            <td align="left" >
            相关技能<span class = "redstar">*</span></td>
            <td colspan="3" align="left" >
            <asp:TextBox ID="txtSkill" runat="server" Width="485px" CssClass="input1"></asp:TextBox>
            <asp:Label ID="lblSkillMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            </tr>

                    <tr>
            <td align="left">
            培训机构<span class = "redstar">*</span></td>
                        <td align="left" colspan="3"><asp:TextBox ID="txtTrainOrgnazation" runat="server" Width="484px" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblOrgzation" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>

        <tr>
            <td align="left">
            培训地点<span class = "redstar">*</span></td>
            <td align="left">
                   <asp:TextBox ID="txtPlace" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblPlaceMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td align="left">
            培训课时<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtActualHour" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualHourMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
                <tr>
            <td align="left">
            培训师<span class = "redstar">*</span></td>
            <td align="left">  
            <asp:TextBox ID="txtTrainer" runat="server" Text="" CssClass="input1"></asp:TextBox>
            &nbsp;
            <asp:Label ID="lblTrainerMsg" runat="server" CssClass = "psword_f"></asp:Label>             
            </td>
            <td align="left">
                培训范围<span class = "redstar">*</span></td>
            <td align="left">
            <asp:DropDownList ID="listScope" runat="server" Width="149px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            培训费用&nbsp;<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtExpectedCost" runat="server"  CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblExpCostMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td align="left">教育补助金额</td>
            <td align="left"><asp:TextBox ID="txtEduSupCost" runat="server"  CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblEduSupCost" runat="server" CssClass = "psword_f"></asp:Label>
    </td>
        </tr>
        <tr><td align="left"><asp:CheckBox ID="cbCertifiacation" runat="server" Text="是否有证书" /></td></tr>
    </table>
</div>
<div class="edittable" id="divApproveRemark" runat="server" visible="false">
   <table width="100%" border="0">
        <tr>
            <td width="14%" align="left">
            申请人信息</td>
            <td align="left" >
                <asp:Label runat="server" ID="lblApplierInfo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="14%" align="left">
            审核备注</td>
            <td align="left" > <asp:TextBox ID="txtApproveRemark" TextMode="MultiLine" runat="server" Width="484px"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>

<div id="Backbtn" runat="server" class="tablebt">  
    <asp:Button ID="btnTemperary"  runat="server" Text="暂　存" CssClass="inputbt" OnClick="btnTemperary_Click" />
    <asp:Button ID="btnOk" OnClick="btnOK_Click"  runat="server" Text="提　交" CssClass="inputbt" />
     <asp:Button ID="btnPass"  runat="server" Text="通  过" CssClass="inputbt" OnClick="btnPass_Click" Visible="false" OnClientClick="return confirm('确定要通过该培训申请？');"/>
    <asp:Button ID="btnFail" OnClick="btnFail_Click"  Visible="false" runat="server" Text="拒  绝" CssClass="inputbt" OnClientClick="return confirm('确定要拒绝该培训申请？');" />
    <asp:Button ID="btnCancle" OnClientClick="history.go(-1)" runat="server" Text="取  消"  CssClass="inputbt"/>
</div>
 <ajaxToolKit:ModalPopupExtender id="mpeEmployeeList" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlSearchEmployee" 
                    TargetControlID="btnMailHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnMailHidden" runat="Server" Style="display: none" />  
<asp:Panel ID="pnlSearchEmployee" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
 <div style="white-space: nowrap; text-align: center;">
     <uc1:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
</div>
</asp:Panel>
 </ContentTemplate>
    </asp:UpdatePanel>