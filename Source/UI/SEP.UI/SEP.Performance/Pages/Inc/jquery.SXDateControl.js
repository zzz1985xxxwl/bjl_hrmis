
Date.dayNames = ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'];

Date.abbrDayNames = ['日', '一', '二', '三', '四', '五', '六'];

Date.monthNames = ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'];

Date.abbrMonthNames = ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'];

Date.firstDayOfWeek = 1;

Date.format = 'yyyy-mm-dd';
//Date.format = 'mm/dd/yyyy';
//Date.format = 'yyyy-mm-dd';
//Date.format = 'dd mmm yy';

/**
 * The first two numbers in the century to be used when decoding a two digit year. Since a two digit year is ambiguous (and date.setYear
 * only works with numbers < 99 and so doesn't allow you to set years after 2000) we need to use this to disambiguate the two digit year codes.
 *
 * @name format
 * @type String
 * @cat Plugins/Methods/Date
 * @author Kelvin Luck
 */
Date.fullYearStart = '20';

function ToDate(stringDate) {
    return new Date(Date.parse(stringDate.replace(/-/g, "/")));
}

(function() {

    function add(name, method) {
        if (!Date.prototype[name]) {
            Date.prototype[name] = method;
        }
    };
    
    add("isLeapYear", function() {
        var y = this.getFullYear();
        return (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
    });
    
    add("isWeekend", function() {
        return this.getDay() == 0 || this.getDay() == 6;
    });
    
    add("isWeekDay", function() {
        return !this.isWeekend();
    });
    
    add("getDaysInMonth", function() {
        return [31, (this.isLeapYear() ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][this.getMonth()];
    });
    
    add("getDayName", function(abbreviated) {
        return abbreviated ? Date.abbrDayNames[this.getDay()] : Date.dayNames[this.getDay()];
    });
    
    add("getMonthName", function(abbreviated) {
        return abbreviated ? Date.abbrMonthNames[this.getMonth()] : Date.monthNames[this.getMonth()];
    });
    
    add("getDayOfYear", function() {
        var tmpdtm = new Date("1/1/" + this.getFullYear());
        return Math.floor((this.getTime() - tmpdtm.getTime()) / 86400000);
    });
    
    add("getWeekOfYear", function() {
        return Math.ceil(this.getDayOfYear() / 7);
    });
    
    add("setDayOfYear", function(day) {
        this.setMonth(0);
        this.setDate(day);
        return this;
    });
    
    add("addYears", function(num) {
        this.setFullYear(this.getFullYear() + num);
        return this;
    });
    
    add("addMonths", function(num) {
        var tmpdtm = this.getDate();
        
        this.setMonth(this.getMonth() + num);
        
        if (tmpdtm > this.getDate()) 
            this.addDays(-this.getDate());
        
        return this;
    });
    
    add("addDays", function(num) {
        //this.setDate(this.getDate() + num);
        this.setTime(this.getTime() + (num * 86400000));
        return this;
    });
    
    add("addHours", function(num) {
        this.setHours(this.getHours() + num);
        return this;
    });
    
    add("addMinutes", function(num) {
        this.setMinutes(this.getMinutes() + num);
        return this;
    });
    
    add("addSeconds", function(num) {
        this.setSeconds(this.getSeconds() + num);
        return this;
    });
    
    add("zeroTime", function() {
        this.setMilliseconds(0);
        this.setSeconds(0);
        this.setMinutes(0);
        this.setHours(0);
        return this;
    });
    
    add("asString", function(format) {
        var r = format || Date.format;
        return r.split('yyyy').join(this.getFullYear()).split('yy').join((this.getFullYear() + '').substring(2)).split('mmmm').join(this.getMonthName(false)).split('mmm').join(this.getMonthName(true)).split('mm').join(_zeroPad(this.getMonth() + 1)).split('dd').join(_zeroPad(this.getDate())).split('hh').join(_zeroPad(this.getHours())).split('min').join(_zeroPad(this.getMinutes())).split('ss').join(_zeroPad(this.getSeconds()));
        
    });
    
    add("equalDate", function(date) {
        return this.getFullYear() == date.getFullYear() && this.getMonth() == date.getMonth() && this.getDate() == date.getDate();
    });
    add("equalMonth", function(date) {
        return this.getFullYear() == date.getFullYear() && this.getMonth() == date.getMonth();
    });
	add("equal", function(date) {
        return this.getFullYear() == date.getFullYear() && this.getMonth() == date.getMonth()&& this.getDate() == date.getDate()&& this.getHours() == date.getHours()&& this.getMinutes() == date.getMinutes();
    });
    Date.fromString = function(s, format) {
        var f = format || Date.format;
        var d = new Date('01/01/1977');
        
        var mLength = 0;
        
        var iM = f.indexOf('mmmm');
        if (iM > -1) {
            for (var i = 0; i < Date.monthNames.length; i++) {
                var mStr = s.substr(iM, Date.monthNames[i].length);
                if (Date.monthNames[i] == mStr) {
                    mLength = Date.monthNames[i].length - 4;
                    break;
                }
            }
            d.setMonth(i);
        }
        else {
            iM = f.indexOf('mmm');
            if (iM > -1) {
                var mStr = s.substr(iM, 3);
                for (var i = 0; i < Date.abbrMonthNames.length; i++) {
                    if (Date.abbrMonthNames[i] == mStr) 
                        break;
                }
                d.setMonth(i);
            }
            else {
                d.setMonth(Number(s.substr(f.indexOf('mm'), 2)) - 1);
            }
        }
        
        var iY = f.indexOf('yyyy');
        
        if (iY > -1) {
            if (iM < iY) {
                iY += mLength;
            }
            d.setFullYear(Number(s.substr(iY, 4)));
        }
        else {
            if (iM < iY) {
                iY += mLength;
            }
            // TODO - this doesn't work very well - are there any rules for what is meant by a two digit year?
            d.setFullYear(Number(Date.fullYearStart + s.substr(f.indexOf('yy'), 2)));
        }
        var iD = f.indexOf('dd');
        if (iM < iD) {
            iD += mLength;
        }
        if (iD > -1) {
            d.setDate(Number(s.substr(iD, 2)));
        }
        if (isNaN(d.getTime())) {
            return false;
        }
        return d;
    };
    
    // utility method
    var _zeroPad = function(num) {
        var s = '0' + num;
        return s.substring(s.length - 2)
        //return ('0'+num).substring(-2); // doesn't work on IE :(
    };
    
})();

(function($) {
    SXMonthDateControl = function($monthcalendar, settings) {
        var defaults = 
        {
            dateClick: function() {
            }
        };
        var dateInfo = new function() {
        };
        var option = $.extend({}, defaults, settings);
        function dc(a) {
            return document.createElement(a);
        };
        function Init() {
            $monthcalendar.addClass("SXCalendar");
            $monthcalendar.children("thead").remove();
            $monthcalendar.append('<thead><tr><th class="thfirst">星期一</th><th class="th">星期二 </th><th class="th"> 星期三 </th><th class="th">星期四</th><th class="th">星期五</th><th class="th">星期六</th><th class="thlast">星期日</th></tr></thead>');
            if ($monthcalendar.find("tbody").length == 0) {
                $monthcalendar.append("<tbody></tbody>");
            }
            Render();
            $(window).resize(function() {
                InitWidth();
            });
        }
        function InitWidth() {
            var width = Math.floor(($("#hideforwidth").width() - 25) / 7 - 6);
            $monthcalendar.find(".content").width(width + 5);
        };
        
        function Render(syear, smonth) {
            $monthcalendar.find("tbody").empty();
            var addNotes = $monthcalendar.closest("div[name='self']").length > 0;
            var today = (new Date()).zeroTime();
            today.setHours(12);
            var month = smonth == undefined ? today.getMonth() : smonth;
            var year = syear || today.getFullYear();
            var currentDate = (new Date(year, month, 1, 12, 0, 0));
            var firstDayOffset = Date.firstDayOfWeek - currentDate.getDay() + 1;
            if (firstDayOffset > 1) 
                firstDayOffset -= 7;
            var weeksToDraw = 6;//Math.ceil(((-1 * firstDayOffset + 1) + currentDate.getDaysInMonth()) / 7);
            currentDate.addDays(firstDayOffset - 1);
            var w = 0;
            dateInfo.start = currentDate;
            while (w++ < weeksToDraw) {
                var $r = $(dc('tr'));
                var firstDayInBounds = false;
                for (var i = 0; i < 7; i++) {
                    var thisMonth = currentDate.getMonth() == month;
                    var $d = $(dc('td')).addClass((thisMonth ? 'current-month ' : 'other-month ') +
                    (currentDate.isWeekend() ? 'weekend ' : 'weekday ') +
                    (thisMonth && currentDate.getTime() == today.getTime() ? 'today ' : ''));
                    var $a = $(dc('a')).addClass("monthDay").data("date", currentDate).html(currentDate.getDate()).unbind().click(function() {
                        option.dateClick($(this).data("date"));
                    });
                    
                    if (addNotes) {
                        var $addItem = $("<div class='addItem'></div>");
                        $addItem.click(function(event) {
                            var $this = $(this);
                            $("#noteEdit").data('date', $this.prev(".monthDay").data('date'));
                            //$monthcalendar.find(".addItemOn").removeClass("addItemOn").hide();
                            //$this.addClass("addItemOn");
                            //$monthcalendar.find("tbody td").find(".addItem").hide();
                            //$this.show();
                            //$this.closest("td").unbind();
                            $("#addItemDiv").css(
                            {
                                'top': $this.offset().top + $this.outerHeight() - 1,
                                'left': $this.offset().left + $this.outerWidth() - $("#addItemDiv").outerWidth() - 1
                            }).slideDown('fast', function() {
                                $("body").unbind().bind("click", function(e) {
                                    if (!e) {
                                        var e = window.event;
                                    };
                                    if (!$(e.target).parents().andSelf().filter("#addItemDiv,.addItem ").length) {
                                        $("#addItemDiv").hide();
                                        $("body").unbind();
                                        //$monthcalendar.find(".addItemOn").removeClass("addItemOn").hide();
                                    }
                                })
                            });
                        })
                        /*
                         $d.hover(function() {
                         $(this).find(".addItem").not(".addItemOn").show()
                         }, function() {
                         $(this).find(".addItem").not(".addItemOn").hide()
                         });
                         */
                    }
                    var $ap = $("<div class='monthDayDiv'></div>").append($a).append($addItem);
                    $d.append($ap).append("<div class='content'></div>");
                    $r.append($d);
                    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1, 12, 0, 0);
                }
                $monthcalendar.find("tbody").append($r);
            }
            InitWidth();
            dateInfo.end = currentDate;
        };
        function GetDateInfo() {
            return dateInfo;
        };
        Init();
        return {
            "Render": Render,
            "GetDateInfo": GetDateInfo
        }
    }
    SXDayDateControl = function($theday) {
        var mawidth;
        function Init() {
            $theday.empty();
            for (var i = 0; i < 24; i++) {
                var time = (i % 12) == 0 ? 12 : (i % 12);
                var mors = i < 12 ? "上午" : "下午";
                $theday.append('<div class="oneday" unselectable="on"><div style="width: 60px;" class="mr"  unselectable="on"><span unselectable="on">' + time + '</span>' + mors + '</div><div class="ma" unselectable="on"><div class="a thm" unselectable="on"> </div><div class="b thm" unselectable="on"></div></div></div>');
            }
            InitWidth();
            $theday.closest(".thedaycontainer").scrollTop(40 * 8 + 8);
            $(window).resize(function() {
                InitWidth()
            });
        }
        function InitWidth() {
            mawidth = $("#hideforwidth").width() - 27 - 79;
            $theday.find(".ma").width(mawidth);
        }
   
        function RenderItem(items) {
            var addNotes = $theday.closest("div[name='self']").length > 0;
            $theday.find(".thm").css("background-color", "#FFFFFF");
            $theday.find(".item").remove();
            if (items == null || typeof items == "undefined" || items.length <= 0) {
                return;
            }
            function Repeat(index) {
                
                var repeatitem = new Array;
                if(items[index].CType.ID==0){
                  return repeatitem;
                }
                var start = items[index].Start;
                var end = items[index].End;
                if (start.getTime() == end.getTime()) {
                    end = end.addMinutes(22.5);
                }
                $.each(items, function(i, item) {
                    if (i != index && item.CType.ID != 0) {
                        var itemend = item.End;
                        if (item.Start.getTime() == item.End.getTime()) {
                            itemend = itemend.addMinutes(22.5);
                        }
                        if (item.Start < end && itemend > start) {
                            repeatitem.push(item);
                        }
                    }
                })
                items[index].repeatitem = repeatitem;
                return repeatitem;
            };
            function RepeatMaxCount() {
                var count = 0;
                for (var i = 0; i < items.length; i++) {
                    items[i].added = false;
                    var c = Repeat(i).length;
                    if (c > count) {
                        count = c;
                    }
                }
                return count > 0 ? count + 1 : 0;
            };
			 if (addNotes) {
			 	
                    $theday.unbind("mousedown").mousedown(function(event) {
						if ($(event.target).hasClass("item")) {
							if ($(event.target).attr("ctype") == "6") {
								noteUpdateShow($(event.target).attr("pkid"));
								return;
							}
						}
						
                        var $target = $(event.target).closest(".theday");
                    
                        if ($target.hasClass("theday")) {
                            var $newEvent = $("<div class='item itemnote'></div>");
							if($target.find(".item").length>0)
							{
								$newEvent.width($target.find(".item").width());
							}
                            $target.append($newEvent); 
                            var columnOffset = $target.offset().top;
                            var clickY = event.pageY - columnOffset;
                            var clickYRounded = (clickY - (clickY % 10)) / 10;
                            var topPosition = clickYRounded * 10;
							var leftPostion=event.pageX-$target.offset().left-$newEvent.outerWidth()/2;
							if(leftPostion<62){leftPostion=62;}
                            $newEvent.css(
                            {
                                top: topPosition,
								left:leftPostion
                            });
                           
                            $target.unbind("mousemove.newevent").bind("mousemove.newevent", function(event) {
                                $newEvent.show();
                                $newEvent.addClass("ui-resizable-resizing");
                                var height = Math.round(event.pageY - columnOffset - topPosition);
                                var remainder = height % 10;
                                //snap to closest timeslot
                                if (remainder < (height / 2)) {
                                    var useHeight = height - remainder;
                                    $newEvent.css("height", useHeight < 10 ? 10 : useHeight);
                                }
                                else {
                                    $newEvent.css("height", height + (10 - remainder));
                                }
                            }).mouseup(function() {
                                $target.unbind("mousemove.newevent");
								var now=othercomm.dateDay();
								var dtstart=new  Date(now.getFullYear(),now.getMonth(), now.getDate(),0);
								var dtend=new  Date(now.getFullYear(),now.getMonth(), now.getDate(),0);
								dtstart.addMinutes(topPosition/20*30);
								dtend.addMinutes(topPosition/20*30+$newEvent.outerHeight()/20*30);
								if (!dtstart.equal(dtend) ) {
									$theNewNote = $newEvent;
									Notes.AddNew(dtstart, dtend);
								}
								$target.unbind("mouseup");
                            });
                        }
                        
                    })
                    
                }
            var maxcount = RepeatMaxCount();
            $.each(items, function(i, item) {
                if (item.CType.ID == 0) {
                    function GetMinutesIndex(min) {
                        var m = min / 30;
                        if (m == 0) {
                            return -1;
                        }
                        else 
                            if (m > 1) {
                                return 1;
                            }
                            else {
                                return 0;
                            }
                        
                    }
                    var begin = item.Start.getHours() * 2 + (item.Start.getMinutes() / 30 >= 1 ? 1 : 0);
                    var end = item.End.getHours() * 2 + GetMinutesIndex(item.End.getMinutes());
                    for (var i = begin; i <= end; i++) {
                        $theday.find(".thm").eq(i).css("background-color", "#ffeded");
                    }
                    return;
                }
                var $itemdiv = $('<div class="item" ctype="'+item.CType.ID+'" pkid="'+item.ObjectID +'">' + item.DayDetail + '</div>');
                var height = (item.End.getTime() - item.Start.getTime()) / 3600000 * 39 + (item.End.getTime() - item.Start.getTime()) / 3600000;
                if (height <= 0) {
                    height = 15;
                }
                var width = mawidth / maxcount;
                if (width > 200) {
                    width = 200;
                }
                var top = item.Start.getHours() * 39 + item.Start.getHours() + item.Start.getMinutes() / 60 * 39;
                var left = 63;
                $.each(item.repeatitem, function(ii, iitem) {
                    if (iitem.added) {
                        left =left>iitem.left+width - 4?left:iitem.left+width - 4;
                    }
                });
                $itemdiv.css(
                {
                    "top": top,
                    "left": left,
                    "background-color": item.CType.Color,
                    "height": height,
                    "width": width
                });
                $theday.append($itemdiv);
               
                /*
                 $itemdiv.resizable({
                 grid:10,
                 containment:$theday,
                 handles: "s"
                 });
                 $itemdiv.draggable(
                 {
                 containment: $theday,
                 grid: [10,10],
                 axis: 'y'
                 });
                 */
                items[i].added = true;
				items[i].left = left;
            })
            
        }
        Init();
        return {
            "RenderItem": RenderItem
        }
    }
})(jQuery);
//参数声明
var otherAccountList = new Array();
var loading = false, isMonth = true, showDialogData, showDialogType, othercomm = new Othercomm();
var $calendarlist, Month = new Month(), Day = new Day(), CDialog = new CDialog(), Notes = new Notes();
var $theNewNote;
var OtherAccount, CommonSets;
function SetInfo(_type, _checked) {
    this.type = _type;
    this.checked = _checked;
};
function OtherAccountInfo(_dateMonth, _dateDay, _sxMonthDateControl, _sxDayDateControl) {
    this.DateMonth = _dateMonth;
    this.DateDay = _dateDay;
    this.SXMonthDateControl = _sxMonthDateControl;
    this.SXDayDateControl = _sxDayDateControl;
};
//入口
$(document).ready(function() {
    $calendarlist = $("#calendarlist");
    OtherAccount = new OtherAccount();
    CommonSets = new CommonSets();
    OtherAccount.Init();
    CommonSets.Init();
    Month.Init();
    Notes.Init();
})
//将显示项设置变成 ，如：0|1|2的格式
function GetTypeList() {
    var setInfo = $.evalJSON($.cookie("CalendarExtPage_SetInfo"));
    var list = "";
    $.each(setInfo, function(i, item) {
        if (item.checked == true) {
            list += (item.type + "|");
        }
    });
    if (list.charAt(list.length - 1) == '|') {
        list = list.substring(0, list.length - 1);
    }
    return list;
}

//当用控件选择日期时触发
function ChangeDate() {
    var newDate = ToDate($("#nowDate").val());
    if (isMonth) {
        $("#nowDate").val(othercomm.dateMonth().asString("yyyy-mm"));
        if (newDate.equalMonth(othercomm.dateMonth())) {
            return;
        }
        othercomm.SetDateMonth(newDate);
        Month.InitMonthDate();
    }
    else {
        if (newDate.equalDate(othercomm.dateDay())) {
            return;
        }
        othercomm.SetDateDay(newDate);
        Day.InitDayDate();
    }
}

function InitDatePickerValue() {
    if ($("#nowDate").val() != '') {
        if (isMonth) {
            $('.date-pick').dpSetSelected($("#nowDate").val(), true, true, "yyyy-mm");
        }
        else {
            $('.date-pick').dpSetSelected($("#nowDate").val());
        }
    }
}

function LoadingOn() {
    loading = true;
    $(".calendarLoading").show();
}

function LoadingOff() {
    $(".calendarLoading").fadeOut(function() {
        loading = false;
    })
}

function conshowmenutext(num) {
    $("#tabtitle").find("div").each(function(i, item) {
        i = i + 1;
        if (num == (i)) {
            $("#floatbt" + i).attr("class", "floatbtbg");
            $("#floatdiv" + i).attr("class", "showdiv");
        }
        else {
            $("#floatbt" + i).attr("class", "floatsetbt");
            $("#floatdiv" + i).attr("class", "hiddendiv");
        }
    });
}

function CommonSets() {
    function Init() {
        if ($.browser.mozilla) {
            $("#calendarlist .monthCalendar").css(
            {
                "border-left": "1px solid #69AD3C"
            });
        }
        //当没有设置选项时，根据默认值保存一遍cookie
        if ($.cookie("CalendarExtPage_SetInfo") == null || $.cookie("CalendarExtPage_SetInfo") == "") {
            SaveSet();
        }
        else {
            var setInfo = $.evalJSON($.cookie("CalendarExtPage_SetInfo"));
            $.each(setInfo, function(i, item) {
                $("#CalendarExtView1_typeUL li input").filter("[value='" + item.type + "']").attr("checked", item.checked);
            });
        }
        $('.date-pick').datePicker(
        {
            verticalOffset: 20,
            horizontalOffset: -50
        });
        
        $(".infoborder").dialog(
        {
            autoOpen: false,
            modal: true,
            width: 600,
            resizable: false
        });
        
        //显示月视图
        $("#monthview").unbind().click(function() {
            isMonth = true;
            othercomm.GetMonthCalendar().show();
            othercomm.GetDayCalendar().hide();
            if (!otherAccountList[othercomm.NowIndex()].added) {
                Month.Init();
            }
            Month.InitMonthSelector();
            $("#monthview").removeClass("ctap").addClass("ctapon");
            $("#dayview").removeClass("ctapon").addClass("ctap");
        });
        //显示日视图
        $("#dayview").unbind().click(function() {
            isMonth = false;
            othercomm.GetMonthCalendar().hide();
            othercomm.GetDayCalendar().show();
            Day.Init();
            Day.InitDaySelector();
            $("#monthview").removeClass("ctapon").addClass("ctap");
            $("#dayview").removeClass("ctap").addClass("ctapon");
            
        });
        
        //显示或隐藏设置显示项
        $("#set").unbind().click(function() {
            if ($("#typeDiv").css("display") == "block") {
                HideSet();
            }
            else {
                ShowSet();
            }
            
        })
        $("#btnSaveSet").unbind().click(function() {
            SaveSetClick()
        });
        $("#btnHideSet").unbind().click(function() {
            HideSet()
        })
    }
    this.Init = Init;
    //保存显示项设置
    function SaveSet() {
        var setInfo = [];
        $("#CalendarExtView1_typeUL").find("li input").each(function() {
            setInfo.push(new SetInfo($(this).val(), $(this).attr("checked")));
        });
        $.cookie("CalendarExtPage_SetInfo", $.toJSON(setInfo), 
        {
            expires: 500
        });
    }
    
    function SaveSetClick() {
        SaveSet();
        HideSet();
        $.each(otherAccountList, function(i, item) {
            if (item.added) {
                item.added = false;
            }
        });
        Month.InitMonthDate();
    }
    
    //隐藏显示项设置
    function HideSet() {
        $(".popdiv").hide();
        $("body").unbind();
    }
    
    //显示显示项设置
    function ShowSet() {
        var setInfo = $.cookie("CalendarExtPage_SetInfo");
        if (setInfo != null && setInfo != "") {
            setInfo = $.evalJSON(setInfo);
            
            $.each(setInfo, function(i, item) {
                $("#CalendarExtView1_typeUL li input").filter("[value='" + item.type + "']").attr("checked", item.checked);
            });
        }
        $("#typeDiv").slideDown("fast", function() {
            $("body").unbind().bind("click", function(e) {
                if (!e) {
                    var e = window.event;
                };
                if (!$(e.target).parents().andSelf().filter("#typeDiv").length) {
                    HideSet();
                }
            });
        });
        
    }
}

/*
 月视图
 */
function Month() {
    function Init() {
        othercomm.SetSXMonthDateControl(new SXMonthDateControl(othercomm.GetCalendar()));
        GetADayList();
        InitMonthSelector();
    };
    this.Init = Init;
    this.InitMonthDate = InitMonthDate;
    this.InitMonthSelector = InitMonthSelector;
    //月视图的日期左右移动事件
    function InitMonthSelector() {
        $("#nowDate").val(othercomm.dateMonth().asString("yyyy-mm"));
        InitDatePickerValue();
        $("#prev").unbind().click(function() {
            if (loading) {
                return;
            }
            othercomm.dateMonth().addMonths(-1);
            InitMonthDate();
            InitDatePickerValue();
        });
        $("#next").unbind().click(function() {
            if (loading) {
                return;
            }
            othercomm.dateMonth().addMonths(1);
            InitMonthDate();
            InitDatePickerValue();
        });
    };
    //画月视图
    function InitMonthDate() {
        if (isMonth) {
            $("#nowDate").val(othercomm.dateMonth().asString("yyyy-mm"));
        }
        othercomm.sxMonthDateControl().Render(othercomm.dateMonth().getFullYear(), othercomm.dateMonth().getMonth());
        GetADayList();
    };
    //显示小窗口详细内容
    function ShowDetailDialog(date, type) {
        showDialogData = date;
        showDialogType = type;
        CDialog.ShowDetail(date, type);
        $(".infoborder").dialog('open');
    };
    //为页面获取数据
    function GetADayList() {
        var startstr = othercomm.sxMonthDateControl().GetDateInfo().start.asString(), endstr = othercomm.sxMonthDateControl().GetDateInfo().end.asString();
        LoadingOn();
        $.ajax(
        {
            url: 'CalendarExtHandler.ashx',
            dataType: 'json',
            data: 
            {
                type: 'GetCalendarADayList',
                start: startstr,
                end: endstr,
                typeList: GetTypeList(),
                name: $calendarlist.children(".calendaron").attr("accountName")
            },
            cache: false,
            success: function(ans) {
                LoadingOff();
                //画月视图
                othercomm.GetCalendar().find(".monthDay .content").empty();
                if (ans.aDayList && ans.aDayList.length > 0) {
                    var adaylist = ans.aDayList;
                    othercomm.sxMonthDateControl().adaylist = adaylist;
                    $.each(ans.aDayList, function(i, aday) {
                        othercomm.GetCalendar().find(".monthDay").each(function() {
                            var $thedata = $(this), $content = $(this).closest("td").find(".content");
                            if ($thedata.data("date").equalDate(aday.Date)) {
                                if (aday.MonthItems && aday.MonthItems.length > 0) {
                                    for (var j = 0; j < aday.MonthItems.length; j++) {
                                        if (j == 3 && aday.MonthItems.length > 4) {
                                            var $morelink = $("<a class='hoverline' type='" + aday.MonthItems[j].CType.ID + "' style='color:#000000' >+" + (aday.MonthItems.length - 3) + " 更多</a>").unbind().click(function() {
                                                ShowDetailDialog(aday.Date, $(this).attr("type"));
                                            }).wrap("<div></div>")
                                            $content.append($morelink);
                                            break;
                                        }
                                        else {
                                            $content.append($("<div><a class='hoverline' type='" + aday.MonthItems[j].CType.ID + "' style='color:" + aday.MonthItems[j].CType.Color + ";'  title='"+aday.MonthItems[j].Title +"'>" + aday.MonthItems[j].Title + "</a></div>").unbind().click(function() {
                                                ShowDetailDialog(aday.Date, $(this).find("a").attr("type"))
                                            }));
                                            if (aday.MonthItems[j].BackgroundColor) {
                                                $content.css("background-color", aday.MonthItems[j].BackgroundColor);
                                            }
                                        }
                                    }
                                }
                            }
                        })
                    })
                }
                //画节日
                if (ans.holidayList && ans.holidayList.length > 0) {
                    $.each(ans.holidayList, function(i, item) {
                        othercomm.GetCalendar().find(".monthDay").each(function() {
                            if ($(this).data("date").equalDate(item.Date)) {
                                $(this).html(item.Name + $(this).html());
                            }
                        })
                    });
                }
                
                //如果显示日视图则更新之
                if (!isMonth) {
                    Day.InitDayDate();
                }
                if ($(".infoborder").css("display") == "block" && $(".infoborder").closest("..ui-dialog").css("display") == "block") {
                    CDialog.ShowDetail(showDialogData, showDialogType);
                }
                otherAccountList[othercomm.NowIndex()].added = true;
                
            }
        });
    }
}

/*
 日试图
 */
function Day() {
    //页面加载时调用
    function Init() {
        othercomm.SetSXDayDateControl(new SXDayDateControl(othercomm.GetDayCalendar().find(".theday")));
        InitDayDate();
    }
    
    this.Init = Init;
    this.InitDaySelector = InitDaySelector;
    this.InitDayDate = InitDayDate;
    //日视图的日期左右移动事件
    function InitDaySelector() {
        InitDatePickerValue();
        $("#prev").unbind().click(function() {
            if (loading) {
                return;
            }
            othercomm.dateDay().addDays(-1);
            InitDayDate();
            InitDatePickerValue();
        });
        $("#next").unbind().click(function() {
            if (loading) {
                return;
            }
            othercomm.dateDay().addDays(1);
            InitDayDate();
            InitDatePickerValue();
        });
    }
    //更新日试图内容
    function InitDayDate() {
        $("#nowDate").val(othercomm.dateDay().asString());
        othercomm.GetToDayWeek().html(othercomm.dateDay().getDayName());
        DayRenderItem(othercomm.dateDay());
    }
    //画日视图中的每一项，如果能在月视图显示范围内的数据中找到，则直接取该数据，如果不在月视图显示范围内，则ajax取数据
    function DayRenderItem(day) {
        if (othercomm.sxMonthDateControl() && day >= othercomm.sxMonthDateControl().GetDateInfo().start && day <= othercomm.sxMonthDateControl().GetDateInfo().end) {
            var find = false, adaylist = othercomm.sxMonthDateControl().adaylist;
            if (adaylist && adaylist.length > 0) {
                for (var i = 0; i < adaylist.length; i++) {
                    if (adaylist[i].Date.equalDate(day)) {
                        othercomm.sxDayDateControl().RenderItem(adaylist[i].DayItems);
                        find = true;
                        break;
                    }
                }
            }
            if (!find) {
                othercomm.sxDayDateControl().RenderItem(null);
            }
        }
        else {
            AjaxRenderDayItem(day);
        }
    }
    
    function AjaxRenderDayItem(day) {
        LoadingOn();
        $.ajax(
        {
            url: 'CalendarExtHandler.ashx',
            dataType: 'json',
            data: 
            {
                type: 'GetDayItems',
                date: day.asString(),
                typeList: GetTypeList(),
                name: $calendarlist.children(".calendaron").attr("accountName")
            },
            cache: false,
            success: function(ans) {
                LoadingOff();
                othercomm.sxDayDateControl().RenderItem(ans.dayItems);
            }
        });
    }
}

/*
 小界面
 */
function CDialog() {
    this.ShowDetail = ShowDetail;
    function ShowDetail(date, type) {
        // 选择初始显示的tab页
        var selectTypeIndex = 0;
        // 清空Tab
        $("#tab_list").empty();
        // 显示当前天
        $("#displayDate").html(date.asString());
        
        // 获取要显示的tab页
        var setInfo = $.cookie("CalendarExtPage_SetInfo");
        
        if (setInfo != null && setInfo != "") {
            setInfo = $.evalJSON(setInfo);
        }
        
        var tabList = new Array(), adaylist = othercomm.sxMonthDateControl().adaylist;
        if (adaylist && adaylist.length > 0) {
            $.each(adaylist, function(i, aday) {
                // 判断daylist的日期是否是选中的那天
                if (date.equalDate(aday.Date)) {
                    // 当天的所有事件
                    if (aday.MonthItems && aday.MonthItems.length > 0) {
                        var isIndex = true;
                        // 获取当前页面需要显示的tab页
                        $.each(setInfo, function(i, item) {
                            var tempDetail = '';
                            var tempTitle = '';
                            $.each(aday.MonthItems, function(i, monthItem) {
                            
                                // 是否需要显示
                                if (monthItem.CType.ID == item.type && item.checked) {
                                    tempTitle = monthItem.CType.Name
                                    if (tempDetail) {
                                        tempDetail = tempDetail + "<div></div>" + monthItem.Detail
                                    }
                                    else {
                                        tempDetail = monthItem.Detail;
                                    }
                                }
                            });
                            
                            if (tempTitle) {
                                tabList.push(
                                {
                                    title: tempTitle,
                                    html: tempDetail,
                                    callback: function() {
                                    }
                                });
                            }
                            else 
                                if (item.checked) {
                                    tabList.push(
                                    {
                                        title: GetNameByType(item.type),
                                        html: " ",
                                        callback: function() {
                                        }
                                    });
                                }
                            // 计算需要显示在第几个tab页上
                            if (item.checked && isIndex) {
                                if (type) {
                                    if (item.type.toString() == type.toString()) {
                                        isIndex = false;
                                    }
                                    else {
                                        selectTypeIndex++;
                                    }
                                }
                                else {
                                    selectTypeIndex = 0;
                                }
                                
                            }
                        })
                    }
                }
            })
        }
        // 当一条记录都没有显示所有勾选的tab空页
        if (tabList.length == 0) {
            $.each(setInfo, function(i, item) {
                if (item.checked) {
                    tabList.push(
                    {
                        title: GetNameByType(item.type),
                        html: " ",
                        callback: function() {
                        }
                    });
                }
            });
        }
        if (tabList.length > 6) {
            $("#tab_list").Tab(
            {
                items: tabList,
                tabSelectIndex: selectTypeIndex
            });
        }
        else {
            $("#tab_list").Tab(
            {
                items: tabList,
                tabSelectIndex: selectTypeIndex,
                tabScroll: false
            });
        }
    }
    
    function GetNameByType(type) {
        return $("#CalendarExtView1_typeUL li input").filter("[value='" + type + "']").next("span").html();
    }
}

/*
 查看他人日历
 */
function OtherAccount() {
    function Info(_name) {
        this.Name = _name;
    }
    var $namelist = $("#namelist"), $up = $("#nameup"), $down = $("#namedown"), $vessel = $("#updownvessel");
    var $btnaddother = $("#addother"), cookiename = "CalendarExtPage_OtherAccount", canReturn = false;
    function Init() {
        $calendarlist.children("div[name='self']").attr("accountName", $namelist.children(".self").attr("name"));
        //添加本人信息
        othercomm.PushAccount();
        //绑定事件：打开关闭添加员工div
        $btnaddother.unbind().click(function() {
            if ($("#addotherDiv").css("display") == "block") {
                HideSet();
            }
            else {
                ShowSet();
            }
        });
        //绑定事件：添加员工
        $("#btnaddanother").unbind().bind("click", function() {
            if (canReturn) {
                AddAccount($("#addotherDiv").find("input").val());
                $("#addotherDiv").find("input").val("");
            }
            else {
                alert("请通过选择添加他人日历")
            }
        })
        //从cookie中读出添加到人员，并加载
        if ($.cookie(cookiename) && $.cookie(cookiename) != "") {
            var setInfo = $.evalJSON($.cookie(cookiename));
            $.each(setInfo, function(i, item) {
                AddOneEvent(item.Name);
            })
        }
        else {
            var setInfo = [];
            SaveCookie(setInfo);
        }
        BindUpDown();
        BindAllEvent();
        $("#addotherDiv").find("input").keydown(function(event) {
            if (event.keyCode == 13 && canReturn) {
                AddAccount($(this).val());
                $(this).val("");
                event.preventDefault();
            }
            else {
                canReturn = false;
            }
        })
        $("#addotherDiv").find("input").autocomplete("../../GoogleDown.ashx?type=Subordinates", 
        {
            mouseovershow: false
        });
        $("#addotherDiv").find("input").result(function(event, data, formatted) {
            canReturn = true;
        });
    };
    function BindAllEvent() {
        ShowUpDown();
        //AddLastBorder();
        BindChoseAccount();
        BindClose();
    };
    //添加一个人后的事件
    function AddOneEvent(name) {
        $namelist.append("<div class='nametab' name='" + name + "'>" + name + "</div>");
        othercomm.PushAccount();
        $calendarlist.append("<div accountName='" + name + "' class='calendaroff'><div class='monthCalendar'><table class='calendar' cellspacing='0' cellpadding='0' width='100%'></table></div><div class='dayCalendar' style='display:none; '><div class='toDayWeek fontBlackStrong'></div><div class='thedaycontainer'><div class='theday'></div></div></div></div>")
    }
    function DeleteOneEvent(name) {
        var removediv = $calendarlist.children("div[accountName='" + name + "']");
        var index = $calendarlist.children("div").index(removediv);
        othercomm.DeleteAccount(index);
        removediv.remove();
        if (removediv.hasClass("calendaron")) {
            $namelist.scrollTop(0);
            $namelist.find(".self").trigger("click");
        }
    }
    function AddAccount(name) {
        canReturn = false;
        name = $.trim(name)
        if (name != "") {
            var setInfo = $.evalJSON($.cookie(cookiename));
            var exist = false;
            if (name == $namelist.find(".self").html()) {
                exist = true;
            }
            else {
                $.each(setInfo, function(i, item) {
                    if (item.Name == name) {
                        exist = true;
                        return false;
                    }
                });
            }
            if (!exist) {
                AddOneEvent(name);
                BindAllEvent();
                var setInfo = $.evalJSON($.cookie(cookiename));
                setInfo.push(new Info(name));
                SaveCookie(setInfo);
            }
            else {
                alert("该员工已经存在");
            }
            
        }
    }
    function SaveCookie(setInfo) {
        $.cookie(cookiename, $.toJSON(setInfo), 
        {
            expires: 500
        });
    }
    /*
     function AddLastBorder() {
     //$namelist.find("div:not(:last)").css("border-bottom", "none");
     //$namelist.find("div:last").css("border-bottom", "1px solid #69ad3c");
     }
     */
    function BindClose() {
        $namelist.find("div").not(".self").unbind("hover").hover(function() {
            var $this = $(this);
            var $close = $("<div class='close'></div>").click(function() {
                var setInfo = $.evalJSON($.cookie(cookiename));
                $.each(setInfo, function(i, item) {
                    if (item.Name == $this.attr("name")) {
                        setInfo.splice(i, 1);
                        DeleteOneEvent(item.Name);
                        return false;
                    }
                });
                SaveCookie(setInfo);
                $this.remove();
                ShowUpDown();
                //AddLastBorder();
            });
            $this.append($close);
        }, function() {
            $(this).find(".close").remove();
        });
    }
    //点击某个人名后的事件
    function BindChoseAccount() {
        $namelist.find("div").unbind("click").click(function() {
            $namelist.find(".nametabon").removeClass("nametabon").addClass("nametab");
            $(this).removeClass("nametab").addClass("nametabon");
            $calendarlist.children(".calendaron").removeClass("calendaron").addClass("calendaroff");
            $calendarlist.children("div[accountName='" + $(this).attr("name") + "']").removeClass("calendaroff").addClass("calendaron");
            if (isMonth) {
                othercomm.GetMonthCalendar().show();
                othercomm.GetDayCalendar().hide();
                if (!otherAccountList[othercomm.NowIndex()].added) {
                    Month.Init();
                }
                Month.InitMonthSelector();
            }
            else {
                othercomm.GetMonthCalendar().hide();
                othercomm.GetDayCalendar().show();
                Day.Init();
                Day.InitDaySelector();
            }
        });
    }
    //隐藏设置
    function HideSet() {
        $(".popdiv").hide();
        $("body").unbind();
    }
    //显示设置
    function ShowSet() {
        $("#addotherDiv").slideDown("fast", function() {
            $("body").unbind().bind("click", function(e) {
                if (!e) {
                    var e = window.event;
                };
                if (!$(e.target).parents().andSelf().filter("#addotherDiv").length) {
                    HideSet();
                }
            });
        });
        
    }
    //绑定上下箭头事件
    function BindUpDown() {
        var divitemheight = $namelist.find("div").eq(0).outerHeight();
        $down.unbind().click(function() {
            if (GetTop() >= ($namelist.find("div").length * divitemheight - $namelist.outerHeight())) {
                return;
            }
            var newtop = GetTop() + divitemheight;
            $namelist.animate(
            {
                'scrollTop': newtop
            }, '1000')
            $up.attr("class", "nameup");
            if (newtop >= ($namelist.find("div").length * divitemheight - $namelist.outerHeight())) {
                $down.attr("class", "namedowndisable");
            }
        })
        $up.unbind().click(function() {
            if (GetTop() <= 0) {
                return;
            }
            var newtop = GetTop() - divitemheight;
            $namelist.animate(
            {
                'scrollTop': newtop
            }, '1000')
            $down.attr("class", "namedown");
            if (newtop <= 0) {
                $up.attr("class", "nameupdisable");
            }
        })
    };
    //控制是否显示上下箭头
    function ShowUpDown() {
        var divitemheight = $namelist.find("div").eq(0).outerHeight();
        if ($namelist.find("div").length * divitemheight <= $namelist.outerHeight()) {
            $vessel.hide();
            return false;
        }
        else {
            $vessel.show();
            return true;
        }
    };
    function GetTop() {
        return $("#namelist").scrollTop();
    };
    this.Init = Init;
}

function Othercomm() {
    this.dateMonth = function() {
        return otherAccountList[NowIndex()].DateMonth
    };
    this.dateDay = function() {
        return otherAccountList[NowIndex()].DateDay
    };
    this.SetDateMonth = function(d) {
        return otherAccountList[NowIndex()].DateMonth = d;
    };
    this.SetDateDay = function(d) {
        return otherAccountList[NowIndex()].DateDay = d;
    };
    this.sxMonthDateControl = function() {
        return otherAccountList[NowIndex()].SXMonthDateControl
    };
    this.sxDayDateControl = function() {
        return otherAccountList[NowIndex()].SXDayDateControl
    };
    this.SetSXMonthDateControl = function(sx) {
        otherAccountList[NowIndex()].SXMonthDateControl = sx;
    }
    this.SetSXDayDateControl = function(sx) {
        otherAccountList[NowIndex()].SXDayDateControl = sx;
    }
    this.GetCalendar = function() {
        return GetMonthCalendar().find(".calendar");
    };
    this.GetToDayWeek = function() {
        return GetDayCalendar().find(".toDayWeek");
    };
    this.GetTheday = function() {
        return GetDayCalendar().find(".theday");
    };
    this.GetMonthCalendar = GetMonthCalendar;
    this.GetDayCalendar = GetDayCalendar;
    this.NowIndex = NowIndex;
    this.PushAccount = function() {
        otherAccountList.push(new OtherAccountInfo(new Date(), new Date(), null, null))
    }
    this.DeleteAccount = function(index) {
        otherAccountList.splice(index, 1);
    }
    function GetMonthCalendar() {
        return $calendarlist.children(".calendaron").children(".monthCalendar");
    }
    function GetDayCalendar() {
        return $calendarlist.children(".calendaron").children(".dayCalendar");
    }
    function NowIndex() {
        return $calendarlist.children("div").index($calendarlist.children(".calendaron"));
    }
    
}

function Notes() {
    function Init() {
        //便签
        $("#noteEdit").dialog(
        {
            autoOpen: false,
            modal: true,
            width: 640,
            resizable: false
        });
        $(".noteDatePicker").datePicker(
        {
            verticalOffset: 20,
            horizontalOffset: -50
        });
        $("#CalendarExtView1_ddlType").change(function() {
            ShowWhichType($(this).val());
        });
        
        $("#addItemDiv a[title='notes']").unbind("click").click(function() {
            AddNew();
        });
        $("#btnSearchShare").unbind("click").click(function() {
            SearchShare();
        });
    }
    this.Init = Init;
    this.ShowWhichType = ShowWhichType;
    function AddNew(startdate,enddate){
		 $("#noteEditTitle").html("新增便签");
         $("#noteEdit .saveNote").show();
         InitDialog(startdate,enddate);
         $("#noteEdit").dialog("open");
	}
	this.AddNew=AddNew;
    function ShowWhichType(type) {
        if (type == "1") {
            $("#trno").show();
            $("#trdayrepeat").hide();
            $("#trweekrepeat").hide();
            $("#trmonthrepeat").hide();
        }
        else 
            if (type == "2") {
                $("#trno").hide();
                $("#trdayrepeat").show();
                $("#trweekrepeat").hide();
                $("#trmonthrepeat").hide();
            }
            else 
                if (type == "3") {
                    $("#trno").hide();
                    $("#trdayrepeat").hide();
                    $("#trweekrepeat").show();
                    $("#trmonthrepeat").hide();
                }
                else 
                    if (type == "4") {
                        $("#trno").hide();
                        $("#trdayrepeat").hide();
                        $("#trweekrepeat").hide();
                        $("#trmonthrepeat").show();
                    }
    }
    
    function InitDialog(startdate,enddate) {
		if(!startdate||!enddate){
			startdate=$("#noteEdit").data('date');
			enddate=$("#noteEdit").data('date');
		}
        CleanMessage();
        $("#CalendarExtView1_ddlType").val("1");
        $("#txtAllSharer").val("");
        ShowWhichType("1");
        $("#notecontent").val("");
		$("#noteEdit").find("select[name='endhour']").val(enddate.getHours());
		$("#noteEdit").find("select[name='endMinute']").val(enddate.getMinutes());
		$("#noteEdit").find("select[name='starthour']").val(startdate.getHours());
		$("#noteEdit").find("select[name='startMinute']").val(startdate.getMinutes());
        //$("#noteEdit").find("select[name='endhour'],select[name='endMinute'],select[name='starthour'],select[name='startMinute']").val("0");
        $("#noteEdit").find("input[type='radio'],input[type='checkbox']").attr("checked", false);
        //无定期
        $("#tbStartDate").val(startdate.asString());
        $("#tbEndDate").val(enddate.asString());
        //按天
        $("#dayrepeatstart").val(startdate.asString());
        $("#dayrepeatend").val("");
        $("#trdayrepeat input[name=everyday]").val("");
        //按周
        $("#tbweekstart").val(startdate.asString());
        $("#tbweekend").val("");
        $("#trweekrepeat input[name=everyweek]").val("");
        //按月
        $("#monthRepeatStart").val(startdate.asString());
        $("#monthRepeatEnd").val("");
        $("#trmonthrepeat input[name=everymonth]").val("");
        
        $('#divAccountTable').hide();
        $("#noteEdit").find(".saveNote").unbind().click(function() {
            Save();
        });
    }
    function SearchShare() {
        $('#divAccountTable').show();
        $("#searchShareTable").SXTable(
        {
            colNames: ["", "姓名", "部门", "职位", "手机", ""],
            colWidth: ["2%", "20%", "25%", "25%", "20%", "8%"],
            colTemplates: ["", "#Name#", "#DeptmentName#", "#PositionName#", "#MobileNum#", "<a onclick=\"SelectAccount('#Name#');\">选择</a>"],
            url: 'NotesHandler.ashx',
            headers: 
            {
                4: 
                {
                    sorter: false
                }
            },
            data: 
            {
                type: "searchShareAccount",
                accountName: $("#txtShareAccountName").val(),
                Department: $("#CalendarExtView1_ddlDepartment").val()
            },
            pageSize: 5
        
        });
    }
    
    function SaveUpdateCommon(typestring, pkidstring) {
        CleanMessage();
        var sxValidation = new SXValidation();
        var valide = true;
        if (!sxValidation.required($("#notecontent"))) {
            $("#notecontent").after("<span class='error'>不可为空</span>");
            valide = false;
        }
        var $Type = $("#CalendarExtView1_ddlType"), data;
        if ($Type.val() == "1") {
            var $nostartdate = $("#tbStartDate"), $nostartHour = $("#trno").find("select[name='starthour']"), $nostartMinutes = $("#trno").find("select[name='startMinute']");
            var $noenddate = $("#tbEndDate"), $noendHour = $("#trno").find("select[name='endhour']"), $noendMinutes = $("#trno").find("select[name='endMinute']");
            data = 
            {
                type: typestring,
                repeatType: $Type.val(),
                startDate: $nostartdate.val(),
                startHour: $nostartHour.val(),
                startMinutes: $nostartMinutes.val(),
                endDate: $noenddate.val(),
                endHour: $noendHour.val(),
                endMinutes: $noendMinutes.val(),
                content: $("#notecontent").val(),
                shares: $("#txtAllSharer").val(),
                pkid: pkidstring
            };
            if (!sxValidation.date($nostartdate)) {
                $("#trno td").eq(2).append("<span class='error'>格式错误</span>");
                valide = false;
            }
            else 
                if (!sxValidation.date($noenddate)) {
                    $("#trno td").eq(2).append("<span class='error'>格式错误</span>");
                    valide = false;
                }
                else 
                    if (ToDate($nostartdate.val() + " " + $nostartHour.val() + ":" + $nostartMinutes.val() + ":00") >
                    ToDate($noenddate.val() + " " + $noendHour.val() + ":" + $noendMinutes.val() + ":00")) {
                        $("#trno td").eq(2).append("<span class='error'>间隔错误</span>");
                        valide = false;
                    }
        }
        else 
            if ($Type.val() == "2") {
                var $daystartdate = $("#dayrepeatstart"), $daystartHour = $("#trdayrepeat").find("select[name='starthour']"), $daystartMinutes = $("#trdayrepeat").find("select[name='startMinute']");
                var $dayenddate = $("#dayrepeatend"), $dayendHour = $("#trdayrepeat").find("select[name='endhour']"), $dayendMinutes = $("#trdayrepeat").find("select[name='endMinute']");
                data = 
                {
                    type: typestring,
                    repeatType: $Type.val(),
                    startDate: $daystartdate.val(),
                    startHour: $daystartHour.val(),
                    startMinutes: $daystartMinutes.val(),
                    endDate: $dayenddate.val(),
                    endHour: $dayendHour.val(),
                    endMinutes: $dayendMinutes.val(),
                    everyday: $("#trdayrepeat input[name='everyday']").val(),
                    chosetype: $("#trdayrepeat input[name='day']:checked").val(),
                    content: $("#notecontent").val(),
                    shares: $("#txtAllSharer").val(),
                    pkid: pkidstring
                };
                
                if (!sxValidation.date($daystartdate)) {
                    $("#trdayrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                    valide = false;
                }
                else 
                    if (!sxValidation.datenull($dayenddate)) {
                        $("#trdayrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                        valide = false;
                    }
                    else 
                        if ($.trim($dayenddate.val()) != "" &&
                        ToDate($daystartdate.val() + " 00:00:00") >
                        ToDate($dayenddate.val() + " 00:00:00")) {
                            $("#trdayrepeat div").eq(0).append("<span class='error'>间隔错误</span>");
                            valide = false;
                        }
                if (ToDate("2010-1-1 " + $daystartHour.val() + ":" + $daystartMinutes.val() + ":00") >
                ToDate("2010-1-1 " + $dayendHour.val() + ":" + $dayendMinutes.val() + ":00")) {
                    $("#trdayrepeat div").eq(0).before("<span class='error'>间隔错误</span>");
                    valide = false;
                }
                if (!$("#trdayrepeat input[name='day']:checked").val()) {
                    $("#trdayrepeat div").eq(3).append("<span class='error'>不可为空</span>");
                    valide = false;
                }
                if ($("#trdayrepeat input[name='day']:checked").val() == 1) {
                    if (!sxValidation.required($("#trdayrepeat input[name='everyday']"))) {
                        $("#trdayrepeat div").eq(1).append("<span class='error'>不可为空</span>");
                        valide = false;
                    }
                    else 
                        if (!sxValidation.digits($("#trdayrepeat input[name='everyday']"))) {
                            $("#trdayrepeat div").eq(1).append("<span class='error'>格式错误</span>");
                            valide = false;
                        }
                }
            }
            else 
            
                if ($Type.val() == "3") {
                    var weeks = "";
                    $("#trweekrepeat input[type='checkbox']").each(function() {
                        if ($(this).attr("checked")) {
                            weeks += ($(this).val() + "|");
                        }
                    });
                    var $weekstartdate = $("#tbweekstart"), $weekstartHour = $("#trweekrepeat").find("select[name='starthour']"), $weekstartMinutes = $("#trweekrepeat").find("select[name='startMinute']");
                    var $weekenddate = $("#tbweekend"), $weekendHour = $("#trweekrepeat").find("select[name='endhour']"), $weekendMinutes = $("#trweekrepeat").find("select[name='endMinute']");
                    data = 
                    {
                        type: typestring,
                        repeatType: $Type.val(),
                        startDate: $weekstartdate.val(),
                        startHour: $weekstartHour.val(),
                        startMinutes: $weekstartMinutes.val(),
                        endDate: $weekenddate.val(),
                        endHour: $weekendHour.val(),
                        endMinutes: $weekendMinutes.val(),
                        everyweek: $("#trweekrepeat input[name=everyweek]").val(),
                        weeks: weeks,
                        content: $("#notecontent").val(),
                        shares: $("#txtAllSharer").val(),
                        pkid: pkidstring
                    };
                    
                    if (!sxValidation.date($weekstartdate)) {
                        $("#trweekrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                        valide = false;
                    }
                    else 
                        if (!sxValidation.datenull($weekenddate)) {
                            $("#trweekrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                            valide = false;
                        }
                        else 
                            if ($.trim($weekenddate.val()) != "" &&
                            ToDate($weekstartdate.val() + " 00:00:00") >
                            ToDate($weekenddate.val() + " 00:00:00")) {
                                $("#trweekrepeat div").eq(0).append("<span class='error'>间隔错误</span>");
                                valide = false;
                            }
                    if (ToDate("2010-1-1 " + $weekstartHour.val() + ":" + $weekstartMinutes.val() + ":00") >
                    ToDate("2010-1-1 " + $weekendHour.val() + ":" + $weekendMinutes.val() + ":00")) {
                        $("#trweekrepeat div").eq(0).before("<span class='error'>间隔错误</span>");
                        valide = false;
                    }
                    if (!sxValidation.required($("#trweekrepeat input[name=everyweek]"))) {
                        $("#trweekrepeat div").eq(1).append("<span class='error'>不可为空</span>");
                        valide = false;
                    }
                    else 
                        if (!sxValidation.digits($("#trweekrepeat input[name=everyweek]"))) {
                            $("#trweekrepeat div").eq(1).append("<span class='error'>格式错误</span>");
                            valide = false;
                        }
                    if (weeks == "") {
                        $("#trweekrepeat div").eq(2).append("<span class='error'>请选择</span>");
                        valide = false;
                    }
                }
                else 
                    if ($Type.val() == "4") {
                        var $monthstartdate = $("#monthRepeatStart"), $monthstartHour = $("#trmonthrepeat").find("select[name='starthour']"), $monthstartMinutes = $("#trmonthrepeat").find("select[name='startMinute']");
                        var $monthenddate = $("#monthRepeatEnd"), $monthendHour = $("#trmonthrepeat").find("select[name='endhour']"), $monthendMinutes = $("#trmonthrepeat").find("select[name='endMinute']");
                        data = 
                        {
                            type: typestring,
                            repeatType: $Type.val(),
                            startDate: $monthstartdate.val(),
                            startHour: $monthstartHour.val(),
                            startMinutes: $monthstartMinutes.val(),
                            endDate: $monthenddate.val(),
                            endHour: $monthendHour.val(),
                            endMinutes: $monthendMinutes.val(),
                            nmonth: $("#trmonthrepeat input[name=everymonth]").val(),
                            ndayMonthEnum: $("#CalendarExtView1_ddlNDayMonthEnum").val(),
                            monthDayTypeEnum: $("#CalendarExtView1_ddlMonthDayTypeEnum").val(),
                            content: $("#notecontent").val(),
                            shares: $("#txtAllSharer").val(),
                            pkid: pkidstring
                        };
                        
                        if (!sxValidation.date($monthstartdate)) {
                            $("#trmonthrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                            valide = false;
                        }
                        else 
                            if (!sxValidation.datenull($monthenddate)) {
                                $("#trmonthrepeat div").eq(0).append("<span class='error'>格式错误</span>");
                                valide = false;
                            }
                            else 
                                if ($.trim($monthenddate.val()) != "" &&
                                ToDate($monthstartdate.val() + " 00:00:00") >
                                ToDate($monthenddate.val() + " 00:00:00")) {
                                    $("#trmonthrepeat div").eq(0).append("<span class='error'>间隔错误</span>");
                                    valide = false;
                                }
                        if (ToDate("2010-1-1 " + $monthstartHour.val() + ":" + $monthstartMinutes.val() + ":00") >
                        ToDate("2010-1-1 " + $monthendHour.val() + ":" + $monthendMinutes.val() + ":00")) {
                            $("#trmonthrepeat div").eq(0).before("<span class='error'>间隔错误</span>");
                            valide = false;
                        }
                        if (!sxValidation.required($("#trmonthrepeat input[name=everymonth]"))) {
                            $("#trmonthrepeat div").eq(1).append("<span class='error'>不可为空</span>");
                            valide = false;
                        }
                        else 
                            if (!sxValidation.digits($("#trmonthrepeat input[name=everymonth]"))) {
                                $("#trmonthrepeat div").eq(1).append("<span class='error'>格式错误</span>");
                                valide = false;
                            }
                        
                    }
        if (valide) {
            LoadingOn();
            $.ajax(
            {
                url: 'NotesHandler.ashx',
                dataType: 'json',
                type: 'post',
                data: data,
                cache: false,
                success: function(ans) {
                    LoadingOff();
                    if (ans.error && ans.error.length > 0) {
                        CommonError(ans);
                    }
                    else {
                        $("#noteEdit").dialog('close');
                        
                        if ($("#CalendarExtView1_typeUL li input").filter("[value='6']").attr("checked")) {
                            $.each(otherAccountList, function(i, item) {
                                if (item.added) {
                                    item.added = false;
                                }
                            });
                            Month.InitMonthDate();
                        }
                        
                    }
                }
            });
        }
        
    }
    function Save() {
        SaveUpdateCommon('addNotes', 0);
		if($theNewNote){$theNewNote.remove();}
    }
    function Update(pkid) {
        SaveUpdateCommon('updateNotes', pkid);
		if($theNewNote){$theNewNote.remove();}
    }
    this.Update = Update;
}

//便签杂项方法 start
function SelectAccount(name) {
    if ($("#txtAllSharer").val() == "") {
        $("#txtAllSharer").val(name);
    }
    else {
        var contain = false;
        var names = $("#txtAllSharer").val();
        names = names.replace(/:/g, ';').replace(/；/g, ';').replace(/：/g, ';')
        names = names.split(';');
        $.each(names, function(i, item) {
            if ($.trim(item) == $.trim(name)) {
                contain = true;
                return false;
            }
        });
        
        if (!contain) {
            $("#txtAllSharer").val($("#txtAllSharer").val() + ";" + name);
        }
    }
}

function noteUpdateShow(pkid, th) {
    $("#noteEditTitle").html("修改便签");
    $("#noteEdit .saveNote").show();
    noteShowDetailCommon(pkid, th);
    $("#noteEdit").find(".saveNote").unbind().click(function() {
        Notes.Update(pkid);
    });
}

function noteDelete(pkid, th) {
    noteDeleteExitCommon(pkid, th, 'delete', '确定要删除吗？');
}

function noteExitShare(pkid, th) {
    noteDeleteExitCommon(pkid, th, 'quite', '确定要退出吗？');
}

function noteDeleteExitCommon(pkid, th, type, confirmstring) {
    if (confirm(confirmstring)) {
        CleanMessage();
        var $this = $(th);
        LoadingOn();
        $.ajax(
        {
            url: 'NotesHandler.ashx',
            dataType: 'json',
            data: 
            {
                type: type,
                pkid: pkid
            },
            cache: false,
            success: function(ans) {
                if (ans.error && ans.error.length > 0) {
                    CommonError(ans);
                    LoadingOff();
                }
                else {
                    $this.closest(".notesEditDetail").remove();
                    if ($("#CalendarExtView1_typeUL li input").filter("[value='6']").attr("checked")) {
                        $.each(otherAccountList, function(i, item) {
                            if (item.added) {
                                item.added = false;
                            }
                        });
                        Month.InitMonthDate();
                    }
                    else {
                        LoadingOff();
                    }
                }
            }
        });
        
    }
}

function noteShowDetailCommon(pkid) {
    CleanMessage();
    $('#divAccountTable').hide();
    var $nostartdate = $("#tbStartDate"), $nostartHour = $("#trno").find("select[name='starthour']"), $nostartMinutes = $("#trno").find("select[name='startMinute']");
    var $noenddate = $("#tbEndDate"), $noendHour = $("#trno").find("select[name='endhour']"), $noendMinutes = $("#trno").find("select[name='endMinute']");
    var $daystartdate = $("#dayrepeatstart"), $daystartHour = $("#trdayrepeat").find("select[name='starthour']"), $daystartMinutes = $("#trdayrepeat").find("select[name='startMinute']");
    var $dayenddate = $("#dayrepeatend"), $dayendHour = $("#trdayrepeat").find("select[name='endhour']"), $dayendMinutes = $("#trdayrepeat").find("select[name='endMinute']");
    var $weekstartdate = $("#tbweekstart"), $weekstartHour = $("#trweekrepeat").find("select[name='starthour']"), $weekstartMinutes = $("#trweekrepeat").find("select[name='startMinute']");
    var $weekenddate = $("#tbweekend"), $weekendHour = $("#trweekrepeat").find("select[name='endhour']"), $weekendMinutes = $("#trweekrepeat").find("select[name='endMinute']");
    var $monthstartdate = $("#monthRepeatStart"), $monthstartHour = $("#trmonthrepeat").find("select[name='starthour']"), $monthstartMinutes = $("#trmonthrepeat").find("select[name='startMinute']");
    var $monthenddate = $("#monthRepeatEnd"), $monthendHour = $("#trmonthrepeat").find("select[name='endhour']"), $monthendMinutes = $("#trmonthrepeat").find("select[name='endMinute']");
    LoadingOn();
    $.ajax(
    {
        url: 'NotesHandler.ashx',
        dataType: 'json',
        data: 
        {
            type: 'getNoteByID',
            pkid: pkid
        },
        cache: false,
        success: function(ans) {
            LoadingOff();
            if (ans.error && ans.error.length > 0) {
                CommonError(ans);
            }
            else {
                $("#CalendarExtView1_ddlType").val(ans.item.Type);
                Notes.ShowWhichType(ans.item.Type);
                $("#notecontent").val(ans.item.Content);
                $("#txtAllSharer").val(ans.item.Share);
                $nostartdate.val(ans.item.NoStartDate);
                $nostartHour.val(ans.item.NoStartHour);
                $nostartMinutes.val(ans.item.NoStartMinutes);
                $noenddate.val(ans.item.NoEndDate);
                $noendHour.val(ans.item.NoEndHour);
                $noendMinutes.val(ans.item.NoEndMinutes);
                $daystartdate.val(ans.item.DayStartDate);
                $daystartHour.val(ans.item.DayStartHour);
                $daystartMinutes.val(ans.item.DayStartMinutes);
                $dayenddate.val(ans.item.DayEndDate);
                $dayendHour.val(ans.item.DayEndHour);
                $dayendMinutes.val(ans.item.DayEndMinutes);
                $weekstartdate.val(ans.item.WeekStartDate);
                $weekstartHour.val(ans.item.WeekStartHour);
                $weekstartMinutes.val(ans.item.WeekStartMinutes);
                $weekenddate.val(ans.item.WeekEndDate);
                $weekendHour.val(ans.item.WeekEndHour);
                $weekendMinutes.val(ans.item.WeekEndMinutes);
                $("#trdayrepeat input[name='everyday']").val(ans.item.NDayOnce);
                //$("#trdayrepeat input[name='day'][value='" + ans.item.DayType + "']").attr("checked", true);
                $("#trweekrepeat input[name=everyweek]").val(ans.item.NWeek);
                if (ans.item.Weeks) {
                    $.each(ans.item.Weeks, function(i, item) {
                        $("#trweekrepeat input[type='checkbox'][value='" + item + "']").attr("checked", true);
                    })
                }
                $monthstartdate.val(ans.item.MonthStartDate);
                $monthstartHour.val(ans.item.MonthStartHour);
                $monthstartMinutes.val(ans.item.MonthStartMinutes);
                $monthenddate.val(ans.item.MonthEndDate);
                $monthendHour.val(ans.item.MonthEndHour);
                $monthendMinutes.val(ans.item.MonthEndMinutes);
                $("#trmonthrepeat input[name='everymonth']").val(ans.item.NMonth);
                $("#CalendarExtView1_ddlNDayMonthEnum").val(ans.item.NDayMonthEnum);
                $("#CalendarExtView1_ddlMonthDayTypeEnum").val(ans.item.MonthDayTypeEnum);
                $("#noteEdit").dialog("open");
                $("#trdayrepeat input[name='day'][value='" + ans.item.DayType + "']").attr("checked", true);
            }
        }
    });
}

function noteDetailShow(pkid, th) {
    $("#noteEditTitle").html("查看便签");
    $("#noteEdit .saveNote").hide();
    noteShowDetailCommon(pkid);
}

//便签杂项方法 end
