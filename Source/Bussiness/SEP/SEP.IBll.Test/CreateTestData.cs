using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.IBllTest
{
    internal static class CreateTestData
    {
        #region

        public static Account _LoginUser;

        public static Account employee1;
        public static Account employee2;
        public static Account employee3;
        public static Account employee4;
        public static Account employee5;
        public static Account employee6;
        public static Account employee7;
        public static Account employee8;
        public static Account employee9;
        public static Account employee10;
        public static Account employee11;
        public static Account employee12;
        public static Account employee13;
        public static Account employee14;
        public static Account employee15;
        public static Account employee16;
        public static Account employee17;
        public static Account employee18;
        public static Account employee19;
        public static Account employee20;
        public static Account employee21;
        public static Account employee22;
        public static Account employee23;
        public static Account employee24;
        public static Account employee25;
        public static Account employee26;
        public static Account employee27;
        public static Account employee28;
        public static Account employee29;
        public static Account employee30;
        public static Account employee31;
        public static Account employee32;
        public static Account employee33;
        public static Account employee34;
        public static Account employee35;
        public static Account employee36;
        public static Account employee37;
        public static Account employee38;
        public static Account employee39;
        public static Account employee40;
        public static Account employee41;
        public static Account employee42;
        public static Account employee43;
        public static Account employee44;
        public static Account employee45;

        public static Department dept1;
        public static Department dept11;
        public static Department dept111;
        public static Department dept112;

        public static Department dept12;
        public static Department dept121;
        public static Department dept1211;
        public static Department dept1212;
        public static Department dept122;

        public static Department dept13;


        public static Department dept2;
        public static Department dept21;
        public static Department dept22;
        public static Department dept221;
        public static Department dept222;
        public static Department dept223;

        public static Department dept3;
        public static Department dept31;
        public static Department dept32;

        #endregion

        public static void Login()
        {
            _LoginUser = BllInstance.AccountBllInstance.LoginVerify("admin", "111111");
        }

        public static void CreateDeptData()
        {
            dept1 = NewDepartment();
            dept1.Name = "dept1";
            dept1.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept1, _LoginUser);

            dept11 = NewDepartment();
            dept11.Name = "dept11";
            dept11.Leader = employee2;
            BllInstance.DepartmentBllInstance.CreateDept(dept1.Id, dept11, _LoginUser);

            dept111 = NewDepartment();
            dept111.Name = "dept111";
            dept111.Leader = employee3;
            BllInstance.DepartmentBllInstance.CreateDept(dept11.Id, dept111, _LoginUser);

            dept112 = NewDepartment();
            dept112.Name = "dept112";
            dept112.Leader = employee4;
            BllInstance.DepartmentBllInstance.CreateDept(dept11.Id, dept112, _LoginUser);

            dept12 = NewDepartment();
            dept12.Name = "dept12";
            dept12.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept1.Id, dept12, _LoginUser);

            dept121 = NewDepartment();
            dept121.Name = "dept121";
            dept121.Leader = employee5;
            BllInstance.DepartmentBllInstance.CreateDept(dept12.Id, dept121, _LoginUser);

            dept1211 = NewDepartment();
            dept1211.Name = "dept1211";
            dept1211.Leader = employee8;
            BllInstance.DepartmentBllInstance.CreateDept(dept121.Id, dept1211, _LoginUser);

            dept1212 = NewDepartment();
            dept1212.Name = "dept1212";
            dept1212.Leader = employee5;
            BllInstance.DepartmentBllInstance.CreateDept(dept121.Id, dept1212, _LoginUser);

            dept122 = NewDepartment();
            dept122.Name = "dept122";
            dept122.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept12.Id, dept122, _LoginUser);

            dept13 = NewDepartment();
            dept13.Name = "dept13";
            dept13.Leader = employee2;
            BllInstance.DepartmentBllInstance.CreateDept(dept1.Id, dept13, _LoginUser);

            dept2 = NewDepartment();
            dept2.Name = "dept2";
            dept2.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept2, _LoginUser);

            dept21 = NewDepartment();
            dept21.Name = "dept21";
            dept21.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept2.Id, dept21, _LoginUser);

            dept22 = NewDepartment();
            dept22.Name = "dept22";
            dept22.Leader = employee2;
            BllInstance.DepartmentBllInstance.CreateDept(dept2.Id, dept22, _LoginUser);

            dept221 = NewDepartment();
            dept221.Name = "dept221";
            dept221.Leader = employee4;
            BllInstance.DepartmentBllInstance.CreateDept(dept22.Id, dept221, _LoginUser);

            dept222 = NewDepartment();
            dept222.Name = "dept222";
            dept222.Leader = employee6;
            BllInstance.DepartmentBllInstance.CreateDept(dept22.Id, dept222, _LoginUser);

            dept223 = NewDepartment();
            dept223.Name = "dept223";
            dept223.Leader = employee5;
            BllInstance.DepartmentBllInstance.CreateDept(dept22.Id, dept223, _LoginUser);

            dept3 = NewDepartment();
            dept3.Name = "dept3";
            dept3.Leader = employee1;
            BllInstance.DepartmentBllInstance.CreateDept(dept3, _LoginUser);

            dept31 = NewDepartment();
            dept31.Name = "dept31";
            dept31.Leader = employee6;
            BllInstance.DepartmentBllInstance.CreateDept(dept3.Id, dept31, _LoginUser);

            dept32 = NewDepartment();
            dept32.Name = "dept32";
            dept32.Leader = employee7;
            BllInstance.DepartmentBllInstance.CreateDept(dept3.Id, dept32, _LoginUser);
        }

        private static Department NewDepartment()
        {
            Department d= new Department();
            d.Address = "";
            d.Phone = "";
            d.Fax = "";
            d.Description = "";
            d.Others = "";
            return d;
        }

        public static void CreateEmployeeData()
        {
            employee1 = new Account();
            employee1.LoginName = "employee1";
            employee1.Name = "employee1";
            BllInstance.AccountBllInstance.CreateAccount(employee1, _LoginUser);

            employee2 = new Account();
            employee2.LoginName = "employee2";
            employee2.Name = "employee2";
            BllInstance.AccountBllInstance.CreateAccount(employee2, _LoginUser);

            employee3 = new Account();
            employee3.LoginName = "employee3";
            employee3.Name = "employee3";
            BllInstance.AccountBllInstance.CreateAccount(employee3, _LoginUser);

            employee4 = new Account();
            employee4.LoginName = "employee4";
            employee4.Name = "employee4";
            BllInstance.AccountBllInstance.CreateAccount(employee4, _LoginUser);

            employee5 = new Account();
            employee5.LoginName = "employee5";
            employee5.Name = "employee5";
            BllInstance.AccountBllInstance.CreateAccount(employee5, _LoginUser);

            employee6 = new Account();
            employee6.LoginName = "employee6";
            employee6.Name = "employee6";
            BllInstance.AccountBllInstance.CreateAccount(employee6, _LoginUser);

            employee7 = new Account();
            employee7.LoginName = "employee7";
            employee7.Name = "employee7";
            BllInstance.AccountBllInstance.CreateAccount(employee7, _LoginUser);

            employee8 = new Account();
            employee8.LoginName = "employee8";
            employee8.Name = "employee8";
            BllInstance.AccountBllInstance.CreateAccount(employee8, _LoginUser);

            employee9 = new Account();
            employee9.LoginName = "employee9";
            employee9.Name = "employee9";
            BllInstance.AccountBllInstance.CreateAccount(employee9, _LoginUser);

            employee10 = new Account();
            employee10.LoginName = "employee10";
            employee10.Name = "employee10";
            BllInstance.AccountBllInstance.CreateAccount(employee10, _LoginUser);

            employee11 = new Account();
            employee11.LoginName = "employee11";
            employee11.Name = "employee11";
            BllInstance.AccountBllInstance.CreateAccount(employee11, _LoginUser);

            employee12 = new Account();
            employee12.LoginName = "employee12";
            employee12.Name = "employee12";
            BllInstance.AccountBllInstance.CreateAccount(employee12, _LoginUser);

            employee13 = new Account();
            employee13.LoginName = "employee13";
            employee13.Name = "employee13";
            BllInstance.AccountBllInstance.CreateAccount(employee13, _LoginUser);

            employee14 = new Account();
            employee14.LoginName = "employee14";
            employee14.Name = "employee14";
            BllInstance.AccountBllInstance.CreateAccount(employee14, _LoginUser);

            employee15 = new Account();
            employee15.LoginName = "employee15";
            employee15.Name = "employee15";
            BllInstance.AccountBllInstance.CreateAccount(employee15, _LoginUser);

            employee16 = new Account();
            employee16.LoginName = "employee16";
            employee16.Name = "employee16";
            BllInstance.AccountBllInstance.CreateAccount(employee16, _LoginUser);

            employee17 = new Account();
            employee17.LoginName = "employee17";
            employee17.Name = "employee17";
            BllInstance.AccountBllInstance.CreateAccount(employee17, _LoginUser);

            employee18 = new Account();
            employee18.LoginName = "employee18";
            employee18.Name = "employee18";
            BllInstance.AccountBllInstance.CreateAccount(employee18, _LoginUser);

            employee19 = new Account();
            employee19.LoginName = "employee19";
            employee19.Name = "employee19";
            BllInstance.AccountBllInstance.CreateAccount(employee19, _LoginUser);

            employee20 = new Account();
            employee20.LoginName = "employee20";
            employee20.Name = "employee20";
            BllInstance.AccountBllInstance.CreateAccount(employee20, _LoginUser);

            employee21 = new Account();
            employee21.LoginName = "employee21";
            employee21.Name = "employee21";
            BllInstance.AccountBllInstance.CreateAccount(employee21, _LoginUser);

            employee22 = new Account();
            employee22.LoginName = "employee22";
            employee22.Name = "employee22";
            BllInstance.AccountBllInstance.CreateAccount(employee22, _LoginUser);

            employee23 = new Account();
            employee23.LoginName = "employee23";
            employee23.Name = "employee23";
            BllInstance.AccountBllInstance.CreateAccount(employee23, _LoginUser);

            employee24 = new Account();
            employee24.LoginName = "employee24";
            employee24.Name = "employee24";
            BllInstance.AccountBllInstance.CreateAccount(employee24, _LoginUser);

            employee25 = new Account();
            employee25.LoginName = "employee25";
            employee25.Name = "employee25";
            BllInstance.AccountBllInstance.CreateAccount(employee25, _LoginUser);

            employee26 = new Account();
            employee26.LoginName = "employee26";
            employee26.Name = "employee26";
            BllInstance.AccountBllInstance.CreateAccount(employee26, _LoginUser);

            employee27 = new Account();
            employee27.LoginName = "employee27";
            employee27.Name = "employee27";
            BllInstance.AccountBllInstance.CreateAccount(employee27, _LoginUser);

            employee28 = new Account();
            employee28.LoginName = "employee28";
            employee28.Name = "employee28";
            BllInstance.AccountBllInstance.CreateAccount(employee28, _LoginUser);

            employee29 = new Account();
            employee29.LoginName = "employee29";
            employee29.Name = "employee29";
            BllInstance.AccountBllInstance.CreateAccount(employee29, _LoginUser);

            employee30 = new Account();
            employee30.LoginName = "employee30";
            employee30.Name = "employee30";
            BllInstance.AccountBllInstance.CreateAccount(employee30, _LoginUser);

            employee31 = new Account();
            employee31.LoginName = "employee31";
            employee31.Name = "employee31";
            BllInstance.AccountBllInstance.CreateAccount(employee31, _LoginUser);

            employee32 = new Account();
            employee32.LoginName = "employee32";
            employee32.Name = "employee32";
            BllInstance.AccountBllInstance.CreateAccount(employee32, _LoginUser);

            employee33 = new Account();
            employee33.LoginName = "employee33";
            employee33.Name = "employee33";
            BllInstance.AccountBllInstance.CreateAccount(employee33, _LoginUser);

            employee34 = new Account();
            employee34.LoginName = "employee34";
            employee34.Name = "employee34";
            BllInstance.AccountBllInstance.CreateAccount(employee34, _LoginUser);

            employee35 = new Account();
            employee35.LoginName = "employee35";
            employee35.Name = "employee35";
            BllInstance.AccountBllInstance.CreateAccount(employee35, _LoginUser);

            employee36 = new Account();
            employee36.LoginName = "employee36";
            employee36.Name = "employee36";
            BllInstance.AccountBllInstance.CreateAccount(employee36, _LoginUser);

            employee37 = new Account();
            employee37.LoginName = "employee37";
            employee37.Name = "employee37";
            BllInstance.AccountBllInstance.CreateAccount(employee37, _LoginUser);

            employee38 = new Account();
            employee38.LoginName = "employee38";
            employee38.Name = "employee38";
            BllInstance.AccountBllInstance.CreateAccount(employee38, _LoginUser);

            employee39 = new Account();
            employee39.LoginName = "employee39";
            employee39.Name = "employee39";
            BllInstance.AccountBllInstance.CreateAccount(employee39, _LoginUser);

            employee40 = new Account();
            employee40.LoginName = "employee40";
            employee40.Name = "employee40";
            BllInstance.AccountBllInstance.CreateAccount(employee40, _LoginUser);

            employee41 = new Account();
            employee41.LoginName = "employee41";
            employee41.Name = "employee41";
            BllInstance.AccountBllInstance.CreateAccount(employee41, _LoginUser);

            employee42 = new Account();
            employee42.LoginName = "employee42";
            employee42.Name = "employee42";
            BllInstance.AccountBllInstance.CreateAccount(employee42, _LoginUser);

            employee43 = new Account();
            employee43.LoginName = "employee43";
            employee43.Name = "employee43";
            BllInstance.AccountBllInstance.CreateAccount(employee43, _LoginUser);

            employee44 = new Account();
            employee44.LoginName = "employee44";
            employee44.Name = "employee44";
            BllInstance.AccountBllInstance.CreateAccount(employee44, _LoginUser);

            employee45 = new Account();
            employee45.LoginName = "employee45";
            employee45.Name = "employee45";
            BllInstance.AccountBllInstance.CreateAccount(employee45, _LoginUser);
        }

        public static void AssignEmployeeToDept()
        {
            employee1.Dept = dept21;
            BllInstance.AccountBllInstance.UpdateAccount(employee1, _LoginUser);

            employee2.Dept = dept13;
            BllInstance.AccountBllInstance.UpdateAccount(employee2, _LoginUser);

            employee3.Dept = dept111;
            BllInstance.AccountBllInstance.UpdateAccount(employee3, _LoginUser);

            employee4.Dept = dept112;
            BllInstance.AccountBllInstance.UpdateAccount(employee4, _LoginUser);

            employee5.Dept = dept1212;
            BllInstance.AccountBllInstance.UpdateAccount(employee5, _LoginUser);

            employee6.Dept = dept31;
            BllInstance.AccountBllInstance.UpdateAccount(employee6, _LoginUser);

            employee7.Dept = dept32;
            BllInstance.AccountBllInstance.UpdateAccount(employee7, _LoginUser);

            employee8.Dept = dept1211;
            BllInstance.AccountBllInstance.UpdateAccount(employee8, _LoginUser);

            employee9.Dept = dept221;
            BllInstance.AccountBllInstance.UpdateAccount(employee9, _LoginUser);

            employee10.Dept = dept221;
            BllInstance.AccountBllInstance.UpdateAccount(employee10, _LoginUser);

            employee11.Dept = dept221;
            BllInstance.AccountBllInstance.UpdateAccount(employee11, _LoginUser);

            employee12.Dept = dept222;
            BllInstance.AccountBllInstance.UpdateAccount(employee12, _LoginUser);

            employee13.Dept = dept223;
            BllInstance.AccountBllInstance.UpdateAccount(employee13, _LoginUser);

            employee14.Dept = dept223;
            BllInstance.AccountBllInstance.UpdateAccount(employee14, _LoginUser);

            employee15.Dept = dept222;
            BllInstance.AccountBllInstance.UpdateAccount(employee15, _LoginUser);

            employee16.Dept = dept223;
            BllInstance.AccountBllInstance.UpdateAccount(employee16, _LoginUser);

            employee17.Dept = dept222;
            BllInstance.AccountBllInstance.UpdateAccount(employee17, _LoginUser);

            employee18.Dept = dept32;
            BllInstance.AccountBllInstance.UpdateAccount(employee18, _LoginUser);

            employee19.Dept = dept31;
            BllInstance.AccountBllInstance.UpdateAccount(employee19, _LoginUser);

            employee20.Dept = dept21;
            BllInstance.AccountBllInstance.UpdateAccount(employee20, _LoginUser);

            employee21.Dept = dept21;
            BllInstance.AccountBllInstance.UpdateAccount(employee21, _LoginUser);

            employee22.Dept = dept13;
            BllInstance.AccountBllInstance.UpdateAccount(employee22, _LoginUser);

            employee23.Dept = dept13;
            BllInstance.AccountBllInstance.UpdateAccount(employee23, _LoginUser);

            employee24.Dept = dept122;
            BllInstance.AccountBllInstance.UpdateAccount(employee24, _LoginUser);

            employee25.Dept = dept122;
            BllInstance.AccountBllInstance.UpdateAccount(employee25, _LoginUser);

            employee26.Dept = dept122;
            BllInstance.AccountBllInstance.UpdateAccount(employee26, _LoginUser);

            employee27.Dept = dept111;
            BllInstance.AccountBllInstance.UpdateAccount(employee27, _LoginUser);

            employee28.Dept = dept112;
            BllInstance.AccountBllInstance.UpdateAccount(employee28, _LoginUser);

            employee29.Dept = dept111;
            BllInstance.AccountBllInstance.UpdateAccount(employee29, _LoginUser);

            employee30.Dept = dept112;
            BllInstance.AccountBllInstance.UpdateAccount(employee30, _LoginUser);

            employee31.Dept = dept1211;
            BllInstance.AccountBllInstance.UpdateAccount(employee31, _LoginUser);

            employee32.Dept = dept1211;
            BllInstance.AccountBllInstance.UpdateAccount(employee32, _LoginUser);

            employee33.Dept = dept1212;
            BllInstance.AccountBllInstance.UpdateAccount(employee33, _LoginUser);

            employee34.Dept = dept1212;
            BllInstance.AccountBllInstance.UpdateAccount(employee34, _LoginUser);

            employee35.Dept = dept1212;
            BllInstance.AccountBllInstance.UpdateAccount(employee35, _LoginUser);

            employee36.Dept = dept12;
            BllInstance.AccountBllInstance.UpdateAccount(employee36, _LoginUser);

            employee37.Dept = dept12;
            BllInstance.AccountBllInstance.UpdateAccount(employee37, _LoginUser);

            employee38.Dept = dept11;
            BllInstance.AccountBllInstance.UpdateAccount(employee38, _LoginUser);

            employee39.Dept = dept11;
            BllInstance.AccountBllInstance.UpdateAccount(employee39, _LoginUser);

            employee40.Dept = dept121;
            BllInstance.AccountBllInstance.UpdateAccount(employee40, _LoginUser);

            employee41.Dept = dept121;
            BllInstance.AccountBllInstance.UpdateAccount(employee41, _LoginUser);

            employee42.Dept = dept22;
            BllInstance.AccountBllInstance.UpdateAccount(employee42, _LoginUser);

            employee43.Dept = dept22;
            BllInstance.AccountBllInstance.UpdateAccount(employee43, _LoginUser);

            employee44.Dept = dept2;
            BllInstance.AccountBllInstance.UpdateAccount(employee44, _LoginUser);

            employee45.Dept = dept1;
            BllInstance.AccountBllInstance.UpdateAccount(employee45, _LoginUser);
        }
    }
}
