<%@ Import Namespace="AdvancedCondition.Enums" %>
<%@ Import Namespace="AdvancedCondition" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetSearchConditionView.ascx.cs"
    Inherits="SEP.Performance.Views.SetSearchConditionView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"
    charset="gb2312"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery.DownTableSelected.js"
    charset="gb2312"></script>
<link href="../../CSS/jquery.DownTableSelected.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    function showdescription(strID) {
        strID = "Item" + strID;
        var currtr = document.getElementById(strID);
        for (i = 0; i < document.all.length; i++) {
            if (document.all(i).tagName.toUpperCase() == "DIV"
        && document.all(i).id != ""
        && document.all(i).id.substring(0, 4) == "Item"
        && document.all(i).id != strID) {
                document.all(i).style.display = "none";
            }
        }
        if (currtr == null) {
            return;
        }
        if (currtr.style.display == "none") {
            currtr.style.display = "inline"; //展开
        }
        else {
            currtr.style.display = "none"; //收缩
        }
    }

    function btntxtSearchFieldChangeClick(th) {
        $(th).next().val($(th).val());
        $(th).next().trigger("click");
    }
    function getSearchConditionTableValue() {
        var s = "";
        $(".SearchConditionTable tr:has(td)").each(function () {
            $(this).find("td").each(function () {
                if ($(this).find(".SearchFieldInfo").length != 0) {
                    s += $(this).find(".SearchFieldInfo").val() + "&";
                }
                if ($(this).find(".CompareTypeInfo").length != 0) {
                    s += $(this).find(".CompareTypeInfo").val() + "&";
                }
                if ($(this).find(".ExpressionValueInfo").length != 0) {
                    s += $(this).find(".ExpressionValueInfo").val() + "&";
                }
                if ($(this).find(".IsInvertInfo").length != 0) {
                    s += $(this).find("input[type='checkbox']").attr("checked") + "&";
                }
                if ($(this).find(".CollectedTypeInfo").length != 0) {
                    s += $(this).find(".CollectedTypeInfo").val() + "&";
                }
            })
            s += "|";
        });
        return s;
    }
</script>
<div class="marginepx">
    <div class="edittable5">
        <span style="float: left;">设置查询条件</span>
        <img style="float: right; margin-top: 9px; cursor: hand;" src="../../image/shid1.gif"
            id="hiddenSetSearchCondition" onmouseover="AddClass(this,'AdvanceViewButtonAlter');"
            onmouseout="RemoveClass(this,'AdvanceViewButtonAlter');" class="showsetdiv" onclick="ShowOrHideForm('divSetSearchCondition','showSetSearchCondition','hiddenSetSearchCondition',0)" />
        <img style="float: right; margin-top: 9px; cursor: hand;" src="../../image/shid2.gif"
            id="showSetSearchCondition" onmouseover="AddClass(this,'AdvanceViewButtonAlter');"
            onmouseout="RemoveClass(this,'AdvanceViewButtonAlter');" class="hiddensetdiv"
            onclick="ShowOrHideForm('divSetSearchCondition','showSetSearchCondition','hiddenSetSearchCondition',1)" />
        <div style="clear: both;">
        </div>
    </div>
    <div id="divSetSearchCondition">
        <div class="edittable4">
            <table id="tbSearchConditionList" runat="server" width="100%" class="linetable">
                <tr>
                    <td>
                        <asp:GridView GridLines="None" Width="100%" ID="gvSearchConditionList" runat="server"
                            AutoGenerateColumns="false" OnRowDataBound="gvSearchConditionList_RowDataBound"
                            CssClass="SearchConditionTable">
                            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                            <RowStyle Height="28px" CssClass="GridViewRowLink" />
                            <AlternatingRowStyle CssClass="table_g" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                                            runat="server" Text="" Style="display: none;" />
                                    </ItemTemplate>
                                    <ItemStyle Width="0%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Eval("FieldParaBase.Id").ToString()=="-1"? "*":""%>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="条件字段">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSearchField" runat="server" CssClass="input1 SearchFieldInfo"
                                            Width="88%" Text='<%# Eval("FieldParaBase.FieldName") %>' AutoPostBack="true"
                                            OnTextChanged="txtSearchField_TextChanged"></asp:TextBox>
                                        <asp:Button ID="btntxtSearchFieldChange" runat="server" Text="Button" Style="display: none;"
                                            OnClick="btntxtSearchFieldChange_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="字段类型">
                                    <ItemTemplate>
                                        <%# Eval("FieldParaBase.Id").ToString() == "-1" ? "" : Utility.GetEnumFieldTypeName((EnumFieldType)Eval("ConditionField.EnumFieldType"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div onclick="javascript:showdescription('<%# Eval("FieldParaBase.Id")%>');">
                                            <img src="../Pages/image/icon02.gif" id="imgResult" runat="server" visible='<%# Eval("FieldParaBase.Id").ToString()!="-1"%>'
                                                onmouseover="AddClass(this,'hand');" onmouseout="RemoveClass(this,'hand');" />
                                        </div>
                                        <div id="<%# "Item"+Eval("FieldParaBase.Id")%>" style="display: none; background-color: #FFFFFF;
                                            z-index: 10; position: absolute;">
                                            <table width="450px" class="linetable_3" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="28" class="tdbg02bg">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="8%" height="23" align="center">
                                                                    <img src="../../image/icon04.jpg" />
                                                                </td>
                                                                <td width="84%" align="left">
                                                                    <strong style="color: #FFFFFF">
                                                                        <%# Utility.GetEnumFieldTypeName((EnumFieldType)Eval("ConditionField.EnumFieldType"))%>类型
                                                                        详细说明</strong>
                                                                </td>
                                                                <td width="8%" align="center">
                                                                    <img src="../../image/xxx.jpg" border="0" onclick="javascript:showdescription('<%# Eval("FieldParaBase.Id")%>');"
                                                                        onmouseover="AddClass(this,'hand');" onmouseout="RemoveClass(this,'hand');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                            <tr>
                                                                <td height="100" align="center" valign="top">
                                                                    <table width="98%" height="93" border="0" cellpadding="5" style="border-collapse: separate;"
                                                                        cellspacing="6">
                                                                        <tr>
                                                                            <td width="97%" class="fonttable_2" align="left" valign="top" height="100">
                                                                                <%# Eval("ConditionField.Description")%>
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
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="比较方式">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCompareType" CssClass="CompareTypeInfo" runat="server" Width="95%"
                                            Visible='<%# Eval("FieldParaBase.Id").ToString()!="-1"%>'>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Width="13%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="比较值">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtExpression" runat="server" CssClass="input1 ExpressionValueInfo"
                                            Width="95%" Text='<%# Eval("ConditionField.ConditionExpression") %>' Visible='<%# Eval("FieldParaBase.Id").ToString()!="-1"%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="36%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="取反">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbIsInvert" runat="server" CssClass="IsInvertInfo" Checked='<%# Eval("ConditionField.IsInvert") %>'
                                            Visible='<%# Eval("FieldParaBase.Id").ToString()!="-1"%>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="组合方式">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlCollectedType" CssClass="CollectedTypeInfo" runat="server"
                                            Width="95%" Visible='<%# Eval("FieldParaBase.Id").ToString()!="-1"%>'>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
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
                        <img src="../../image/add.gif" id="imgHide" style="display: none" onload="BindGoogleDownSearchField();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
