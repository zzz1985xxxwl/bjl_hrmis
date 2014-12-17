using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// ��ֵ����б�
    /// </summary>
    public class BindItemValueCollection
    {
        private List<BindItemValue> _BindItemValueList;
        private Employee _Employee;
        /// <summary>
        /// ���캯��
        /// </summary>
        public BindItemValueCollection()
        {
            _BindItemValueList = new List<BindItemValue>();
        }
        /// <summary>
        /// Ա��
        /// </summary>
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        /// <summary>
        /// ��ֵ����
        /// </summary>
        public List<BindItemValue> BindItemValueList
        {
            get { return _BindItemValueList; }
            set { _BindItemValueList = value; }
        }
        /// <summary>
        /// �������а���
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
        /// ΪbindItemEnum��ֵΪvalue
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
        /// ����bindItemEnum��value
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
