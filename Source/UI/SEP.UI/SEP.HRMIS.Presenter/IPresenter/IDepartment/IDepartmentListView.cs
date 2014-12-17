using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentListView
    {
        string Message { set; get;}

        List<Department> Departments { set; get;}
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateID BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// 查看详情事件
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
