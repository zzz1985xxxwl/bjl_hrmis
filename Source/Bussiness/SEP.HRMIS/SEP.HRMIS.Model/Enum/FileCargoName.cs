//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FileCargoName.cs
// 创建者: yyb
// 创建日期: 2008-08-26
// 概述: 档案名称
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 档案名称
    /// </summary>
    [Serializable]
    public class FileCargoName : ParameterBase
    {
        public FileCargoName(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// 员工信息登记表
        /// </summary>
        public static FileCargoName YuanDongXinXiDengJiBiao = new FileCargoName(1, "员工信息登记表");
        /// <summary>
        /// 求职申请表
        /// </summary>
        public static FileCargoName QiuZhiShenQingBiao = new FileCargoName(2, "求职申请表");
        /// <summary>
        /// 简历
        /// </summary>
        public static FileCargoName JianLi = new FileCargoName(3, "简历");
        /// <summary>
        /// 面试评估表
        /// </summary>
        public static FileCargoName MianShiPingGuBiao = new FileCargoName(4, "面试评估表");
        /// <summary>
        /// 身份证复印件
        /// </summary>
        public static FileCargoName ShenFengZhengFuYinJian = new FileCargoName(5, "身份证复印件");
        /// <summary>
        /// 户口本复印件/户籍证明
        /// </summary>
        public static FileCargoName HuKouBenFuYinJian = new FileCargoName(6, "户口本复印件/户籍证明");
        /// <summary>
        /// 学历证书复印件
        /// </summary>
        public static FileCargoName XueLiZhengShuFuYinJian = new FileCargoName(7, "学历证书复印件");
        /// <summary>
        /// 学位证书复印件
        /// </summary>
        public static FileCargoName XueWeiZhengShu = new FileCargoName(8, "学位证书复印件");
        /// <summary>
        /// 劳动手册/退工单/离职证明
        /// </summary>
        public static FileCargoName LaoDongShouCe = new FileCargoName(9, "劳动手册/退工单/离职证明");
        /// <summary>
        /// 技能证书
        /// </summary>
        public static FileCargoName JiNengZhengShu = new FileCargoName(10, "技能证书");
        /// <summary>
        /// 居住证
        /// </summary>
        public static FileCargoName JuZhuZheng = new FileCargoName(11, "居住证");
        /// <summary>
        /// 结婚证复印件
        /// </summary>
        public static FileCargoName JieHunZhengFuYinJian = new FileCargoName(12, "结婚证复印件");
        /// <summary>
        /// 报到证
        /// </summary>
        public static FileCargoName BaoDaoZheng = new FileCargoName(13, "报到证");
        /// <summary>
        /// 成绩单
        /// </summary>
        public static FileCargoName ChengJiDan = new FileCargoName(14, "成绩单");
        /// <summary>
        /// 学生证复印件
        /// </summary>
        public static FileCargoName XueShengZhengFuYinJian = new FileCargoName(15, "学生证复印件");
        /// <summary>
        /// 就业推荐表
        /// </summary>
        public static FileCargoName JiuYeTuiJianBiao = new FileCargoName(16, "就业推荐表");
        /// <summary>
        /// 就业协议书
        /// </summary>
        public static FileCargoName JiuYeXieYiShu = new FileCargoName(17, "就业协议书");
        /// <summary>
        /// 体检证明
        /// </summary>
        public static FileCargoName TiJianZhengMing = new FileCargoName(18, "体检证明");
        /// <summary>
        /// 在职证明
        /// </summary>
        public static FileCargoName ZaiZhiZhengMing = new FileCargoName(19, "在职证明");
        /// <summary>
        /// 收入证明
        /// </summary>
        public static FileCargoName ShouRuZhengMing = new FileCargoName(20, "收入证明");
        /// <summary>
        /// 奖状
        /// </summary>
        public static FileCargoName JiangZhuang = new FileCargoName(21, "奖状");
        /// <summary>
        /// 其他
        /// </summary>
        public static FileCargoName Others = new FileCargoName(22, "其他");
        /// <summary>
        /// 合同文本
        /// </summary>
        public static FileCargoName ContractText = new FileCargoName(23, "合同文本");
        /// <summary>
        /// offer
        /// </summary>
        public static FileCargoName Offer = new FileCargoName(24, "offer");
        /// <summary>
        /// 笔试题
        /// </summary>
        public static FileCargoName InterviewWritePart = new FileCargoName(25, "笔试题");
        /// <summary>
        /// 面试PPT
        /// </summary>
        public static FileCargoName InterviewPPT = new FileCargoName(26, "面试PPT");

        public static FileCargoName FindFileCargoName(int id)
        {
            switch (id)
            {
                case 1:
                    return YuanDongXinXiDengJiBiao;
                case 2:
                    return QiuZhiShenQingBiao;
                case 3:
                    return JianLi;
                case 4:
                    return MianShiPingGuBiao;
                case 5:
                    return ShenFengZhengFuYinJian;
                case 6:
                    return HuKouBenFuYinJian;
                case 7:
                    return XueLiZhengShuFuYinJian;
                case 8:
                    return XueWeiZhengShu;
                case 9:
                    return LaoDongShouCe;
                case 10:
                    return JiNengZhengShu;
                case 11:
                    return JuZhuZheng;
                case 12:
                    return JieHunZhengFuYinJian;
                case 13:
                    return BaoDaoZheng;
                case 14:
                    return ChengJiDan;
                case 15:
                    return XueShengZhengFuYinJian;
                case 16:
                    return JiuYeTuiJianBiao;
                case 17:
                    return JiuYeXieYiShu;
                case 18:
                    return TiJianZhengMing;
                case 19:
                    return ZaiZhiZhengMing;
                case 20:
                    return ShouRuZhengMing;
                case 21:
                    return JiangZhuang;
                case 22:
                    return Others;
                case 23:
                    return ContractText;
                case 24:
                    return Offer;
                case 25:
                    return InterviewWritePart;
                case 26:
                    return InterviewPPT;                 
                default:
                    return null;
            }
        }

        public static List<FileCargoName> GetAll()
        {
            List<FileCargoName> all = new List<FileCargoName>();
            all.Add(YuanDongXinXiDengJiBiao);
            all.Add(QiuZhiShenQingBiao);
            all.Add(JianLi);
            all.Add(MianShiPingGuBiao);
            all.Add(ShenFengZhengFuYinJian);
            all.Add(HuKouBenFuYinJian);
            all.Add(XueLiZhengShuFuYinJian);
            all.Add(XueWeiZhengShu);
            all.Add(LaoDongShouCe);
            all.Add(JiNengZhengShu);
            all.Add(JuZhuZheng);
            all.Add(JieHunZhengFuYinJian);
            all.Add(BaoDaoZheng);
            all.Add(ChengJiDan);
            all.Add(XueShengZhengFuYinJian);
            all.Add(JiuYeTuiJianBiao);
            all.Add(JiuYeXieYiShu);
            all.Add(TiJianZhengMing);
            all.Add(ZaiZhiZhengMing);
            all.Add(ShouRuZhengMing);
            all.Add(JiangZhuang);
            all.Add(Others);
            all.Add(ContractText);
            all.Add(Offer);
            all.Add(InterviewWritePart);
            all.Add(InterviewPPT);

            return all;
        }
    }
}