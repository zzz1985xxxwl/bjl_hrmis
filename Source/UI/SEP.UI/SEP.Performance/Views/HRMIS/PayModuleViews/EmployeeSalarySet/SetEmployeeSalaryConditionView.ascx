<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetEmployeeSalaryConditionView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.SetEmployeeSalaryConditionView" %>
  <script type="text/javascript" src="../../Inc/JsAjax.js">
</script>
    <script type="text/javascript">
       var lblSalaryStartTime = '<%= lblSalaryStartTime.ClientID %>';
       var SalaryTimeID = '<%= txtSalaryTime.ClientID %>';
function postResponseClient(responseString)
{
    document.getElementById(lblSalaryStartTime).innerText=responseString;
}

function postRequestServer()
{
    var txtSalaryTime=document.getElementById(SalaryTimeID).value;
    if(txtSalaryTime=="")
    {
        return;
    }
    JsAjaxPostRequestServer("ChangeSalaryTime.aspx?salaryTime="+encodeURIComponent(txtSalaryTime));
}
</script>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    ���÷�н����
</div>

<div  class="edittable">
  <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 40%">
                            ��нʱ��<span style="color: Red">*</span></td>
                        <td align="left">
                            <asp:Label ID="lblSalaryStartTime" runat="server"  ></asp:Label><%-----<asp:Label ID="lblSalaryEndTime"
                                runat="server"></asp:Label>--%>
                            <asp:Button  ID="btnCalendar" runat="server"  CssClass="inputbt5"/>
                            <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                                TargetControlID="txtSalaryTime" PopupButtonID="btnCalendar">
                            </ajaxToolKit:CalendarExtender>
                            <asp:TextBox ID="txtSalaryTime" runat="server" CssClass="input1" style=" width:0px; height:0px; border:0;"  onchange="postRequestServer();"></asp:TextBox>
                            <asp:Label ID="lblTimeSalaryMessage" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            ������˾&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:DropDownList ID="listCompany" runat="server" Width="160px" Height="24px" AutoPostBack="True"
                                OnSelectedIndexChanged="listCompany_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:DropDownList ID="listDepartment" runat="server" Width="160px" Height="24px">
                            </asp:DropDownList>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            ְ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;λ&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:DropDownList ID="listPossition" runat="server" Width="160px" Height="24px">
                            </asp:DropDownList>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            ��������&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:DropDownList ID="listAccountSet" runat="server" Width="160px" Height="24px">
                            </asp:DropDownList>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            Ա������&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:DropDownList ID="listEmployeeType" runat="server" Width="160px" Height="24px">
                            </asp:DropDownList>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            Ա������&nbsp;&nbsp;</td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGoToSetEmployeeSalary" runat="server" Text="���뷢н" CssClass="inputbt"
                                OnClick="btnGoToSetEmployeeSalary_Click" /></td>
                    </tr>
               
    </table>
</div>
