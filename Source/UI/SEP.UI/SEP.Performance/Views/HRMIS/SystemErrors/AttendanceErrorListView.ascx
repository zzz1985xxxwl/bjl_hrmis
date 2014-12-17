<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceErrorListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.SystemErrors.AttendanceErrorListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 40%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" ></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                部门
            </td>
            <td align="left" style="width: 42%">
                <asp:DropDownList ID="ddlDepartment" runat="server"  >
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td />   
            <td align="left" >
                查询时间
            </td>
            <td align="left"  colspan="3">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1" ></asp:TextBox>
                ---
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1" ></asp:TextBox>
                <asp:Label ID="lblScopeMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
 <asp:Button ID="btnSearch" runat="server" Text="查　询" CssClass="inputbt" OnClick="btnSearch_Click" />
</div>
<div class="nolinetablediv">
<asp:GridView ID="gvSystemError" runat="server" Width="100%" AutoGenerateColumns="False"  AllowPaging="true" 
OnPageIndexChanging="gvSystemError_PageIndexChanging"  CssClass="linetable"   GridLines="None"   OnRowDataBound="gvSystemError_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink" HorizontalAlign="Left"/>
<AlternatingRowStyle CssClass="table_g" />
        <Columns>  
            <asp:TemplateField><ItemTemplate ><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate>
                <ItemStyle Width="2%" VerticalAlign="Middle" />
            </asp:TemplateField>                                                           
           <asp:TemplateField  HeaderText="描述">
                <ItemTemplate>
                    <%#Eval("Description")%>
                </ItemTemplate>
                <ItemStyle Width="88%" />
            </asp:TemplateField>   
            <asp:TemplateField >
                <ItemTemplate>
                     <a onclick='window.open("<%#Eval("EditUrl")%>")' href="#">更正</a>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>              
        </Columns>
        <PagerTemplate>
                        <uc1:PageTemplate ID="PageTemplate1" runat="server" />                   
        </PagerTemplate>   
</asp:GridView>
</div>