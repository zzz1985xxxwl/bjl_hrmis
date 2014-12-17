namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalaryStatusEnum : ParameterBase
    {
        public EmployeeSalaryStatusEnum(int id, string name)
            : base(id, name)
        {
        }

        public static EmployeeSalaryStatusEnum TemporarySave = new EmployeeSalaryStatusEnum(0, "‘›¥Ê");
        public static EmployeeSalaryStatusEnum AccountClosed = new EmployeeSalaryStatusEnum(1, "∑‚’ ");
        public static EmployeeSalaryStatusEnum AccountReopened = new EmployeeSalaryStatusEnum(2, "Ω‚∑‚");

        public static EmployeeSalaryStatusEnum GetEmployeeSalaryStatusEnum(int id)
        {
            switch(id)
            {
                case 0:
                    return TemporarySave;
                case 1:
                    return AccountClosed;
                case 2:
                    return AccountReopened;
                default:
                    return null;
            }
        }

        public static string EmployeeSalaryStatusDisplay(EmployeeSalaryStatusEnum employeeSalaryStatusEnum)
        {
            switch (employeeSalaryStatusEnum.Id)
            {
                case 0:
                    return "‘›¥Ê";
                case 1:
                    return "∑‚’ ";
                case 2:
                    return "Ω‚∑‚";
                default:
                    return "";
            }
        }
    }
}
