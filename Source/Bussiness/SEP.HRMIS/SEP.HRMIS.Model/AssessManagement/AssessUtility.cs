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
        /// ������ʧ�ܣ����׳��쳣,A99Ϊһ��������ֵ�����
        /// </summary>
        public static void CheckFormula(string formula)
        {
            if(formula.Contains(AssessBindItemEnum.ImposibleID))
            {
                throw new Exception("������ѭ��");
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
            ItemClassfications.Add(ItemClassficationEmnu.Performance.ToString(), "��Ч");
            ItemClassfications.Add(ItemClassficationEmnu.Ability.ToString(), "����");
            ItemClassfications.Add(ItemClassficationEmnu.MoralCharacter.ToString(), "Ʒ��");
            ItemClassfications.Add(ItemClassficationEmnu.Acqierement.ToString(), "ѧʶ");
            ItemClassfications.Add(ItemClassficationEmnu.Attitude.ToString(), "̬��");
            ItemClassfications.Add(ItemClassficationEmnu.Other.ToString(), "����");
            ItemClassfications.Add(ItemClassficationEmnu._360.ToString(), "360��");
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
                    return "��Ч";
                case "Ability":
                    return "����";
                case "MoralCharacter":
                    return "Ʒ��";
                case "Acqierement":
                    return "ѧʶ";
                case "Attitude":
                    return "̬��";
                case "Other":
                    return "����";
                case "_360":
                    return "360��";
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
                    return "����";
                case ItemClassficationEmnu.Acqierement:
                    return "ѧʶ";
                case ItemClassficationEmnu.All:
                    return "";
                case ItemClassficationEmnu.MoralCharacter:
                    return "Ʒ��";
                case ItemClassficationEmnu.Performance:
                    return "��Ч";
                case ItemClassficationEmnu.Attitude:
                    return "̬��";
                case ItemClassficationEmnu.Other:
                    return "����";
                case ItemClassficationEmnu._360:
                    return "360��";
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
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Option, "������");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Open, "������");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Score, "�����");
        //    assessTemplateItemTypeSource.Add((int)AssessTemplateItemType.Formula, "��ʽ��");

        //    return assessTemplateItemTypeSource;
        //}
    }
}