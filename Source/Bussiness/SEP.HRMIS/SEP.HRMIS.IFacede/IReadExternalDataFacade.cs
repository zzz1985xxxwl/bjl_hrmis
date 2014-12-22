using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ��ȡ�ⲿ���ڻ����ݽӿ�
    /// </summary>
    public interface IReadExternalDataFacade
    {
        /// <summary>
        /// ϵͳ�Զ�������
        /// </summary>
        /// <param name="readNewHistory"></param>
        void SystemReadDataFromAccessToSQL(ReadDataHistory readNewHistory, Account loginUser);

        /// <summary>
        /// ϵͳ�Զ���ָ��ʱ���ȡ��������
        /// </summary>
        void SystemReadDataFromSetTime(Account loginUser);
    }
}
