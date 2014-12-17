using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAuth
{
    public interface IHrmisAuthTreeView
    {
        /// <summary>
        /// 自助服务
        /// </summary>
        List<Auth> rptPersonalManageDataSrc { set;}
        /// <summary>
        /// 参数设置
        /// </summary>
        List<Auth> rptParameterDataSrc { set;}

        /// <summary>
        /// 用户管理
        /// </summary>
        List<Auth> rptAccountDataSrc { set;}

        /// <summary>
        /// 组织结构管理
        /// </summary>
        List<Auth> rptDepartmentDataSrc { set;}

        /// <summary>
        /// 员工管理
        /// </summary>
        List<Auth> rptEmployeeDataSrc { set;}

        /// <summary>
        /// 考勤管理
        /// </summary>
        List<Auth> rptApplicationDataSrc { set;}

        /// <summary>
        /// 薪资管理
        /// </summary>
        List<Auth> rptPayDataSrc { set;}

        /// <summary>
        /// 绩效管理
        /// </summary>
        List<Auth> rptPerformanceDataSrc { set;}

        /// <summary>
        /// 培训管理
        /// </summary>
        List<Auth> rptTrainingDataSrc { set;}

        /// <summary>
        /// 报销管理
        /// </summary>
        List<Auth> rptReimburseDataSrc { set;}

        /// <summary>
        /// 统计管理
        /// </summary>
        List<Auth> rptStatisticsDataSrc { set;}

        /// <summary>
        /// 数据同步
        /// </summary>
        List<Auth> rptDataTransferDataSrc { set;}

    }
}
