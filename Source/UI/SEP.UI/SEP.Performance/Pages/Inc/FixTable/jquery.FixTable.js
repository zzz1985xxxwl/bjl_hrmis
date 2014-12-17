(function ($) {
    $.fn.extend({
        FixTable: function (option) {
            var defaults = {
                columnIndex: 1,
                width: 900,
                height: 400,
                fixWidth: false,
                scrollTop: 0,
                recalcwidth: true
            }
            var option = $.extend({}, defaults, option);
            function Init($table) {
                var thead = $table.children("thead");
                var tbody = $table.children("tbody");
                var headStr = "<table>";
                var leftStr = "<table>";
                var topStr = "<table style='width:100%'>";
                var bodyStr = "<table>";
                thead.children("tr").each(function () {
                    headStr += "<tr>";
                    topStr += "<tr>";
                    var i = 0;
                    $(this).children("th,td").each(function () {
                        var $item = $(this);
                        var ntd = $(this.outerHTML);
                        if (option.recalcwidth) {
                            ntd.html("<div style='width:" + $item.width() + "px;'>" + ntd.html() + "</div>").width($item.outerWidth()).height($item.outerHeight());
                        }
                        if (i >= option.columnIndex) {
                            headStr += ntd[0].outerHTML;
                        } else {
                            topStr += ntd[0].outerHTML;
                        }
                        var colspan = parseInt(ntd.attr("colspan"));
                        if (!isNaN(colspan)) {
                            i += (colspan - 1);
                        }
                        i++;
                    })
                    headStr += "</tr>";
                    topStr += "</tr>";
                })
                headStr += "</table>";
                tbody.children("tr").each(function () {
                    leftStr += "<tr>";
                    bodyStr += "<tr>";
                    var templefts = $(this).find(".fixleft");
                    if (templefts.length > 0 && !option.recalcwidth) {
                        var l = $("<tr></tr>").append(templefts.clone()), r = $("<tr></tr>").append($(this).find(".fixright").clone());
                        leftStr += l.html();
                        bodyStr += r.html();
                    } else {
                        $(this).children("td").each(function (i, item) {
                            var $item = $(item);
                            var ntd = $(item.outerHTML);
                            if (option.recalcwidth) {
                                ntd.html("<div style='width:" + $item.width() + "px;'>" + ntd.html() + "</div>").width($item.outerWidth()).height($item.outerHeight());
                            }
                            if (ntd.hasClass("fixleft") || ntd.hasClass("fixright")) {
                                if (ntd.hasClass("fixright")) {
                                    bodyStr += ntd[0].outerHTML;
                                } else {
                                    leftStr += ntd[0].outerHTML;
                                }
                            } else {
                                if (i >= option.columnIndex) {
                                    bodyStr += ntd[0].outerHTML;
                                } else {
                                    leftStr += ntd[0].outerHTML;
                                }
                            }
                        })
                    }
                    bodyStr += "</tr>";
                    leftStr += "</tr>";
                })
                bodyStr += "</table>";
                leftStr += "</table>";
                var allwrap = $("<div class='fixTableDiv'></div>");
                var topDiv = $("<div class='fixTableTopDiv'>" + topStr + "</div>");
                var leftDiv = $("<div class='fixTableLeftDiv'><div>" + leftStr + "</div></div>");
                var headDiv = $("<div class='fixTableHeadDiv'><div>" + headStr + "</div></div>");
                var bodyDiv = $("<div class='fixTableBodyDiv'><div>" + bodyStr + "</div></div>");

                allwrap.append(topDiv).append(leftDiv).append(headDiv).append(bodyDiv);
                $table.after(allwrap);
                allwrap.before("<div class='autowidth'></div>");
                var tableid = $table.attr("id");
                $table.remove();
                var bodyTable = bodyDiv.children().children("table");
                bodyTable.attr("id", tableid);
               
                if (option.fixWidth != true) {
                    option.width = allwrap.prev().width();
                }
                
                var leftDivWith = leftDiv.outerWidth(), bodyDivWith = bodyDiv.outerWidth(), headDivheight = headDiv.outerHeight();
                headDiv.css({
                    "left": leftDivWith,
                    "width": bodyDivWith
                });
                bodyDiv.css({
                    "left": leftDivWith,
                    "top": headDivheight,
                    "width": bodyDivWith
                });
                leftDiv.css({
                    "top": topDiv.outerHeight(),
                    "width": leftDivWith
                });
                topDiv.css({
                    "width": leftDivWith
                })
                
                var bodyTRs = bodyDiv.children("div").children("table").children("tbody").children("tr");
                bodyTRs.click(function () {
                    //点击选中行
                    $(this).addClass("on").siblings().removeClass("on");
                })
                //平衡高度
                mationHeight(leftDiv.children("div").children("table").children().children("tr"), bodyTRs);
                mationHeight(topDiv.children("table").children().children("tr"), headDiv.children("div").children("table").children().children("tr"));
                var scrollHeight = 18;
                var rheight = headDiv.height() + bodyDiv.height();
                if (rheight > option.height) {
                    var newHeight = option.height - headDiv.height();
                    var oldHeigth = bodyDiv.height();
                    leftDiv.children("div").height(oldHeigth + scrollHeight);
                    bodyDiv.children("div").height(oldHeigth);
                    bodyDiv.height(newHeight);
                    leftDiv.height(newHeight);
                }
                var rwidth = topDiv.width() + headDiv.width();
                if (rwidth > option.width) {
                    var newWidth = option.width - topDiv.width();
                    var oldWidth = headDiv.width()
                    headDiv.children("div").width(oldWidth + scrollHeight);
                    headDiv.find("table:first").width(oldWidth);
                    bodyDiv.find("table:first").width(oldWidth);
                    bodyDiv.width(newWidth);
                    headDiv.width(newWidth);
                }
                if (rwidth > option.width && rheight <= option.height) {
                    allwrap.height(rheight + scrollHeight);
                }
                else if (rheight > option.height) {
                    allwrap.height(option.height);
                }
                else {
                    allwrap.height(rheight - 3);
                }

                bodyDiv.scroll(function () {
                    var $this = $(this);
                    headDiv.scrollLeft($this.scrollLeft());
                    leftDiv.scrollTop($this.scrollTop());
                });
            }
            function mationHeight(leftTRs, rightTRs) {
                if (rightTRs.children("td[rowspan],th[rowspan]").length == 0 && leftTRs.children("td[rowspan],th[rowspan]").length == 0) {
                    rightTRs.each(function (i, item) {
                        var lefttd = leftTRs.eq(i).children("td,th").eq(0);
                        var td = $(item).children("td,th").eq(0);
                        var tdHeight = td.height(), lefttdHeight = lefttd.height();
                        if (lefttdHeight > tdHeight) {
                            td.height(lefttdHeight + 1);
                        } else if (lefttdHeight < tdHeight) {
                            lefttd.height(tdHeight);
                        }
                    });
                }
            }
            return this.each(function () {
                var $this = $(this);
                Init($this);
            })
        }
    })
})(jQuery);
