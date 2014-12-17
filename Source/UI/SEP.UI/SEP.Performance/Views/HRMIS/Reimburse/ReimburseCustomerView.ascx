<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimburseCustomerView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseCustomerView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    $(function () {
        $(".customerinfo").autocomplete("../../../Pages/HRMIS/ReimbursePages/GoogleDownBackCode.aspx");
    })

      
</script>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    �������ͻ�ά��
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
</div>
<%--<div class="linetabledivbg">
 <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="8px" align="right" style="height: 24px">
            </td>
            <td width="8%" align="left" style="height: 24px">
                ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td width="10%" align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtID" CssClass="input1" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td width="10%" align="left" style="height: 24px">
            </td>
            <td width="8%" align="left" style="height: 24px">
                ����ʱ��
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="dtpApplyDate" CssClass="input1" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtDepartment" CssClass="input1" ReadOnly="True"></asp:TextBox>
            </td>
            <td width="10%" align="left" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ��&nbsp;&nbsp;��&nbsp;&nbsp;��
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="txtApplierName" CssClass="input1" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="8px" align="right" style="height: 24px">
            </td>
            <td width="8%" align="left" style="height: 24px">
                ��������
            </td>
            <td width="10%" align="left" style="height: 24px">
                <asp:DropDownList ID="ddlReimburseCategories" runat="server" Width="150px" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td width="10%" align="left" style="height: 24px">
            </td>
            <td width="8%" align="left" style="height: 24px">
                ��������<span class="redstar">*</span>
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="txtPaperCount" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr id="trDestinations" runat="server">
            <td width="8px" align="right" style="height: 24px">
            </td>
            <td width="10%" align="left" style="height: 24px">
                ����ص�<span class="redstar">*</span>
            </td>
            <td width="10%" align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtDestinations" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
            <td width="10%" align="left" style="height: 24px">
            </td>
            <td width="8%" align="left" style="height: 24px">
                ��������
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="txtOutCityDays" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr id="trProject" runat="server">
            <td width="8px" align="right" style="height: 24px">
            </td>
            <td width="10%" align="left" style="height: 24px">
                ������Ŀ<span class="redstar">*</span>
            </td>
            <td width="8%" align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtProject" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
            <td width="10%" align="left" style="height: 24px">
                &nbsp;
            </td>
            <td align="left">
                �����
            </td>
            <td align="left" colspan="2">
                <asp:TextBox runat="server" ID="txtOutCityAllowance" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr id="trremark" runat="server" visible="false">
            <td>
            </td>
            <td align="left" style="height: 24px">
                ��ע
            </td>
            <td align="left" colspan="5">
                <asp:TextBox runat="server" ID="txtRemak" TextMode="MultiLine" Height="40px" Width="500px"
                    CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px; width: 2%;">
            </td>
            <td align="left" style="height: 24px" width="10%">
                <asp:Label ID="lblTimeName" runat="server"></asp:Label>&nbsp;&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left" colspan="5" style="height: 24px">
                <asp:TextBox runat="server" ID="dtpConsumeDateFrom" CssClass="input1" Width="150px"></asp:TextBox>��
                <asp:TextBox runat="server" ID="dtpConsumeDateTo" CssClass="input1" Width="150px"></asp:TextBox>
            </td>
            <td align="right">
                &nbsp;&nbsp;<strong>�����ܶ</strong>��<asp:Label ID="lblTotalCost" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="20px" align="right">
            </td>
            <td align="left" colspan="7" valign="top">
                <div id="tbReimburseItem" runat="server" class="linetable">
                    <asp:GridView GridLines="None" Width="100%" ID="gvReimburseItem" runat="server" AutoGenerateColumns="false"
                        OnPageIndexChanging="gvReimburseItem_PageIndexChanging" OnRowDataBound="gvReimburseItem_RowDataBound">
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                        <RowStyle Height="28px" CssClass="GridViewRowLink" />
                        <AlternatingRowStyle CssClass="table_g" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("HashCode")  %>' CommandName="HiddenPostButtonCommand"
                                        runat="server" Text="" Style="display: none;" />
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�������">
                                <ItemTemplate>
                                    <%#ReimburseItem.GetReimburseTypeNameByReimburseType((ReimburseTypeEnum)Eval("ReimburseTypeEnum"))%>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���ѵص�">
                                <ItemTemplate>
                                    <%# Eval("ConsumePlace")%>
                                </ItemTemplate>
                                <ItemStyle Width="16%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�ͻ�����">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCustomerInfo" runat="server" CssClass="grayborder customerinfo"
                                        Style="width: 95%"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="26%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����">
                                <ItemTemplate>
                                    <%# Eval("Reason")%>
                                </ItemTemplate>
                                <ItemStyle Width="26%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���">
                                <ItemTemplate>
                                    <%#Eval("TotalCost")%>(<%#Eval("ExchangeRateName")%>)
                                </ItemTemplate>
                                <ItemStyle Width="11%" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="pages">
                                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="btnOK" runat="server" class="inputbt" OnClick="btnOK_Click" />
    <asp:Button Text="ȡ����" ID="btnCancel" runat="server" class="inputbt" OnClick="btnCancel_Click" />
</div>
