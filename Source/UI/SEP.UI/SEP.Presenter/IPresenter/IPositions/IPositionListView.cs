using System.Collections.Generic;
using SEP.Model.Positions;

namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionListView
    {
        string PositionName { get; set;}

        string Message { set; get;}

        List<Position> positions { set; get;}

        //List<PositionGrade> PositionGradeSource { set;}

        //string PositionGradeId { get;set;}
        //string PositionGradeName { get;set;}

        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// �鿴�������
        /// </summary>
        event DelegateID BtnDetailEvent;

    }
    
}
