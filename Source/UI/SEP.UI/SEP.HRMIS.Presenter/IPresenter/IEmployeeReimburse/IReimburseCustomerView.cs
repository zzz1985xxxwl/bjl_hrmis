//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReimburseCustomerView.cs
// ������: ����
// ��������: 2009-09-07
// ����: ��ӳ���ͻ�����
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
   public interface IReimburseCustomerView
    {
        string DepartmentName { set;}
        Reimburse Reimburse { get; set;}

       string ApplierName { set;}

        string Message { get; set; }

        string ApplyDate { get; set; }

        List<ReimburseItem> ReimburseItemSource { get; set; }
        string PaperCount { get; set;  }
        string Destinations { get; set;  }
        string ProjectName { get; set;  }

        event EventHandler btnOKClick;


        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateFrom { get; set;  }


        /// <summary>
        /// ����ʱ��
        /// </summary>
        string ConsumeDateTo { get; set;  }


        /// <summary>
        /// Ͷ�����
        /// </summary>
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        /// <summary>
        /// Ͷ���������
        /// </summary>
        string ReimburseCategoriesEnumID { set; get;}


        /// <summary>
        /// ���ñ���
        /// </summary>
        bool IsTravelReimburse { get; set; }


        string OutCityAllowance { get; set;  }

        string OutCityDays { get; set;  }

        string Remark { get; set;  }
    }
}
