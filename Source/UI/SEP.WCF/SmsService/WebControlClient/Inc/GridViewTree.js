var ImgJian = "Image/jian.gif";
var ImgJia = "Image/jia.gif";
function ExpandOrShrinkTree(strID, strImgName)
{ 
		var i=1;
		var objParent = document.getElementById(strID);
		var imgParent = document.getElementById(strID+"_"+strImgName);
		var obj;
		while (obj = document.getElementById(strID+"_"+i)) 
		{
			if (obj.style.display=="none" && objParent.style.display=="block")
			{
				obj.style.display = "block"; //Õ¹¿ª
				imgParent.src = ImgJian;
			}
			else
			{ 
				obj.style.display = "none"; //ÊÕËõ
				ExpandOrShrinkTree(strID+"_"+i,strImgName);
				imgParent.src = ImgJia;
			} 
			i++;
		}
} 
