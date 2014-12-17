<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackDetailView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.FeedBackDetailView" %>
  <div id="tbMessage" runat="server" class="leftitbor" >
            <span class="fontred"><asp:Label ID="lblMessage" runat="server" ></asp:Label></span><%--<a href="#" class="fontreda"></a>--%>
</div>          
<div class="leftitbor2" >
        <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
        
 <div class="edittable">
    <table width="100%" border="0" >
        <tr>
            <td align="right" style="width: 12%;">
                培训课程</td>
            <td align="left" style="width: 38%;">
              <asp:TextBox ID="txtCourse" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
                <asp:HiddenField ID="HFCourseId" runat="server" />
                </td>
            <td align="right"style="width: 12%;">
                反馈人
                </td>
            <td align="left" style="width: 38%;">
            <asp:TextBox ID="tbName" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" >
                反馈时间</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="tbFBTime" runat="server" CssClass="input1" ReadOnly="true"></asp:TextBox>
                
                <asp:Label ID="lblScore" runat="server" ></asp:Label>
                <asp:HiddenField ID="HFEmployeeId" runat="server"/>
            </td>
        </tr>
                <tr id="trCertification" runat="server">
            <td align="right" >
                培训所获证书名称</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="txtCertification" runat="server" CssClass="input1" Width="300px"></asp:TextBox>
                
            </td>
        </tr>
    </table>
 </div>
        
<div id="tblAssessItem" runat="server" >
     <asp:Repeater ID="rptQuesItems" runat="server">
          <ItemTemplate>
                        <div class="linetablediv">
                        <table width="100%"  cellpadding="10" cellspacing="0" >
                          <tr>
                            <td align="left" class="green2"><table width="100%" border="0" cellspacing="0" cellpadding="6">
                              <tr>
                                <td width="10%" height="27" align="right"><strong>反馈项</strong>&nbsp;&nbsp;</td>
                                <td><asp:Label ID="lblQuestion" runat="server"><%# Eval("FBQuestion")%></asp:Label>
                                &nbsp;&nbsp;      
                                    <asp:HiddenField ID="flFbID" runat="server" />                    </td>
                                      </tr>
                                   <tr>
                                <td height="34" align="right">选　项&nbsp;&nbsp;</td>
                                <td>
                                <asp:DropDownList ID="ddlScore" runat="server" Width="165px"></asp:DropDownList></td></tr>
                                      </table>
                                </div>
                                </td>
                              </tr>

                            </table>
                    </div>
          </ItemTemplate>
      </asp:Repeater>
</div>
<div  class="edittable" id="tblComment" runat="server">
  <table width="100%">
    <tr>
      <td width="12%" align="right" valign="top">建议</td>
      <td width="88%" align="left">
        <asp:TextBox ID="txtComment" runat="server" Width="70%" Height="100px" TextMode="MultiLine" CssClass="grayborder"></asp:TextBox></td>
    </tr>
   </table>
</div>
<div class="tablebt"  runat="server" id="Front">
    <asp:Button ID="btnOk" runat="server" CssClass = "inputbt"  Text="确　定" OnClick="btnOk_Click" />
    <asp:Button ID="btnCancle" runat="server" CssClass = "inputbt"  Text="取　消" OnClick="btnCancle_Click" />
</div>
<div class="tablebt"  runat="server" id="Back">
    <asp:Button ID="btnBackOk" runat="server" CssClass = "inputbt"  Text="确　定" OnClick="btnBackOk_Click"  />
    <asp:Button ID="btnBackCancle" runat="server" CssClass = "inputbt"  Text="取　消" OnClick="btnBackCancle_Click"  />
</div>