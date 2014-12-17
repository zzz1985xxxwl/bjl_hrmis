<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentDistributionView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.DepartmentDistributionView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<table cellpadding="0" cellspacing="0" border="0" width="100%">
  <tr>
    <td >
            <table class="leftitbor2" width="98%"><tr><td width="40px"></td>  
    <td>部门人员配置表</td>
      </tr>
    </table></td>
  </tr>
  <tr id="trSearch" runat="server">
    <td height="68" align="center">
        <div width="98%"  class="linetable" >
                <asp:GridView GridLines="None" Width="100%" ID="gvDepartmentDistribution" runat="server" AutoGenerateColumns="false" 
                OnRowDataBound="gvDepartmentDistribution_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
                    <Columns> 
                    <asp:TemplateField>                    
                        <ItemTemplate> 
                        </ItemTemplate>
                            <ItemStyle Width="2%" />
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="部 门">
                            <ItemTemplate> 
                                <img id="imgTree" runat="server"/>
                                <%#Eval("DepartmentName")%>
                                <asp:HiddenField ID="hfIndexFromRoot" Value='<%#Eval("IndexFromRoot")%>' runat="server" />
                                <asp:HiddenField ID="hfHasChild" Value='<%#Eval("HasChild")%>' runat="server" />
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="25%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上级部门">
                            <ItemTemplate> 
                                <%#Eval("ParentDepartment.DepartmentName")%>
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="25%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Index">
                            <ItemTemplate> 
                                <%#Eval("IndexFromRoot")%>
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="25%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HasChild">
                            <ItemTemplate> 
                                <%#Eval("HasChild")%>
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="25%"/>
                        </asp:TemplateField>
                    </Columns>                
                </asp:GridView>
        </div>
     </td>
  </tr>
</table>
<script language= "javascript " type="text/javascript" src="../../Inc/GridViewTree.js" > 

</script> 