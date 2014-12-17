//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FileCargoName.cs
// ������: yyb
// ��������: 2008-08-26
// ����: ��������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public class FileCargoName : ParameterBase
    {
        public FileCargoName(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Ա����Ϣ�ǼǱ�
        /// </summary>
        public static FileCargoName YuanDongXinXiDengJiBiao = new FileCargoName(1, "Ա����Ϣ�ǼǱ�");
        /// <summary>
        /// ��ְ�����
        /// </summary>
        public static FileCargoName QiuZhiShenQingBiao = new FileCargoName(2, "��ְ�����");
        /// <summary>
        /// ����
        /// </summary>
        public static FileCargoName JianLi = new FileCargoName(3, "����");
        /// <summary>
        /// ����������
        /// </summary>
        public static FileCargoName MianShiPingGuBiao = new FileCargoName(4, "����������");
        /// <summary>
        /// ���֤��ӡ��
        /// </summary>
        public static FileCargoName ShenFengZhengFuYinJian = new FileCargoName(5, "���֤��ӡ��");
        /// <summary>
        /// ���ڱ���ӡ��/����֤��
        /// </summary>
        public static FileCargoName HuKouBenFuYinJian = new FileCargoName(6, "���ڱ���ӡ��/����֤��");
        /// <summary>
        /// ѧ��֤�鸴ӡ��
        /// </summary>
        public static FileCargoName XueLiZhengShuFuYinJian = new FileCargoName(7, "ѧ��֤�鸴ӡ��");
        /// <summary>
        /// ѧλ֤�鸴ӡ��
        /// </summary>
        public static FileCargoName XueWeiZhengShu = new FileCargoName(8, "ѧλ֤�鸴ӡ��");
        /// <summary>
        /// �Ͷ��ֲ�/�˹���/��ְ֤��
        /// </summary>
        public static FileCargoName LaoDongShouCe = new FileCargoName(9, "�Ͷ��ֲ�/�˹���/��ְ֤��");
        /// <summary>
        /// ����֤��
        /// </summary>
        public static FileCargoName JiNengZhengShu = new FileCargoName(10, "����֤��");
        /// <summary>
        /// ��ס֤
        /// </summary>
        public static FileCargoName JuZhuZheng = new FileCargoName(11, "��ס֤");
        /// <summary>
        /// ���֤��ӡ��
        /// </summary>
        public static FileCargoName JieHunZhengFuYinJian = new FileCargoName(12, "���֤��ӡ��");
        /// <summary>
        /// ����֤
        /// </summary>
        public static FileCargoName BaoDaoZheng = new FileCargoName(13, "����֤");
        /// <summary>
        /// �ɼ���
        /// </summary>
        public static FileCargoName ChengJiDan = new FileCargoName(14, "�ɼ���");
        /// <summary>
        /// ѧ��֤��ӡ��
        /// </summary>
        public static FileCargoName XueShengZhengFuYinJian = new FileCargoName(15, "ѧ��֤��ӡ��");
        /// <summary>
        /// ��ҵ�Ƽ���
        /// </summary>
        public static FileCargoName JiuYeTuiJianBiao = new FileCargoName(16, "��ҵ�Ƽ���");
        /// <summary>
        /// ��ҵЭ����
        /// </summary>
        public static FileCargoName JiuYeXieYiShu = new FileCargoName(17, "��ҵЭ����");
        /// <summary>
        /// ���֤��
        /// </summary>
        public static FileCargoName TiJianZhengMing = new FileCargoName(18, "���֤��");
        /// <summary>
        /// ��ְ֤��
        /// </summary>
        public static FileCargoName ZaiZhiZhengMing = new FileCargoName(19, "��ְ֤��");
        /// <summary>
        /// ����֤��
        /// </summary>
        public static FileCargoName ShouRuZhengMing = new FileCargoName(20, "����֤��");
        /// <summary>
        /// ��״
        /// </summary>
        public static FileCargoName JiangZhuang = new FileCargoName(21, "��״");
        /// <summary>
        /// ����
        /// </summary>
        public static FileCargoName Others = new FileCargoName(22, "����");
        /// <summary>
        /// ��ͬ�ı�
        /// </summary>
        public static FileCargoName ContractText = new FileCargoName(23, "��ͬ�ı�");
        /// <summary>
        /// offer
        /// </summary>
        public static FileCargoName Offer = new FileCargoName(24, "offer");
        /// <summary>
        /// ������
        /// </summary>
        public static FileCargoName InterviewWritePart = new FileCargoName(25, "������");
        /// <summary>
        /// ����PPT
        /// </summary>
        public static FileCargoName InterviewPPT = new FileCargoName(26, "����PPT");

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