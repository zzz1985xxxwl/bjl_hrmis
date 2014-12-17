<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentHistoryListView.ascx.cs"
            Inherits="SEP.Performance.Views.HRMIS.DepartmentHistory.DepartmentHistoryListView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function showdescription(strID) {
        var show = "show" + strID;
        var hide = "hide" + strID;
        strID = "Item" + strID;
        var currtr = document.getElementById(strID);
        if (currtr == null) {
            return;
        }
        if (currtr.style.display == "none") {
            currtr.style.display = "block"; //չ��
            document.getElementById(show).style.display = "none";
            document.getElementById(hide).style.display = "block";
        } else {
            currtr.style.display = "none"; //����
            document.getElementById(show).style.display = "block";
            document.getElementById(hide).style.display = "none";
        }
    }

    function showInformation(strID, displaystyle) {
        strID = "Information" + strID;
        var currtr = document.getElementById(strID);
        if (currtr == null) {
            return;
        }
        currtr.style.display = displaystyle; //չ��
    }
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div runat="server" id="trMessage" class="leftitbor">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
        </div>
        <div class="leftitbor2">
            <asp:Label ID="lbl_Title" runat="server" Text=""></asp:Label>
        </div>
        <div id="ShowSearchTime" runat="server">
        </div>
        <div class="edittable">
            <table width="100%" border="0">
                <tr>
                    <td align="left" style="width: 2%;" >
                    </td>
                    <td align="left" style="width: 13%;" >
                        ��ѯʱ��
                    </td>
                    <td align="left" style="width: 85%" >
                        <asp:TextBox ID="txtSearchTime" runat="server" class="input1"></asp:TextBox> 
                    </td>
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSearchTime" 
                                                  Format="yyyy-MM-dd" >
                    </ajaxToolKit:CalendarExtender>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ"  OnClick="btnSearch_Click" CssClass="inputbt" />
            <asp:Button ID="btnExport" runat="server" Text="��  ��"  OnClick="btnExport_Click" CssClass="inputbt" />
        </div>
        <div id="tbDepartment" runat="server" class="linetablediv">
            <asp:GridView GridLines="None" Width="100%" ID="gvDepartment" runat="server" AutoGenerateColumns="False"
                          OnRowDataBound="gvDepartment_RowDataBound">
                <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                <RowStyle Height="28px" CssClass="GridViewRowLink" />
                <AlternatingRowStyle CssClass="table_g" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("DepartmentID") %>'
                                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�� ��">
                        <ItemTemplate>
                            <img id="imgTree" runat="server" />
                            <%--                            <%#Eval("DepartmentName")%>--%><span onmouseover=" showInformation('<%# Eval("DepartmentID") %>', 'block'); " onmouseout=" showInformation('<%# Eval("DepartmentID") %>', 'none'); "><%#Eval("DepartmentName") %>(<%#Eval("CountEmployee") %>��)</span>
                            <div id="<%# "Information" + Eval("DepartmentID") %>" style="display: none; z-index: 20; position: absolute; margin: 8px; background: #FFFFFF; padding: 5px; line-height: 35px;"  class="linetable_5">
                                <table width="450px" border="0" class="fonttable_2" cellpadding="5" cellspacing="6" style="border-collapse: separate; padding-left: 20px;" >
                                    <tr>
                                        <td width="15%" align="left" >�绰</td>
                                        <td width="35%" align="left" ><%#Eval("Phone") %>
                                        </td>
                                        <td width="15%" align="left" >����
                                        </td><td width="35%" align="left" ><%#Eval("Fax") %></td></tr>
                                    <tr>
                                        <td width="15%" align="left">����ʱ��</td>
                                        <td width="35%" align="left"><%#Eval("FoundationTime", "{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td width="15%" align="left">����
                                        </td><td width="35%" align="left"><%#Eval("Others") %></td></tr>
                                    <tr>
                                        <td width="15%" align="left"> ��ַ</td>
                                        <td colspan="3" align="left"><%# Eval("Address") %>
                                        </td></tr><tr>
                                                      <td width="15%" align="left" rowspan="2" style="height: 40px" valign="top">
                                                          ����</td>
                                                      <td  colspan="3" align="left" valign="top" rowspan="2"><%#Eval("Description") %></td>                               <td width="8%" align="left">
                                                  </tr>
                                </table>
                            </div>
                            <asp:HiddenField ID="hfIndexFromRoot" Value='<%#Eval("IndexFromRoot") %>' runat="server" />
                            <asp:HiddenField ID="hfHasChild" Value='<%#Eval("HasChild") %>' runat="server" />
                            <asp:HiddenField ID="hfHasMemeber" Value='<%#Eval("HasMemeber") %>' runat="server" />
     

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="48%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���ž���">
                        <ItemTemplate>
                            <%#Eval("DepartmentLeader.Name") %>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblShowOrHide">                                              
                                            <a href="javascript:showdescription('<%# Eval("DepartmentID") %>');" style="color: #3c953b;">
                                                <span id="<%# "show" + Eval("DepartmentID") %>">��ʾ���ų�Ա</span>    
                                                <span id="<%# "hide" + Eval("DepartmentID") %>" style="display: none;">���ز��ų�Ա</span> 
                                            </a></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="<%# "Item" + Eval("DepartmentID") %>" style="display: none; z-index: 10; position: relative;">
                                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                                <%#Eval("EmployeesNamePositionShow") %>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="38%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing ID="Progressing1" runat="server"></uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSearch" />
        <asp:PostBackTrigger ControlID="btnExport" />
    </Triggers>
</asp:UpdatePanel>

<script language="javascript " type="text/javascript" src="../../Inc/GridViewTree.js"></script>
<script language= "javascript " type="text/javascript" src="../../../Pages/Inc/jquery.lightbox-0.5.js"> </script> 
<link href="../../../Pages/CSS/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
<script language= "javascript " type="text/javascript" > 
ExpandOrShrinkTree('cphCenter_DepartmentHistoryListView1_gvDepartment__1','imgTree');
ExpandOrShrinkTree('cphCenter_DepartmentHistoryListView1_gvDepartment__1','imgTree');
$(function(){
showphoto();
})
function showphoto()
{
  $(".nameshowphoto").each(function(){
var name=$(this).html();
var id=$(this).attr("accountid");
$(this).wrap("<a class='linkphoto' title='"+name+"' href='../../HRMIS/EmployeePages/GetEmployeePhoto.aspx?id="+id+"' title='Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery').lightBox();'></a>");
});
$(".linkphoto").lightBox();
}

</script>