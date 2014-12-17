<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DimissionBasicView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.DimissionInformation.DimissionBasicView" %>
 <table cellpadding="0" cellspacing="0" border="0" width="100%">
  <tr>
    <td align="left">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
    <td align="left">
      <table width="100%" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10" >
            <tr>
	  <td width="2%" align="right" ></td>
             <td style="width: 12%;">离职日期</td>
             <td style="width: 35%;">
                 <asp:TextBox ID="txtStartDate" Width="60%" runat="server" CssClass="input1"></asp:TextBox>
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStartDate">
                 </ajaxToolKit:CalendarExtender>
                 <asp:Label ID="lblDataMessage" runat="server" CssClass = "psword_f"></asp:Label></td>
             <td style="width: 16%;">经济补偿标准</td>
             <td style="width: 35%;">
             <asp:TextBox ID="txtDimissionMonth" Width="55%" runat="server" CssClass="input1"></asp:TextBox>
                  <asp:Label ID="Label1" runat="server" Text="月" Height="20px"></asp:Label>
                 <asp:Label ID="lblMonthMessage" runat="server" CssClass = "psword_f"></asp:Label></td>
            </tr>
            <tr>
	  <td width="2%" align="right" ></td>
             <td>离职类型</td>
             <td colspan="3">
                 <asp:TextBox ID="txtDimissionType" CssClass="input1" Width="82%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
	  <td width="2%" align="right" ></td>
             <td>离职原因</td>
             <td valign="top">
                 <asp:RadioButtonList ID="RBList1" runat="server" OnSelectedIndexChanged="RBList1_SelectedIndexChanged" AutoPostBack="true">
                 </asp:RadioButtonList></td>
                 <td colspan="2">&nbsp;&nbsp;<asp:Label ID="lblReseanTypeMessage" runat="server" CssClass = "psword_f"></asp:Label></td>
            </tr>
            <tr id="trDimissionReason" runat="server">
	  <td width="2%" align="right" ></td>
             <td></td>
             <td colspan="3">
                 <asp:TextBox ID="txtDimissionReason" runat="server" Width="82%" CssClass="input1" size="28" ></asp:TextBox></td>
            </tr>
<%--            <tr>
	  <td width="2%" align="right" ></td>
                <td>
                </td>
                <td colspan="3">
                 <asp:Button ID="btnAddInfo" runat="server" CssClass="inputbt" Text="新增档案" OnClick="btnAddInfo_Click" /></td>
            </tr>--%>
     </table>
        </td>
      </tr>
<%--        <tr>
         <td align="center">
       <table id="tbfileCargo" runat="server" cellpadding="0" cellspacing="0" border="0" width="98%"  visible="false"> 
       <tr>
         <td>&nbsp;</td>
        </tr>
        <tr>
         <td align="left"><span class="font14px">档案信息</span></td>
        </tr>
       <tr>
        <td align="center">
         <table width="100%" class="linetable" cellpadding="0" cellspacing="0">
          <tr>
           <td width="100%">
            <asp:GridView ID="DimissionInfoGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Width="100%" OnPageIndexChanging="DimissionInfoGV_PageIndexChanging"  OnRowDataBound="DimissionInfoGV_RowDataBound1" >
             <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
             <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
             <AlternatingRowStyle CssClass="table_g" />
             <Columns>
              <asp:TemplateField >
　　　　　　　 <ItemTemplate>
　　　　　　　　<asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Name.Name") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
　　　　　　　 </ItemTemplate><ItemStyle Width="2%" />
　　　　　　　</asp:TemplateField>
　　　　　　　  <asp:BoundField DataField="HashCode" HeaderText="Id"  Visible="false">
                     
                        <ItemStyle Width="0%" />
                    </asp:BoundField>
　　　　　　　<asp:TemplateField HeaderText="资料类型" HeaderStyle-Width="25%">
　　　　　　　 <ItemTemplate>　<%# Eval("Name.Name")%> </ItemTemplate>
　　　　　　　  </asp:TemplateField>  
　　　　　　　
              <asp:BoundField DataField="Remark" HeaderText="备注" >
                  <ItemStyle Width="39%" HorizontalAlign="center" />
              </asp:BoundField>
              <asp:TemplateField>
               <ItemTemplate>
                 <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                      CommandName="BtnUpdateClick"  OnCommand="BtnUpdate_Click" Text="修    改" ></asp:LinkButton>
                 </ItemTemplate>
                  <ItemStyle Width="15%" />
              </asp:TemplateField>
              <asp:TemplateField>
               <ItemTemplate>
                 <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                      CommandName="BtnDeleteClick"   OnCommand="BtnDelete_Click" Text="删    除"  OnClientClick= "Confirmed = confirm('确定要删除吗？'); return Confirmed;"></asp:LinkButton>
               </ItemTemplate>
                  <ItemStyle Width="15%" />
              </asp:TemplateField>
             </Columns>
             
                    <PagerTemplate>
		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>                          
                    </PagerTemplate>
             
             
            </asp:GridView>
           </td>
          </tr>
         </table>
        </td>
       </tr>
      </table>
         </td>
        </tr>--%>
        
         <tr>
<td style="height:10px;">
</td></tr>

    </table>
    </td>
  </tr>

</table>
