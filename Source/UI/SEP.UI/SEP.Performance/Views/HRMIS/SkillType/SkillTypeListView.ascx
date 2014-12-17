<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkillTypeListView.ascx.cs" Inherits="SEP.Performance.Views.SkillType.SkillTypeListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<div  class="leftitbor" >
  <span class="font14b">���鵽 </span>     
<asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
<span class="font14b"> ����¼</span>	
<asp:Label ID="lblErrorMsg" runat="server" Text=""��CssClass = "font14b"/>		  
</div>
<div class="leftitbor2">���ü�������
</div>
<div class="edittable"> 
 <table width="100%" border="0">
    <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                ����</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" Width="170px" class="input1"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                </td>
            <td align="left" style="width: 41%">
            </td>
    </tr>       
      
  </table>
</div>
<div class="tablebt">   
<asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt"/>
 <asp:Button ID="btnAdd" runat="server" Text="��  ��" OnClick="btnAdd_Click" CssClass="inputbt"/>
</div>
<div id="tbSkill" runat="server"  class="linetablediv" >
  <asp:GridView GridLines="None" Width="100%" ID="gvSkill" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvSkillType_PageIndexChanging" OnRowCommand="gvSkillType_RowCommand" OnRowDataBound="gvSkillType_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
                    <asp:TemplateField>
                            <ItemTemplate><asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("ParameterID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
                            <ItemStyle Width="2%" />
                        </asp:TemplateField> 
                    <%--<asp:TemplateField HeaderText="���">
                        <ItemTemplate> 
                            <%#Eval("ParameterID")%>
                        </ItemTemplate>
                            <ItemStyle Width="20%" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="��������">
                        <ItemTemplate> 
                          <%#Eval("Name")%>
                        </ItemTemplate>
                            <ItemStyle Width="34%" />
                    </asp:TemplateField>
                                       <asp:TemplateField>
                      <ItemTemplate>
                       <asp:LinkButton ID="btnUpdate" runat="server"  Text="�޸�" CausesValidation="false"
                    CommandArgument='<%# Eval("ParameterID") %>' OnCommand="btnUpdate_Click"/>   
                      </ItemTemplate>
                            <ItemStyle Width="20%" />
                    </asp:TemplateField>   
                    <asp:TemplateField>
                      <ItemTemplate>
                       <asp:LinkButton ID="btnDelete" runat="server"  Text="ɾ��" CausesValidation="false"
                    CommandArgument='<%# Eval("ParameterID") %>' OnClientClick= "Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"
                    OnCommand="btnDelete_Click"/>   
                      </ItemTemplate>
                            <ItemStyle Width="20%" />
                    </asp:TemplateField>                    
                                        
    </Columns>                
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>            --%>    
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />		          
                    </PagerTemplate>
    </asp:GridView>

</div>