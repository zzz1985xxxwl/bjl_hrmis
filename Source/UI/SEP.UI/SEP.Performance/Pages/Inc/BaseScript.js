

try {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
} 
catch (ex) {
}
function EndRequestHandler(sender, args) {
    if (args.get_error() != undefined) {
        window.location.reload();
        
        args.set_errorHandled(true);
    }
}

//功能：显示或隐藏区域
//tableid表示要显示或隐藏的区域id
//showbuttonid表示显示按钮的id
//hidebuttonid表示隐藏按钮的id
//showboolean表示是隐藏还是现实 0隐藏 1显示
function ShowOrHideForm(tableid, showbuttonid, hidebuttonid, showboolean) {
    if (showboolean == 1) {
        document.getElementById(tableid).className = 'showformdiv';
        document.getElementById(showbuttonid).className = 'hiddensetdiv';
        document.getElementById(hidebuttonid).className = 'showsetdiv';
    }
    else {
        document.getElementById(tableid).className = 'hiddenformdiv';
        document.getElementById(showbuttonid).className = 'showsetdiv';
        document.getElementById(hidebuttonid).className = 'hiddensetdiv';
    }
}

//关闭页面中所有的ModalPopupExtender小窗口
//约定所有的小界面div的id为"divMPE"开头
function CloseAllModalPopupExtender() {
    try {
        for (i = 0; i < document.all.length; i++) {
            if (document.all(i).tagName.toUpperCase() == "DIV" &&
            document.all(i).id != "" &&
            document.all(i).id.substring(0, 6) == "divMPE") {
                document.all(i).style.display = "none";
            }
        }
        return false;
    } 
    catch (ex) {
        return true;
    }
}

function CloseModalPopupExtender(mpeName) {
    try {
        for (i = 0; i < document.all.length; i++) {
            if (document.all(i).id == mpeName) {
                document.all(i).style.display = "none";
            }
        }
        return false;
    } 
    catch (ex) {
        return true;
    }
}

//id  checkbox的id
//ischecked checkbox是否选择
//gridview的客户端名称
//girdview的pagesize，加上列和下面的翻页按钮，应多加2
function Hidden_Click(id, ischecked, gridName, MaxRow) {
    col_num = id;
    rows = document.getElementById(gridName).rows;
    rowsCount = rows.length;
    if (rows.length >= MaxRow) {
        rowsCount = rows.length - 1;
    }
    else {
        rowsCount = rows.length;
    }
    for (i = 0; i < rowsCount; i++) {
        if (ischecked) {
            rows[i].cells[col_num].style.display = "block";
        }
        else {
            rows[i].cells[col_num].style.display = "none";
        }
    }
}

//checkbox全选/清除     
function ChooseAllorClearAll(checkbox, cblClientName) {
    for (var i = 0;; i++) {
        var checkboxitem = document.getElementById(cblClientName + "_" + i);
        if (checkboxitem == null) {
            break;
        }
        checkboxitem.checked = checkbox.checked;
    }
}

//设置对象display属性
function SetObjectDisplayStatus(divName, status) {
    document.getElementById(divName).style.display = status;
}

//单个checkbox控制全选/清除的事件
function SetCheckBoxAll(selectedcheckboxitem, cblClientName, cbAllClientName) {
    var cbAllClient = document.getElementById(cbAllClientName);
    if (!selectedcheckboxitem.checked) {
        cbAllClient.checked = false;
        return;
    }
    var isAllChecked = true;
    for (var i = 0;; i++) {
        var checkboxitem = document.getElementById(cblClientName + "_" + i);
        if (checkboxitem == null) {
            break;
        }
        if (!checkboxitem.checked) {
            isAllChecked = false;
            break;
        }
    }
    cbAllClient.checked = isAllChecked;
}

