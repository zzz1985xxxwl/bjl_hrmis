//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{

    public class OverWorkUtility
    {
        private readonly IOverWorkEditView _View;

        public OverWorkUtility(IOverWorkEditView view)
        {
            _View = view;
        }

        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ApplicationItemForAddAtEvent(string rowIndex)
        {
            List<OverWorkItem> applicationList = _View.ApplicationItemList;
            List<OverWorkItem> items = new List<OverWorkItem>();
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
            List<OverWorkItem> items = _View.ApplicationItemList;
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
            if (string.IsNullOrEmpty(_View.ProjectName))
            {
                valid = false;
                _View.ProjectNameMessage = "不能为空";
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
        public DateTime GetFromDate(List<OverWorkItem> OverWorkItemList)
        {
            DateTime fromDate = OverWorkItemList[0].FromDate;
            foreach (OverWorkItem item in OverWorkItemList)
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
        public DateTime GetToDate(List<OverWorkItem> OverWorkItemList)
        {
            DateTime toDate = OverWorkItemList[0].ToDate;
            foreach (OverWorkItem item in OverWorkItemList)
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
        public Decimal GetCostTime(List<OverWorkItem> OverWorkItemList)
        {
            decimal costTime = 0;
            if (OverWorkItemList != null && OverWorkItemList.Count > 0)
            {
                foreach (OverWorkItem item in OverWorkItemList)
                {
                    costTime += item.CostTime;
                }
            }
            return costTime;
        }

        public static List<OverWorkItem> AddNullItem(List<OverWorkItem> items)
        {
            DateTime now = DateTime.Now;
            DateTime show = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            OverWorkItem item = new OverWorkItem(-1, show, show, 0, RequestStatus.New,OverWorkType.PuTong,true,0);
            items.Add(item);
            return items;
        }

        public OverWork OverWorkCollector(RequestStatus status)
        {
            Account account = new Account(_View.EmployeeID, "", _View.EmployeeName);
            List<OverWorkItem> applicationitems = _View.ApplicationItemList;
            foreach (OverWorkItem item in applicationitems)
            {
                item.Status = status;
            }
            OverWork outApplicatin =
                new OverWork(_View.ApplicationID, account, _View.SubmitDate, _View.Reason,
                                   GetFromDate(applicationitems),
                                   GetToDate(applicationitems),
                                   GetCostTime(applicationitems),
                                   applicationitems, _View.ProjectName);
            return outApplicatin;
        }



    }

}