/**
 * @author xue.wenlong
 */
 
(function($) {
	$.extend({
		SHjqTable: new function() {
			
			function InitTableCol($table) {
			      var c=$table.config;
			      if(($table.find("thead").length<=0&&$table.find("tfoot").length<=0)||!c.pageLoading)
			      {
			      
			          $table.empty();
			          $table.attr({"border":"0","cellpadding":"0","cellspacing":"0"}).css("border-collapse","separate");
				      $table.parent("div").css("position","relative");
			          var tablethlength=c.colNames.length;
                      var sthead="";
			          for(var i=0;i<tablethlength;i++)
			          {
			            sthead+="<th style=\"width:"+c.colWidth[i]+"\">"+ c.colNames[i] +"</th>";	
			          }
			          $table.append("<thead><tr class=\""+c.theadClass+"\" style=\"height: "+c.trHeight+";\">"+sthead+"</tr></thead>");
			          $table.append("<tbody></tbody>");
			          if(!c.pageLoading)
			          {
			              if($table.find("tbody tr").length<=0)
                          {
                             var emptybody = "<tr style=\"height:"+c.trHeight+"\"><td  colspan='"+tablethlength +"'> </td></tr>";
                             $table.find("tbody").append(emptybody);
                          }
			          }

                      var foot="<tfoot><tr style=\"height:"+c.trHeight+"\"><th style=\"font-weight:normal;\" colspan='"+tablethlength 
                      +"'><div class='"+c.cssPage+"' id=\"pages\"> 共 <span class='"+c.cssPageCount+"'>0</span> 页  第 <span class='"
                      +c.cssPageNowIndex+"'>0</span> 页     <a  class='"
                      +c.cssFirst+"' > 首页</a><a  class='"
                      +c.cssPrev+"' > 上一页</a><a  class='"
                      +c.cssNext+"'  > 下一页</a><a  class='"
                      +c.cssLast+"'> 末页</a>    转到<input class='input1 "
                      +c.cssGoIndex+"' type=\"text\" style=\"width: 20px;\" />     页<a  class='"
                      +c.cssGo+"'>GO</a></div></th></tr></tfoot>"; 

                      $table.find("tbody").after(foot);
			      }
				 
			}
			
			function InitTableSortPage($table)
			{
				$table.find("tbody").find("tr").css("height",$table.config.trHeight);
	             if($table.find("tbody tr").length<=0)
                 {
                   $table.find("#pages .pagenowindex").html("0");
                   $table.find("#pages .pagecount").html("0");
                   $table.find("#pages a").attr("disabled",true);
                 }
                 else
                 {
                     $table.find("#pages a").attr("disabled",false);
                 }
//                 else
//                 {
                    $table.tablesorter(
                    {
                    widgetZebra:$table.config.widgetZebra,
                    headers: $table.config.headers,
                    getrows:$table.config.getrows})
                    .tablesorterPager({
                    container: $table.find("#pages"),
                    size:$table.config.pageSize,
                    cssNext: "."+$table.config.cssNext,
				    cssPrev: "."+$table.config.cssPrev,
				    cssFirst:"."+$table.config.cssFirst,
			     	cssLast: "."+$table.config.cssLast,
				    cssGo:"."+$table.config.cssGo,
				    cssGoIndex:"."+$table.config.cssGoIndex,
				    cssPageDisplay:"."+$table.config.cssPageDisplay,
				    cssPageSize: "."+$table.config.cssPageSize,
				    cssPageNowIndex:"."+$table.config.cssPageNowIndex,
				    cssPageCount:"."+$table.config.cssPageCount,
				    afterchangepage:$table.config.afterchangepage,
                    page:$table.config.pageindex
                    });
//                 }  
			}
			
			function BuildTable($table)
			{
			       if(!$table.config.pageLoading)
			       {$table.after("<div class=\"loadingImage\" style=\"position:absolute;top:40%;left:47%;\"></div>");}
			       else{AddOverLayLoding();}
			       var tr="";
			       for(var i=0;i<$table.config.colTemplates.length;i++)
			       {
			       	tr+="<td>"+ $table.config.colTemplates[i]+"</td>"
			       }
                   tr= "<tr id=#"+$table.config.colPKIDName+"#>"+tr+"</tr>";  
                   $.ajax({
                   type: "get",
                   url: $table.config.url,
                   data: $table.config.data,
                   cache:false,
                   dataType:'json',
                   success: function(json){
                        if(!$table.config.pageLoading)
                        {$table.next(".loadingImage").remove();}
                        else
                        {RemoveOverLayLoding();}
                        $table.find("tbody").empty();
                        if(json.error&&json.error.length>0)
                        { 
                             for(var i=0;i<json.error.length;i++){
                            if(json.error[i]["ErrorControlID"]!=null)
                            {
                               $table.config.error(json);
                              
                               return;
                            }
                           }
                        }
                        else if(json.itemList&&json.itemList.length>0)
                        {
                            if(!$table.config.isHtml)
                            {   
                                for(var i=0,l=json.itemList.length;i<l;i++){
                        	        var t=tr;
                                    for(var key in json.itemList[i]){
                            	        var reg=new RegExp("#"+key+"#","g");
                            	        t=t.replace(reg,json.itemList[i][key]);
                                     }
                                     $(t).appendTo($table.find("tbody")); 
                                }
                            }
                        }
                        else{ 
                             for(var i=0;i<json.length;i++){
                                if(json[i]["ErrorControlID"]!=null)
                                {
                                   $table.config.error(json);
                                   return;
                                }
                            }
                            
                            if(!$table.config.isHtml)
                            {   
                                for(var i=0,l=json.length;i<l;i++){
                        	        var t=tr;
                                    for(var key in json[i]){
                            	        var reg=new RegExp("#"+key+"#","g");
                            	        t=t.replace(reg,json[i][key]);
                                     }
                                     $(t).appendTo($table.find("tbody")); 
                                }
                            }
                            else
                            {
                               $table.find("tbody").html(json[0]["Html"]);
                            }
                        }
                       
                       $table.config.afterbuild();
                       InitTableSortPage($table);
                       $table.config.success();
                     }
                   });
			}
			
			this.defaults = {		
				colNames:[],
				colWidth:[],
				colPKIDName:'',
				pageSize:10,
				colTemplates:[],
				headers:{},
				url:'',
				data:{},
				success:function(){},
				error:function(){},
				getrows:function(){},
                theadClass:'headerstyleblue',
                widgetZebra:{css: ["GridViewRowLink","table_g"]},
                pageLoading:false,
                isHtml:false,
                trHeight:'28px',
                cssNext: 'pagenextbutton',
				cssPrev: 'pageprevbutton',
				cssFirst: 'pagefirstbutton',
				cssLast: 'pagelastbutton',
				cssGo:'pagegobutton',
				cssGoIndex:'pagegoindex',
				cssPageDisplay: 'pagedisplay',
				cssPageSize: 'pagesize',
				cssPageNowIndex:"pagenowindex",
				cssPageCount:"pagecount",
				cssPage:"pages2",
				afterchangepage:function(){},
				pageindex:0,
				afterbuild:function(){}
			};
			
			this.construct = function(settings) {
				return this.each(function() {	
					config = $.extend(this.config, $.SHjqTable.defaults, settings);	
					var $table = $(this);
					$table.config=config;
				    InitTableCol($table);
					BuildTable($table);
				});
			};
			
		}
	});
	// extend plugin scope
	$.fn.extend({
        SHjqTable: $.SHjqTable.construct
	});
	
})(jQuery);	