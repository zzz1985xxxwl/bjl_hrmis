using System;
using System.Collections.Generic;
using System.Text;
using TransferDatas;

namespace TOutApplicationFilter
{
    public class TOutApplicationFilter : TableFilterTemplate
    {
        private const string _ProtectedTable = "TOutApplicationItem";
        private TOutApplicationItemFilter _OutApplicationItemFilter = new TOutApplicationItemFilter();

        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TOutApplicationFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where not ([From]<='{2}' and '{1}'<=[To])", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select pkid from {0} where [From]<='{2}' and '{1}'<=[To]", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add(_ProtectedTable, "OutApplicationID");
            return retVal;
        }

        protected override string DefineOperationString()
        {
            StringBuilder sb = new StringBuilder(string.Format("根据时间筛选主表，根据外键删选表：{0}，", _ProtectedTable));
            sb.Append(_OutApplicationItemFilter.ToString());
            return sb.ToString();
        }

        protected override string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _OutApplicationItemFilter.AfterBackTableAndIds = tablesAndIds;
            return _OutApplicationItemFilter.FilterTableData(startDay, endDay);
        }

        protected override string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            _OutApplicationItemFilter.BeforeRestoreTableAndIds = orginTablesAndIds;
            return _OutApplicationItemFilter.RestoreTableData(startDay, endDay);
        }

        public override void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _OutApplicationItemFilter.ConfigTheFilter(theRule, _ProtectedTable, orginDbName, orginCopyDbName, restoreDbName, forRestoreCopyDbName);
            _OutApplicationItemFilter.IgnoreMainTableProcess = true;
        }
    }
}
