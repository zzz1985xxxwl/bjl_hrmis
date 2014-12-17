<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeWelfareSearchList.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeWelfares.EmployeeWelfareSearchList" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc2" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
     <script type="text/javascript" language="javascript">
     function InportClick()
     {
         if($(".fileuploaddiv").css("display")=="none")
         {$(".fileuploaddiv").show();}
         else{$(".fileuploaddiv").hide();}
     }
     
     </script>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
查询员工
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                职位
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%" Height="24px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工类型
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                部门
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList><asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="包括子部门" />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工状态
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="在职" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="离职" Value="1"></asp:ListItem>
                </asp:DropDownList></td>
            </td>
            <td align="left" style="width: 8%;">
                所属公司
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="40%"></asp:DropDownList>
            </td>
        </tr>        
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
     <asp:Button ID="btnSave" runat="server" Text="保  存" OnClick="btnSave_Click" CssClass="inputbt" />
      <asp:Button ID="btnExport" runat="server" Text="导  出" OnClick="btnExport_Click" CssClass="inputbt" />
      <input id="btnInport" type="button" class="inputbt showbtnIn" onclick="InportClick();"  value="导  入"/>
</div>
<div class="edittable fileuploaddiv" style="text-align:left;display:none;">
  <asp:FileUpload ID="fuExcel" runat="server" onkeydown="event.returnValue=false;"
onpaste="return false" CssClass="fileupload" />
<asp:Button ID="btnIn" runat="server" Text="确　定" CssClass="inputbt" OnClick="btnInport_Click" />
</div>
<div class="nolinetablediv">
 <asp:GridView ID="gvEmployeeWelfare" Width="100%" runat="server" AutoGenerateColumns="False" PageSize="15"
                        AllowPaging="True" OnPageIndexChanging="gvEmployeeWelfare_PageIndexChanging" CssClass="linetable"
                        GridLines="None"  OnRowDataBound="gvEmployeeWelfare_RowDataBound">
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                        <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                        <AlternatingRowStyle CssClass="table_g" />
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("EmployeeWelfareID") %>'
                                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="name" runat="server" Text='<%# Eval("Owner.Name") %>' ></asp:Label>                    
                                </ItemTemplate>
                                <ItemStyle  Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="社保类型">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddSocialSecurityType"  Width="95%"  runat="server"></asp:DropDownList>                            
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="社保基数">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSocialSecurityBase" Text=' <%#Eval("SocialSecurity.BaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="生效年月">
                                <ItemTemplate>
                                      <asp:TextBox ID="txtSocialSecurityYear" runat="server"  Width="45%" CssClass="input1"> </asp:TextBox> -
                                      <asp:TextBox ID="txtSocialSecurityMonth" runat="server" Width="20%"   CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公积金帐号">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtAccumulationFundAccount"   Width="85%" Text='<%#Eval("AccumulationFund.Account")%>' runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公积金基数"> 
                                <ItemTemplate>
                                     <asp:TextBox ID="txtAccumulationFundBase" Width="85%"  Text='<%#Eval("AccumulationFund.BaseTemp")%>'  runat="server" CssClass="input1"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="8%"/>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="生效年月">
                                <ItemTemplate>
                                        <asp:TextBox ID="txtAccumulationFundYear" runat="server"  Width="45%" CssClass="input1"> </asp:TextBox> -
                                         <asp:TextBox ID="txtAccumulationFundMonth" runat="server"  Width="20%" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%"/>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="补充公积金帐号">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSupplyAccount" Width="85%"  Text='<%#Eval("AccumulationFund.SupplyAccount")%>'  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="9%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="补充公积金基数">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSupplyBase" Width="85%"  Text='<%#Eval("AccumulationFund.SupplyBase")%>'  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="养老缴费基数">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtYangLaoBase" Text=' <%#Eval("SocialSecurity.YangLaoBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="失业缴费基数">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtShiYeBase" Text=' <%#Eval("SocialSecurity.ShiYeBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="医疗缴费基数">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtYiLiaoBase" Text=' <%#Eval("SocialSecurity.YiLiaoBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                        </Columns>
                <PagerTemplate>
<%--	<div class="pages">
	    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
	    上一页</asp:LinkButton>
	    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
	    下一页</asp:LinkButton>
	</div>         --%>      
<uc2:PageTemplate ID="PageTemplate1" runat="server" />	           
                </PagerTemplate>
</asp:GridView>
</div>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server" />         
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
     <Triggers>
         <asp:PostBackTrigger ControlID="btnExport" />
         <asp:PostBackTrigger ControlID="btnIn" />
     </Triggers>
</asp:UpdatePanel>

