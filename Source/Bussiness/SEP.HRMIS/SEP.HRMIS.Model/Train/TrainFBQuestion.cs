//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainFBQuestion.cs
// ������: ����
// ��������: 2008-11-05
// ����: ��ѵ��������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
   ///<summary>
   /// ��ѵ��������
   ///</summary>
    [Serializable]
    public class TrainFBQuestion
    {
       private int _FBQuestionID;
       private string _Description;
       private TrainFBQuesType _FBQuesType;
       private List<TrainFBItem> _FBItems;

       ///<summary>
       ///</summary>
       ///<param name="fbQuestioniD"></param>
       ///<param name="description"></param>
       ///<param name="fBQuesType"></param>
       ///<param name="fbItems"></param>
       public TrainFBQuestion(int fbQuestioniD, string description,TrainFBQuesType fBQuesType, List<TrainFBItem> fbItems)
        {
            _FBQuestionID = fbQuestioniD;
            _Description = description;
            _FBItems = fbItems;
           _FBQuesType = fBQuesType;
        }
       /// <summary>
       /// ����ID
       /// </summary>
       public int FBQuestioniD
        {
            get
            {
                return _FBQuestionID;
            }
            set
            {
                _FBQuestionID = value;
            }
        }
       /// <summary>
       /// ��������
       /// </summary>
       public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
       /// <summary>
       /// ������������
       /// </summary>
       public TrainFBQuesType TrainFBQuesType
       {
           get
           {
               return _FBQuesType;
           }
           set
           {
               _FBQuesType = value;
           }
       }
       /// <summary>
       /// �����ѡ��
       /// </summary>
       public List<TrainFBItem> FBItems
        {
            get
            {
                return _FBItems;
            }
            set
            {
                _FBItems = value;
            }
        }

       ///<summary>
       ///</summary>
       ///<param name="description"></param>
       ///<returns></returns>
       public bool FindNotExistItems(string description)
       {
           foreach (TrainFBItem item in FBItems)
           {
               if(item.Description == description)
               {
                   return false;
               }
               else
               {
                   return true;
               }
           }
           return true;
       }

       //public void RemoveAllItems()
       //{
       //    if (FBItems == null)
       //    {
       //        return;
       //    }
       //    FBItems.RemoveAll();
           
       //}

    }
}
