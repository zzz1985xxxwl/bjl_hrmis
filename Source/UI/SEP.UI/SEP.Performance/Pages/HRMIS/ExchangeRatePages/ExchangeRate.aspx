<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"
    CodeBehind="ExchangeRate.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.ExchangeRatePages.ExchangeRate" %>

<%@ Register Src="../../../Views/PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender ID="mpeInfo" runat="server" Drag="false" BackgroundCssClass="modalBackground"
                PopupControlID="pnlRule" TargetControlID="btnHiddenPostButton">
            </ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <div class="leftitbor">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <div class="leftitbor2">
                设置汇率信息
            </div>
            <div class="edittable">
                <table width="100%" border="0">
                    <tr>
                        <td align="left" style="width: 10%; padding-left: 35px;">
                            币种
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:TextBox ID="txtName" runat="server" Width="150px" class="input1"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 10%; padding-left: 35px;">
                            日期
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:TextBox ID="txtActiveDate" runat="server" Width="150px" class="input1"></asp:TextBox>
                            <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtActiveDate"
                                Format="yyyy-MM">
                            </ajaxToolKit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebt">
                <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
                <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
            </div>
            <div class="nolinetablediv">
                <asp:GridView CssClass="linetable" GridLines="None" Width="100%" ID="gvExchangeRate"
                    runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvExchangeRate_PageIndexChanging"
                    OnRowCommand="gvExchangeRate_RowCommand" OnRowDataBound="gvExchangeRate_RowDataBound">
                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                    <AlternatingRowStyle CssClass="table_g" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                                    runat="server" Text="" Style="display: none;" /></ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="币种">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="汇率">
                            <ItemTemplate>
                                <%#Eval("Rate")%>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日期">
                            <ItemTemplate>
                                <%#Eval("ActiveDate","{0:yyyy-MM}")%>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="符号">
                            <ItemTemplate>
                                <%#Eval("Symbol")%>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                                    CommandArgument='<%# Eval("PKID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                    </PagerTemplate>
                </asp:GridView>
            </div>
            <!--小界面-->
            <div id="divMPE">
                <asp:Panel ID="pnlRule" runat="server" CssClass="modalBox" Style="display: none;"
                    Width="400px">
                    <div style="white-space: nowrap; text-align: center;">
                        <div id="tbMessage" runat="server" class="leftitbor">
                            <asp:Label ID="lblDialogMessage" runat="server" CssClass="fontred"></asp:Label>
                        </div>
                        <div class="leftitbor2">
                            <asp:Label ID="lblOperation" runat="server">  
                            </asp:Label>
                            <asp:HiddenField ID="hfOperation" runat="server" />
                            <asp:HiddenField ID="hfPKID" runat="server" />
                        </div>
                        <div class="edittable">
                            <table width="100%" border="0">
                                <tr>
                                    <td align="left">
                                        币种&nbsp; <span class="redstar" style="padding-right: 10px">*</span>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtDialogName" CssClass="input1"></asp:TextBox>
                                        <asp:Label ID="lblNameMessage" runat="server" CssClass="psword_f"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        日期&nbsp; <span class="redstar" style="padding-right: 10px">*</span>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtDialogActiveDate" CssClass="input1"></asp:TextBox>
                                        <asp:Label ID="lblActiveDateMessage" runat="server" CssClass="psword_f"></asp:Label>
                                        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDialogActiveDate"
                                            Format="yyyy-MM">
                                        </ajaxToolKit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        符号&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtDialogSymbol" CssClass="input1"></asp:TextBox>
                                        <asp:Label ID="lblSymbolMessage" runat="server" CssClass="psword_f"></asp:Label>
                                        <p>
                                            如，￥</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        汇率&nbsp; <span class="redstar" style="padding-right: 10px">*</span>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtDialogRate" CssClass="input1"></asp:TextBox>
                                        <asp:Label ID="lblRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                                        <p>
                                            此处填对人民币的汇率，</p>
                                        <p>
                                            如1美元等于6.14人民币，此处填6.14</p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="tablebt">
                            <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" />
                            <asp:Button Text="取　消" ID="btnCancel" runat="server" CssClass="inputbt" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
