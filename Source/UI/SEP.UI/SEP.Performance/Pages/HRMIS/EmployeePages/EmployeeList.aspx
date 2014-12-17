<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeList" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeTableView.ascx" TagName="EmployeeTableView"
    TagPrefix="uc4" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeListView.ascx" TagName="EmployeeListView"
    TagPrefix="uc2" %>
<%@ Register Src="../../../Views/HRMIS/Employee/LetterSearchView.ascx" TagName="LetterSearchView"
    TagPrefix="uc3" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeCardView.ascx" TagName="EmployeeCardView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
<script language="javascript " type="text/javascript" src="../../Inc/jquery.lightbox-0.5.js"></script>
<link href="../../CSS/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <uc2:EmployeeListView id="EmployeeListView1" runat="server">
        </uc2:EmployeeListView>
        <uc3:LetterSearchView id="LetterSearchView1" runat="server">
        </uc3:LetterSearchView>      
        <uc1:EmployeeCardView id="EmployeeCardView1" runat="server">
        </uc1:EmployeeCardView>
        <uc4:EmployeeTableView ID="EmployeeTableView1" runat="server" />
                <!--Loading界面 -->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing id="Progressing1" runat="server">
                </uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
     <asp:Button ID="btnExportServer" runat="server" Text="Button" OnClick="btnExportServer_Click" style="display:none;"/>
<script type="text/javascript">
function loadphoto(a)
{
        
        var t=$(a);
        t.parent("a").lightBox();
		var id=t.attr("accountid");
		t.hide();
		var loading=$("<img alt='加载中...' title='图片加载中...' style='border:none' src='../../image/loading.gif' /> ");	
		t.after(loading);
		var objImagePreloader = new Image();
		$(objImagePreloader).css({"width":t.css("width"),"height":t.css("height")});
		objImagePreloader.src="GetEmployeePhoto.aspx?id="+id;
		objImagePreloader.onload = function() {
			t.after($(objImagePreloader));
		    loading.remove();	
			objImagePreloader.onload=null;
		};
				
//		$.ajax({
//		   data:"",
//           url: "EmployeePhoto.aspx?id="+id,
//           success: function(msg){
//            loading.remove();
//             t.after(msg);
//           }
//        });
}
</script>    

</asp:Content>   
   