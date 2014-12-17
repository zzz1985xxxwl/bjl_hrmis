using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train
{
    internal class FeedBackQuestionEditor
    {
        private readonly IFeedBackPaperView _ITemplatePaperView;
        private readonly ITrainFacade _IFacade;

        public FeedBackQuestionEditor(IFeedBackPaperView accountSetView)
        {
            _ITemplatePaperView = accountSetView;
            _IFacade = InstanceFactory.CreateTrainFacade();
        }
        public FeedBackQuestionEditor(IFeedBackPaperView accountSetView, ITrainFacade iAccountSetFacade)
        {
            _ITemplatePaperView = accountSetView;
            _IFacade = iAccountSetFacade;
        }

        private List<TrainFBQuestion> UpdateRowPara(string rowIndex, string itemId)
        {
            TrainFBQuestion item =
                _IFacade.GetFBQuestionByID(Convert.ToInt32(itemId));
            if (item == null)
            {
                return _ITemplatePaperView.QuestionList;
            }
            List<TrainFBQuestion> items = _ITemplatePaperView.QuestionList;
            items[Convert.ToInt32(rowIndex)] = item;
            return items;
        }
        /// <summary>
        /// �ڽ�����������ѡ��Para��ʵ����Para�У������б�������ӿ���
        /// </summary>
        /// <param name="itemId"></param>
        public void ddlChangedForAddEvent(string itemId)
        {
            List<TrainFBQuestion> items = UpdateRowPara((_ITemplatePaperView.QuestionList
                .Count - 1).ToString(),
                                                           itemId);
            items.Add(new TrainFBQuestion(-1,string.Empty,new TrainFBQuesType(-1,string.Empty),new List<TrainFBItem>() ));
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// �޸�rowIndex����Ϣ
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="itemId"></param>
        public void ddlChangedForUpdateEvent(string rowIndex, string itemId)
        {
            _ITemplatePaperView.QuestionList = UpdateRowPara(rowIndex, itemId);
        }
        /// <summary>
        /// ɾ��rowIndex��
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ddlChangedForDeleteEvent(string rowIndex)
        {
            List<TrainFBQuestion> items = _ITemplatePaperView.QuestionList;
            items.RemoveAt(Convert.ToInt32(rowIndex));
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// ��rowIndex����������
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ddlAssessItemChangedForAddAtEvent(string rowIndex)
        {
            List<TrainFBQuestion> items = new List<TrainFBQuestion>();
            for (int i = 0; i < _ITemplatePaperView.QuestionList.Count; i++)
            {
                if (Convert.ToInt32(rowIndex) == i)
                {
                    items.Add(new TrainFBQuestion(-1, string.Empty, new TrainFBQuesType(-1, string.Empty), new List<TrainFBItem>()));
                }
                items.Add(_ITemplatePaperView.QuestionList[i]);
            }
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// ������id��<==>��id-1��
        /// </summary>
        /// <param name="id"></param>
        public void ddlAssessItemChangedForUpEvent(string id)
        {
            List<TrainFBQuestion> items = _ITemplatePaperView.QuestionList;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            TrainFBQuestion tempItem = items[currRow - 1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// ������id��<==>��id+1��
        /// </summary>
        /// <param name="id"></param>
        public void ddlAssessItemChangedForDownEvent(string id)
        {
            List<TrainFBQuestion> items = _ITemplatePaperView.QuestionList;
            int currRow = Convert.ToInt32(id);
            if (currRow + 2 == items.Count)
            {
                return;
            }
            TrainFBQuestion tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// ճ���¼�����AccountSet���󣬶���AccountSetItem���-1�У����һ�����Ͽ���
        /// </summary>
        public void btnPasteEvent()
        {
            _ITemplatePaperView.TemplatePaperName = _ITemplatePaperView.SessionCopyPaper.FeedBackPaperName;

            List<TrainFBQuestion> items = new List<TrainFBQuestion>();
            for (int i = 0; i < _ITemplatePaperView.SessionCopyPaper.FBQuestions.Count; i++)
            {
                if (_ITemplatePaperView.SessionCopyPaper.FBQuestions[i].FBQuestioniD != -1)
                {
                    items.Add(_ITemplatePaperView.SessionCopyPaper.FBQuestions[i]);
                }
            }
            items.Add(new TrainFBQuestion(-1, string.Empty, new TrainFBQuesType(-1, string.Empty), new List<TrainFBItem>()));
            _ITemplatePaperView.QuestionList = items;
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        public void btnCopyEvent()
        {
            Model.FeedBackPaper paper = new Model.FeedBackPaper();
            paper.FeedBackPaperId = 0;
            paper.FeedBackPaperName = _ITemplatePaperView.TemplatePaperName;
            paper.FBQuestions = _ITemplatePaperView.QuestionList;
            _ITemplatePaperView.SessionCopyPaper = paper;
        }
    }
}
