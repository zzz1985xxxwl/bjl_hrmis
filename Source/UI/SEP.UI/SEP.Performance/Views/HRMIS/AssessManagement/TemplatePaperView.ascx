<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TemplatePaperView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessManagement.TemplatePaperView" %>
<%@ Register Src="ChosePositionView.ascx" TagName="ChosePositionView" TagPrefix="uc2" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>

<script type="text/javascript">
function btnChoosePositionClick()
{
   $(".btnChoosePositionHiddencss").trigger("click");
}
</script>

<script type="text/javascript" src="../../../../Pages/Inc/JsAjax.js"></script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="tbMessage" runat="server" class="leftitbor">
            <asp:Label ID="lblResultMessage" runat="server" CssClass="fontred"></asp:Label>
        </div>
        <div class="leftitbor2">
            <asp:Label ID="lblOperationInfo" runat="server"></asp:Label>
            <asp:HiddenField ID="lblOperation" runat="server" />
        </div>
        <%--<div id="tbAssessPaperView" runat="server" class="linetabledivbg">
            <table width="100%" height="56px" border="0" cellpadding="0" cellspacing="10">--%> 
<div  class="edittable">
  <table width="100%" border="0">
                <tr>
                    <td width="2%" align="right">
                    </td>
                    <td align="left" style="width: 12%">
                        名称&nbsp;<span class="redstar">*</span></td>
                    <td align="left" colspan="3">
                        <asp:TextBox runat="server" ID="txtPaperName" Width="500px"   CssClass="input1"></asp:TextBox>&nbsp;
                        <asp:Label runat="server" ID="lblValidateName" CssClass="psword_f"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td width="2%" align="right">
                    </td>
                    <td align="left" style="width: 12%">
                        年终考评绑定职位</td>
                    <td align="left" colspan="3">
                        <asp:TextBox runat="server" ID="txtPosition" TextMode="MultiLine" Height="50px" CssClass="input1" Width="500px" onfocus="btnChoosePositionClick();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="2%" align="right">
                    </td>
                    <td align="left" colspan="5" valign="top">
     
        <div id="divAssessPaperItem" runat="server" class="linetablediv">
                                    <asp:GridView GridLines="None" Width="100%" ID="gvAssessPaperItemList" runat="server"
                                        AutoGenerateColumns="false" OnRowDataBound="gvAssessPaperItemList_RowDataBound">
                                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                        <RowStyle Height="28px" CssClass="GridViewRowLink" />
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
                                                    <asp:Label ID="lbl" runat="server"  >
                                                                <%# Eval("AssessTemplateItemID").ToString() != "-1" ? Eval("AssessTemplateItemID").ToString() : "*"%>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="绩效考核项">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlAssessItem" runat="server" Width="100%" OnSelectedIndexChanged="ddlAssessItem_Changed"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="50%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="题型">
                                                <ItemTemplate>
                                                    <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessTemplateItemTypeToString((AssessTemplateItemType)Eval("AssessTemplateItemType")) : ""%>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="分类">
                                                <ItemTemplate>
                                                    <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessUtility.ClassficationToString((ItemClassficationEmnu)Eval("Classfication")) : ""%>
                                                </ItemTemplate>
                                                <ItemStyle Width="5%"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="人力资源项">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chbType" Enabled="false" runat="server" Checked='<%# Eval("AssessTemplateItemID").ToString() != "-1" ? ConvertToBoolIsHr((OperateType)Eval("ItsOperateType")) : false%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="left" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="权重">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtWeight" runat="server" Text='<%# Eval("Weight")%>' Width="40px" CssClass="input1"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%"  />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbUpItem" runat="server" OnCommand="lbUpItem_Command" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDownItem" runat="server" OnCommand="lbDownItem_Command" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" />
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                   
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button Text="确  定" ID="btnOK" OnClientClick="AbortxmlHttp();" runat="server"
                class="inputbt" OnClick="btnOK_Click" />
            <asp:Button Text="取　消" ID="btnCancel" runat="server" class="inputbt" OnClick="btnCancel_Click" />
            <asp:Button Text="复　制" ID="btnCopy" runat="server" class="inputbt" OnClick="btnCopy_Click" />
            <asp:Button Text="粘　贴" ID="btnPaste" runat="server" class="inputbt" OnClick="btnPaste_Click"
                OnClientClick="Confirmed = confirm('此操作会覆盖当前绩效考核表信息，确定要粘贴吗？'); return Confirmed;" />
        </div>
        
          <ajaxToolKit:ModalPopupExtender ID="mpeChoosePosition" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlChoosePosition" TargetControlID="btnChoosePositionHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnChoosePositionHidden" CssClass="btnChoosePositionHiddencss" runat="Server" Style="display: none" />
        <div id="divMPEReimburse" runat="server">
            <asp:Panel ID="pnlChoosePosition" runat="server" CssClass="modalBox" Style="display: none;"
                Width="500px">
                <div style="white-space: nowrap; text-align: center;">
                     <uc2:ChosePositionView ID="ChosePositionView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
     
    </ContentTemplate>
</asp:UpdatePanel>
