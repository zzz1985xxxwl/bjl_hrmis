<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentListView.ascx.cs" Inherits="SEP.Performance.Views.Departments.DepartmentListView" %>
<script type="text/javascript">
function showdescription(strID)
{
    var show = "show"+strID;
    var hide = "hide"+strID;
    strID = "Item"+strID ;
    var currtr = document.getElementById(strID);
    if(currtr==null)
    {
        return;
    }
    if (currtr.style.display=="none")
    {
	    currtr.style.display = "block"; //չ��
        document.getElementById(show).style.display = "none";
	    document.getElementById(hide).style.display = "block";
    }
    else
    { 
	    currtr.style.display = "none"; //����
	    document.getElementById(show).style.display = "block";
	    document.getElementById(hide).style.display = "none";
    } 
}
</script>

<div id="trMessage" class="leftitbor" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
		</div>  
   <div class="leftitbor2">��֯�ܹ�����
		 </div>
	<div class="linetablediv" id="tbDepartment" runat="server">
  <asp:GridView GridLines="None" Width="100%" ID="gvDepartment" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvDepartment_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
                    <Columns> 
                       <asp:TemplateField>
                          <ItemTemplate> 
    ������������������������<asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Id") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
                          </ItemTemplate>  
                         <ItemStyle Width="2%" />
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="�� ��">
                            <ItemTemplate> 
                                <img id="imgTree" runat="server"/>
                                <%#Eval("Name")%>(<%#Eval("CountEmployee")%>��)
                                <asp:HiddenField ID="hfIndexFromRoot" Value='<%#Eval("IndexFromRoot")%>' runat="server" />
                                <asp:HiddenField ID="hfHasChild" Value='<%#Eval("HasChild")%>' runat="server" />
                                <asp:HiddenField ID="hfHasMemeber" Value='<%#Eval("HasMemeber")%>' runat="server" />
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="40%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���ž���">
                            <ItemTemplate> 
                                <%#Eval("Leader.Name")%>      
                            </ItemTemplate>
                                <ItemStyle Width="14%"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
          <table width="100%" border="0" cellspacing="5" cellpadding="0">
            <tr>
              <td align="left">     
              <asp:Label runat="server" ID="lblShowOrHide">                      
                <a href="javascript:showdescription('<%# Eval("Id")%>');" style="color:#3c953b;">
                    <span id="<%# "show"+Eval("Id")%>">��ʾ���ų�Ա</span>    
                    <span id="<%# "hide"+Eval("Id")%>" style="display:none;">���ز��ų�Ա</span> 
                </a></asp:Label> 
              </td>
            </tr>
            <tr>
                <td>
                    <div  id="<%# "Item"+Eval("Id")%>" style="display:none; z-index:10; position:relative;">
                        <table width="100%" border="0" cellspacing="5" cellpadding="0">
                            <%#Eval("EmployeesNamePositionShow")%>
                        </table>
                    </div>
                </td>
            </tr>
          </table>

                            </ItemTemplate>
                                <ItemStyle Width="24%"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate> 
                                <asp:LinkButton ID="btnAdd" Text="����Ӳ���" OnCommand="btnAdd_Click" runat="server"  CommandArgument='<%# Eval("Id")%>'/>
                            </ItemTemplate>
                                <ItemStyle Width="10%"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate> 
                               <asp:LinkButton ID="btnUpdate" runat="server" 
                               Text="�޸�" 
                                CommandArgument='<%# Eval("Id") %>' 
                               OnCommand="btnModify_Click"></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate> 
                                <asp:LinkButton ID="btnDelete" Text="ɾ��" OnCommand="btnDelete_Click"  runat="server" CommandArgument='<%# Eval("Id")%>' />
                            </ItemTemplate>
                                <ItemStyle Width="5%"/>
                        </asp:TemplateField>
                    </Columns>                
    </asp:GridView>
       </div>
<script language= "javascript " type="text/javascript" src="../../../Pages/Inc/GridViewTree.js"> </script> 
<script language= "javascript " type="text/javascript" > 
ExpandOrShrinkTree('cphCenter_DepartmentInfoView1_DepartmentListView1_gvDepartment__1','imgTree');
ExpandOrShrinkTree('cphCenter_DepartmentInfoView1_DepartmentListView1_gvDepartment__1','imgTree');

</script> 