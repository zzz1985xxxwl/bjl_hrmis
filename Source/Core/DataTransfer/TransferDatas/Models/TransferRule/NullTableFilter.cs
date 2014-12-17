using System;
using System.Collections.Generic;

namespace TransferDatas
{
    public class NullTableFilter : ITableFilter
    {
        private TransferRule _TheRule;
        // ������
        private string _MainTable;
        //����Դ�����ݿ���(��ϵͳ�����ݿ���)
        private string _OrginDbName;
        //����ԴԴ�Ŀ������ݿ���(������ϵͳ�����ݿ���)
        private string _OrginCopyDbName;
        //��ҪǨ�Ƶ����ݿ���(��ϵͳ�����ݿ���)
        private string _RestoreDbName;
        //��ϵͳ�������ݿ��ڴ�ϵͳ�ϵĿ���
        private string _ForRestoreCopyDbName;

        #region ITableFilter ��Ա

        public bool GetNeedTimeFilter()
        {
            return false;
        }

        public void ConfigTheFilter(TransferRule theRule, string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _MainTable = mainTableName;
            _TheRule = theRule;
            _OrginDbName = orginDbName;
            _OrginCopyDbName = orginCopyDbName;
            _RestoreDbName = restoreDbName;
            _ForRestoreCopyDbName = forRestoreCopyDbName;
        }

        public string FilterTableData(DateTime? fromDay, DateTime? toDay)
        {
            int allCount = SqlCommandRunner.GetTableRowCount(_MainTable, _OrginDbName);
            return string.Format("--��{0}����:������{1}��ɾ��0������", _MainTable, allCount);
        }

        public string RestoreTableData(DateTime? fromDay, DateTime? toDay)
        {
            List<ConstraintInfo> backUpConstraintInfo = SqlCommandRunner.GetConstraintInfo(_MainTable, _RestoreDbName);
            SqlCommandRunner.DropTable(_MainTable, _RestoreDbName);
            SqlCommandRunner.CopyTable(_MainTable, _ForRestoreCopyDbName, _RestoreDbName);
            SqlCommandRunner.RestoreConstraintInfo(backUpConstraintInfo, _MainTable, _RestoreDbName);
            
            return string.Format("--��{0}����:������������", _MainTable);
        }

        #endregion

        #region ICloneable ��Ա

        public object Clone()
        {
            NullTableFilter aCloneObj = new NullTableFilter();
            aCloneObj._ForRestoreCopyDbName = _ForRestoreCopyDbName;
            aCloneObj._MainTable = _MainTable;
            aCloneObj._OrginCopyDbName = _OrginCopyDbName;
            aCloneObj._OrginDbName = _OrginDbName;
            aCloneObj._RestoreDbName = _RestoreDbName;
            //����Ŀ�¡�е�����,�ڷ���ConfigTheFilter�󣬸ÿ�¡��������ȫ���Ʊ���
            aCloneObj._TheRule = null;
            return aCloneObj;
        }

        public override string ToString()
        {
            return "ȫ����ʽ����";
        }

        #endregion
    }
}