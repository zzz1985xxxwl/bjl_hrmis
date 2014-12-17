using System;

namespace SEP.Presenter
{
    public delegate void DelegateID(string id);
    public delegate void DelegateDateTime(DateTime date);
    public delegate void DelegateNoParameter();

    public delegate void DelegateSomeParameter(string specialDateID, string specialDate,
                                             string specialDateBackColor, string specialDescription,
                                             string specialForeColor,string specialHeader, int isWork);
}