var ImgJian = "../../Image/jian.gif";
var ImgJia = "../../Image/jia.gif";
//strID��ID
//strImgNameͼƬID
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
				obj.style.display = "block"; //չ��
				imgParent.src = ImgJian;
			}
			else
			{ 
				obj.style.display = "none"; //����
				ExpandOrShrinkTree(strID+"_"+i,strImgName);
				imgParent.src = ImgJia;
			} 
			i++;
		}
} 
//strID��ID
//strcbName��ѡ��ID
function SelectedNodeTree(strID, strcbName)
{
    SetChildrenNodeSelected(strID, strcbName);
    SetParentNodeSelected(strID, strcbName);
}
//strID��ID
//strcbName��ѡ��ID
function SetChildrenNodeSelected(strID, strcbName)
{
		var i=1;
		var cbCurr = document.getElementById(strID+"_"+strcbName);
		//�ݹ�ѭ��Ϊ����ڵ㸳ֵcheckbox
		while (document.getElementById(strID+"_"+i)) //ѭ��������
		{
		    document.getElementById(strID+"_"+i+"_"+strcbName).checked=cbCurr.checked;
		    SetChildrenNodeSelected(strID+"_"+i, strcbName);
			i++;
		}
}
//strID��ID
//strcbName��ѡ��ID
function SetParentNodeSelected(strID, strcbName)
{
		var i=1;
		var cbCurr = document.getElementById(strID+"_"+strcbName);
		var cbCurrParentChecked = cbCurr.checked;//���ڵ����յ�Check״̬����ʼ��ΪcbCurr��״̬
		var cbCurrParentID = GetParentIDByChildID(strID);
		if(cbCurr.checked)//�����ǰcbCurr��ѡ�У���Ҫѭ���ֵܣ��ж��Ƿ������ֵܶ�ѡ��
		{
		    while (document.getElementById(cbCurrParentID+"_"+i)) //ѭ���ֵ���
		    {
		        //ֻҪ��һ���ֵ�cb��״̬��cbCurr״̬��ͬ��������ѭ��
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
		    document.getElementById(cbCurrParentID+"_"+strcbName).checked = cbCurrParentChecked;//�ı丸�ڵ�״̬
		}
		//ѭ���ݹ�Ϊ�游�ڵ㸳ֵcheckbox
		if (document.getElementById(GetParentIDByChildID(cbCurrParentID)+"_"+1)) //�Ƿ����游
		{
            SetParentNodeSelected(cbCurrParentID, strcbName)
		}
}
//���ݺ�����ID��ȡ����ID
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