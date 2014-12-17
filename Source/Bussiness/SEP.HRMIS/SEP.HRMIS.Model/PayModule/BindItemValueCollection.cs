using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 绑定值结果列表
    /// </summary>
    public class BindItemValueCollection
    {
        private List<BindItemValue> _BindItemValueList;
        private Employee _Employee;
        /// <summary>
        /// 构造函数
        /// </summary>
        public BindItemValueCollection()
        {
            _BindItemValueList = new List<BindItemValue>();
        }
        /// <summary>
        /// 员工
        /// </summary>
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        /// <summary>
        /// 绑定值类型
        /// </summary>
        public List<BindItemValue> BindItemValueList
        {
            get { return _BindItemValueList; }
            set { _BindItemValueList = value; }
        }
        /// <summary>
        /// 生成所有绑定项
        /// </summary>
        public void CreateAllBindItemsExceptNull()
        {
            _BindItemValueList = new List<BindItemValue>();
            List<BindItemEnum> _BindItemEnumList = BindItemEnum.GetAllBindItemsExceptNull();
            foreach (BindItemEnum itemEnum in _BindItemEnumList)
            {
                _BindItemValueList.Add(new BindItemValue(itemEnum));
            }
        }
        /// <summary>
        /// 为bindItemEnum赋值为value
        /// </summary>
        /// <param name="bindItemEnum"></param>
        /// <param name="value"></param>
        public void SetBindItemValue(BindItemEnum bindItemEnum, decimal value)
        {
            foreach (BindItemValue itemValue in _BindItemValueList)
            {
                if(itemValue.BindItemEnum.Id == bindItemEnum.Id)
                {
                    itemValue.Value = value;
                    break;
                }
            }
        }
        /// <summary>
        /// 返回bindItemEnum的value
        /// </summary>
        /// <param name="bindItemEnum"></param>
        /// <returns></returns>
        public decimal GetBindItemValue(BindItemEnum bindItemEnum)
        {
            foreach (BindItemValue itemValue in _BindItemValueList)
            {
                if (itemValue.BindItemEnum.Id == bindItemEnum.Id)
                {
                    return itemValue.Value;
                }
            }
            return 0;
        }
    }

}
