/*
 * Script from NETTUTS.com [by James Padolsey]
 * @requires jQuery($), jQuery UI & sortable/draggable UI modules
 */
	var info=function(_colum,_location,_url,_title,_isopen){
		this.colum=_colum;
		this.location=_location;
		this.url=_url;
		this.title=_title;
		this.isopen=_isopen;
	};
	
var iNettuts = {
    
    jQuery : $,
    
    settings : {
        columns : '.column',
        widgetSelector: '.widget',
        handleSelector: '.widget-head',
        contentSelector: '.widget-content',
        widgetDefault : {
            movable: true,
            removable: true,
            collapsible: true
        }

    },

    init : function () {
        this.BuildDashBoard();
        this.addWidgetControls();
        this.makeSortable();
    },
    getWidgetSettings : function (id) {
        var $ = this.jQuery,
            settings = this.settings;
        return (id&&settings.widgetIndividual[id]) ? $.extend({},settings.widgetDefault,settings.widgetIndividual[id]) : settings.widgetDefault;
    },
    
    addWidgetControls : function () {
        var iNettuts = this,
            $ = this.jQuery,
            settings = this.settings;
            
        $(settings.widgetSelector, $(settings.columns)).each(function () {
            var thisWidgetSettings = iNettuts.getWidgetSettings(this.id);
            if (thisWidgetSettings.removable) {
                $("a.remove").mousedown(function (e) {
                    e.stopPropagation();    
                }).click(function () {
                        $(this).parents(settings.widgetSelector).animate({
                            opacity: 0    
                        },function () {
                            $(this).wrap('<div/>').parent().slideUp(function () {
                                $(this).remove();
                                 iNettuts.SavePersonInfo();
                            });
                        });
                    return false;
                });
            }
            
            
            if (thisWidgetSettings.collapsible) {
                   $('a.collapseopen').mousedown(function (e) {
                        e.stopPropagation();    
                    }).unbind("click").toggle(function () {
                        $(this).removeClass("collapseopen").addClass("collapseclose")
                            .parents(settings.widgetSelector)
                                .find(settings.contentSelector).hide();
                       iNettuts.SavePersonInfo();
                       
                        return false;
                    },function () {
                        $(this).removeClass("collapseclose").addClass("collapseopen")
                            .parents(settings.widgetSelector)
                                .find(settings.contentSelector).show();
                       iNettuts.SavePersonInfo();
                        return false;
                    });
               
                   $('a.collapseclose').mousedown(function (e) {
                        e.stopPropagation();    
                    }).toggle(function () {
                    $(this).removeClass("collapseclose").addClass("collapseopen")
                            .parents(settings.widgetSelector)
                                .find(settings.contentSelector).show();
                       iNettuts.SavePersonInfo();
                        return false;
                    },function () {
                         $(this).removeClass("collapseopen").addClass("collapseclose")
                            .parents(settings.widgetSelector)
                                .find(settings.contentSelector).hide();
                       iNettuts.SavePersonInfo();
                        return false;
                    });
            }
        }); 
    },
    
    SavePersonInfo: function()
	{
		var personinfo=[];
	    $("#columns").find(".column").find("li").filter(".widget").each(function(){
		      $this=$(this);
		      personinfo.push(new info($(".column").index($this.parent("ul.column")),
		      $this.parent("ul.column").find("li").filter(".widget").index($this),
		      $this.find("iframe").attr("src"),
		      $this.find(".widget-head h3").html(),
		      $this.find(".widget-content").css("display")
		      ));
	    });
	    $.cookie("personinfo",$.toJSON(personinfo),{expires: 500}) ;
	   Flash();
	},
	
	BuildDashBoard:function()
	{
	    var cookieinfo=$.cookie("personinfo");
	    if(cookieinfo=="")
	    {
	        cookieinfo=null;
	    }
		var personinfoInit=$.evalJSON(cookieinfo);
       if(personinfoInit==null)
       {
	      personinfoInit=[{"colum":0, "location":0, "url":"../../SEP/CalendarPages/CalendarIFramePage.aspx", "title":"»’¿˙", "isopen":"block"}];
          $.cookie("personinfo",$.toJSON(personinfoInit));
	   }
		$.each(personinfoInit,function(i ,item){
			
			if(item.colum==0)
			{$("#columns #column1").append(iNettuts.WidgetString(item.title,item.url,item.isopen));}
			else
			{$("#columns #column2").append(iNettuts.WidgetString(item.title,item.url,item.isopen));}
		});
	},
	AddDashBoard:function(title,url,colum)
	{
        if(colum==0||colum=="0")
		  {$("#columns #column1").append(iNettuts.WidgetString(title,url,"block"));}
		else
		  {$("#columns #column2").append(iNettuts.WidgetString(title,url,"block"));}
		iNettuts.SavePersonInfo();
		iNettuts.addWidgetControls();
        iNettuts.makeSortable();
	},
	WidgetString:function(title,url,isopen)
	{
	   var coll="collapseopen";
	   if(isopen=="none"){coll="collapseclose";}
       var s=" <li class=\"widget\"><div class=\"widget-head\"><h3>"+title+"</h3><a href=\"#\" class=\"remove\">CLOSE</a><a href=\"#\" class=\"collapse "+coll+"\">COLLAPSE</a></div> <div class=\"widget-content\" style=\"display:"+isopen+";\">" ;
          s+="<div style='position:relative;'><iframe frameborder=\"0\" scrolling=\"no\" onload=\"iNettuts.AutoHight(this,300);\" style=\"border: 0pt none ; margin: 0pt; padding: 0pt; overflow: hidden; width: 100%;min-height:100px;\" src=\""+url+"\" ></iframe><div class='LoadingIFrame'></div></div></div></li>"; 
        return s;
	},
	AutoHight:function(th,time)
	{ 
	  $(th).next("div.LoadingIFrame").remove();
	  function hei(th)
	  {
	      var cwin=th;
          if (document.getElementById)
          {
            if (cwin && !window.opera)
            {
              if (cwin.contentDocument && cwin.contentDocument.body.offsetHeight)
                cwin.height = cwin.contentDocument.body.offsetHeight; 
              else if(cwin.Document && cwin.Document.body.scrollHeight)
                cwin.height = cwin.Document.body.scrollHeight;
            }
          }
	  }
	  hei(th);
	  setInterval(function(){
	    hei(th);
//        $(th).css({"height":$(th).contents().find("body").height()+8});
       },time);
	},
	
    makeSortable : function () {
        var iNettuts = this,
            $ = this.jQuery,
            settings = this.settings,
            $sortableItems = $(settings.widgetSelector);
        $sortableItems.find(settings.handleSelector).css({
            cursor: 'move'
        }).mousedown(function (e) {
            $sortableItems.css({width:''});
            $(this).parent().css({
                width: $(this).parent().width() + 'px'
            });
        }).mouseup(function () {
            if(!$(this).parent().hasClass('dragging')) {
               $(this).parent().css({width:''});
            } else {
                $(settings.columns).sortable('disable');
            }
        });
        $(settings.columns).sortable("destroy");
        $(settings.columns).sortable({
            items: $sortableItems,
            connectWith: $(settings.columns),
            handle: settings.handleSelector,
            placeholder: 'widget-placeholder',
            forcePlaceholderSize: true,
            revert: 300,
            distance:3,
            opacity: 0.8,
            start: function (e,ui) {
                $(ui.helper).addClass('dragging');
            },
            stop: function (e,ui) {
                $(ui.item).css({width:''}).removeClass('dragging');
                $(settings.columns).sortable('enable');
                iNettuts.SavePersonInfo();
            }
        });
    }
  
};


