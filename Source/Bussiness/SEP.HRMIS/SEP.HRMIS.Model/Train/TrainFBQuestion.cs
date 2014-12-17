//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainFBQuestion.cs
// 创建者: 张珍
// 创建日期: 2008-11-05
// 概述: 培训反馈问题
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
   ///<summary>
   /// 培训反馈问题
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
       /// 问题ID
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
       /// 问题描述
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
       /// 问题所属类型
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
       /// 问题的选项
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
