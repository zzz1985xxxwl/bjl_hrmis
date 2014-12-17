<%@ Import namespace="ShiXin.Security"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeResumeBasicView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeInformation.ResumeInformation.EmployeeResumeBasicView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<table cellpadding="0" cellspacing="0" border="0" width="100%">
  <tr>
    <td align="center">
    <table width="100%" cellpadding="10" cellspacing="0">
      <tr>
        <td align="left">
          <table  width="100%" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10" >
            <tr>
              <td align="right" style="width: 2%"></td>
              <td align="left" style="width: 8%" >职称</td>
              <td align="left" style="width: 41%;" >
              <asp:TextBox ID="txtWorkTitle" Width="60%" runat="server" CssClass="input1"/></td>  
              <td align="left" style="width: 8%">外语能力</td>
              <td align="left" style=" width:41%;" >
              <asp:TextBox ID="TxtFLanguageAbility" Width="60%" runat="server" CssClass="input1"/></td>              
            </tr>
            <tr>
              <td width="2%" align="right" style="height: 82px" ></td>
              <td align="left" style="height: 82px;" valign="top" >证书</td>
              <td align="left" style="width: 90%; height: 82px;" colspan = "3">
              <asp:TextBox ID="TxtCertificates" runat="server" CssClass="grayborder" TextMode="MultiLine"  Height="80px" Width="82%"/></td>  
            </tr>
              <tr>
                  <td align="right" width="2%">
                  </td>
                  <td align="left">
                  </td>
                  <td align="left" colspan="3" style="width: 90%;">
		  	<asp:Button ID="btnAddEducation" runat="server" OnClick="btnAddEdu_Click" Text="新增教育"  class="inputbt"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddWork" runat="server" Text="新增工作" OnClick="btnAddwork_Click" class="inputbt"/>
            <asp:Label ID="lblMessage" runat="server"  CssClass="fontred"></asp:Label></td>
              </tr>
          </table></td>
      </tr>
    </table></td>
  </tr>
  
 
  
  <tr>
  <td >

  <table id="listEducation" runat="server" width="98%" border="0" style="margin-left:8px;" cellpadding="0" cellspacing="0"  visible="false">
  
   <tr>
  <td>&nbsp;</td>
  </tr>
  
  <tr>       
  <td width="10%" align="left" style="height: 18px" ><span class="font14px">教育培训经历（从高中起）</span></td>
   </tr> 
    <tr>
    <td align="center" >
    <table id="TableEdu" width="100%" class="linetable"  runat="server" cellpadding="0" cellspacing="0" >	 

        <tr>
	     <td width = "100%"   >
            <asp:GridView GridLines="None"   Width="100%" ID="grveducationlist" runat="server" AutoGenerateColumns="False" PageSize="5"
                AllowPaging="True" OnPageIndexChanging="grvEduList_PageIndexChanging"  BorderStyle="None" OnRowDataBound="grveducationlist_RowDataBound"  >
       <HeaderStyle Height="28px" CssClass="headerstyleblue"/>       
       <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
       <AlternatingRowStyle CssClass="table_g" />               
                       <Columns>
                      <asp:TemplateField >
                        <ItemTemplate><asp:Button ID="btnHiddenPostButtonEdu" CommandArgument='<%# Eval("Place") %>' CommandName="HiddenPostButtonCommandEdu" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
                        <ItemStyle Width="2%" />
                    </asp:TemplateField> 
                      <asp:BoundField DataField="HashCode" HeaderText="Id"  Visible="false">
                     
                        <ItemStyle Width="0%" />
                    </asp:BoundField>                               
                    <asp:BoundField DataField="ExperiencePeriod" HeaderText="教育时间" >
                     
                        <ItemStyle Width="15%" />
                    </asp:BoundField>                    
                    <asp:BoundField DataField="Place" HeaderText="学校" >
                       
                        <ItemStyle Width="15%" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="Contect" HeaderText="教育内容" >
                       
                        <ItemStyle Width="15%" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="Remark" HeaderText="备 注" >     
                        <ItemStyle Width="36%" />
                    </asp:BoundField> 
                    <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnUpdateEdu" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                    Text="修    改"  OnCommand ="btnUpdateEdu_Click" ></asp:LinkButton>
                           </ItemTemplate>
                        <ItemStyle Width="7%" />
                       </asp:TemplateField>  
                         <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnDeleteEdu" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                    Text="删    除"  OnCommand ="btnDeleteEdu_Click"   OnClientClick= "Confirmed = confirm('确定要删除吗？'); return Confirmed;"></asp:LinkButton>
                           </ItemTemplate>
                             <ItemStyle Width="7%" />
                       </asp:TemplateField>                    
                </Columns>                       
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>        --%>     
		 <uc1:PageTemplate ID="PageTemplateEdu" runat="server" />             
                    </PagerTemplate>
          </asp:GridView>  
            
           </td>
       </tr>
       </table>
    </td>
  </tr>
