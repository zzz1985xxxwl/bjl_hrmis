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
        /// CEO电子签名
        /// </summary>
        byte[] CEOElectricName { get; set;}

        /// <summary>
        /// 财务电子签名
        /// </summary>
        byte[] FinanceElectricName { get; set;}

        /// <summary>
        /// 部门领导电子签名
        /// </summary>
        byte[] DepartmentLeaderElectricName { get; set;}

        /// <summary>
        /// 领款人电子签名
        /// </summary>
        //byte[] RecipientsElectricName { get; set;}
    }
}
