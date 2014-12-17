using System.Transactions;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.Bll.SpecialDates
{
    public class AddSpecialDate : Transaction
    {
        private readonly SpecialDate _SpecialDate;
        private readonly Account _LoginUser;

        public AddSpecialDate(SpecialDate specialDate, Account loginUser)
        {
            _SpecialDate = specialDate;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    //��ɾ����һ����ǰ�������������ã�Ȼ�������������������������
                    //���������޸Ĳ���
                    DalInstance.SpecialDateDalInstance.DeleteSpecialDateByDate(_SpecialDate.SpecialDateTime);
                    DalInstance.SpecialDateDalInstance.InsertSpecialDate(_SpecialDate);
                    ts.Complete();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            //Ȩ����֤
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A503))
            {
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            }
        }
    }
}
