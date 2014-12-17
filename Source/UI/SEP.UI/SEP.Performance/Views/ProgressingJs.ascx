<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressingJs.ascx.cs" Inherits="SEP.Performance.Views.ProgressingJs" %>
<style type="text/css">
/*jsloader----------------------------------------------*/
#jsloader {
  font-family:Tahoma, Helvetica, sans;
  font-size:11.5px;
  color: #abc;
  padding:10px 0 16px 0;
  margin:0 auto;  
  display:block;
  width:130px;
  text-align:left;  
  z-index:2;
}
 </style> 

<script type="text/javascript">
function RemoveProgressLoading() 
{
    var targelem = document.getElementById('jsloader');
    targelem.style.display='none';
    targelem.style.visibility='hidden';
}
</script>
<div id="jsloader">
    <div align="center">loading ...</div>
    <div align="center">
        <img src="../../Pages/image/jsloading.gif" />
    </div>
</div>
