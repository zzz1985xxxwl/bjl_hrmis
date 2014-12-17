<%@ Import namespace="SEP.HRMIS.Model.OverWork"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CancelOverWorkItemView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.CancelOverWorkItemView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

            <div id="divResultMessage" runat="server" class="leftitbor" style="display:none; ">
                  <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
            </div>
            <div class="leftitbor2">
             <asp:Label ID="lbOperationType" runat="server"></asp:Label>
              <asp:HiddenField ID="hfEmployeeID" runat="server" />
             </div>
            <%--<div id="tbPositionView" runat="server" class="linetabledivbg">
                                    <table width="100%" height="56" border="0" cellpadding="0"  style="border-collapse:separate;" cellspacing="10">--%>
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
                                                加班时间段</td>
                                            <td align="left" style="width: 39%">
                                                <strong>
                                                    <asp:Label ID="lbDate" runat="server"></asp:Label></strong></td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left">
                                                加班项目&nbsp;<span class="redstar">*</span></td>
                                            <td align="left"> 
                                                    <asp:TextBox ID="txtOutLoacation" runat="server" CssClass="grayborder"></asp:TextBox></td>
                                            <td align="left">
                                                加班时间</td>
                                            <td align="left">
                                                <strong>
                                                    <asp:Label ID="lbCostTime" runat="server"></asp:Label></strong>
                                                    <asp:Label ID="lbAdjustRest" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left" valign="top">
                                                加班理由&nbsp;<span class="redstar">*</span></td>
                                            <td align="left" colspan="3" valign="top">
                                                <asp:TextBox runat="server" ID="tbReason" CssClass="grayborder" Height="70px" TextMode="MultiLine"
                                                    Width="85%"></asp:TextBox>
                                              </td>
                                        </tr>
                                         <tr>
                                            <td align="right">
                                            </td>
                                            <td align="left" colspan="6" valign="top">                            
                                             <asp:GridView GridLines="None" Width="100%" ID="gvOverWork" runat="server"
                                                                AutoGenerateColumns="false" CssClass="linetable"  OnRowDataBound="gvItemList_RowDataBound">
                                                                <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                                                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                                                <AlternatingRowStyle CssClass="table_g" />
                                                                <Columns>
                                                                     <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                                                                                        runat="server" Text="" Style="display: none;" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="2%" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="编号">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chbId" runat="server" Text='<%# Eval("ItemID") %>'/>
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
                                                                            <asp:TemplateField HeaderText="">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="bb" runat="server" Text=" ～"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="1%" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="结束时间">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="tbEnd" runat="server" Text='<%# Eval("ToDate")%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="14%" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="加班小时">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="txtCostTime" runat="server" Text='<%# Eval("CostTime")%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="7%" HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="加班类型">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbOverWorkType" runat="server" Text='<%# OverWorkUtility.GetOverWorkTypeName((OverWorkType)Eval("OverWorkType"))%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="tbStatusID" Visible ="false" runat="server" Text='<%# Eval("Status.Id")%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="0%" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="状态">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="tbStatusName" runat="server" Text='<%# Eval("Status.Name")%>'>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="8%" />
                                                                            </asp:TemplateField>
                                                                           <asp:TemplateField HeaderText="调休">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlAdjust" runat="server"  Enabled ='<%# Eval("CanChangeAdjust").ToString()=="True" %>' >
                                                                                    <asp:ListItem>是</asp:ListItem>
                                                                                    <asp:ListItem>否</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="5%" />
                                                                          </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="换休小时" >
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtAdjustHour" runat="server" Text='<%# Eval("AdjustHour")%>' Enabled='<%# Eval("CanChangeAdjust").ToString()=="True" %>'  Width="94%" CssClass="grayborder"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="7%" />
                                                                          </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="操作">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100%" CssClass="fromhour">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="10%" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="理由">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtRemark" Text='' runat="server" Rows="1" Width="94%" CssClass="grayborder"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="16%" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                            </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                       </div>
            <div class="tablebt">
                                    <asp:Button ID="BtnOK" OnClick="BtnOK_Click" Text="确  定"  runat="server" class="inputbt" />
                                    <asp:Button ID="BtnCancel" OnClick="BtnCancel_Click" Text="取  消" runat="server" class="inputbt" />
                       </div>
         <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>