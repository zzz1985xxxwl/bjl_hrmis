using System;
using System.Collections.Generic;
using TransferDatas;

namespace TReadDataHistoryFilter
{
    public class TReadDataHistoryFilter : TableFilterTemplate
    {
        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TReadDataHistoryFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where not (ReadTime >= '{1}' and ReadTime <= '{2}')", _MainTable, fromDay.Value, toDay.Value);
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select * from {0} where ReadTime >= '{1}' and ReadTime <= '{2}'", _MainTable, fromDay.Value, toDay.Value);
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            return new Dictionary<string, string>();
        }

        protected override string DefineOperationString()
        {
            return "根据时间筛选主表:";
        }

        protected override string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            return string.Empty;
        }

        protected override string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            return string.Empty;
        }

        public override void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
        }
    }
}