function AlternateAuthNodeClass(obj, closeclassname, openclassname) {
    try {
        for (i = 0; i < document.all.length; i++) {
            if (document.all(i).tagName.toUpperCase() == "DIV" &&
            document.all(i).id != obj.id &&
            IsStringContain(document.all(i).id, "divAuth")) {
                document.all(i).className = closeclassname;
            }
        }
        if (obj.className == closeclassname) {
            obj.className = openclassname;
        }
        else {
            obj.className = closeclassname;
        }
    } 
    catch (ex) {
    }
}

function IsStringContain(parentstring, substring) {
    if (parentstring.indexOf(substring) >= 0) {
        return true;
    }
    else {
        return false;
    }
}

function makewidth(th) {
    var width = $(th).parent().css("width").replace("px", "");
    if (width > 0) {
        $(th).next(".FixedGridViewDiv").css("width", width - 2) + "px";
    }
}

function fixColumn(th) {
    $(th).find(".FixedDataColumn").css("left", $(th).scrollLeft());
    $(th).find(".FixedDataColumnStart").css("left", $(th).scrollLeft());
    $(th).find(".FixedDataColumnEnd").css("left", $(th).scrollLeft());
    $(th).find(".FixedDataColumnStartEnd").css("left", $(th).scrollLeft());
    $(th).find(".FixedTitleRowColumn").css("left", $(th).scrollLeft());
    $(th).find(".FixedTitleRowColumn").css("top", $(th).scrollTop());
    $(th).find(".FixedTitleRow").css("top", $(th).scrollTop());
    $(th).find(".FixedTitleRowStart").css("top", $(th).scrollTop());
    $(th).find(".FixedTitleRowEnd").css("top", $(th).scrollTop());
    $(th).find(".FixedTitleRowStartEnd").css("top", $(th).scrollTop());
}

function makewidthfive(th) {
    var width = $("#widthfrom").css("width").replace("px", "");
    if (width > 0) {
        $(th).next(".FixedGridViewDiv500").css("width", width - 7) + "px";
    }
}

//给th对象增加classname的效果
function AddClass(th, classname) {
    $(th).addClass(classname);
    
    
}

//给th对象除去classname的效果
function RemoveClass(th, classname) {
    $(th).removeClass(classname);
}

function makewidth2(th) {
    var width = $(th).parent().css("width").replace("px", "");
    if (width > 0) {
        $(th).next(".FixedGridViewDiv400").css("width", width - 2) + "px";
    }
}

function CommonError(ans) {
    CleanMessage();
    for (var i = 0; i < ans.error.length; i++) {
        var node = $("#" + ans.error[i]["ErrorControlID"]), type = node.attr("nodeName").toLowerCase();
        if (type == "span" || type == "div") {
            node.next(".font14b").eq(0).remove();
            node.prev(".font14b").eq(0).remove();
            node.html(ans.error[i]["ErrorMessage"]);
            node.parents(".leftitbor").show();
        }
        else {
            node.after("<span class='error'>" + ans.error[i]["ErrorMessage"] + "</span>");
        }
    }
}

var CommonErrorMessage;
$(function() {
    CommonErrorMessage = $(".leftitbor").filter(function(index) {
        return $(this).css("display") == "none";
    });
})

function CleanMessage() {
    $(".error").remove();
    CommonErrorMessage.hide();
}

function AddOverLayLoding(time) {
    var t = 1000;
    if (time) {
        t = time;
    }
    layloding = true;
    setTimeout(function() {
        if (layloding) {
            $("body").append("<div class='overlayAjax'></div><div id='pageloading' class='LoadingAjax'>正在读取数据...</div>");
        }
    }, t);
}

var layloding = true;
function RemoveOverLayLoding() {
    layloding = false;
    $("body .overlayAjax").remove()
    $(".LoadingAjax").remove();
}

//return   if   s1   ends   with   s2   
function IsStringEndWith(s1, s2) {
    if (s1.length == 0 || s1.length < s2.length) {
        return false;
    }
    if (s1 == s2) {
        return true;
    }
    if (s1.substring(s1.length - s2.length) == s2) {
        return true;
    }
    return false;
}

