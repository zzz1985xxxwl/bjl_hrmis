<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacationListView.ascx.cs"
    Inherits="SEP.Performance.VacationListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc2" %>
<%@ Register Src="ManageVacationView.ascx" TagName="ManageVacationView" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <triggers>
     <asp:PostBackTrigger ControlID="btnExport" />
 </triggers>
    <contenttemplate>
<div id="count" runat="server" class="leftitbor" >
<span class="font14b">共有</span>
    <asp:Label ID="lbCount" runat="server"  CssClass="fontred"></asp:Label>
<span class="font14b"> 条记录</span>   
</div> 
<div id="Error" runat="server" class="leftitbor">
 <span class="font14b"><asp:Label ID="lblMessage" runat="server"  CssClass="fontred"></asp:Label></span>
</div>
<div class="leftitbor2">
查询员工年假
</div>
 
<div  class="edittable">
  <table width="100%" border="0">
            <tr>
              <td width="1%" ></td>
              <td width="10%" align="left">员工姓名</td>
              <td width="27%" align="left"><asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="150px"></asp:TextBox></td>
              <td width="12%" align="left">年假结束时间</td>
              <td align="left" colspan="2">
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVacationEndDateStart" Format="yyyy-MM-dd">
                  </ajaxToolKit:CalendarExtender>
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtVacationEndDateEnd" Format="yyyy-MM-dd">
                  </ajaxToolKit:CalendarExtender>
              <asp:TextBox ID="txtVacationEndDateStart" runat="server" CssClass="input1" size="17"></asp:TextBox>&nbsp;--&nbsp;<asp:TextBox ID="txtVacationEndDateEnd" runat="server" CssClass="input1" size="17"></asp:TextBox></td>
             </tr>
             <tr>
             <td width="1%" ></td>
               <td align="left">年假总天数</td>
               <td align="left"><asp:TextBox ID="txtVacationDayNumStart" runat="server" CssClass="input1" Width="63px"></asp:TextBox>&nbsp;--&nbsp;<asp:TextBox ID="txtVacationDayNumEnd" runat="server"  CssClass="input1" Width="63px"></asp:TextBox></td>
               <td align="left">剩余天数</td>
               <td width="25%" align="left"><asp:TextBox ID="txtSurplusDayNumStart" runat="server" CssClass="input1"  Width="54px"></asp:TextBox>&nbsp;--&nbsp;<asp:TextBox ID="txtSurplusDayNumEnd"   CssClass="input1" runat="server" Width="54px"></asp:TextBox></td>
               <td width="26%" align="left"></td> 
            </tr>
            <tr>
              <td></td>
             <td align="left" >
                员工状态
            </td>
            <td align="left" colspan="4">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="150px">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="在职" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="离职" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            </table>
</div>  
<div class="tablebt">
           <asp:Button ID="btnSearch" runat="server"  CssClass="inputbt" Text="查 询" OnClick="btnSearch_Click" />
<asp:Button ID="btnExport" runat="server" Text="导　出" OnClick="btnExport_Click" CssClass="inputbt btnExport" />
</div> 
<div id="Result" runat="server"  class="marginepx"> 
       <asp:GridView ID="dvVacationList" runat="server"  CssClass="linetable" AutoGenerateColumns="False"  Width="100%" AllowPaging="True" PageSize="10"  OnPageIndexChanging="dvVacationList_PageIndexChanging"   GridLines="None" OnRowDataBound="dvVacationList_RowDataBound">
           <HeaderStyle Height="28px" CssClass="headerstyleblue"/>
            <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
            <AlternatingRowStyle CssClass="table_g" />
             <Columns>
                    <asp:TemplateField >
       <ItemTemplate>
    <asp:Button ID="btnHiddenPostButton"  CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
   </ItemTemplate>  
   <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="姓名">
                      <ItemTemplate>
                          <%#Eval("Employee.Account.Name")%></a>
                      </ItemTemplate> 
                    </asp:TemplateField> 
                       
                       <asp:TemplateField HeaderText="年假起始日"  HeaderStyle-Width="12%">
                           <ItemTemplate>
                               <%#Eval("VacationStartDate", "{0:yyyy-MM-dd}")%>
                          </ItemTemplate> 
                      </asp:TemplateField>   
                       <asp:TemplateField HeaderText="年假到期日"  HeaderStyle-Width="12%">
                           <ItemTemplate>
                               <%#Eval("VacationEndDate", "{0:yyyy-MM-dd}")%>
                          </ItemTemplate> 
                      </asp:TemplateField>  
                       <asp:BoundField DataField="VacationDayNum" HeaderText="年假总天数" >
                           <ItemStyle />
                           <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>  
                        <asp:BoundField DataField="UsedDayNum" HeaderText="已用天数 " >
                           <ItemStyle  />
                           <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>
                        <asp:BoundField DataField="SurplusDayNum" HeaderText="剩余天数" >
                           <ItemStyle  />
                           <HeaderStyle HorizontalAlign="Center" />
                       </asp:BoundField>   
                        
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("Employee.Account.Id")%>'
                                    OnCommand="btnAdd_Click" Text="新增" ></asp:LinkButton>
                           </ItemTemplate>
                          <ItemStyle  HorizontalAlign="Center" />
                       </asp:TemplateField> 
                       
                        <asp:TemplateField>
                           <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("VacationID")%>' 
                                   OnCommand="btnUpdate_Click" Text="修改" ></asp:LinkButton>
                            </ItemTemplate>
                           <ItemStyle  HorizontalAlign="Center" />
                      </asp:TemplateField>
                      
                      <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("VacationID")%>'
                                    OnCommand="btnDelete_Click" Text="删除"  OnClientClick= "Confirmed = confirm('确定要删除吗？'); return Confirmed;"></asp:LinkButton>
                           </ItemTemplate>
                          <ItemStyle  HorizontalAlign="Center" />
                       </asp:TemplateField>
                                
                   </Columns>          
                   
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>       --%>   
		     <uc2:PageTemplate ID="PageTemplate1" runat="server" />           
                    </PagerTemplate>
        </asp:GridView> 
  </div>
 <ajaxToolKit:ModalPopupExtender id="mpeEdit" runat="server"  BackgroundCssClass="modalBackground" PopupControlID="pnlEdit" 
        TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
      <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
    <div id="divMPEVacation" > 
        <asp:Panel ID="pnlEdit" runat="server" CssClass="modalBox" Style="display: none" Width="670px">
	        <div style="white-space: nowrap; text-align: center;">
            <div class="leftitbor2" >年假</div>
         <uc1:ManageVacationView ID="ManageVacationView1" runat="server" /> 
            <div class="tablebt">
                <asp:Button ID="btnOK" runat="server" Text="确  定" OnClick="btnOK_Click" CssClass="inputbt" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="取  消"   OnClientClick="return CloseModalPopupExtender('divMPEVacation');"  CssClass="inputbt"  />
	        </div>
        </asp:Panel> 
    </div> 
    
  </contenttemplate>
</asp:UpdatePanel>
