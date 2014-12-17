

namespace SEP.HRMIS.Model
{
   ///<summary>
   /// 反馈问题项
   ///</summary>
   public class FBPaperItem
    {
      //反馈问题，反馈的问题对应的项，分值

       private string _FBQuestion;
       private string _FBQueItems;
       private string _Worths;
       private int _FBPaperItemId;

       ///<summary>
       /// 反馈问题项ID
       ///</summary>
       public int FBPaperItemId
       {
           get { return _FBPaperItemId; }
           set { _FBPaperItemId = value; }
       }

       ///<summary>
       ///</summary>
       public string FBQuestion
       {
           get { return _FBQuestion; }
           set { _FBQuestion = value; }
       }

       ///<summary>
       ///</summary>
       public string FBQueItems
       {
           get { return _FBQueItems; }
           set { _FBQueItems = value; }
       }

       ///<summary>
       ///</summary>
       public string Worths
       {
           get { return _Worths; }
           set { _Worths = value;}
       }

    }
}
