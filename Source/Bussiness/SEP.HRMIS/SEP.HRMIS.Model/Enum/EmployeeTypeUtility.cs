using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    public class EmployeeTypeUtility
    {
        public static string EmployeeTypeDisplay(EmployeeTypeEnum employeeType)
        {
            switch (employeeType)
            {
                case EmployeeTypeEnum.PracticeEmployee:
                    return "ʵϰ";
                case EmployeeTypeEnum.ProbationEmployee:
                    return "����";
                case EmployeeTypeEnum.NormalEmployee:
                    return "��ʽ";
                case EmployeeTypeEnum.PartTimeEmployee:
                    return "��ְ";
                case EmployeeTypeEnum.DimissionEmployee:
                    return "��ְ";
                case EmployeeTypeEnum.BorrowedEmployee:
                    return "����";
                case EmployeeTypeEnum.Retirement:
                    return "����";
                case EmployeeTypeEnum.RetirementHire:
                    return "��Ƹ";
                case EmployeeTypeEnum.WorkEmployee:
                    return "����";
                default:
                    return "";
            }
        }
        public static EmployeeTypeEnum GetEmployeeTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return EmployeeTypeEnum.PracticeEmployee;
                case 1:
                    return EmployeeTypeEnum.ProbationEmployee;
                case 2:
                    return EmployeeTypeEnum.NormalEmployee;
                case 3:
                    return EmployeeTypeEnum.PartTimeEmployee;
                case 4:
                    return EmployeeTypeEnum.DimissionEmployee;
                case 5:
                    return EmployeeTypeEnum.BorrowedEmployee;
                case 6:
                    return EmployeeTypeEnum.Retirement;
                case 7:
                    return EmployeeTypeEnum.RetirementHire;
                case 8:
                    return EmployeeTypeEnum.WorkEmployee;
                default:
                    return EmployeeTypeEnum.All;
            }
        }

        /// <summary>
        /// ���쿼�����������ֵ�
        /// </summary>
        private static void AddEmployeeTypeValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData, EmployeeTypeEnum employeeTypeEnum)
        {
            dictionaryData.Add(((int)employeeTypeEnum).ToString(), EmployeeTypeDisplay(employeeTypeEnum));
        }
        /// <summary>
        /// ��ȡ����Ա������
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllEmployeeTypeEnum()
        {
            Dictionary<string, string> employeeType = new Dictionary<string, string>();
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.PracticeEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.ProbationEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.NormalEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.PartTimeEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.DimissionEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.BorrowedEmployee);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.Retirement);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.RetirementHire);
            AddEmployeeTypeValueAndNameIntoDictionary(employeeType, EmployeeTypeEnum.WorkEmployee);
            return employeeType;
        }
    }
}
