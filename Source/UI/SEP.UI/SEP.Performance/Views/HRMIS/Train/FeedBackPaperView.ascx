<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackPaperView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.FeedBackPaperView" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>

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
            <table width="100%" height="56px" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%> 
<div  class="edittable">
  <table width="100%" border="0">
                <tr>
                    <td width="2%" align="right">
                    </td>
                    <td align="left" style="width: 10%">
                        ����&nbsp;<span class="redstar">*</span></td>
                    <td align="left" colspan="3">
                        <asp:TextBox runat="server" ID="txtPaperName" CssClass="input1"></asp:TextBox>&nbsp;
                        <asp:Label runat="server" ID="lblValidateName" CssClass="psword_f"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="2%" align="right">
                    </td>
                    <td align="left" colspan="5" valign="top">
     
        <div id="divFeedBackPaperItem" runat="server" class="linetablediv">
                                    <asp:GridView GridLines="None" Width="100%" ID="gvFeedBackPaperItemList" runat="server"
                                        AutoGenerateColumns="false" OnRowDataBound="gvFeedBackPaperList_RowDataBound">
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
                                            <asp:TemplateField HeaderText="���">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server">
                                                                <%# Eval("FBQuestioniD").ToString() != "-1" ? Eval("FBQuestioniD").ToString() : "*"%>
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="5%" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="��������">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFBQuestion" runat="server" Width="60%" OnSelectedIndexChanged="ddlFBQuestion_Changed"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="65%" />
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
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                   
                    </td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button Text="ȷ  ��" ID="btnOK" OnClientClick="AbortxmlHttp();" runat="server"
                class="inputbt" OnClick="btnOK_Click" />
            <asp:Button Text="ȡ����" ID="btnCancel" runat="server" class="inputbt" OnClick="btnCancel_Click" />
            <asp:Button Text="������" ID="btnCopy" runat="server" class="inputbt" OnClick="btnCopy_Click" />
            <asp:Button Text="ճ����" ID="btnPaste" runat="server" class="inputbt" OnClick="btnPaste_Click"
                OnClientClick="Confirmed = confirm('�˲����Ḳ�ǵ�ǰ�����ʾ���Ϣ��ȷ��Ҫճ����'); return Confirmed;" />
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>