using System;

namespace TransferDatas
{
    public class TableTransfer:ICloneable
    {
        private string _TableName;
        private ITableFilter _TableFilter;
        private string _TableFilterName;

        #region 属性

        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        public ITableFilter TableFilter
        {
            get
            {
                return _TableFilter;
            }
            set
            {
                _TableFilter = value;
            }
        }

        public string TableFilterName
        {
            get
            {
                return _TableFilterName;
            }
            set
            {
                _TableFilterName = value;
            }
        }

        #endregion

        #region 方法

        internal void Check(string ruleName)
        {
            Utility.AssertStringNotEmpty(_TableName, string.Format("{0}{1}", Utility._Error_XmlConfig_TableName_NotFit, ruleName));
        }

        internal object MakeString()
        {
            string theFilterRule = string.IsNullOrEmpty(_TableFilterName) ? string.Empty : string.Format("({0})", _TableFilterName);
            return string.Format("[{0}{1}]", _TableName, theFilterRule);
        }

        internal void Construct()
        {
            _TableFilter = string.IsNullOrEmpty(_TableFilterName) ? new NullTableFilter() : DiskOperations.CreateTableFilterObj(_TableFilterName);
        }

        internal void ConfigRuleFitler(TransferRule transferRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreDbName)
        {
            _TableFilter.ConfigTheFilter(transferRule, _TableName, orginDbName, orginCopyDbName, restoreDbName, forRestoreDbName);
        }

        internal void BackUpData(DateTime? fromDay, DateTime? toDay, RunningStatus theRuningStatusInSession)
        {
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_FilterTable, _TableName));
            theRuningStatusInSession.AddInformationLine(_TableFilter.FilterTableData(fromDay, toDay));
        }

        internal void RestoreData(DateTime? fromDay, DateTime? toDay, RestoreStatus theRuningStatusInSession)
        {
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_RestoreTable, _TableName));
            theRuningStatusInSession.AddInformationLine(_TableFilter.RestoreTableData(fromDay, toDay));
        }

        internal bool GetNeedTimeFilter(TransferRule transferRule)
        {
            if(_TableFilter == null)
            {
                transferRule.Construct();
            }
            return _TableFilter.GetNeedTimeFilter();
        }

        #endregion


        #region ICloneable 成员

        public object Clone()
        {
            TableTransfer aCloneObj = new TableTransfer();
            aCloneObj._TableFilter = _TableFilter.Clone() as ITableFilter;
            aCloneObj._TableFilterName = _TableFilterName;
            aCloneObj._TableName = _TableName;
            return aCloneObj;
        }

        public override string ToString()
        {
            return string.Format("--表:{0}，执行{1}", _TableName, _TableFilter);
        }

        #endregion
    }
}