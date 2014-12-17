//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AssessUtility.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-17
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using Evaluant.Calculator.Extensions;

namespace SEP.HRMIS.Model
{
    /// <summary> 
    /// </summary>
    public class AssessUtility
    {
        /// <summary>
        /// 如果检查失败，则抛出异常,A99为一个不会出现的序列
        /// </summary>
        public static void CheckFormula(string formula)
        {
            if(formula.Contains(AssessBindItemEnum.ImposibleID))
            {
                throw new Exception("出现死循环");
            }
            Random rd=new Random();
            List<ExpressionItem> items = new List<ExpressionItem>();
            foreach (AssessBindItemEnum itemEnum in AssessBindItemEnum.GetAllAssessBindItemEnum())
            {
                items.Add(new ExpressionItem(string.Format("A{0}", itemEnum.ID), rd.NextDouble().ToString(), EnumDataType.Number));
            }
            items.Add(new ExpressionItem(AssessBindItemEnum.ImposibleID, formula, EnumDataType.Number));
            CheckExpressionItem checkExpressionItem =
                new CheckExpressionItem(AssessBindItemEnum.ImposibleID, "A", items);
            checkExpressionItem.CheckExpressionItemValid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetItemClassfication()
        {
            Dictionary<string, string> ItemClassfications = new Dictionary<string, string>();
            ItemClassfications.Add(ItemClassficationEmnu.Performance.ToString(), "绩效");
            ItemClassfications.Add(ItemClassficationEmnu.Ability.ToString(), "能力");
            ItemClassfications.Add(ItemClassficationEmnu.MoralCharacter.ToString(), "品德");
            ItemClassfications.Add(ItemClassficationEmnu.Acqierement.ToString(), "学识");
            ItemClassfications.Add(ItemClassficationEmnu.Attitude.ToString(), "态度");
            ItemClassfications.Add(ItemClassficationEmnu.Other.ToString(), "其它");
            ItemClassfications.Add(ItemClassficationEmnu._360.ToString(), "360度");
            return ItemClassfications;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemClassfication"></param>
        /// <returns></returns>
        public static ItemClassficationEmnu GetChoosedItemClassfication(string itemClassfication)
        {
            switch (itemClassfication)
            {
                case "Performance":
                    return ItemClassficationEmnu.Performance;
                case "Ability":
                    return ItemClassficationEmnu.Ability;
                case "MoralCharacter":
                    return ItemClassficationEmnu.MoralCharacter;
                case "Acqierement":
                    return ItemClassficationEmnu.Acqierement;
                case "Attitude":
                    return ItemClassficationEmnu.Attitude;
                case "Other":
                    return ItemClassficationEmnu.Other;
                case "_360":
                    return ItemClassficationEmnu._360;
                default:
                    return ItemClassficationEmnu.All;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemClassfication"></param>
        /// <returns></returns>
        public static string GetChoosedItemClassficationName(string itemClassfication)
        {
            switch (itemClassfication)
            {
                case "Performance":
                    return "绩效";
                case "Ability":
                    return "能力";
                case "MoralCharacter":
                    return "品德";
                case "Acqierement":
                    return "学识";
                case "Attitude":
                    return "态度";
                case "Other":
                    return "其它";
                case "_360":
                    return "360度";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ClassficationToString(ItemClassficationEmnu type)
        {
            switch (type)
            {
                case ItemClassficationEmnu.Ability:
                    return "能力";
                case ItemClassficationEmnu.Acqierement:
                    return "学识";
                case ItemClassficationEmnu.All:
                    return "";
                case ItemClassficationEmnu.MoralCharacter:
                    return "品德";
                case ItemClassficationEmnu.Performance:
                    return "绩效";
                case ItemClassficationEmnu.Attitude:
                    return "态度";
                case ItemClassficationEmnu.Other:
                    return "其它";
                case ItemClassficationEmnu._360:
                    return "360度";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ItemClassficationEmnu> GetAllItemClassficationEmnu()
        {
            List<ItemClassficationEmnu> ItemClassfications =new  List<ItemClassficationEmnu>();
            ItemClassfications.Add(ItemClassficationEmnu.Performance);
            ItemClassfications.Add(ItemClassficationEmnu.Ability);
            ItemClassfications.Add(ItemClassficationEmnu.MoralCharacter);
            ItemClassfications.Add(ItemClassficationEmnu.Acqierement);
            ItemClassfications.Add(ItemClassficationEmnu.Attitude);
            ItemClassfications.Add(ItemClassficationEmnu.Other);
            ItemClassfications.Add(ItemClassficationEmnu._360);
            return ItemClassfications;
        }

        //public Dictionary<int, string> AssessTemplateItemTypeSource()
        //{
        //    Dictionary<int, string> assessTemplateItemTypeSource = new Dictionary<int, string>();
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Option, "开发项");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Open, "开发项");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Score, "打分项");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Formula, "公式项");

        //    return assessTemplateItemTypeSource;
        //}
    }
}