//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelAllOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.OverWorks.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class CancelAllOverWork : Transaction
    {
        private readonly int _OverWorkID;
        private readonly string _Remark;
        private OverWork _OverWork;
        private readonly IOverWork _DalOverWork = DalFactory.DataAccess.CreateOverWork();
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();

        /// <summary>
        /// </summary>
        public CancelAllOverWork(int OverWorkID, string remark)
        {
            _OverWorkID = OverWorkID;
            _Remark = remark;
        }

        protected override void Validation()
        {
            _OverWork = _DalOverWork.GetOverWorkByOverWorkID(_OverWorkID);
            if (_OverWork == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OverWork_Not_Exit);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                bool sendmail = false;
                foreach (OverWorkItem item in _OverWork.Item)
                {
                    bool valide = CancelOverWorkItem.CancelOneItem(item, _OverWork.Account, _Remark,
                                                                   _DalOverWork, _OverWorkDiyProcessUtility);
                    if (valide)
                    {
                        new OverWorkMailAndPhoneDelegate().CancelOperation(_OverWorkID, item.ItemID);
                        sendmail = true;
                    }
                }
                if (sendmail)
                {
                    new OverWorkMailAndPhoneDelegate().CancelOperationMail(_OverWorkID);
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}