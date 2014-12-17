(function($) {
	$.extend({
		tablesorterPager: new function() {
			
			function updatePageDisplay(c) {
				//var s = $(c.cssPageDisplay,c.container).val((c.page+1) + c.seperator + c.totalPages);
				$(c.cssPageNowIndex,c.container).html((c.page+1));
				$(c.cssPageCount,c.container).html(c.totalPages);
				makeDisable(c);
			}
			function makeDisable(c){
			  if(c.page<=0)
				{
				  $(c.cssPrev).attr("disabled",true);
				  $(c.cssFirst).attr("disabled",true);
				}
				else
				{
				  $(c.cssPrev).attr("disabled",false);
				  $(c.cssFirst).attr("disabled",false);
				}
			  if(c.page>=(c.totalPages-1))
				{
				  $(c.cssNext).attr("disabled",true);
				  $(c.cssLast).attr("disabled",true);
				}
				else
				{
				  $(c.cssNext).attr("disabled",false);
				  $(c.cssLast).attr("disabled",false);
				}
			}
			function setPageSize(table,size) {
				var c = table.config;
				c.size = size;
				c.totalPages = Math.ceil(c.totalRows / c.size);
				c.pagerPositionSet = false;
				moveToPage(table);
				fixPosition(table);
			}
			
			function fixPosition(table) {
				var c = table.config;
				if(!c.pagerPositionSet && c.positionFixed) {
					var c = table.config, o = $(table);
					if(o.offset) {
						c.container.css({
							top: o.offset().top + o.height() + 'px',
							position: 'absolute'
						});
					}
					c.pagerPositionSet = true;
				}
			}
			
			function moveToFirstPage(table) {
				var c = table.config;
				c.page = 0;
				moveToPage(table);
			}
			
			function moveToLastPage(table) {
				var c = table.config;
				c.page = (c.totalPages-1);
				moveToPage(table);
			}
			
			function moveToNextPage(table) {
				var c = table.config;
				c.page++;
				if(c.page >= (c.totalPages-1)) {
					c.page = (c.totalPages-1);
				}
				moveToPage(table);
			}
			
			function moveToPrevPage(table) {
				var c = table.config;
				c.page--;
				if(c.page <= 0) {
					c.page = 0;
				}
				moveToPage(table);
			}
			
			function moveToIndex(table ,index) {
			 if (parseInt(index)) 
			 {
				var c = table.config;
				c.page=index-1;
				if(c.page <= 0) {
					c.page = 0;
				}
				moveToPage(table);
			  }	
			}			
			
			function moveToPage(table) {
				var c = table.config;
				if(c.page < 0) {
					c.page = 0;
				}
				else if(c.page > (c.totalPages-1))
				{
				   c.page=c.totalPages-1;
				}
				
				renderTable(table,c.rowsCopy);
				config.afterchangepage(c.page);				
			}
			
			function renderTable(table,rows) {
				if(rows.length>0)
				{
				    var c = table.config;
				    var l = rows.length;
				    var s = (c.page * c.size);
				    var e = (s + c.size);
				    if(e > rows.length ) {
					    e = rows.length;
				    }
    				
    				
				    var tableBody = $(table.tBodies[0]);
    				
				    // clear the table body
    				
				    $.tablesorter.clearTableBody(table);
    				
				    for(var i = s; i < e; i++) {
    					
					    //tableBody.append(rows[i]);
    					
					    var o = rows[i];
					    var l = o.length;
					    for(var j=0; j < l; j++) {
    						
						    tableBody[0].appendChild(o[j]);

					    }
				    }
    				
				    fixPosition(table,tableBody);
    				
				    $(table).trigger("applyWidgets");
    				
				    if( c.page >= c.totalPages ) {
        			    moveToLastPage(table);
				    }
    				
				    updatePageDisplay(c);
				}
				
			}
			
			this.appender = function(table,rows) {
				
				var c = table.config;
				
				c.rowsCopy = rows;
				c.totalRows = rows.length;
				c.totalPages = Math.ceil(c.totalRows / c.size);
                renderTable(table,rows);
			};
			
			this.defaults = {
				size: 10,
				offset: 0,
				page: 0,
				totalRows: 0,
				totalPages: 0,
				container: null,
				cssNext: '.pagenextbutton',
				cssPrev: '.pageprevbutton',
				cssFirst: '.pagefirstbutton',
				cssLast: '.pagelastbutton',
				cssGo:'.pagegobutton',
				cssGoIndex:'.pagegoindex',
				cssPageDisplay: '.pagedisplay',
				cssPageSize: '.pagesize',
				seperator: "/",
				cssPageNowIndex:".pagenowindex",
				cssPageCount:".pagecount",
				positionFixed: false,
				appender: this.appender,
				afterchangepage:function(){}
			};
			
			this.construct = function(settings) {
				
				return this.each(function() {	
					
					config = $.extend(this.config, $.tablesorterPager.defaults, settings);
					
					var table = this, pager = config.container;
				
					$(this).trigger("appendCache");
					
					//config.size = parseInt($(".pagesize",pager).val());
					
					$(config.cssNext,pager).unbind("click");
					$(config.cssPrev,pager).unbind("click");
					$(config.cssFirst,pager).unbind("click");
					$(config.cssLast,pager).unbind("click");
					$(config.cssGo,pager).unbind("click");
					$(config.cssPageSize,pager).unbind("change");
					
					$(config.cssFirst,pager).click(function() {
						moveToFirstPage(table);
						return false;
					});
					$(config.cssNext,pager).click(function() {
						moveToNextPage(table);
						return false;
					});
					$(config.cssPrev,pager).click(function() {
						moveToPrevPage(table);
						return false;
					});
					$(config.cssLast,pager).click(function() {
						moveToLastPage(table);
						return false;
					});
					$(config.cssGo,pager).click(function() {
						moveToIndex(table,$(config.cssGoIndex,pager).val());
						return false;
					});
					$(config.cssPageSize,pager).change(function() {
						setPageSize(table,parseInt($(this).val()));
						return false;
					});
				});
			};
			
		}
	});
	// extend plugin scope
	$.fn.extend({
        tablesorterPager: $.tablesorterPager.construct
	});
	
})(jQuery);				