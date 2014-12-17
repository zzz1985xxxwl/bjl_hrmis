using SEP.Model.Accounts;

namespace SEP.Presenter.Core
{
    public abstract class BasePresenter
    {
        private readonly Account _LoginUser;
        protected Account LoginUser
        {
            get
            {
                return _LoginUser;
            }
        }

        protected BasePresenter(Account loginUser)
        {
            _LoginUser = loginUser;
        }
        public abstract void Initialize(bool isPostBack);
    }
}
