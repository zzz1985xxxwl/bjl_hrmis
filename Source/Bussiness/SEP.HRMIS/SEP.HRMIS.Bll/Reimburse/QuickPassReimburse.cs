using System;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class QuickPassReimburse : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();

        private static ICustomerInfoDal _DalCustomerInfo = DalFactory.DataAccess.CreateCustomerInfoDal();
        private readonly int _ReimburseID;
        private readonly int _PaperCount;
        private readonly string _Destinations;
        private readonly string _CustomerID;
        private readonly string _ProjectName;
        private readonly DateTime _ConsumeDateFrom;
        private readonly DateTime _ConsumeDateTo;
        private readonly Account _LoginUser;
        private Model.Reimburse _Reimburse;
        private decimal _OutCityAllowance;
        private decimal _OutCityDays;
        private string _Remark;

        public QuickPassReimburse(Account loginUser, int reimburseID, int paperCount, string destinations,
                                  string customerName, string projectName, DateTime consumeDateFrom,
                                  DateTime consumeDateTo, string remark, decimal outcityAllowance, decimal outcitydays)
        {
            _ReimburseID = reimburseID;
            _PaperCount = paperCount;
            _Destinations = destinations;
            if (customerName != string.Empty)
            {
                _CustomerID = _DalCustomerInfo.GetCustomerIDInfoByName(customerName).CustomerInfoId.ToString();
            }
            else
            {
                _CustomerID = string.Empty;
            }

            _ProjectName = projectName;
            _ConsumeDateFrom = consumeDateFrom;
            _ConsumeDateTo = consumeDateTo;
            _LoginUser = loginUser;
            _Remark = remark;
            _OutCityDays = outcitydays;
            _OutCityAllowance = outcityAllowance;
        }

        public QuickPassReimburse(Account loginUser, int reimburseID, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            _Reimburse = _DalReimburse.GetReimburseByReimburseID(_ReimburseID);
            if (_Reimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            else
            {
                _Reimburse.PaperCount = _PaperCount;
                _Reimburse.Destinations = _Destinations;
                //_Reimburse.CustomerID = _CustomerID;
                _Reimburse.ProjectName = _ProjectName;
                _Reimburse.ConsumeDateFrom = _ConsumeDateFrom;
                _Reimburse.ConsumeDateTo = _ConsumeDateTo;
                _Reimburse.OutCityAllowance = _OutCityAllowance;
                _Reimburse.OutCityDays = _OutCityDays;
                _Reimburse.Remark = _Remark;
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _Reimburse.ReimburseStatus = ReimburseStatusEnum.Auditing;
                _DalReimburse.UpdateReimburse(_LoginUser, _Reimburse, ReimburseStatusEnum.Auditing);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}