//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{

    public class OutApplicationUtility
    {
        private readonly IOutApplicationEditView _View;

        public OutApplicationUtility(IOutApplicationEditView view)
        {
            _View = view;
        }

        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ApplicationItemForAddAtEvent(string rowIndex)
        {
            List<OutApplicationItem> applicationList = _View.ApplicationItemList;
            List<OutApplicationItem> items = new List<OutApplicationItem>();
            for (int i = 0; i < applicationList.Count; i++)
            {
                items.Add(applicationList[i]);
                if (Convert.ToInt32(rowIndex) == i)
                {
                    AddNullItem(items);
                }
            }
            _View.ApplicationItemList = items;
        }

        /// <summary>
        /// 删除rowIndex行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ApplicationItemForDeleteAtEvent(string rowIndex)
        {
            List<OutApplicationItem> items = _View.ApplicationItemList;
            if (rowIndex == "0" && items.Count == 1)
            {
                items[0].FromDate = DateTime.Now.Date;
                items[0].ToDate = DateTime.Now.Date;
            }
            else
            {
                items.RemoveAt(Convert.ToInt32(rowIndex));
            }
            _View.ApplicationItemList = items;
        }

        public bool Validation()
        {
            bool valid=true;
            if (string.IsNullOrEmpty(_View.OutLocation))
            {
                valid = false;
                _View.OutLocationMessage = "不能为空";
            }
            if(string.IsNullOrEmpty(_View.Reason))
            {
                valid = false;
                _View.ReasonMessage = "不能为空";
            }
            return valid;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime GetFromDate(List<OutApplicationItem> outApplicationItemList)
        {
            DateTime fromDate = outApplicationItemList[0].FromDate;
            foreach (OutApplicationItem item in outApplicationItemList)
            {
                if (item.FromDate.CompareTo(fromDate) < 0)
                {
                    fromDate = item.FromDate;
                }
            }
            return fromDate;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime GetToDate(List<OutApplicationItem> outApplicationItemList)
        {
            DateTime toDate = outApplicationItemList[0].ToDate;
            foreach (OutApplicationItem item in outApplicationItemList)
            {
                if (item.ToDate.CompareTo(toDate) > 0)
                {
                    toDate = item.ToDate;
                }
            }
            return toDate;
        }

        /// <summary>
        /// 时间段，按小时计
        /// </summary>
        public Decimal GetCostTime(List<OutApplicationItem> outApplicationItemList)
        {
            decimal costTime = 0;
            if (outApplicationItemList != null && outApplicationItemList.Count > 0)
            {
                foreach (OutApplicationItem item in outApplicationItemList)
                {
                    costTime += item.CostTime;
                }
            }
            return costTime;
        }

        public static List<OutApplicationItem> AddNullItem(List<OutApplicationItem> items)
        {
            DateTime now = DateTime.Now;
            DateTime show = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            OutApplicationItem item = new OutApplicationItem(-1, show, show, 0, RequestStatus.New,true,0);
            items.Add(item);
            return items;
        }

        public OutApplication OutCollector(RequestStatus status)
        {
            Account account = new Account(_View.EmployeeID, "", _View.EmployeeName);
            List<OutApplicationItem> applicationitems = _View.ApplicationItemList;
            foreach (OutApplicationItem item in applicationitems)
            {
                item.Status = status;
            }
            OutApplication outApplicatin =
                new OutApplication(_View.ApplicationID, account, _View.SubmitDate, _View.Reason,
                                   GetFromDate(applicationitems),
                                   GetToDate(applicationitems),
                                   GetCostTime(applicationitems),
                                   applicationitems, _View.OutLocation,_View.OutType);
            return outApplicatin;
        }

    }

    public enum OperationType
    {
        Confirm,
        Cancel
    }

}