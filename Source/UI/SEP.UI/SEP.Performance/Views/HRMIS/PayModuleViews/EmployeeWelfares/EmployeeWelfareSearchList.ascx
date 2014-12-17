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
��ѯԱ��
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ְλ
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
                Ա������
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                ����
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList><asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="�����Ӳ���" />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա��״̬
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="��ְ" Value="1"></asp:ListItem>
                </asp:DropDownList></td>
            </td>
            <td align="left" style="width: 8%;">
                ������˾
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="40%"></asp:DropDownList>
            </td>
        </tr>        
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
     <asp:Button ID="btnSave" runat="server" Text="��  ��" OnClick="btnSave_Click" CssClass="inputbt" />
      <asp:Button ID="btnExport" runat="server" Text="��  ��" OnClick="btnExport_Click" CssClass="inputbt" />
      <input id="btnInport" type="button" class="inputbt showbtnIn" onclick="InportClick();"  value="��  ��"/>
</div>
<div class="edittable fileuploaddiv" style="text-align:left;display:none;">
  <asp:FileUpload ID="fuExcel" runat="server" onkeydown="event.returnValue=false;"
onpaste="return false" CssClass="fileupload" />
<asp:Button ID="btnIn" runat="server" Text="ȷ����" CssClass="inputbt" OnClick="btnInport_Click" />
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
                              <asp:TemplateField HeaderText="����">
                                <ItemTemplate>
                                    <asp:Label ID="name" runat="server" Text='<%# Eval("Owner.Name") %>' ></asp:Label>                    
                                </ItemTemplate>
                                <ItemStyle  Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�籣����">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddSocialSecurityType"  Width="95%"  runat="server"></asp:DropDownList>                            
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�籣����">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSocialSecurityBase" Text=' <%#Eval("SocialSecurity.BaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��Ч����">
                                <ItemTemplate>
                                      <asp:TextBox ID="txtSocialSecurityYear" runat="server"  Width="45%" CssClass="input1"> </asp:TextBox> -
                                      <asp:TextBox ID="txtSocialSecurityMonth" runat="server" Width="20%"   CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�������ʺ�">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtAccumulationFundAccount"   Width="85%" Text='<%#Eval("AccumulationFund.Account")%>' runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���������"> 
                                <ItemTemplate>
                                     <asp:TextBox ID="txtAccumulationFundBase" Width="85%"  Text='<%#Eval("AccumulationFund.BaseTemp")%>'  runat="server" CssClass="input1"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="8%"/>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="��Ч����">
                                <ItemTemplate>
                                        <asp:TextBox ID="txtAccumulationFundYear" runat="server"  Width="45%" CssClass="input1"> </asp:TextBox> -
                                         <asp:TextBox ID="txtAccumulationFundMonth" runat="server"  Width="20%" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle  Width="9%"/>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="���乫�����ʺ�">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSupplyAccount" Width="85%"  Text='<%#Eval("AccumulationFund.SupplyAccount")%>'  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="9%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���乫�������">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtSupplyBase" Width="85%"  Text='<%#Eval("AccumulationFund.SupplyBase")%>'  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���Ͻɷѻ���">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtYangLaoBase" Text=' <%#Eval("SocialSecurity.YangLaoBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ʧҵ�ɷѻ���">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtShiYeBase" Text=' <%#Eval("SocialSecurity.ShiYeBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ҽ�ƽɷѻ���">
                                <ItemTemplate>
                                     <asp:TextBox ID="txtYiLiaoBase" Text=' <%#Eval("SocialSecurity.YiLiaoBaseTemp")%>'  Width="85%"  runat="server" CssClass="input1"> </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="8%"  />
                            </asp:TemplateField>
                        </Columns>
                <PagerTemplate>
<%--	<div class="pages">
	    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
	    ��һҳ</asp:LinkButton>
	    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
	    ��һҳ</asp:LinkButton>
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

