//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReimburseTypeEnum.cs
// ������: ��ɯ��
// ��������: 2008-10-06
// ����: ��������
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum ReimburseTypeEnum
    {
        CityTrafficCost,  //���ڽ�ͨ��
        MealCost,       //�ͷ�
        AdminCost,//��������
        //BizTrip,//���÷�
        CommunicationCost,//ͨѶ��
        //BizCustomerCost,//ҵ������
        VehicleRunningCost,  //�������з�
        TrainingCost,       //��ѵ��
        WelfareCost,//������
        AccommodationCost,  //����
        ConferenceFeesCost,       //�����
        ConsultancyFeesCost,//���ʷ�
        OtherCost ,//����

        ShortDistanceCost,//��;��ͨ��
        LongDistanceCost,  //��;��ͨ��
        LodgingCost, //ס�޷�
        CommunicationEntertainmentCost,//����Ӧ���
        /// <summary>
        /// �ʼķ�
        /// </summary>
        MailPostCost,
        /// <summary>
        /// �г�����
        /// </summary>
        MarkCost,
        /// <summary>
        /// �ֿ����
        /// </summary>
        WarehouseCost,
        /// <summary>
        /// չ�������
        /// </summary>
        ExhibitionCost,
        All=-1
    }
}
