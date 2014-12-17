/**
 * @author User
 */
(function($) {
    $.fn.extend(
    {
        SXTable: function(settings) {
            var currentpage, $page, showitems, config, allitems, $table;
             function BindPage() {
                 if(config.styleclass == "simple")
                {             
                    $page.addClass("pages2").css({"text-align":"center","clear":"both"});
                    $("<a class='pagefirstbutton' style='padding-left:0px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a><span>&nbsp;&nbsp;</span>").bind("click", function() {
                        GoToFirst();
                    }).appendTo($page);
                    $("<a  class='pageprevbutton' style='padding-left:0px;'>&nbsp;&nbsp;&nbsp;</a>").bind("click", function() {
                        GoToPrev();
                    }).appendTo($page);
                    $page.append("<span class='pagenowindex'>0</span> / <span class='pagecount'>0</span> ");
                    
                    $("<a  class='pagenextbutton' style='padding-right:0px;'>&nbsp;&nbsp;&nbsp;</a><span>&nbsp;&nbsp;</span>").bind("click", function() {
                        GoToNext();
                    }).appendTo($page);
                    $("<a  class='pagelastbutton' style='padding-right:0px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>").bind("click", function() {
                        GoToLast();
                    }).appendTo($page);        
                    
                    
                    $("<span>&nbsp; 转到 <input class='input1' type='text' style='width: 20px;' /> 页</span>").appendTo($page);
                    $("<a class='pagegobutton' style='padding-right:0px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>").bind("click", function() {
                        GoTo();
                    }).appendTo($page);
                }
                else
                {             
                    $page.addClass("pages2").css(
                    {
                        "clear": "both"
                    }).append("共 <span class='pagecount'>0</span> 页  第 <span class='pagenowindex'>0</span> 页     ");
                    $("<a class='pagefirstbutton' > 首页</a>").bind("click", function() {
                        GoToFirst();
                    }).appendTo($page);
                    $("<a  class='pageprevbutton' > 上一页</a>").bind("click", function() {
                        GoToPrev();
                    }).appendTo($page);
                    $("<a  class='pagenextbutton'  > 下一页</a>").bind("click", function() {
                        GoToNext();
                    }).appendTo($page);
                    $("<a  class='pagelastbutton'> 末页</a>").bind("click", function() {
                        GoToLast();
                    }).appendTo($page);
                    $("<span>    转到<input class='input1' type='text' style='width: 20px;' />     页</span>").appendTo($page);
                    $("<a class='pagegobutton'>GO</a>").bind("click", function() {
                        GoTo();
                    }).appendTo($page);
                }                
            };
            //处理enable
            function UpdatePage() {
                $page.find("a:disabled").attr("disabled", false);
                if (!getNavState().canGotoFirst) {
                    $($page).find(".pagefirstbutton").attr("disabled", true);
                }
                if (!getNavState().canGotoLast) {
                    $($page).find(".pagelastbutton").attr("disabled", true);
                }
                if (!getNavState().canGotoPrev) {
                    $($page).find(".pageprevbutton").attr("disabled", true);
                }
                if (!getNavState().canGotoNext) {
                    $($page).find(".pagenextbutton").attr("disabled", true);
                }
                if (!getNavState().canGoto) {
                    $($page).find(".pagegobutton").attr("disabled", true);
                }
                $page.find(".pagenowindex").html(currentpage);
                $page.find(".pagecount").html(getNavState().lastPage);
            };
            
            function GoToFirst() {
                if (getNavState().canGotoFirst) {
                    currentpage = 1;
                    BuildTable();
                }
            };
            
            function GoToPrev() {
                if (getNavState().canGotoPrev) {
                    currentpage--;
                    BuildTable();
                }
            };
            function GoToNext() {
                if (getNavState().canGotoNext) {
                    currentpage++;
                    BuildTable();
                }
            };
            function GoToLast() {
                if (getNavState().canGotoLast) {
                    currentpage = getNavState().lastPage;
                    BuildTable();
                }
            };
            
            
            function GoTo() {
                if (getNavState().canGoto) {
                    var page = $page.find("input").val();
                    if (parseInt(page) && page <= getNavState().lastPage && page > 0) {
                        currentpage = page;
                    }
                    BuildTable();
                }
            };
            function BuildTable() {
                var pageSize = config.pageSize, endIndex = pageSize * currentpage, itemArray = allitems;
                endIndex = itemArray.length > endIndex ? endIndex : itemArray.length;
                if (currentpage > getNavState().lastPage) {
                    currentpage = getNavState().lastPage;
                }
                UpdatePage();
                showitems = new Array();
                for (var i = (currentpage - 1) * pageSize; i < endIndex && itemArray.length > 0; i++) {
                    showitems.push(itemArray[i]);
                }
                
                BuildTableBody(showitems);
                config.getrows(itemArray);
                config.afterChangePage(currentpage);
            };
            //得到页面状态
            function getNavState() {
            
                var pageSize = config.pageSize, lastPage = Math.floor((allitems.length - 1) / pageSize) + 1;
                return {
                    canGotoFirst: pageSize != 0 && currentpage > 1,
                    canGotoLast: pageSize != 0 && currentpage != lastPage,
                    canGotoPrev: pageSize != 0 && currentpage > 1,
                    canGotoNext: pageSize != 0 && currentpage < lastPage,
                    canGoto: pageSize != 0 && lastPage > 1,
                    lastPage: lastPage
                }
            };
            
            function deleteItem(id) {
                allitems.splice(getItemIndexByID(id), 1);
                refresh();
            }
            function refresh() {
                if (currentpage > getNavState().lastPage) {
                    currentpage = getNavState().lastPage;
                }
                BuildTable();
            }
            function getItemIndexByID(id) {
                if (allitems && allitems.length > 0) {
                    for (var i = 0; i < allitems.length; i++) {
                        if (allitems[i].PKID == id) {
                            return i;
                        }
                    }
                }
                return -1;
            }
            function getItemByID(id) {
                if (allitems && allitems.length > 0) {
                    for (var i = 0; i < allitems.length; i++) {
                        if (allitems[i].PKID == id) {
                            return allitems[i];
                        }
                    }
                }
                return null;
            }
            function getcurrentpage() {
                return currentpage;
            }
            function getshowitems() {
                return showitems;
            }
            function getallitems() {
                return allitems;
            }
            
            function BuildTableStruct() {
            
                $table.closest(".linetablediv").find("table[name='foot']").remove();
                $table.empty();
                $table.attr(
                {
                    "border": "0",
                    "cellpadding": "0",
                    "cellspacing": "0"
                }).css("border-collapse", "separate");
                $table.parent("div").css("position", "relative");
                var tablethlength = config.colNames.length; 
				var sthead = "";
                for (var i = 0; i < tablethlength; i++) {
                    sthead += "<th style=\"width:" + config.colWidth[i] + "\">" + config.colNames[i] + "</th>";
                }
                $table.append("<thead><tr class='headerstyleblue' style=\"height: 28px;\">" + sthead + "</tr></thead>");
                $table.append("<tbody></tbody>");
                var emptybody = "<tr style=\"height:28px;\"><td  colspan='" + tablethlength + "'> </td></tr>";
                $table.find("tbody").append(emptybody); 
                var $foot = $("<tfoot><tr style='28px'><th style=\"font-weight:normal;\" colspan='" + tablethlength +
                "'><div id='page'></div></th></tr></tfoot>");
                $page = $foot.find("#page");
                BindPage();
                if (config.scrollx) {
                    var $linetablediv = $table.closest(".linetablediv")
                    if ($linetablediv.parent("div[name='p']").length < 1) {
                        $linetablediv.wrap("<div name='p' style='position:relative;margin:8px;'></div>")
                    }
                    $linetablediv.css(
                    {
                        "position": "absolute",
                        "margin": "0",
                        "left": "0",
                        "right": "0",
                        "overflow": "hidden"
                    });
                    var divwidth = $linetablediv.parent("div[name='p']").outerWidth() - 2;
                    $table.width(config.width);
                    if ($table.closest(".scroll").length < 1) {
                        $table.wrap($("<div style='overflow-x:auto;overflow-y:hidden;' class=\"scroll\"></div>").width(divwidth));
                    }
                    $table.parent("div").after($("<table name='foot'></table>").width(divwidth).append($foot));
                    $linetablediv.unbind("resize").resize(function() {
                        var changewidth = $(this).width();
                        $table.parent("div").width(changewidth);
                        $(this).find("table[name='foot']").width(changewidth);
                    })
                }
                else {
                    $table.find("tbody").after($foot);
                }
                
                //绑定表头排序样式以及排序事件
                $tableHeaders = $table.find("thead th");
                
                $tableHeaders.each(function(index) {
                    var $this = $(this);
                    if (checkHeaderOptions(index) || $this.html() == "") {
                        this.sortDisabled = true;
                    }
                    if (!this.sortDisabled) {
                        $this.css("cursor", "pointer");
                        $this.find(".UpDown").remove();
                        $this.append("<span class='UpDown' style='width:20px;height:20px;'>&nbsp</span>");
                        $this.find(".UpDown").addClass(config.cssHeader);
						var key="";
						if(config.colTemplates[index]!="")
						{
							key = ((config.colTemplates[index]).match(/\b#\w*\b#|^#\w*\b#/)).toString();
						}
                        if (key != "") {
                            key = key.replace(/#/g, "");
                        }
                        
                        $this.toggle(function() {
                            $tableHeaders.find(".UpDown").removeClass("sortheaderSortUp").removeClass("sortheaderSortDown");
                            fastSort(key, true);
                            $this.find(".UpDown").removeClass("sortheaderSortUp").addClass("sortheaderSortDown");
                            BuildTable();
                        }, function() {
                            $tableHeaders.find(".UpDown").removeClass("sortheaderSortUp").removeClass("sortheaderSortDown");
                            fastSort(key, false);
                            $this.find(".UpDown").removeClass("sortheaderSortDown").addClass("sortheaderSortUp");
                            BuildTable();
                        });
                        
                    }
                });
                
            };
            
            function checkHeaderOptions(i) {
                if ((config.headers[i]) && (config.headers[i].sorter === false)) {
                    return true;
                };
                return false;
            };
            //排序方法
            function fastSort(field, ascending) {
                var oldToString = Object.prototype.toString;
                Object.prototype.toString = (typeof field == "function") ? field : function() {
                    return this[field]
                };
                allitems.sort(function(a, b) {
                    if ((/^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(a)) && (/^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(b))) {
                        return parseFloat(a.toString()) - parseFloat(b.toString());
                    }
                    else {
                        return (a.toString()).localeCompare(b.toString())
                    }
                    
                });
                if (!ascending) 
                    allitems.reverse();
                Object.prototype.toString = oldToString;
            };
            
            function BuildTableBody(items) {
                $table.find("tbody").empty();
                var tr = "";
                for (var i = 0; i < config.colTemplates.length; i++) {
                    tr += "<td>" + config.colTemplates[i] + "</td>"
                }
                tr = "<tr>" + tr + "</tr>";
                if (items && items.length > 0) {
                    for (var i = 0, l = items.length; i < l; i++) {
                        var t = tr;
                        for (var key in items[i]) {
                            var reg = new RegExp("#" + key + "#", "g");
                            t = t.replace(reg, items[i][key]);
                        }
                        $(t).appendTo($table.find("tbody"));
                    }
                }
                //绑定样式		
                $table.find("tbody tr").filter(':even').removeClass(config.widgetZebra.css[1]).addClass(config.widgetZebra.css[0]).attr("rowtype", config.widgetZebra.css[0]).end().filter(':odd').removeClass(config.widgetZebra.css[0]).addClass(config.widgetZebra.css[1]).attr("rowtype", config.widgetZebra.css[1]);
                $table.find("tbody tr").css("height", "28px").bind("mouseover", function() {
                    $(this).removeClass(config.widgetZebra.css[0]).removeClass(config.widgetZebra.css[1]);
                    $(this).addClass(config.cssMouseover);
                }).bind("mouseout", function() {
                    $(this).removeClass(config.cssMouseover);
                    $(this).addClass($(this).attr("rowtype"));
                });
                if (config.scrollx) {
                    $table.closest(".scroll").height(items.length * 28 + 48)
                }
            }
            //异步取数据
            function GetItems() {
                if (config.url != "") {
                    $table.after("<div class=\"loadingImage\" style=\"position:absolute;top:40%;left:47%;\"></div>");
                    CleanMessage();
                    $.ajax(
                    {
                        type: "get",
                        url: config.url,
                        data: config.data,
                        cache: false,
                        dataType: 'json',
                        success: function(ans) {
                            $table.next(".loadingImage").remove();
                            if (ans.error && ans.error.length > 0) {
                                CommonError(ans);
                            }
                            else {
                                allitems = ans.itemList;
                                BuildTable();
                                config.success(pmethods);
                            }
                        }
                    })
                }
                else {
                    allitems = config.items;
                    BuildTable();
                    config.success(pmethods);
                }
                
            }
            var defaults = 
            {
                url: "",
                items: [],
                data: {},
                pageSize: 10,
                currentPage: 1,
                colNames: [],
                colWidth: [],
                colTemplates: [],
				getrows:function(){},
                headers: {},
                width: 1400,
                scrollx: false,
                widgetZebra: 
                {
                    css: ["GridViewRowLink", "table_g"]
                },
                cssMouseover: "tablerow_mouseover",
                cssHeader: "sortheader",
                cssAsc: "sortheaderSortUp",
                cssDesc: "sortheaderSortDown",
                afterChangePage: function(currentpage) {
                },
                success: function() {
                }
            };
            /*
             function init() {
             config = $.extend({},defaults, settings);
             currentpage = config.currentPage<=0?1:config.currentPage;
             BuildTableStruct();
             GetItems();
             
             }
             */
            //init();
            var pmethods = 
            {
                "showitems": getshowitems,
                "allitems": getallitems,
                "deleteItem": deleteItem,
                "getItemByID": getItemByID,
                "currentpage": getcurrentpage,
                "refresh": refresh
            }
            this.methods = pmethods;
            config = $.extend({}, defaults, settings);
            currentpage = config.currentPage <= 0 ? 1 : config.currentPage;
            return this.each(function() {
                $table = $(this);
                BuildTableStruct();
                GetItems();
            });
            
            
        }
    });
    
})(jQuery);

