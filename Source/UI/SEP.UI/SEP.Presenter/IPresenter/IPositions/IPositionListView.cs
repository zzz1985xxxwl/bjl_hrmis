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
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// 查看详情界面
        /// </summary>
        event DelegateID BtnDetailEvent;

    }
    
}
