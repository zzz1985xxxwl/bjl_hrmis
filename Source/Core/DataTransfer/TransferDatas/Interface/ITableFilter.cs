//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: ITableFilter.cs
// ������: �ߺ�
// ��������: 2009-05-11
// ����: ���ⷢ���Ľӿڣ�������չ��ɾѡ�������ڴ˴��Զ�����θ���
//       ʱ���ɸѡ�Լ���Ҫ�����ݣ�ͬʱ��Ҫ�������ȥ��ԭ��Щ����
// ----------------------------------------------------------------
using System;

namespace TransferDatas
{
    public interface ITableFilter:ICloneable
    {
        /// <summary>
        /// ��ȡ�Ƿ���Ҫʱ������
        /// </summary>
        bool GetNeedTimeFilter();
        /// <summary>
        /// ���ù�������ʵ����
        /// </summary>
        /// <param name="theRule">���ݵ��������˹�����󣬿������ɵ��ڽӿ������������Ĺ�������</param>
        /// <param name="mainTableName">������</param>
        /// <param name="orginDbName">Դ���ݿ�����(��ϵͳ���ݿ���)</param>
        /// <param name="orginCopyDbName">����Դ���ݿ������(��ϵͳ�Ŀ���)</param>
        /// <param name="restoreDbName">����ԭ���ݿ�����(��ϵͳ���ݿ���)</param>
        /// <param name="forRestoreCopyDbName">�ڴ�ϵͳ�ϵĿ������ݿ���(��ϵͳ����һ�ݿ���)</param>
        void ConfigTheFilter(TransferRule theRule,string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName);
        /// <summary>
        /// ��ʼ��ԭ������
        /// </summary>
        string RestoreTableData(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// ��ʼ���˱�����
        /// </summary>
        string FilterTableData(DateTime? fromDay, DateTime? toDay);
    }
}