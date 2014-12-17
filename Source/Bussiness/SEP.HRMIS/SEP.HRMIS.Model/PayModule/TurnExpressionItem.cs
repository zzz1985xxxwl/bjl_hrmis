using System;
using System.Collections.Generic;
using Evaluant.Calculator.Extensions;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// ����ExpressionItem,AccountSetItem
    /// </summary>
    public class TurnExpressionItem
    {
        /// <summary>
        /// ExpressionItem���㵽AccountSetItem
        /// </summary>
        /// <param name="items"></param>
        /// <param name="accountSetItems"></param>
        public static void TurnBackAccountSetItemList(List<ExpressionItem> items, List<AccountSetItem> accountSetItems)
        {
            int j = 0;
            for (int i = 0; i < accountSetItems.Count; i++)
            {
                if (accountSetItems[i].AccountSetPara != null && accountSetItems[i].AccountSetPara.FieldAttribute != null)
                {
                    accountSetItems[i].CalculateResult = Convert.ToDecimal(items[j].Result);
                    j++;
                }
            }
        }

        /// <summary>
        /// AccountSetItem���㵽ExpressionItem
        /// </summary>
        /// <param name="parameterNameTitle"></param>
        /// <param name="accountSetItems"></param>
        /// <returns></returns>
        /// <param name="operation"></param>
        public static List<ExpressionItem> TurnToExpressionItemList(string parameterNameTitle, List<AccountSetItem> accountSetItems, Operation operation)
        {
            List<ExpressionItem> ret_ItemList = new List<ExpressionItem>();
            Random rd = new Random();
            foreach (AccountSetItem item in accountSetItems)
            {
                if (item.AccountSetPara == null || item.AccountSetPara.FieldAttribute == null)
                {
                    continue;
                }
                if (item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.CalculateField.Id)
                {
                    ret_ItemList.Add(
                        new ExpressionItem(parameterNameTitle + item.AccountSetPara.AccountSetParaID,
                                           MantissaRoundDeal(item.CalculateFormula, item.AccountSetPara.MantissaRound),
                                           EnumDataType.Number));
                }
                else
                {
                    if (operation == Operation.Check)
                    {
                        //��֤ʱ�����ڴ������ֵ����Ϊ����������֪����Щ�ֶ�����֪������Щ�ֶ���������
                        item.CalculateResult = Convert.ToDecimal(rd.NextDouble());
                    }
                    ret_ItemList.Add(
                        new ExpressionItem(parameterNameTitle + item.AccountSetPara.AccountSetParaID,
                                           MantissaRoundDeal(item.CalculateResult.ToString(),
                                                             item.AccountSetPara.MantissaRound), EnumDataType.Number));
                }
            }
            return ret_ItemList;
        }
        /// <summary>
        /// ����β��������
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="mantissaRound"></param>
        /// <returns></returns>
        public static string MantissaRoundDeal(string formula, MantissaRoundEnum mantissaRound)
        {
            return MantissaRoundEnum.ChangeMantissaRoundEnumToFunctionName(mantissaRound.Id) + "(" + formula + ")";
        }

        /// <summary>List<ExpressionItem>
        /// ������;
        /// </summary>
        public enum Operation
        {
            /// <summary>
            /// ���ڼ��
            /// </summary>
            Check,
            /// <summary>
            /// ���ڼ���
            /// </summary>
            Calculate,
        }
    }
}
