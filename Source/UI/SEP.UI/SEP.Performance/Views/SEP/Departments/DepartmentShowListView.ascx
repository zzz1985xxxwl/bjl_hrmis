<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentShowListView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Departments.DepartmentShowListView" %>
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
	    currtr.style.display = "block"; //展开
        document.getElementById(show).style.display = "none";
	    document.getElementById(hide).style.display = "block";
    }
    else
    { 
	    currtr.style.display = "none"; //收缩
	    document.getElementById(show).style.display = "block";
	    document.getElementById(hide).style.display = "none";
    } 
}
</script>

<div id="trMessage" class="leftitbor" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
		 </div>
  
   <div class="leftitbor2" >组织架构管理
		 </div>
    <div id="tbDepartment" runat="server" class="linetablediv" >
  <asp:GridView GridLines="None" Width="100%" ID="gvDepartment" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvDepartment_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
                    <Columns> 
                       <asp:TemplateField>
                          <ItemTemplate> 
    　　　　　　　　　　　　<asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Id") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
                          </ItemTemplate>  
                         <ItemStyle Width="2%" />
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="部 门">
                            <ItemTemplate> 
                                <img id="imgTree" runat="server"/>
                                <%#Eval("Name")%>
                                <asp:HiddenField ID="hfIndexFromRoot" Value='<%#Eval("IndexFromRoot")%>' runat="server" />
                                <asp:HiddenField ID="hfHasChild" Value='<%#Eval("HasChild")%>' runat="server" />
                                <asp:HiddenField ID="hfHasMemeber" Value='<%#Eval("HasMemeber")%>' runat="server" />
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="45%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="部门经理">
                            <ItemTemplate> 
                                <%#Eval("Leader.Name")%>      
                            </ItemTemplate>
                                <ItemStyle Width="20%"/>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
          <table width="100%" border="0" cellspacing="5" cellpadding="0">
            <tr>
              <td align="left">     
              <asp:Label runat="server" ID="lblShowOrHide">                      
                <a href="javascript:showdescription('<%# Eval("Id")%>');" style="color:#3c953b;">
                    <span id="<%# "show"+Eval("Id")%>">显示部门成员</span>    
                    <span id="<%# "hide"+Eval("Id")%>" style="display:none;">隐藏部门成员</span> 
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
                                <ItemStyle Width="35%"/>
                        </asp:TemplateField>
                    </Columns>                
    </asp:GridView>
       </div>
<script language= "javascript " type="text/javascript" src="../../../Pages/Inc/GridViewTree.js"> 
</script> 