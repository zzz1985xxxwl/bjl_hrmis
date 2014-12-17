using System;
using System.Collections.Generic;
using System.Text;
using TransferDatas;

namespace TLeaveRequestFilter
{
    public class TLeaveRequestFilter : TableFilterTemplate
    {
        private const string _ProtectedTable = "TLeaveRequestItem";
        private TLeaveRequestItemFilter _LeaveRequestItemFilter = new TLeaveRequestItemFilter();

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
            return string.Format("delete from {0} where not ((absentFrom >= '{1}' and absentFrom <= '{2}') or (absentTo >= '{1}' and absentTo <= '{2}') or (absentFrom <= '{1}' and absentTo >= '{2}'))", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            //满足2段时间有交集就可以了
            return string.Format("select pkid from {0} where (absentFrom >= '{1}' and absentFrom <= '{2}') or (absentTo >= '{1}' and absentTo <= '{2}') or (absentFrom <= '{1}' and absentTo >= '{2}')", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add(_ProtectedTable, "LeaveRequestId");
            return retVal;
        }

        protected override string DefineOperationString()
        {
            StringBuilder sb = new StringBuilder(string.Format("根据时间筛选主表，根据外键删选表：{0}，", _ProtectedTable));
            sb.Append(_LeaveRequestItemFilter.ToString());
            return sb.ToString();
        }

        protected override string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _LeaveRequestItemFilter.AfterBackTableAndIds = tablesAndIds;
            return _LeaveRequestItemFilter.FilterTableData(startDay, endDay);
        }

        protected override string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _LeaveRequestItemFilter.BeforeRestoreTableAndIds = orginTablesAndIds;
            return _LeaveRequestItemFilter.RestoreTableData(startDay, endDay);
        }

        public override void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _LeaveRequestItemFilter.ConfigTheFilter(theRule, _ProtectedTable, orginDbName, orginCopyDbName, restoreDbName, forRestoreCopyDbName);
        }
    }
}
