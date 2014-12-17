<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReimburse.aspx.cs"
    Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.PrintReimburse" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/PrintReimburseView.ascx" TagName="PrintReimburseView"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>打印报销单</title>
    <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content" class="center">
        <style type="text/css">
            html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td
            {
                margin: 0;
                padding: 0;
                border: 0;
                outline: 0;
                font-size: 12px;
                vertical-align: baseline;
                background: transparent;
                font-weight: normal;
            }
            body
            {
                margin: 0px auto;
                font-size: 12px;
                font-family: "arial";
                background: #FFFFFF;
            }
            div
            {
                font-size: 12px;
                font-family: "宋体";
            }
            .kqtop
            {
                font-weight: bold;
                color: #ffffff;
                text-align: center;
            }
            .kqfont01
            {
                font-weight: bold;
                font-size: 16px;
                color: #498929;
            }
            .kqfont02
            {
                border-right: #69ad3c 1px solid;
                border-top: #69ad3c 1px solid;
                font-weight: normal;
                border-left: #69ad3c 1px solid;
                color: #519331;
                border-bottom: #69ad3c 1px solid;
            }
            .kqfont02 a
            {
                color: #519331;
            }
            .kqfont03
            {
                border-right: #000000 1px solid;
                border-top: #000000 1px solid;
                font-weight: normal;
                border-left: #000000 1px solid;
                color: #000000;
                border-bottom: #000000 1px solid;
            }
            .kqfont04
            {
                border-left: #000000 1px solid;
                border-bottom: #000000 1px solid;
            }
            .kqfont05
            {
                border-right: #000000 1px solid;
                border-left: #000000 1px solid;
                border-bottom: #000000 1px solid;
            }
            .kqfont06
            {
                border-bottom: #000000 1px solid;
            }
            td,th
            {
                vertical-align: middle;
            }
        </style>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table style="width: 100%">
                <tr align="center">
                    <td>
                        <table style="width: 800px">
                            <tr>
                                <td>
                                    <uc1:PrintReimburseView ID="PrintReimburseView1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
    <script language="javascript" src="../../Inc/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0"></embed>
    </object>
    <script type="text/javascript">
        (function () {
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            if (typeof (LODOP.PRINT_INIT) == "undefined") { return; }
            LODOP.PRINT_INIT("报销打印");
            LODOP.SET_PRINT_PAGESIZE(2, 0, 0, "A4");
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.getElementById("content").innerHTML);
            LODOP.PREVIEW();
            window.close();
        })()
    </script>
</body>
</html>
