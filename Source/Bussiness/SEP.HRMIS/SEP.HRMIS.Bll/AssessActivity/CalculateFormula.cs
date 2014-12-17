//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateFormula.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-17
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using Evaluant.Calculator.Extensions;
using SEP.HRMIS.Bll.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculateFormula
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Calculate(int accountid, DateTime start, DateTime end, string formula)
        {
            GetBindField getBindField = new GetBindField();
            BindItemValueCollection collection = getBindField.BindItemValueCollection(accountid, start, end);
            List<ExpressionItem> expressionItemList = new List<ExpressionItem>();
            expressionItemList.Add(new ExpressionItem(AssessBindItemEnum.ImposibleID,formula,EnumDataType.Number));
            foreach (BindItemValue item in collection.BindItemValueList)
            {
                if (item.BindItemEnum.Id == BindItemEnum.ShiJia.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.ShiJia.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.BingJia.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.BingJia.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.ChanQianJia.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.ChanQianJia.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.BuRuJia.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.BuRuJia.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.ChanJia.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.ChanJia.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.BeLate.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.BeLate.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.LeaveEarly.Id)
                {
                    expressionItemList.Add(
                         new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.LeaveEarly.ID), item.Value.ToString(),
                                            EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.Absenteeism.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.Absenteeism.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.WorkAge.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.WorkAge.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.OnDutyDays.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.OnDutyDays.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.ExpectedOnDutyDays.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.ExpectOnDutyDays.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.PuTongOverTime.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.PuTongOverTime.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.ShuangXiuOverTime.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.ShuangXiuOverTime.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.JieRiOverTime.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.JieRiOverTime.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                else if (item.BindItemEnum.Id == BindItemEnum.OutCityDays.Id)
                {
                    expressionItemList.Add(
                        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.OutCityDays.ID), item.Value.ToString(),
                                           EnumDataType.Number));
                }
                //else if (item.BindItemEnum.Id == BindItemEnum.NotEntryDays.Id)
                //{
                //    expressionItemList.Add(
                //        new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.NotEntryDays.ID), item.Value.ToString(),
                //                           EnumDataType.Number));
                //}
                //else if (item.BindItemEnum.Id == BindItemEnum.DimissionDays.Id)
                //{
                //    expressionItemList.Add(
                //       new ExpressionItem(string.Format("A{0}", AssessBindItemEnum.DimissionDays.ID), item.Value.ToString(),
                //                          EnumDataType.Number));
                //}
            }
            CalculateExpressionItemList cal=new CalculateExpressionItemList(expressionItemList,"A");
            cal.CalculateExpressionResult();
            foreach (ExpressionItem item in expressionItemList)
            {
                if(item.Parameter==AssessBindItemEnum.ImposibleID)
                {
                    return Convert.ToDecimal(item.Result);
                }
            }
            return 0;
        }
    }
}