function getQueryStringRegExp(name) {
    var reg = new RegExp("(^|\\?|&)" + name + "=([^&]*)(\\s|&|$)", "i");
    if (reg.test(location.href)) 
        return unescape(RegExp.$2.replace(/\+/g, " "));
    return "";
}

(function($) {
    $.ajaxJson = function(settings) {
        this.defaults = 
        {
            url: "",
            data: {},
            success: function() {
            },
            cache: false,
            type: "post"
        };
        var config = $.extend(this.config, this.defaults, settings);
        AddOverLayLoding();
        $.ajax(
        {
            url: config.url,
            dataType: 'json',
            data: config.data,
            type: config.type,
            cache: config.cache,
            success: function(ans) {
                RemoveOverLayLoding();
                config.success(ans);
            }
        });
    }
})(jQuery);

function AddReturnUrl() {
    var link = location.href;
    var f = "/pages/";
    return "returnUrl=" + link.substring(link.toLowerCase().indexOf(f) + f.length, link.length);
}

function GetReturnUrl() {
    var returnurl = getQueryStringRegExp("returnUrl");
    var link = location.href;
    var f = "/pages/";
    return link.substring(0, link.toLowerCase().indexOf(f) + f.length) + getQueryStringRegExp("returnUrl");
}
function HideTheAuth(){
    $("#hiddenAuthTree").click();
}




