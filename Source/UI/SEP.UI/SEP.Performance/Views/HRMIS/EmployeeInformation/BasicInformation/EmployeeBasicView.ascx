<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EmployeeBasicView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeInformation.BasicInformation.EmployeeBasicView" %>

<script type="text/javascript">
function PhotoHiddenBtnClick()
{
document.getElementById("divMPEPhoto").style.display="block";
document.getElementById("cphCenter_EmployeeView1_EmployeeBasicView1_btnPhotoHidden").click();
}
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnAdd" />
    </Triggers>
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="left">
                    <table width="100%" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
                        <tr>
                            <td style="width: 2%;">
                            </td>
                            <td style="width: 10%;" valign="top" rowspan="7">
                                ��Ƭ</td>
                            <td style="width: 39%;" rowspan="7">
                                <a id="PhotoLink" runat="server">
                                    <asp:Image ID="imgPhoto" runat="server" ImageAlign="Left" Width="120px" Height="160px"
                                        ImageUrl="../../../../pages/image/photo.jpg" BorderWidth="1px" BorderColor="#919191" /></a></td>
                            <td style="width: 10%;">
                                ��¼��</td>
                            <td style="width: 39%;">
                                <asp:Label ID="txtAccountName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                ������</td>
                            <td>
                                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ��������</td>
                            <td>
                                <asp:Label ID="lblDepartmentName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ְλ</td>
                            <td>
                                <asp:Label ID="lblPositionName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ��ϵ�绰</td>
                            <td>
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                �����ַ1</td>
                            <td>
                                <asp:Label ID="lblMail1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                �����ַ2</td>
                            <td>
                                <asp:Label ID="lblMail2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                �Ա�</td>
                            <td>
                                <asp:RadioButtonList ID="genderRadio" runat="server" RepeatDirection="Horizontal"
                                    Width="60%">
                                </asp:RadioButtonList>
                                <asp:Label ID="MsgGender" runat="server" Text=""></asp:Label></td>
                            <td>
                                ���� <span class="redstar">*</span></td>
                            <td>
                                <asp:DropDownList ID="ddlCountryNationality" runat="server" Width="62%">
                                </asp:DropDownList>
                                <asp:Label ID="MsgCountryNationality" runat="server" CssClass="psword_f"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Ա������&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:DropDownList ID="ddlEmployeeType" runat="server" Width="62%">
                                </asp:DropDownList>
                                <asp:Label ID="MsgEmployeeType" runat="server" CssClass="psword_f"></asp:Label>
                            </td>
                            <td>
                                Ӣ����</td>
                            <td>
                                <asp:TextBox ID="txtEngName" runat="server" size="28" Width="60%" CssClass="input1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ����&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:TextBox ID="txtNativePlace" runat="server" CssClass="input1" Width="60%" size="28"></asp:TextBox><asp:Label
                                    ID="MsgNativePlace" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                ��������&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBirthday"
                                    Format="yyyy-MM-dd">
                                </ajaxToolKit:CalendarExtender>
                                <asp:TextBox ID="txtBirthday" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox><asp:Label
                                    ID="MsgBirthday" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ������ò</td>
                            <td>
                                <asp:DropDownList ID="ddlPolictial" runat="server" Width="62%">
                                </asp:DropDownList><asp:Label ID="MsgPolitical" runat="server" Text=""></asp:Label></td>
                            <td>
                                ����&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:TextBox ID="txtNationality" Width="60%" runat="server" size="28" CssClass="input1"></asp:TextBox><asp:Label
                                    ID="MsgNationality" runat="server" CssClass="psword_f"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ����״��&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:DropDownList ID="ddlMarital" runat="server" Width="62%">
                                </asp:DropDownList><asp:Label ID="MsgMarital" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                ����״��&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtPhysical" Width="60%" runat="server" CssClass="input1"></asp:TextBox><asp:Label
                                    ID="MsgPhysical" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ���(cm)&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtHeight" Width="60%" CssClass="input1" size="28" runat="server"></asp:TextBox><asp:Label
                                    ID="MsgHeight" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                ����(kg)&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtWeight" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox><asp:Label
                                    ID="MsgWeight" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ֤������&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:TextBox ID="txtIDNo" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox><asp:Label
                                    ID="MsgIDNo" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                ֤����Ч��</td>
                            <td>
                                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtIDDueDate"
                                    Format="yyyy-MM-dd">
                                </ajaxToolKit:CalendarExtender>
                                <asp:TextBox ID="txtIDDueDate" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox><asp:Label
                                    ID="MsgDueDate" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                ѧУ&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:TextBox ID="txtSchool" runat="server" size="28" CssClass="input1" Width="60%"></asp:TextBox><asp:Label
                                    ID="MsgSchool" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                ��ҵʱ��&nbsp;</td>
                            <td>
                                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGrudateDate"
                                    Format="yyyy-MM-dd">
                                </ajaxToolKit:CalendarExtender>
                                <asp:TextBox ID="txtGrudateDate" Width="60%" runat="server" CssClass="input1" size="28"></asp:TextBox>
                                <asp:Label ID="MsgGrudateDate" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                �Ļ��̶�&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:DropDownList ID="ddlEdu" runat="server" Width="62%">
                                </asp:DropDownList><asp:Label ID="MsgEdu" runat="server" CssClass="psword_f"></asp:Label></td>
                            <td>
                                רҵ&nbsp;<span class="redstar">*</span></td>
                            <td>
                                <asp:TextBox ID="txtMajor" Width="60%" runat="server" CssClass="input1" size="28"></asp:TextBox><asp:Label
                                    ID="MsgMajor" runat="server" CssClass="psword_f"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <ajaxToolKit:ModalPopupExtender ID="mpePhoto" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlUpdatePhoto" TargetControlID="btnPhotoHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnPhotoHidden" runat="Server" Style="display: none" />
        <div id="divMPEPhoto">
            <asp:Panel ID="pnlUpdatePhoto" runat="server" CssClass="modalBox" Width="400px">
                <div style="white-space: nowrap; text-align: center;">
                    <div class="leftitbor" id="tbResultMessage" runat="server">
                        <span class="fontred">
                            <asp:Label ID="lbResultMessage" runat="server"></asp:Label></div>
                    <div class="leftitbor2">
                        �ϴ�ͼƬ</div>
                    <div class="edittable2">
                        <table width="100%" cellpadding="10" cellspacing="0">
                            <tr>
                                <td align="middle">
                                    <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
                                        <tr>
                                            <td align="left" style="width: 3%">
                                            </td>
                                            <td width="80%" align="left">
                                                <asp:FileUpload ID="UpPhoto" name="UpPhoto" CssClass="fileupload" runat="server" Width="300px" onkeydown="event.returnValue=false;"
                                                    onpaste="return false" /></td>
                                            <td width="17px" align="left">
                                                <asp:Button ID="btnAdd" name="btnAdd" runat="server" Text="�ϴ�" OnClick="btnAdd_Click"
                                                    CssClass="inputbt4"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 3%">
                                            </td>
                                            <td width="80%" align="left" colspan="2">
                                                ����ͼƬ��С��500k����&nbsp;������280��200</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebt">
                        <asp:Button Text="�ء���" ID="btnCancel" OnClick="btnClose_Click" OnClientClick="return CloseModalPopupExtender('divMPEPhoto');"
                            runat="server" CssClass="inputbt" />
                    </div>
                    <%--<uc1:UpdateEmployeePhoto ID="UpdateEmployeePhoto1" runat="server" />--%>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
