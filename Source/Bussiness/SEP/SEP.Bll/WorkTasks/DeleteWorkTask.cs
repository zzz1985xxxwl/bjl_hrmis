using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.WorkTasks
{
    internal class DeleteWorkTask : Transaction
    {
        private readonly int _WorkTaskId;

        public DeleteWorkTask(int workTaskId)
        {
            _WorkTaskId = workTaskId;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.WorkTaskDalInstance.Delete(_WorkTaskId);
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