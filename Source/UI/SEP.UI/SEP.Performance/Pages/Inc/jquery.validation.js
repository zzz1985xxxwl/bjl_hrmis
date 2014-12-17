(function($) {
    SXValidation = function(settings) {
        var config, success = true, defaultmessages = 
        {
            required: "不可为空"
        }
        var defaults = 
        {
            valid: {}
        }
        var errorItems=new Array();
        function init() {
            config = $.extend(defaults, settings);
        }
        init();
        function errorItem(_element,_message)
        {
            this.element=_element;
            this.message=_message;
        }
         function validError() {
            errorItems=new Array();
            success = true;
            var rules = config.valid.rules;
            for (var key in rules) {
                var elements = $("[valid=" + key + "]"), type = rules[key];
                elements.each(function() {
                    var element = $(this);
                    element.nextAll(".error").remove();
                    for (var k in type) {
                        var over = false;
                        switch (k)
                        {
                            case "required":
                                if (!required(element)) 
                                {
                                    addErrorMessage(element, key, "required");
                                    over = true;
                                }
                                break;
                            case "email":
                                if (!email(element)) 
                                {
                                    addErrorMessage(element, key, "email");
                                    over = true;
                                }
                                break;
                            case "url":
                                if (!url(element)) 
                                {
                                    addErrorMessage(element, key, "url");
                                    over = true;
                                }
                                break;
                            case "date":
                                if (!date(element)) 
                                {
                                    addErrorMessage(element, key, "date");
                                    over = true;
                                }
                                break;
                            case "datenull":
                                if (!datenull(element)) 
                                {
                                    addErrorMessage(element, key, "datenull");
                                    over = true;
                                }
                                break;
                            case "time":
                                if (!time(element)) 
                                {
                                    addErrorMessage(element, key, "time");
                                    over = true;
                                }
                                break;
                            case "number":
                                if (!number(element)) 
                                {
                                    addErrorMessage(element, key, "number");
                                    over = true;
                                }
                                break;
                            case "digits":
                                if (!digits(element)) 
                                {
                                    addErrorMessage(element, key, "digits");
                                    over = true;
                                }
                                break;
                            case "minlength":
                                if (!minlength(element, type.minlength)) 
                                {
                                    addErrorMessage(element, key, "minlength");
                                    over = true;
                                }
                                break;
                            case "maxlength":
                                if (!maxlength(element, type.maxlength)) 
                                {
                                    addErrorMessage(element, key, "maxlength");
                                    over = true;
                                }
                                break;
                            case "range":
                                if (!range(element, type.range)) 
                                {
                                    addErrorMessage(element, key, "range");
                                    over = true;
                                }
                                break;
                            default:
                                break;
                        }
                        if (over) {
                            break
                        };
                                    }
                })
                
                
            }
            return success;
        }
        
        function addErrorMessage(element, key, type) {
            var messages = config.valid.messages;
            var s = messages[key][type];
            if (typeof s == "undefined") {
                s = defaultmessages[type];
                if (typeof s == "undefined") {
                    s = "格式错误";
                }
            }
            element.after("<span class='error'>" + s + "</span>");
            errorItems.push(new errorItem(element,s));
            success = false;
        }
        function required(element) {
            var s = element.attr("nodeName");
            switch (s.toLowerCase())
            {
                case 'select':
                    var val = element.val();
                    return val && val.length > 0;
                case 'input':
                    return $.trim(element.val()).length > 0;
                default:
                    return $.trim(element.val()).length > 0;
            }
        };
        function number(element) {
            return /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(element.val());
        };
        
        function digits(element) {
            return /^\d+$/.test(element.val());
        };
        
        function minlength(element, length) {
            return $.trim(element.val()).length >= length;
        }
        function maxlength(element, length) {
            return $.trim(element.val()).length <= length;
        }
        function range(element, para) {
            return $.trim(element.val()) >= para[0] && $.trim(element.val()) <= para[1];
        }
        function time(element) {
            var str = element.val(), a = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);
            if (a == null) {
                return false;
            }
            if (a[1] > 24 || a[3] > 60 || a[4] > 60) {
                return false
            }
            return true;
        }
        function date(element) {
            var str = element.val(), r = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            if (r == null) 
                return false;
            var d = new Date(r[1], r[3] - 1, r[4]);
            return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
        }
        function datenull(element) {
            if(element.val() == '')
                return true;
            var str = element.val(), r = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            if (r == null) 
                return false;
            var d = new Date(r[1], r[3] - 1, r[4]);
            return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
        }
        function dateTime(element) {
            var str = element.val(), reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
            var r = str.match(reg);
            if (r == null) 
                return false;
            var d = new Date(r[1], r[3] - 1, r[4], r[5], r[6], r[7]);
            return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4] && d.getHours() == r[5] && d.getMinutes() == r[6] && d.getSeconds() == r[7]);
        }
        function email(element) {
            return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(element.val());
        }
        function url(element) {
            return /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(element.val());
        }
        function getErrorItems(){
            return errorItems;
        };
        return {
            "valide": validError,
            "required":required,
            "dateTime":dateTime,
            "email":email,
            "url":url,
            "datenull":datenull,
            "date":date,
            "number":number,
            "digits":digits,
            "minlength":minlength,
            "maxlength":maxlength,
            "range":range,
            "time":time,
            "getErrorItems":getErrorItems
        }
        
    }
    
    
    
})(jQuery);
