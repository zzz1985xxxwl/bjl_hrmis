using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IDepartmentListView DepartmentListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        IDepartmentView DepartmentView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool DepartmentViewVisible { get;set;}

        string divMPEDepartmentClientID { get; }
    }
}
