$.fn.Tab = function(opt){
	var cfg={
		items:[{'id':1,'title':'tab','html':'','callback':function(){}}],
		width:572,
		height:100,
		tabcontentWidth:520,
		tabWidth:100,
		tabHeight:25,
		tabScroll:true,
		tabScrollWidth:10,
		tabClass:'benma_ui_tab',
		tabContentClass:'tab-div-content',
		tabClassOn:'tab_item',
		tabClassOff:'off',
		tabClassInner:'tab_item',
		tabClassInnerMiddle:'tab_item1',
		tabClassText:'text',
		tabClassScrollLeft:'scroll-left',
		tabClassScrollRight:'scroll-right',
		tabClassDiv:'benma_ui_tab',
        tabMarginLeft:'12',
        tabSelectIndex :0,
        //一次显示几个tab页
        tabDisplayCount:6
	};
	//默认显示第一个li
	var displayLINum = 0;

	$.extend(cfg,opt);
	
	//判断是不是有隐藏的tab
	if(!cfg.tabScroll)null;
	
	//tabDiv,该div是自动增加的
	var tab=$('<div />').attr('id','jquery_tab_div').height(cfg.tabHeight).addClass(cfg.tabClass).append('<ul />');

	//具体显示的内容
	var tabContent=$('<div />').attr('id','jquery_tab_div_content').width(cfg.tabcontentWidth).height(200).addClass(cfg.tabContentClass);
	
	//增加一个tab下的li得模板
	var tabTemplate='';
	tabTemplate = '<table class="'+cfg.tabClassInner+'"  id="{0}" border="0" cellpadding="0" cellspacing="0"><tr>' 
			+ '<td class="'+cfg.tabClassInnerMiddle+'"><span class="'+cfg.tabClassText+'">{1}</span></td>' 
			+ '</tr></table>';
	

	var scrollTab=function(o,flag){

		//当前的left
		var displayWidth=Number(tab.css('left').replace('px',''));
		!displayWidth?displayWidth=0:null;
		//显示第几个LI
		var displayNum=0;
		var left=0;
		if(flag&&displayWidth==0){
			return;
		}

		//向左边移动一个tab
		if(flag){
			displayLINum--;
			left=displayWidth+tab.find('li').eq(displayLINum).width();
			left>0?left=0:null;
			
		}
		//向右边移动一个tab
		else{ 
			//判断当前显示得li得宽度					
			if((tab.find('li:last').offset().left+tab.find('li:last').width()-tab.find('li').eq(displayLINum).offset().left)<=cfg.width-2*cfg.tabScrollWidth){

				return;
			}
			left=displayWidth-tab.find('li').eq(displayLINum).width();
			displayLINum++;

		}
		tab.animate({'left':left});
	}
    $.each(cfg.items,function(i,o){
		addTab(o);
	});
    function addTab(item){
        var innerString=tabTemplate.replace("{0}",item.id).replace("{1}",item.title);
		var liObj=$('<li></li>');
		liObj.append(innerString).appendTo(tab.find('ul')).find('table td:eq(0)').click(function(){
		
        //判断当前是不是处于激活状态
        var _self=liObj;
        if(_self.hasClass(cfg.tabClassOn)) return;
			
        //改变内部得css
        _self.find('td:eq(0)').addClass(cfg.tabClassInnerMiddle+'_selected');	
        var activeLi=_self.parent().find('li.'+cfg.tabClassOn);
        activeLi.find('td:eq(0)').removeClass().addClass(cfg.tabClassInnerMiddle);
        activeLi.removeClass().addClass(cfg.tabClassOff);
		_self.removeClass().addClass(cfg.tabClassOn);

	    //读取详细信息
        if(item.html){
            tabContent.html(item.html);
        }
        //回调函数是什么
        if(item.callback) item.callback(item);
		}).hover();
	}

	var cW=cfg.width;
	var scrollLeft,srcollRight;
	//需要滑动
	if(cfg.tabScroll){
		scrollLeft=$('<div class="'+cfg.tabClassScrollLeft+'"></div>').click(function(){
			scrollTab($(this),true);
		});
        srcollRight=$('<div class="'+cfg.tabClassScrollRight+'"></div>').click(function(){
            scrollTab($(this),false);
        });
		cW-=cfg.tabScrollWidth*2;
	}
	
	var container=$('<div />').css({
		'overflow':'hidden',
		'position':'relative',
		'width':cfg.width,
		'height':cfg.tabHeight,
		'margin-left': cfg.tabMarginLeft
	}).append(srcollRight).append(scrollLeft).addClass(cfg.tabClassDiv);
	
	var tabContenter=$('<div />').css({
		'overflow':'hidden',
		'width':cW,
		'height':cfg.tabHeight,
		'float':'left'
	}).append(tab);
	

	var obj=$(this).append(container.append(tabContenter)).append(tabContent);
	//点击要点中第几个tab页
	tab.find('li:eq('+cfg.tabSelectIndex+') td:eq(0)').click();
	// 移动到指定的tab页
	if (cfg.tabSelectIndex>(cfg.tabDisplayCount-1))
	{
		var moveIndex = (cfg.tabDisplayCount-cfg.tabSelectIndex-1)*92
	    tab.animate({'left':moveIndex});
	    displayLINum=displayLINum+(cfg.tabSelectIndex-cfg.tabDisplayCount+1);
	}
	
	return obj.extend({'addTab':addTab});
};