using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IPrintReimburseView
    {
        Employee Employee { get; set; }

        Reimburse Reimburse { get; set; }

        string Title { get; set; }

        string DepartmentName { get; set; }

        //string CompanyName { get; set; }
        //bool IsTravelReimburse { get; set; }

        string PaperCount { get; set; }

        string ConsumeDate { get; set; }

        string Destinations { get; set; }

        string ProjectName { get; set; }
        List<ReimburseItem> ReimburseItemSource { get; set; }

        /// <summary>
        /// CEO����ǩ��
        /// </summary>
        byte[] CEOElectricName { get; set;}

        /// <summary>
        /// �������ǩ��
        /// </summary>
        byte[] FinanceElectricName { get; set;}

        /// <summary>
        /// �����쵼����ǩ��
        /// </summary>
        byte[] DepartmentLeaderElectricName { get; set;}

        /// <summary>
        /// ����˵���ǩ��
        /// </summary>
        //byte[] RecipientsElectricName { get; set;}
    }
}
