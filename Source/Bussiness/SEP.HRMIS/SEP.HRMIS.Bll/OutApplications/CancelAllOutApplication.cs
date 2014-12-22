//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelAllOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-16
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.OutApplications.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary> 
    /// </summary>
    public class CancelAllOutApplication : Transaction
    {
        private readonly int _OutApplicationID;
        private readonly string _Remark;
        private OutApplication _OutApplication;
        private readonly IOutApplication _DalOutApplication = new OutApplicationDal();
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// </summary>
        public CancelAllOutApplication(int OutApplicationID, string remark)
        {
            _OutApplicationID = OutApplicationID;
            _Remark = remark;
        }

        protected override void Validation()
        {
            _OutApplication = _DalOutApplication.GetOutApplicationByOutApplicationID(_OutApplicationID);
            if (_OutApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OutApplication_Not_Exit);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                bool sendmail = false;
                foreach (OutApplicationItem item in _OutApplication.Item)
                {
                    bool valide =
                        CancelOutApplicationItem.CancelOneItem(item, _OutApplication.Account, _Remark,
                                                               _DalOutApplication, _OutDiyProcessUtility, _OutApplication);
                    if (valide)
                    {
                        new OutMailAndPhoneDelegate().CancelOperation(_OutApplication.PKID, item.ItemID);
                        sendmail = true;
                    }
                }
                if (sendmail)
                {
                    new OutMailAndPhoneDelegate().CancelOperationMail(_OutApplication.PKID);
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}