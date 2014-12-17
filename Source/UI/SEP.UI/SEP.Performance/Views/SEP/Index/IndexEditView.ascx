<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexEditView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Index.IndexEditView" %>


<script type="text/javascript">
	   function conshowmenutext(num) {
	  $("#floatsetting").find("div").each(function(i,item){
	      i=i+1;
	      if(num==(i))
	      {
	         $("#floatbt"+i).attr("class","floatbtbg");
	         $("#floatdiv"+i).attr("class","showdiv");
	      }
	      else
	      {
	         $("#floatbt"+i).attr("class","floatsetbt");
	         $("#floatdiv"+i).attr("class","hiddendiv");
	      }
	   });
        	   
	   }
	   	   
	   
</script>
<div id="editwebpart" title="ÉèÖÃ">
                <table width="100%" >
                  <tr>
                    <td>
                	   	
                    <div id="floatsetting">
	                    <div id="floatbt1" class="floatbtbg"><a href="#" onclick="conshowmenutext(1)">SEP</a></div>
	                     <asp:Label ID="lblHrmis" runat="server"></asp:Label>   
                         <asp:Label ID="lblCrm" runat="server"></asp:Label>   
                         <asp:Label ID="lblMyCmmi" runat="server"></asp:Label>    
                    </div>
	                <div id="floatdiv1">         	
                        <table width="100%" border="0" cellspacing="6"  style="border-collapse:separate;" id="tableNormal" cellpadding="8" runat="server"></table>
	                </div>
                     <div id="floatdiv2" class="hiddendiv" >
                       <table width="100%" border="0" cellspacing="6" style="border-collapse:separate;" id="tableHrmis" cellpadding="8" runat="server"></table>
                     </div>
                      <div id="floatdiv3" class="hiddendiv" >
                       <table width="100%" border="0" cellspacing="6" style="border-collapse:separate;" id="tableCrm" cellpadding="8" runat="server"></table>
                     </div>
                      <div id="floatdiv4" class="hiddendiv" >
                       <table width="100%" border="0"  cellspacing="6" style="border-collapse:separate;" id="tableMyCmmi" cellpadding="8" runat="server"></table>
                     </div>
	                  </td>
                  </tr>
                  
                  <tr>
                    <td>
                      <table width="100%" border="0"  cellspacing="8px" style="border-collapse:separate;" >
                      <tr>
                            <td align="center" colspan="3" style="height: 25px;"> 
                             <input type="button" id="btnAdd" value="È·  ¶¨" class="inputbt" onclick="AddWebPart();" ></input>         
                             </td>
                          </tr>

                      </table>

                    </td>
                  </tr>
                </table>              	             
</div>
