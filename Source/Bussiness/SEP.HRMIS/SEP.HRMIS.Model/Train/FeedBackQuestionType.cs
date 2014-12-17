
namespace SEP.HRMIS.Model
{
   ///<summary>
   /// 反馈问题类型
   ///</summary>
   public class FeedBackQuestionType:Parameter
    {
       ///<summary>
       ///</summary>
       ///<param name="feedBackQuestionTypeID"></param>
       ///<param name="feedBackQuestionTypeName"></param>
       public FeedBackQuestionType(int feedBackQuestionTypeID, string feedBackQuestionTypeName)
           : base(feedBackQuestionTypeID, feedBackQuestionTypeName, "")
        {
        }
    }
}
