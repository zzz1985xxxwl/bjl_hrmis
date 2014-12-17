//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: SortList.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-18
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SEP.Model.Utility
{
    public class SortList<T> : IComparer<T>
    {
        private readonly Type _Type = null;
        private ReverserInfo _Info;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="type">���бȽϵ�������</param>
        /// <param name="name">���бȽ϶������������</param>
        /// <param name="direction">�ȽϷ���(����/����)</param>
        public SortList(Type type, string name, ReverserInfo.Direction direction)
        {
            _Type = type;
            _Info._Name = name;
            if (direction != ReverserInfo.Direction.ASC)
                _Info._Direction = direction;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="t">���бȽϵ����͵�ʵ��</param>
        /// <param name="name">���бȽ϶������������</param>
        /// <param name="direction">�ȽϷ���(����/����)</param>
        public SortList(T t, string name, ReverserInfo.Direction direction)
        {
            _Type = t.GetType();
            _Info._Name = name;
            _Info._Direction = direction;
        }

        //���룡ʵ��IComparer<T>�ıȽϷ�����
        int IComparer<T>.Compare(T t1, T t2)
        {
            object x = _Type.InvokeMember(_Info._Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t1, null);
            object y = _Type.InvokeMember(_Info._Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t2, null);
            if (_Info._Direction != ReverserInfo.Direction.ASC)
                Swap(ref x, ref y);
            return (new CaseInsensitiveComparer()).Compare(x, y);
        }

        //����������
        private static void Swap(ref object x, ref object y)
        {
            object temp;
            temp = x;
            x = y;
            y = temp;
        }
    }

    /// <summary>
    /// ����Ƚ�ʱʹ�õ���Ϣ��
    /// </summary>
    public struct ReverserInfo
    {
        /**/
        /// <summary>
        /// �Ƚϵķ������£�
        /// ASC������
        /// DESC������
        /// </summary>
        public enum Direction
        {
            ASC = 0,
            DESC,
        };

        public enum Target
        {
            CUSTOMER = 0,
            FORM,
            FIELD,
            SERVER,
        };

        public string _Name;
        public Direction _Direction;
        public Target _Target;
    }
}