
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Presenter.IPresenter.IAuths
{
    public interface IAuthTreeView
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        List<Auth> rptAccountManageDataSrc { set;}

        /// <summary>
        /// 组织结构管理
        /// </summary>
        List<Auth> rptDeptManageDataSrc { set;}

        /// <summary>
        /// 公告管理
        /// </summary>
        List<Auth> rptBulletinsManageDataSrc { set;}

        /// <summary>
        /// 公司目标管理
        /// </summary>
        List<Auth> rptGoalMangeDataSrc { set;}

        /// <summary>
        /// 企业文化
        /// </summary>
        List<Auth> rptCompanuManageDataSrc { set;}

        /// <summary>
        /// 增值服务
        /// </summary>
        List<Auth> rptServiceManageDataSrc { set;}
        /// <summary>
        /// 个人设置
        /// </summary>
        List<Auth> rptPersonalManageDataSrc { set;}
    }
}
