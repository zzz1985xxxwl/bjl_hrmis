<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Progressing.ascx.cs" Inherits="SEP.Performance.Views.Progress" %>
<style type="text/css">
.fontlayout {
      position: absolute;
      z-index: 99999;
      color: #416f02;
      left: 45%;
      top: 45%;
      border: 1px solid #3C3C3C; 
      background-color: #fff;
     }
.backlayout {
      position: absolute;
      z-index: 99997;
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;    
      background: #000;
      filter:alpha(opacity=30);     /* IE */ 
      opacity: 0.6;     /* 支持CSS3的浏览器（FF 1.5也支持）*/
      -moz-opacity: 0.6; /* Moz + FF */ 
      }
}

</style>
      <div class="fontlayout" id="fontlayout">
          <table style="vertical-align:middle; text-align:center">
          <tr><td height ="50px" align="right" width="145px">
              正在读取数据...&nbsp;&nbsp;
          </td><td align="left" width="95px" valign="middle">
             <div class="loadingImage" >&nbsp;</div> 
          </td></tr>
          </table>
      </div>
      <div class="backlayout" id="backlayout"></div>

<script type="text/javascript">
var fontlayoutWidth = 240;
var fontlayoutHeight = 50;
window.onscroll=setlayoutlocation;
window.onresize=setlayoutlocation;
window.onload=keepsetlayoutlocation;

function setlayoutlocation(){
 document.getElementById("backlayout").style.top=document.documentElement.scrollTop+"px";
 document.getElementById("backlayout").style.left=document.documentElement.scrollLeft+"px";
 document.getElementById("fontlayout").style.top=(document.documentElement.scrollTop+(document.documentElement.clientHeight-fontlayoutHeight)/2)+"px";
 document.getElementById("fontlayout").style.left=(document.documentElement.scrollLeft+(document.documentElement.clientWidth-fontlayoutWidth)/2)+"px";
}

function keepsetlayoutlocation(){
 setlayoutlocation();
 setTimeout("keepsetlayoutlocation()",1000);
}

</script>