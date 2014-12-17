using System;
using System.Collections.Generic;
using System.Text;
using TransferDatas;

namespace TLeaveRequestFilter
{
    public class TLeaveRequestFilter : TableFilterTemplate
    {
        private const string _ProtectedTable = "TLeaveRequestItem";
        private TLeaveRequestItemFilter _LeaveRequestFilterItemFilter = new TLeaveRequestItemFilter();

        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TLeaveRequestFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where not (AbsentFrom<='{2}' and '{1}'<=AbsentTo)", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select pkid from {0} where AbsentFrom<='{2}' and '{1}'<=AbsentTo", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add(_ProtectedTable, "LeaveRequestID");
            return retVal;
        }

        protected override string DefineOperationString()
        {
            StringBuilder sb = new StringBuilder(string.Format("根据时间筛选主表，根据外键删选表：{0}，", _ProtectedTable));
            sb.Append(_LeaveRequestFilterItemFilter.ToString());
            return sb.ToString();
        }

        protected override string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _LeaveRequestFilterItemFilter.AfterBackTableAndIds = tablesAndIds;
            return _LeaveRequestFilterItemFilter.FilterTableData(startDay, endDay);
        }

        protected override string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _LeaveRequestFilterItemFilter.BeforeRestoreTableAndIds = orginTablesAndIds;
            return _LeaveRequestFilterItemFilter.RestoreTableData(startDay, endDay);
        }

        public override void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _LeaveRequestFilterItemFilter.ConfigTheFilter(theRule, _ProtectedTable, orginDbName, orginCopyDbName, restoreDbName, forRestoreCopyDbName);
            _LeaveRequestFilterItemFilter.IgnoreMainTableProcess = true;
        }
    }
}
