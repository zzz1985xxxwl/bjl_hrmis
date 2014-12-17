
 $(document).ready(function(){ 
    CardResize();
    $(".pool-table,table").bind("resize",function(){CardResize();});
	$(".cards-container").sortable({
		 items:".draggable",
		 connectWith: $(".cards-container"),
		 distance: 2 ,
		 over: function(event, ui) { 
		 var b=$(this);
		 b.css("background-color","#B2D5FC");
		  },
         out: function(event, ui) { 
		 var b=$(this);
		 b.css("background-color","#F1F0EC");
		  },
		 start: function(event, ui) { $(ui.item).css("background-color","#F1EFEB"); },
		 stop: function(event, ui) { $(ui.item).css("background-color","#FFFFFF"); },
		 receive: function (e,ui) {
		 var ajaxurl=$(this).attr("url");
         var $img=$(ui.item).children().children("img");
		 $img.show(); 
         $(ui.item).removeClass("draggable");
		 $.ajax({url: ajaxurl,
		 data:"id="+$(ui.item).attr("CardID"),
		 type:"get",
         success:function(msg){ 
              $(ui.item).addClass("draggable");
			  $img.hide(); 
			   if(GetValue("ans",msg)=="false")
			   {$(ui.item).appendTo($(ui.sender));} 
			   else{ReCount();}
               } 
              });
         }
	  }); 
  });
  
function GetValue(key,response){
var value,valueList=response.split('#');
for( i=0;i<valueList.length;i++) 
{if(valueList[i].substring(0,valueList[i].indexOf('='))==key)
{ return  valueList[i].substring(valueList[i].indexOf('=') + 1,valueList[i].length);}}return value;
}
function ReCount()
{
	$(".cards-container").each(function(){
	var a=$(".cards-container").index($(this));
	$(".lane-card-number").eq(a).html("("+$(this).children(".card-icon").length+")");
	})
}
function CardResize()
{
	var tablewidth=$(".pool-table").eq(0).css("width").replace("px","");
	var tdcount=$(".group").length;
	if((tablewidth/tdcount-8)<92)
	{$(".card-icon").css("width",(tablewidth/tdcount-8)+"px").css("height",(tablewidth/tdcount-8)*0.65+"px");};
}