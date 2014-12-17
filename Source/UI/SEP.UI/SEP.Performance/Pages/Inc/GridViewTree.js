var ImgJian = "../../Image/jian.gif";
var ImgJia = "../../Image/jia.gif";
//strID行ID
//strImgName图片ID
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
				obj.style.display = "block"; //展开
				imgParent.src = ImgJian;
			}
			else
			{ 
				obj.style.display = "none"; //收缩
				ExpandOrShrinkTree(strID+"_"+i,strImgName);
				imgParent.src = ImgJia;
			} 
			i++;
		}
} 
//strID行ID
//strcbName复选框ID
function SelectedNodeTree(strID, strcbName)
{
    SetChildrenNodeSelected(strID, strcbName);
    SetParentNodeSelected(strID, strcbName);
}
//strID行ID
//strcbName复选框ID
function SetChildrenNodeSelected(strID, strcbName)
{
		var i=1;
		var cbCurr = document.getElementById(strID+"_"+strcbName);
		//递归循环为子孙节点赋值checkbox
		while (document.getElementById(strID+"_"+i)) //循环子孙行
		{
		    document.getElementById(strID+"_"+i+"_"+strcbName).checked=cbCurr.checked;
		    SetChildrenNodeSelected(strID+"_"+i, strcbName);
			i++;
		}
}
//strID行ID
//strcbName复选框ID
function SetParentNodeSelected(strID, strcbName)
{
		var i=1;
		var cbCurr = document.getElementById(strID+"_"+strcbName);
		var cbCurrParentChecked = cbCurr.checked;//父节点最终的Check状态，初始化为cbCurr的状态
		var cbCurrParentID = GetParentIDByChildID(strID);
		if(cbCurr.checked)//如果当前cbCurr被选中，则要循环兄弟，判断是否所有兄弟都选中
		{
		    while (document.getElementById(cbCurrParentID+"_"+i)) //循环兄弟行
		    {
		        //只要有一个兄弟cb的状态与cbCurr状态不同，则跳出循环
		        if(cbCurrParentChecked != document.getElementById(cbCurrParentID+"_"+i+"_"+strcbName).checked)
		        {
		            cbCurrParentChecked = !cbCurr.checked;
		            break;
		        }
			    i++;
		    }
		}
		if(document.getElementById(cbCurrParentID+"_"+strcbName))
		{
		    document.getElementById(cbCurrParentID+"_"+strcbName).checked = cbCurrParentChecked;//改变父节点状态
		}
		//循环递归为祖父节点赋值checkbox
		if (document.getElementById(GetParentIDByChildID(cbCurrParentID)+"_"+1)) //是否有祖父
		{
            SetParentNodeSelected(cbCurrParentID, strcbName)
		}
}
//根据孩子行ID或取父亲ID
function GetParentIDByChildID(strChildID)
{
    var strParentID=strChildID.split("_")[0];
    try
    {
        for(var i=1;i<strChildID.split("_").length-1;i++)
        {
            strParentID = strParentID+"_"+strChildID.split("_")[i];
        } 
    }
    catch(ex){}
    return strParentID;
}