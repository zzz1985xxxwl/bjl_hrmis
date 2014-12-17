using System;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseView
    {
        string DepartmentName { set;}
        Reimburse Reimburse { get; set;}

        string Message { get; set; }

        Employee Employee { get; set; }

        string ApplyDate { get; set; }

        List<ReimburseItem> ReimburseItemSource { get; set; }

        string Operation { get; set; }
        int ExchangeRateID{ get; set; }

        List<ExchangeRateEntity> ExchangeRateSource { set; }
        int SetDeleteFormButton { set; }

        bool SetFormReadonly { get; set; }

        //bool SetUpdateReadonly { set; }

        bool SetDetailReadonly { set; }

        bool SetComfirmReadonly { set;}

        bool SetOutCityVisible{ set;}

        event DelegateID btnUpdateClick;

        event DelegateID btnDeleteClick;

        event DelegateNoParameter btnAddClick;
        string lblApplyDateMsg { set;}
        event EventHandler btnSaveClick;
        event EventHandler btnSubmitClick;
        event EventHandler btnOKClick;
        event EventHandler btnCancelClick;
        event DelegateID btnDetailClick;
        event DelegateID btnPassClick;
        event DelegateID btnIntermitClick;
        event DelegateNoParameter BindReimburseHistorySource;
        /// <summary>
        /// ��ϵ��
        /// </summary>
        List<ReimburseFlow> ReimburseHistorySource { set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateFrom { get; set;  }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateFromHour { get; set;  }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateFromMinute { get; set;  }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateTo { get; set;  }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateToHour { get; set;  }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateToMinute { get; set;  }

        string ConsumeDateMsg { get; set; }

        /// <summary>
        /// Ͷ�����
        /// </summary>
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        /// <summary>
        /// Ͷ���������
        /// </summary>
        string ReimburseCategoriesEnumID { set; get;}

        /// <summary>
        /// ��������
        /// </summary>
        string PaperCount { get; set;  }
        string PaperCountMsg { get; set; }

        /// <summary>
        /// ���ñ���
        /// </summary>
        bool IsTravelReimburse { get; set; }

        /// <summary>
        /// Ŀ�ĵ�
        /// </summary>
        string Destinations { get; set;  }
        string DestinationsMsg { get; set; }

        /// <summary>
        /// �ͻ�
        /// </summary>
        //string CustomerName { get; set;  }
        //string CustomerNameMsg { get; set; }

        /// <summary>
        /// ��Ŀ
        /// </summary>
        string ProjectName { get; set;  }
        string ProjectNameMsg { get; set; }
        int ProjectID { get; set; }

        string OutCityAllowance { get; set;  }
        string OutCityAllowanceMsg { get; set;  }

        string OutCityDays { get; set;  }
        string OutCityDaysMsg { get; set;  }

        string Remark { get; set;  }
        string Discription { get; set; }


    }
}
