using System;
using SEP.HRMIS.Bll.PayModule;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Facade.PayModule
{
    /// <summary>
    /// ��ȡ��ֵ��Ϣ
    /// </summary>
    public class GetBindFieldFacade : IGetBindFieldFacade
    {
        public BindItemValueCollection GetEmployeePassMonthBindField(int accountID, DateTime endDt)
        {
            return new GetBindField().GetEmployeePassMonthBindField(accountID, endDt);
        }
    }
}
