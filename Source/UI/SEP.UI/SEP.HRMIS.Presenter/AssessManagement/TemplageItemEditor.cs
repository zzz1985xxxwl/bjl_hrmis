using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.AssessManagement
{
    internal class TemplageItemEditor
    {
        private readonly ITemplatePaperView _ITemplatePaperView;
        private readonly IAssessManagementFacade _IAssessManagementFacade;

        public TemplageItemEditor(ITemplatePaperView accountSetView)
        {
            _ITemplatePaperView = accountSetView;
            _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        }
        public TemplageItemEditor(ITemplatePaperView accountSetView, IAssessManagementFacade iAccountSetFacade)
        {
            _ITemplatePaperView = accountSetView;
            _IAssessManagementFacade = iAccountSetFacade;
        }

        private List<AssessTemplateItem> UpdateRowPara(string rowIndex, string itemId)
        {
            AssessTemplateItem item =
                _IAssessManagementFacade.GetTemplateItemById(Convert.ToInt32(itemId));
            if (item == null)
            {
                return _ITemplatePaperView.AssessItemList;
            }
            List<AssessTemplateItem> items = _ITemplatePaperView.AssessItemList;
            items[Convert.ToInt32(rowIndex)] = item;
            return items;
        }
        /// <summary>
        /// �ڽ�����������ѡ��Para��ʵ����Para�У������б�������ӿ���
        /// </summary>
        /// <param name="itemId"></param>
        public void ddlChangedForAddEvent(string itemId)
        {
            List<AssessTemplateItem> items = UpdateRowPara((_ITemplatePaperView.AssessItemList.Count - 1).ToString(),
                                                           itemId);
            items.Add(new AssessTemplateItem(-1, null, OperateType.NotHR));
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// �޸�rowIndex����Ϣ
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="itemId"></param>
        public void ddlChangedForUpdateEvent(string rowIndex, string itemId)
        {
            _ITemplatePaperView.AssessItemList = UpdateRowPara(rowIndex, itemId);
        }
        /// <summary>
        /// ɾ��rowIndex��
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ddlChangedForDeleteEvent(string rowIndex)
        {
            List<AssessTemplateItem> items = _ITemplatePaperView.AssessItemList;
            items.RemoveAt(Convert.ToInt32(rowIndex));
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// ��rowIndex����������
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ddlAssessItemChangedForAddAtEvent(string rowIndex)
        {
            List<AssessTemplateItem> items = new List<AssessTemplateItem>();
            for (int i = 0; i < _ITemplatePaperView.AssessItemList.Count; i++)
            {
                if (Convert.ToInt32(rowIndex) == i)
                {
                    items.Add(new AssessTemplateItem(-1, null, OperateType.NotHR));
                }
                items.Add(_ITemplatePaperView.AssessItemList[i]);
            }
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// ������id��<==>��id-1��
        /// </summary>
        /// <param name="id"></param>
        public void ddlAssessItemChangedForUpEvent(string id)
        {
            List<AssessTemplateItem> items = _ITemplatePaperView.AssessItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            AssessTemplateItem tempItem = items[currRow - 1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// ������id��<==>��id+1��
        /// </summary>
        /// <param name="id"></param>
        public void ddlAssessItemChangedForDownEvent(string id)
        {
            List<AssessTemplateItem> items = _ITemplatePaperView.AssessItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow + 2 == items.Count)
            {
                return;
            }
            AssessTemplateItem tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// ճ���¼�����AccountSet���󣬶���AccountSetItem���-1�У����һ�����Ͽ���
        /// </summary>
        public void btnPasteEvent()
        {
            _ITemplatePaperView.TemplatePaperName = _ITemplatePaperView.SessionCopyPaper.PaperName;
            
            List<AssessTemplateItem> items = new List<AssessTemplateItem>();
            for (int i = 0; i < _ITemplatePaperView.SessionCopyPaper.ItsAssessTemplateItems.Count; i++)
            {
                if (_ITemplatePaperView.SessionCopyPaper.ItsAssessTemplateItems[i].AssessTemplateItemID != -1)
                {
                    items.Add(_ITemplatePaperView.SessionCopyPaper.ItsAssessTemplateItems[i]);
                }
            }
            items.Add(new AssessTemplateItem(-1, "", OperateType.NotHR));
            _ITemplatePaperView.AssessItemList = items;
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        public void btnCopyEvent()
        {
            AssessTemplatePaper paper = new AssessTemplatePaper(0, _ITemplatePaperView.TemplatePaperName, _ITemplatePaperView.AssessItemList);
            _ITemplatePaperView.SessionCopyPaper = paper;
        }
    }
}
