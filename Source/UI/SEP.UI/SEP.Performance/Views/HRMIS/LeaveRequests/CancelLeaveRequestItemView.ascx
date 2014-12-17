<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CancelLeaveRequestItemView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.CancelLeaveRequestItemView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>
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
            <div id="divResultMessage" runat="server" class="leftitbor">
                <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
            </div>
            <div class="leftitbor2">
                <asp:Label ID="lbOperationType" runat="server"></asp:Label>
                <asp:HiddenField ID="hfEmployeeID" runat="server" />
                <asp:HiddenField ID="hfOperatorID" runat="server" />
                <asp:Label ID="lbID" runat="server" Text="#" Style="display: none;"></asp:Label>
            </div>
            <%--<div id="tbPositionView" runat="server" class="linetabledivbg">
                <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
            <div class="edittable">
                <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td align="left" style="width: 10%;">
                            员工姓名</td>
                        <td align="left" style="width: 39%">
                            <strong>
                                <asp:Label ID="lbEmployeeName" runat="server"></asp:Label></strong></td>
                        <td align="left" style="width: 10%;">
                            请假时间段</td>
                        <td align="left" style="width: 39%">
                            <strong>
                                <asp:Label ID="lbDate" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            请假类型&nbsp;<span class="redstar">*</span></td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAbsentType" runat="server" Width="160px" AutoPostBack="True">
                            </asp:DropDownList>
                            <a href="javascript:showdescription('lblTypeDescription');">
                                <img src="../../image/icon01.gif" align="absmiddle" border="0" /></a>
                            <div id="ItemlblTypeDescription" style="display: none; background-color: #FFFFFF;
                                z-index: 10; position: absolute;">
                                <table onclick="javascript:IsNextExecute = false;" width="450px" class="linetable_3"
                                     cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td height="28" class="tdbg02bg">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="8%" height="23" align="center">
                                                        <img src="../../image/icon04.jpg" /></td>
                                                    <td width="84%" align="left">
                                                        <strong style="color: #FFFFFF">
                                                            <asp:Label ID="lblTypeTitle" runat="server" />详细说明</strong></td>
                                                    <td width="8%" align="center">
                                                        <a href="javascript:showdescription('lblTypeDescription');">
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
                                                        <table width="98%" height="100" border="0" cellpadding="5" style="border-collapse:separate;" cellspacing="6">
                                                            <tr>
                                                                <td width="97%" class="fonttable_2" align="left" valign="top" height="100">
                                                                    <asp:Label ID="lblTypeDescription" runat="server" />
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
                            <asp:Label ID="lbTypeMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                        <td align="left">
                            请假时间</td>
                        <td align="left">
                            <asp:Label ID="lbCostTime" runat="server" Style="font-weight: bold; margin-right: 6px;"></asp:Label><asp:Label
                                ID="lbAnnualLeave" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trRule" runat="server" style="display: none;">
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                        <td align="left" colspan="3">
                            注：你目前的工作时间为
                            <asp:Label ID="lblMorningRule" runat="server"></asp:Label>，
                            <asp:Label ID="lblAfternoonTimeRule" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" valign="top">
                            请假理由&nbsp;<span class="redstar">*</span></td>
                        <td align="left" colspan="3" valign="top">
                            <asp:TextBox runat="server" ID="tbRemark" CssClass="grayborder" Height="91px" TextMode="MultiLine"
                                Width="558px"></asp:TextBox>
                            <asp:Label ID="lbRemarkMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" colspan="5" valign="top">

                            <div id="tbLeaveRequestItem" runat="server" class="linetable">
                                        <asp:GridView GridLines="None" Width="100%" ID="gvLeaveRequestItemList" runat="server"
                                            AutoGenerateColumns="false" OnRowDataBound="gvLeaveRequestItemList_RowDataBound">
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
                                                <asp:TemplateField HeaderText="编号" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chbId" runat="server" Text='<%# Eval("LeaveRequestItemID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="8%" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="开始时间">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tbStart" runat="server" Text='<%# Eval("FromDate")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="14%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        ～
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="结束时间">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tbEnd" runat="server" Text='<%# Eval("ToDate")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="请假小时">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtCostTime" runat="server" Text='<%# Eval("CostTime")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tbStatusID" Visible="false" runat="server" Text='<%# Eval("Status.Id")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="0%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tbStatusName" runat="server" Text='<%# Eval("Status.Name")%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作">
                                                    <ItemTemplate>
                                                        <%--1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中--%>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100%" CssClass="fromhour">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbIfCancel" runat="server" Text='<%# Eval("IfCancel")%>' Style="display: none;">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="0%" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbIfApprove" runat="server" Text='<%# Eval("IfApprove")%>' Style="display: none;">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="0%" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="备注">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemark" Text=''  CssClass="grayborder" runat="server" Rows="1" Width="94%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="28%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </div>
   
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebt">
                <asp:Button ID="BtnOK" OnClick="BtnOK_Click" runat="server" class="inputbt" />
                <asp:Button ID="BtnSubmit" OnClick="BtnCancel_Click" runat="server" class="inputbt" />
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
