//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetEmployeeFromCache.cs
// ������: �ߺ�
// ��������: 2008-11-20
// ����: ͨ������EmployeeCache�õ�Ա����Ϣ�������е�ÿһ����Ϣ��ȷ��
//        private int _EmployeeID;
//        private string _Name;
//        private string _Email;
//        private string _Email2;
//        private EmployeeTypeEnum _EmployeeType;
//        private Position _Position;
//        private Department _Department;
//        private AccountsFront _AccountsFront;
//        private EmployeeDetails _EmployeeDetails;
//        ���ϵ�ÿһ���ֶΣ�����֮�����Ϣ��δ���أ�Ҳ��δ��֤
//        ע�⣬�ڻ����еĻ�ȡ�Ķ����޷���ɸ��£�����Щ����
//        �����ڲ�ѯ��״̬
// ----------------------------------------------------------------
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// Ա������
    /// </summary>
    public class CachedEmployee
    {
        /// <summary>
        /// ͨ���绰�����ȡԱ�������ڸ����У�ֻҪ�������ݾ�ȷ�ԣ��Ϳ��Թ�����ͬ�Ĳ�ѯ����
        /// </summary>
        public static Employee GetEmployeeByPhoneNumber(string phoneNumber)
        {
            foreach (Employee detailedEmployee in EmployeeCache.GetAllEmployeeBasicInfoFromCache)
            {
                if (detailedEmployee.EmployeeDetails != null)
                {
                    if (detailedEmployee.Account.MobileNum == phoneNumber)
                    {
                        return detailedEmployee;
                    }
                }
            }
            return null;
        }
    }
}