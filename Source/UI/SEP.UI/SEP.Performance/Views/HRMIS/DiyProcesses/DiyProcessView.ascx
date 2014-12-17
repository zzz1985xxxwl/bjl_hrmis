<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DiyProcessView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.DiyProcesses.DiyProcessView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<%@ Register Src="../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView" TagPrefix="uc2" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      
<div id="divResultMessage" runat="server"  class="leftitbor">
 <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
 <asp:HiddenField ID="hfRowID" runat="server" />                  
</div>
 <div class="leftitbor2" >
        <asp:Label ID="lbOperationType" runat="server"></asp:Label>
        <asp:Label ID="lbID" runat="server" Text="#" Style="display: none;"></asp:Label>
</div>
<div id="tbPositionView" runat="server" class="edittable">
 <table width="100%" border="0">
    <tr>
        <td align="right" style="width: 8%;">
            名称&nbsp;<span class="redstar">*</span></td>
        <td align="left" style="width: 41%">
            <asp:TextBox runat="server" ID="tbName" CssClass="input1" Width="60%"></asp:TextBox>
            <asp:Label ID="lbNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        <td align="right" style="width: 8%;">
            类型&nbsp;<span class="redstar">*</span></td>
        <td align="left" style="width: 41%">
            <asp:DropDownList ID="ddlType" runat="server" Width="160px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                AutoPostBack="True">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right" valign="top">
            备注&nbsp;&nbsp;</td>
        <td align="left" colspan="3" valign="top">
            <asp:TextBox runat="server" ID="tbRemark" CssClass="grayborder" Height="91px" TextMode="MultiLine"
                Width="558px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="5" valign="top">
                    <div id="tbLeaveRequestItem" runat="server" class="linetable">
                        <asp:GridView GridLines="None" Width="100%" ID="gvDiyStepList" runat="server" AutoGenerateColumns="false"
                            OnRowDataBound="gvDiyStepList_RowDataBound">
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
                                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("DiyStepID").ToString() != "-1" ? Eval("DiyStepID").ToString() : "*"%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlStatus" Enabled='<%# Eval("IfSystem").ToString()=="False" %>' runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作人类型">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlOperatorType" Enabled='<%# Eval("IfSystem").ToString()=="False" %>' runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作人">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlOperatorID" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="发信通知">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMailAccount" Text='<%# Eval("MailAccountShow").ToString()%>' runat="server" CssClass="input1" Width="90%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="22%"/>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command" Enabled='<%# Eval("IfSystem").ToString()=="False" %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbUpItem" runat="server" OnCommand="lbUpItem_Command" Enabled='<%# Eval("IfSystem").ToString()=="False" %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDownItem" runat="server" OnCommand="lbDownItem_Command" Enabled='<%# Eval("IfSystem").ToString()=="False" %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
        </td>
    </tr>
</table>
</div>
<div class="tablebt">                               
    <asp:Button ID="BtnOK" OnClick="BtnOK_Click" runat="server" class="inputbt" Text="确定" />
    <asp:Button ID="btnCancel" OnClick="BtnSubmit_Click" runat="server" class="inputbt" Text="取消" />
</div>                                    
        <ajaxToolKit:ModalPopupExtender ID="mpeChooseEmployee" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlChooseEmployee" TargetControlID="btnChooseEmployeeHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="bthChooseEmployeeShow" OnClick="btnShowChooseEmployee_Click" runat="Server" Style="display: none" />
        <asp:Button ID="btnChooseEmployeeHidden" runat="Server" Style="display: none" />
        <div id="divMPEReimburse" runat="server">
            <asp:Panel ID="pnlChooseEmployee" runat="server" CssClass="modalBox" Style="display: none;"
                Width="700px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server"></uc1:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>

<script type="text/javascript">
function btnChooseMailCCClick(obj)
{
document.getElementById("cphCenter_DiyProcessView1_hfRowID").value=obj;
$("#cphCenter_DiyProcessView1_bthChooseEmployeeShow").trigger("click");
}
</script>