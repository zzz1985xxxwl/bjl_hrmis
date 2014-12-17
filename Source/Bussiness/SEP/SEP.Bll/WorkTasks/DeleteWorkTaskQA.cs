using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.WorkTasks
{
    internal class DeleteWorkTaskQA : Transaction
    {
        private readonly int _WorkTaskQAId;

        public DeleteWorkTaskQA(int workTaskQAId)
        {
            _WorkTaskQAId = workTaskQAId;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.WorkTaskDalInstance.DeleteWorkTaskQA(_WorkTaskQAId);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
        }
    }
}