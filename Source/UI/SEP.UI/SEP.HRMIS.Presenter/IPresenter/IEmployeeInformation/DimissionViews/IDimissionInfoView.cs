using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews
{
    public interface IDimissionInfoView
    {
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        IDimissionBasicView DimmissionBasicView { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        IFileCargoView FileCargoView { get; set;}
        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool FileCargoViewVisible { get; set;}
    }

    public delegate void DlgFileCargos(List<FileCargo> filecargos);
}