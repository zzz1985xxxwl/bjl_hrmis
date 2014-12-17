using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAuth
{
    public interface IHrmisAuthTreeView
    {
        /// <summary>
        /// ��������
        /// </summary>
        List<Auth> rptPersonalManageDataSrc { set;}
        /// <summary>
        /// ��������
        /// </summary>
        List<Auth> rptParameterDataSrc { set;}

        /// <summary>
        /// �û�����
        /// </summary>
        List<Auth> rptAccountDataSrc { set;}

        /// <summary>
        /// ��֯�ṹ����
        /// </summary>
        List<Auth> rptDepartmentDataSrc { set;}

        /// <summary>
        /// Ա������
        /// </summary>
        List<Auth> rptEmployeeDataSrc { set;}

        /// <summary>
        /// ���ڹ���
        /// </summary>
        List<Auth> rptApplicationDataSrc { set;}

        /// <summary>
        /// н�ʹ���
        /// </summary>
        List<Auth> rptPayDataSrc { set;}

        /// <summary>
        /// ��Ч����
        /// </summary>
        List<Auth> rptPerformanceDataSrc { set;}

        /// <summary>
        /// ��ѵ����
        /// </summary>
        List<Auth> rptTrainingDataSrc { set;}

        /// <summary>
        /// ��������
        /// </summary>
        List<Auth> rptReimburseDataSrc { set;}

        /// <summary>
        /// ͳ�ƹ���
        /// </summary>
        List<Auth> rptStatisticsDataSrc { set;}

        /// <summary>
        /// ����ͬ��
        /// </summary>
        List<Auth> rptDataTransferDataSrc { set;}

    }
}
