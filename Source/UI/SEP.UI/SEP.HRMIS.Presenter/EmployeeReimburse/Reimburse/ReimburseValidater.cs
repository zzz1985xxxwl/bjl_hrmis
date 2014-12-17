using System;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse
{
    public class ReimburseValidater
    {
        private readonly IReimburseView _IReimburseView;

        public ReimburseValidater(IReimburseView iReimburseView)
        {
            _IReimburseView = iReimburseView;
        }

        public bool Validate(bool isAuditing=false)
        {
            bool b_ret = true;
            _IReimburseView.Message = string.Empty;
            _IReimburseView.PaperCountMsg = string.Empty;
            _IReimburseView.DestinationsMsg = string.Empty;
            _IReimburseView.ProjectNameMsg = string.Empty;
            _IReimburseView.ConsumeDateMsg = string.Empty;
            _IReimburseView.OutCityDaysMsg = string.Empty;
            _IReimburseView.OutCityAllowanceMsg = string.Empty;
            _IReimburseView.lblApplyDateMsg = string.Empty;

            if (!string.IsNullOrEmpty(_IReimburseView.OutCityDays))
            {
                decimal temp;
                if (!decimal.TryParse(_IReimburseView.OutCityDays, out temp))
                {
                    _IReimburseView.OutCityDaysMsg = ReimburseUtility._DateError;
                    b_ret = false;
                }
            }
            if (!string.IsNullOrEmpty(_IReimburseView.OutCityAllowance))
            {
                decimal temp;
                if (!decimal.TryParse(_IReimburseView.OutCityAllowance, out temp))
                {
                    _IReimburseView.OutCityAllowanceMsg = ReimburseUtility._DateError;
                    b_ret = false;
                }
            }
            if (_IReimburseView.ReimburseItemSource == null || _IReimburseView.ReimburseItemSource.Count == 0)
            {
                _IReimburseView.Message = ReimburseUtility._NoReimburseItem;
                b_ret = false;
            }
            // ������������Ϊ��
            if (string.IsNullOrEmpty(_IReimburseView.PaperCount.Trim()))
            {
                _IReimburseView.PaperCountMsg = ReimburseUtility._IsEmpty;
                b_ret = false;
            }
            else
            {
                int inttemp;
                if (!Int32.TryParse(_IReimburseView.PaperCount.Trim(), out inttemp))
                {
                    _IReimburseView.PaperCountMsg = ReimburseUtility._PaperCountError;
                    b_ret = false;
                }
                else if (inttemp <= 0)
                {
                    _IReimburseView.PaperCountMsg = ReimburseUtility._PaperCountThanZero;
                    b_ret = false;
                }
            }
            if (_IReimburseView.IsTravelReimburse)
            {
                // Ŀ�ĵز���Ϊ��
                if (string.IsNullOrEmpty(_IReimburseView.Destinations.Trim()))
                {
                    _IReimburseView.DestinationsMsg = ReimburseUtility._IsEmpty;
                    b_ret = false;
                }
                if(string.IsNullOrEmpty(_IReimburseView.ProjectName.Trim()))
                {
                    _IReimburseView.ProjectNameMsg = "����Ϊ��";
                    b_ret = false;
                }
                else if(!isAuditing)
                {
                    var projectInfo = ProjectInfoLogic.GetProjectInfoByName(_IReimburseView.ProjectName);
                    if (projectInfo == null)
                    {
                        _IReimburseView.ProjectNameMsg = "�����ڸ���Ŀ";
                        b_ret = false;
                    }
                }
            }


            if (string.IsNullOrEmpty(_IReimburseView.ApplyDate))
            {
                _IReimburseView.lblApplyDateMsg = ReimburseUtility._IsEmpty;
                b_ret = false;
            }
            else
            {
                DateTime dt;
                if (!DateTime.TryParse(_IReimburseView.ApplyDate, out dt))
                {
                    _IReimburseView.lblApplyDateMsg = ReimburseUtility._TimeIsError;
                    b_ret = false;
                }
            }
            if (string.IsNullOrEmpty(_IReimburseView.ConsumeDateFrom) ||
                string.IsNullOrEmpty(_IReimburseView.ConsumeDateTo))
            {
                _IReimburseView.ConsumeDateMsg = "����ʱ�䲻��Ϊ�ա�";
                b_ret = false;
            }
            else
            {
                DateTime dtConsumeDateFrom;
                DateTime dtConsumeDateTo;
                if (
                    !(DateTime.TryParse(_IReimburseView.ConsumeDateFrom, out dtConsumeDateFrom) &&
                      DateTime.TryParse(_IReimburseView.ConsumeDateTo, out dtConsumeDateTo)))
                {
                    _IReimburseView.ConsumeDateMsg = "����ʱ���ʽ����ȷ��";
                    b_ret = false;
                }
                else
                {
                    dtConsumeDateFrom =
                        new DateTime(dtConsumeDateFrom.Year, dtConsumeDateFrom.Month, dtConsumeDateFrom.Day,
                                     Convert.ToInt32(_IReimburseView.ConsumeDateFromHour),
                                     Convert.ToInt32(_IReimburseView.ConsumeDateFromMinute), 0);
                    dtConsumeDateTo = new DateTime(dtConsumeDateTo.Year, dtConsumeDateTo.Month, dtConsumeDateTo.Day,
                                                   Convert.ToInt32(_IReimburseView.ConsumeDateToHour),
                                                   Convert.ToInt32(_IReimburseView.ConsumeDateToMinute), 0);

                    if (DateTime.Compare(dtConsumeDateFrom, dtConsumeDateTo) > 0)
                    {
                        _IReimburseView.ConsumeDateMsg = "��ʼʱ�䲻�����ڽ���ʱ�䡣";
                        b_ret = false;
                    }
                }
            }
            return b_ret;
        }
    }
}