using System;
using System.Collections.Generic;
using TransferDatas;

namespace TVacationFilter
{
    public class TVacationFilter : TableFilterTemplate
    {
        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TVacationFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where not (VacationStartDate<='{2}' and '{1}'<=VacationEndDate)", _MainTable, fromDay.Value, toDay.Value);
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select * from {0} where VacationStartDate<='{2}' and '{1}'<=VacationEndDate", _MainTable, fromDay.Value, toDay.Value);
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