</table>

   </td>
</tr>
 
 
  <tr>
    <td>
   <table id="listWork" runat="server" width="98%" border="0" style="margin-left:8px;" cellpadding="0" cellspacing="0" visible="false">
   
   <tr>
  <td style="height: 25px">&nbsp;</td>
  </tr>
<tr>
  <td width="10%" align="left" ><span class="font14px">工作经历</span></td></tr>
  <tr>
    <td align="center" >
    <table id="Tablework" width="100%" class="linetable"  runat="server" cellpadding="0" cellspacing="0" >	 
       
  <tr><td width = "100%"    >
            <asp:GridView GridLines="None"   Width="100%" ID="grvworklist" runat="server" AutoGenerateColumns="False" PageSize="5"
                AllowPaging="True" OnPageIndexChanging="grvWorkList_PageIndexChanging"  BorderStyle="None"  OnRowDataBound="grvworklist_RowDataBound">
       <HeaderStyle Height="28px" CssClass="headerstyleblue"/>       
       <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
       <AlternatingRowStyle CssClass="table_g" />               
                       <Columns>
                      <asp:TemplateField >
                        <ItemTemplate><asp:Button ID="btnHiddenPostButtonWork" CommandArgument='<%# Eval("Place") %>' CommandName="HiddenPostButtonCommandWork" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>    
                     <asp:BoundField DataField="HashCode" HeaderText="Id" Visible="false" >
                     
                        <ItemStyle Width="0%" />
                    </asp:BoundField>                             
                    <asp:BoundField DataField="ExperiencePeriod" HeaderText="工作时期" >
                        <ItemStyle Width="13%" />
                    </asp:BoundField>                    
                    <asp:BoundField DataField="Place" HeaderText="工作单位" >
                        <ItemStyle Width="13%" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="Contect" HeaderText="工作内容" >
                        <ItemStyle Width="13%" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="ContactPerson" HeaderText="联系人" >
                        <ItemStyle Width="13%" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="Remark" HeaderText="备 注" >
                        <ItemStyle Width="29%" />
                    </asp:BoundField> 
                    <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnUpdateWork" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                    Text="修    改" OnCommand="btnUpdateWork_Click" ></asp:LinkButton>
                           </ItemTemplate>
                        <ItemStyle Width="7%" />
                       </asp:TemplateField>
                         <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnDeleteWork" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                    Text="删    除" OnCommand="btnDelete1Work_Click"  OnClientClick= "Confirmed = confirm('确定要删除吗？'); return Confirmed;"></asp:LinkButton>
                           </ItemTemplate>
                             <ItemStyle Width="7%" />
                       </asp:TemplateField>
                </Columns>                       
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>    --%>     
       <uc1:PageTemplate ID="PageTemplateWork" runat="server" />		                 
                    </PagerTemplate>
          </asp:GridView>  
           </td></tr>
 

 
       </table>
 
    </td>
  </tr>
</table>
</td>
 </tr>

<tr>
<td style="height:10px;">
</td>
</tr>
</table>