var app = (function () {
    var a = {};
    var b = [];
    a.inc = function (d, c) {
        return true
    };
    a.register = function (e, c) {
        var g = e.split(".");
        var f = a;
        var d = null;
        while (d = g.shift()) {
            if (g.length) {
                if (f[d] === undefined) {
                    f[d] = {}
                }
                f = f[d]
            } else {
                if (f[d] === undefined) {
                    try {
                        f[d] = c(a)
                    } catch (h) {
                        b.push(h)
                    }
                }
            }
        }
    };
    a.IE = /msie/i.test(navigator.userAgent);
    return a
})();
app.register("math", function () {
    return {
        //说明：javascript的加法结果会有误差，在两个浮点数相加的时候会比较明显。这个函数返回较为精确的加法结果
        accAdd: function (a, b) {
            var r1, r2, m;
            try { r1 = a.toString().split(".")[1].length } catch (e) { r1 = 0 }
            try { r2 = b.toString().split(".")[1].length } catch (e) { r2 = 0 }
            m = Math.pow(10, Math.max(r1, r2))
            return (a * m + b * m) / m
        },
        toMoney: function (number) {
            var n = parseFloat(number);
            if (n >= 0) {
                return n.toFixed(2).replace(/./g, function (c, i, a) {
                    return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                });
            } else {
                return n.toFixed(2).replace(/./g, function (c, i, a) {
                    return i > 1 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                });
            }
        },
        moneyToNumber: function (number) {
            return number.replace(/,/g, "");
        }
    }
})
app.register("util", function () {
    var a = {
        fastSearchInit: function ($element, defalut, $triggerButton) {
            $element.val(defalut).css("color", "#bcbcbc").focus(function () {
                if (this.value != defalut) {
                    this.style.color = '#000';
                } else {
                    this.value = '';
                    this.style.color = '#bcbcbc'
                }
            }).keydown(function (e) {
                if ($triggerButton && e.keyCode == 13) {
                    $triggerButton.trigger("click");
                    return;
                }
                this.style.color = '#000'
            }).blur(function () {
                if (this.value == '') {
                    this.value = defalut;
                    this.style.color = '#bcbcbc';
                }
            }).attr("autocomplete", "off");
        },
        bindNameValue: function (item, itemValue) {
            if (typeof (item) != "undefined" && item) {
                for (var key in itemValue) {
                    var a = itemValue[key];
                    var editparam = item.find("[name=" + key + "]");
                    editparam.each(function () {
                        var $thisEditParam = $(this);
                        switch ($thisEditParam[0].nodeName) {
                            case "SELECT":
                                if ($thisEditParam.find("option[value='" + a + "']").length == 0) {
                                    $thisEditParam.find("option:eq(0)").attr("selected", "selected")
                                } else {
                                    $thisEditParam.val(a);
                                }
                                break;
                            case "INPUT":
                            case "TEXTAREA":
                                if ($thisEditParam.is(":checkbox")) {
                                    if (a == "1") {
                                        $thisEditParam.attr("checked", true);
                                    }
                                    $thisEditParam.attr("checked", false)
                                }
                                else if (!$thisEditParam.is(":file")) {
                                    $thisEditParam.val(a);
                                }
                                break;
                            case "SPAN":
                                $thisEditParam.html(a);
                                break;
                            case "DIV":
                            case "TD":
                            case "TR":
                            case "FONT":
                                $thisEditParam.html(a);
                                break;
                            default:
                                $thisEditParam.val(a);
                        }
                    })
                }
            }
        },
        bindValue: function (editParams, ans) {
            if (typeof (editParams) != "undefined" && editParams) {
                if (editParams.selector) {
                    editParams = app.util.getNameParam(editParams);
                }
                var hasData = typeof (ans) != "undefined" && typeof (ans.data) != "undefined" && ans.data;
                for (var key in editParams) {
                    var a;
                    if (ans === "") {
                        a = "";
                    } else if (hasData) {
                        a = ans.data[key];
                    }
                    var editparam = editParams[key];
                    editparam.each(function () {
                        var $thisEditParam = $(this);
                        switch ($thisEditParam[0].nodeName) {
                            case "SELECT":
                                if ($thisEditParam.find("option[value='" + a + "']").length == 0) {
                                    $thisEditParam.find("option:eq(0)").attr("selected", "selected")
                                } else {
                                    $thisEditParam.val(a);
                                }
                                break;
                            case "INPUT":
                            case "TEXTAREA":
                                if ($thisEditParam.is(":checkbox")) {
                                    if (a == "1") {
                                        $thisEditParam.attr("checked", true);
                                    }
                                    $thisEditParam.attr("checked", false)
                                }
                                else if (!$thisEditParam.is(":file")) {
                                    $thisEditParam.val(a);
                                }
                                break;
                            case "SPAN":
                                $thisEditParam.html(a);
                                break;
                            case "DIV":
                            case "TD":
                            case "TR":
                            case "FONT":
                                $thisEditParam.html(a);
                                break;
                            default:
                                $thisEditParam.val(a);
                        }
                    })
                }
            }
        },
        clearError: function ($element) {
            if ($element) {
                $element.find(".input-validation-error").removeClass("input-validation-error");
                $element.find("span.field-validation-error").empty();
                $element.find(".dialog-error,.title-error").empty().hide();
                if ($element.hasClass("dialog-error") || $element.hasClass("title-error")) {
                    $element.empty().hide();
                }
            } else {
                $(".input-validation-error").removeClass("input-validation-error");
                $(".field-validation-error").empty();
                $(".dialog-error,.title-error").empty().hide();
            }
        },
        onError: function (errors, form) {
            if (errors) {
                var length = errors.length;
                for (var i = 0; i < length; i++) {
                    var container;
                    if (errors[i].key == "alert") {
                        alert(errors[i].value);
                        return;
                    }
                    if (errors[i].key.startWith("#")) {
                        container = $(errors[i].key);
                        container.show();
                    } else if (form) {
                        container = form.find("[data-valmsg-for='" + errors[i].key + "']");
                    } else {
                        container = $("span.[data-valmsg-for='" + errors[i].key + "']");
                    }
                    replace = $.parseJSON(container.attr("data-valmsg-replace")) !== false;
                    container.removeClass("field-validation-valid").addClass("field-validation-error");
                    container.empty();
                    $("<span generated='true'>" + errors[i].value + "</span>").appendTo(container);
                }
            }
        },
        getEditParam: function ($edittable) {
            var ans = {};
            $edittable.find("select,input[type=text],input[type=hidden],input[type=file],input[type=checkbox],textarea").each(function () {
                var $this = $(this);
                ans[$this.attr("name")] = $this;
            })
            return ans;
        },
        getShowParam: function ($edittable, className) {
            var ans = {};
            $edittable.find("." + className).each(function () {
                var $this = $(this);
                ans[$this.attr("name")] = $this;
            })
            return ans;
        },
        getNameParam: function ($edittable) {
            var ans = {};
            $edittable.find("[name]:not([type=submit])").each(function () {
                var $this = $(this);
                ans[$this.attr("name")] = $this;
            })
            return ans;
        },
        serializeParamArray: function (param) {
            var ans = {};
            for (var key in param) {
                if (param[key].is(":checkbox")) {
                    ans[key] = param[key].is(":checked") ? "on" : "off";
                } else {
                    ans[key] = $.trim(param[key].val());
                }
            }
            return ans;
        },
        autoCalcKeyNo: function ($quantity, $from, $to) {
            $from.bind("blur", calc);
            $to.bind("blur", calc);
            function calc() {
                app.util.calcKeyNo($quantity, $from, $to);
            }
        },
        calcKeyNo: function ($quantity, $from, $to) {
            var strQuantity = $quantity.val(),
                    strFrom = $from.val(),
                    strTo = $to.val();
            if (strQuantity != "") {
                var quantity = parseInt(strQuantity);
                if (isNaN(quantity)) return;
                if (strFrom != "" && (strTo == "" || strTo == "号段范围")) {
                    if (isNaN(parseInt(strFrom))) return;
                    $to.val(parseInt(strFrom) + quantity - 1);
                    $to.removeClass("prompt");
                }
                else if ((strFrom == "" || strFrom == "号段范围") && strTo != "") {
                    if (isNaN(parseInt(strTo))) return;
                    $from.val(parseInt(strTo) - quantity + 1);
                    $from.removeClass("prompt");
                }
            }
        }
    }
    return a;
});
app.register("util.storage", function (d) {
    var a = window.localStorage;
    if (a) {
        return {
            get: function (e) {
                return unescape(a.getItem(e))
            },
            set: function (e, g, h) {
                a.setItem(e, escape(g))
            },
            del: function (e) {
                a.removeItem(e)
            },
            clear: function () {
                a.clear()
            },
            getAll: function () {
                var e = a.length, h = null, j = [];
                for (var g = 0; g < e; g++) {
                    h = a.key(g), j.push(h + "=" + this.getKey(h))
                }
                return j.join("; ")
            }
        }
    } else {
        if (window.ActiveXObject) {
            var b = document.documentElement;
            var c = "localstorage";
            try {
                b.addBehavior("#default#userdata");
                b.save("localstorage")
            } catch (f) {
            }
            return {
                set: function (e, g) {
                    b.setAttribute(e, g);
                    b.save(c)
                },
                get: function (e) {
                    b.load(c);
                    return b.getAttribute(e)
                },
                del: function (e) {
                    b.removeAttribute(e);
                    b.save(c)
                }
            }
        } else {
            return {
                get: function (m) {
                    var h = document.cookie.split("; "), g = h.length, e = [];
                    for (var j = 0; j < g; j++) {
                        e = h[j].split("=");
                        if (m === e[0]) {
                            return unescape(e[1])
                        }
                    }
                    return null
                },
                set: function (e, g, h) {
                    if (!(h && typeof h === date)) {
                        h = new Date(), h.setDate(h.getDate() + 1)
                    }
                    document.cookie = e + "=" + escape(g) + "; expires=" + h.toGMTString()
                },
                del: function (e) {
                    document.cookie = e + "=''; expires=Fri, 31 Dec 1999 23:59:59 GMT;"
                },
                clear: function () {
                    var h = document.cookie.split("; "), g = h.length, e = [];
                    for (var j = 0; j < g; j++) {
                        e = h[j].split("=");
                        this.deleteKey(e[0])
                    }
                },
                getAll: function () {
                    return unescape(document.cookie.toString())
                }
            }
        }
    }
});
