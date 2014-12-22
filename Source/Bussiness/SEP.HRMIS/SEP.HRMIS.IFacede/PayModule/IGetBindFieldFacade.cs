using System;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IFacede.PayModule
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGetBindFieldFacade
    {
        /// <summary>
        /// 仅获取GetEmployeePassMonth数据
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        BindItemValueCollection GetEmployeePassMonthBindField(int accountID, DateTime endDt);
        
    }
}
