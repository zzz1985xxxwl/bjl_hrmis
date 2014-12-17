
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Presenter.IPresenter.IAuths
{
    public interface IAuthTreeView
    {
        /// <summary>
        /// �û�����
        /// </summary>
        List<Auth> rptAccountManageDataSrc { set;}

        /// <summary>
        /// ��֯�ṹ����
        /// </summary>
        List<Auth> rptDeptManageDataSrc { set;}

        /// <summary>
        /// �������
        /// </summary>
        List<Auth> rptBulletinsManageDataSrc { set;}

        /// <summary>
        /// ��˾Ŀ�����
        /// </summary>
        List<Auth> rptGoalMangeDataSrc { set;}

        /// <summary>
        /// ��ҵ�Ļ�
        /// </summary>
        List<Auth> rptCompanuManageDataSrc { set;}

        /// <summary>
        /// ��ֵ����
        /// </summary>
        List<Auth> rptServiceManageDataSrc { set;}
        /// <summary>
        /// ��������
        /// </summary>
        List<Auth> rptPersonalManageDataSrc { set;}
    }
}
