 using System;
 using AdvancedCondition;

namespace SEP.Presenter.Core
{
    public delegate void DelegateID(string id);
    public delegate void DelegateNoParameter();

    public delegate void Delegate2Parameter(string id1, string id2);

    public delegate void DelegateSomeParameter(string specialDateID, string specialDate,
                                             string specialDateBackColor, string specialDescription,
                                             string specialForeColor, string specialHeader, int isWork);

    public delegate byte[] DelegateReturnByte(int id);
    public delegate string DelegateReturnString(int id);

    public delegate bool DelegateReturnBool(int id);
    public delegate void DelegateGUID(Guid id);

    public delegate SearchField GetSearchFieldObject(string fieldName);
}
