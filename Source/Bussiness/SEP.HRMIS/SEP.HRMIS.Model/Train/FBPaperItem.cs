

namespace SEP.HRMIS.Model
{
   ///<summary>
   /// ����������
   ///</summary>
   public class FBPaperItem
    {
      //�������⣬�����������Ӧ�����ֵ

       private string _FBQuestion;
       private string _FBQueItems;
       private string _Worths;
       private int _FBPaperItemId;

       ///<summary>
       /// ����������ID
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
