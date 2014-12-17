<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkView.ascx.cs" Inherits="SEP.Performance.Views.SEP.CompanyRegulations.LinkView" %>
<div class="ruleleft">
	<div class="ruleleftbor">
		<div class="ruleleftlist">
			<ul>
				<li class="bighei" >公司规章制度</li>
			    <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">新员工指南</asp:LinkButton></li>
			    <li id="lCompanyFrame" runat="server"><asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">组织架构</asp:LinkButton></li>
			    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">制度流程</asp:LinkButton></li>
			    <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">薪酬福利</asp:LinkButton></li>
			    <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">培训发展</asp:LinkButton></li>
			    <li><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">绩效考核</asp:LinkButton></li>
			    <li><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">FAQS</asp:LinkButton></li>
			</ul>
		</div>
	</div>
</div>