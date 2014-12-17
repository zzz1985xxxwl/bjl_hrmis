(function($){
$(function(){
    $("div.ColorSelectorM").ColorPicker({
			onShow: function (colpkr) {
				$(colpkr).fadeIn(500);
				return false;
			},
			onBeforeShow: function(){
				$(this).ColorPickerSetColor(this.childNodes[0].style.backgroundColor);
			},
			onHide: function (colpkr) {
				$(colpkr).fadeOut(500);
				return false;
			},
			onChange: function (hsb, hex, rgb) {
     	    var a=$("div.colorpicker").index($(this));
     	    $("div.ColorSelectorDivM").eq(a).css('backgroundColor', '#' + hex);	   
			}
		});	
})
})(jQuery)