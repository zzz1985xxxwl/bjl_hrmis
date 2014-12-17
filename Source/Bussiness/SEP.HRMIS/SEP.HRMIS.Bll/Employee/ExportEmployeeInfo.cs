//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ExportEmployeeInfo.cs
// 创建者: 薛文龙
// 创建日期: 2008-10-08
// 概述: 用于导出员工的基本信息
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.IO;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 导出员工基本信息
    /// </summary>
    public class ExportEmployeeInfo
    {
        
        private readonly string _EmployeeTemplateLocation ;
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private readonly Employee _Employee;
        private int _FamilyStartRow;
        private int _FamilyCount;
        private int _WorkStartRow;
        private int _WorkCount;
        private int _EducationStratRow;
        private int _EducationCount;
        private int _LanguageStratRow;
        private readonly string _TempPhotolocation;
        /// <summary>
        /// 导出员工基本信息构造函数
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeTemplateLocation"></param>
        public ExportEmployeeInfo(int employeeID,string employeeTemplateLocation)
        {
            _Employee = new GetEmployee().GetEmployeeByAccountID(employeeID);
            _EmployeeTemplateLocation = employeeTemplateLocation;
            _TempPhotolocation = _EmployeeExportLocation + "\\" + _Employee.Account.Name + ".jpg";
        }
        /// <summary>
        /// 执行导出方法
        /// </summary>
        /// <returns></returns>
        public string  ExcuteSelf()
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            object nothing = Type.Missing;
            object localPatho = _EmployeeTemplateLocation;
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
            try
            {
                if (!Directory.Exists(_EmployeeExportLocation))
                {
                    Directory.CreateDirectory(_EmployeeExportLocation);
                }    
                Microsoft.Office.Interop.Word.Table tb = doc.Tables[1];
                InitRows(ref tb);
                AddBasicInfo(ref tb);
                AddFamilyInfo(ref tb);
                AddWorkInfo(ref tb);
                AddEducationInfo(ref tb);
                AddLanguageInfo(ref tb);
                AddEmployeePhoto(ref tb, ref doc);
              
                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatTemplate97;
                object filename = _EmployeeExportLocation + "\\" + _Employee.Account.Name + "的员工信息登记表.doc";
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                return filename.ToString();
            }
            catch(Exception e)
            {
                doc.Tables[1].Cell(3, 2).Range.Text = e.Message;
                object filename = _EmployeeExportLocation + "\\" + "temp.doc";
                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatTemplate97;
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                          ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                          ref nothing, ref nothing);
                return "";
            } 
            finally
            {        
                doc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);
                //清理照片
                if (File.Exists(_TempPhotolocation))
                {
                    File.Delete(_TempPhotolocation);
                }
            }
        }

        private void AddEmployeePhoto(ref Microsoft.Office.Interop.Word.Table tb,ref Microsoft.Office.Interop.Word.Document doc)
        {
            if (_Employee.EmployeeDetails.Photo != null)
            {
                //插入图片
                CreatePicture();
                string FileName = _TempPhotolocation;  
                object LinkToFile = false;
                object SaveWithDocument = true;
                tb.Cell(11, 5).Select();
                object Anchor = doc.Application.Selection.Range;

                doc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile,
                                                                       ref SaveWithDocument, ref Anchor);
                doc.Application.ActiveDocument.InlineShapes[2].Width = 78f; //图片宽度
                doc.Application.ActiveDocument.InlineShapes[2].Height = 111f; //图片高度   

                //将图片设置为四周环绕型
                Microsoft.Office.Interop.Word.Shape s =
                    doc.Application.ActiveDocument.InlineShapes[2].ConvertToShape();
                s.WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapFront;
            }
        }
        /// <summary>
        /// 新增一个临时照片
        /// </summary>
        private void CreatePicture()
        {
            byte[] bytes = _Employee.EmployeeDetails.Photo;
            FileStream fs = new FileStream(_TempPhotolocation, FileMode.Create, FileAccess.Write);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
        }

        private void InitRows(ref Microsoft.Office.Interop.Word.Table tb)
        {
            _FamilyCount = _Employee.EmployeeDetails.Family.FamilyMembers.Count;
            _WorkCount = _Employee.EmployeeDetails.Work.WorkExperiences.Count;
            _EducationCount = _Employee.EmployeeDetails.Education.EducationExperiences.Count;
            _FamilyStartRow = 15;

            _FamilyCount = _FamilyCount == 0 ? 1 : _FamilyCount;
            _WorkCount = _WorkCount == 0 ? 1 : _WorkCount;
            _EducationCount = _EducationCount == 0 ? 1 : _EducationCount;

            _WorkStartRow = _FamilyStartRow + _FamilyCount + 2;
            _EducationStratRow = _WorkStartRow + _WorkCount + 2;
            _LanguageStratRow = _EducationStratRow + _EducationCount + 1;
            AddNeedRow(ref tb, _FamilyCount, _FamilyStartRow);
            AddNeedRow(ref tb, _WorkCount, _WorkStartRow);
            AddNeedRow(ref tb, _EducationCount, _EducationStratRow);
        }
        private void AddBasicInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            tb.Cell(2, 3).Range.Text = _Employee.Account.Id.ToString();
            tb.Cell(3, 2).Range.Text = _Employee.Account.Dept.Name;
            tb.Cell(3, 4).Range.Text = _Employee.EmployeeDetails.Work.ComeDate.ToShortDateString();
            tb.Cell(5, 2).Range.Text = _Employee.Account.Name;
            tb.Cell(5, 4).Range.Text = _Employee.EmployeeDetails.Gender.Name;
            tb.Cell(5, 6).Range.Text = _Employee.EmployeeDetails.Birthday.ToShortDateString();
            tb.Cell(5, 8).Range.Text = _Employee.EmployeeDetails.Height.ToString();
            tb.Cell(5, 10).Range.Text = _Employee.EmployeeDetails.Weight.ToString();
            tb.Cell(6, 2).Range.Text = _Employee.EmployeeDetails.NativePlace;
            tb.Cell(6, 4).Range.Text = _Employee.EmployeeDetails.PoliticalAffiliation.Name;
            tb.Cell(6, 6).Range.Text = _Employee.EmployeeDetails.Nationality;
            tb.Cell(6, 8).Range.Text = _Employee.EmployeeDetails.Education.EducationalBackground.Name;
            tb.Cell(6, 10).Range.Text = _Employee.EmployeeDetails.PhysicalConditions;
            tb.Cell(7, 2).Range.Text = _Employee.EmployeeDetails.Education.School;
            tb.Cell(7, 4).Range.Text = _Employee.EmployeeDetails.Education.Major;
            tb.Cell(8, 2).Range.Text = "身份证：" + _Employee.EmployeeDetails.IDCard.IDCardNo;
            tb.Cell(8, 4).Range.Text = _Employee.EmployeeDetails.MaritalStatus.Name;
            tb.Cell(9, 2).Range.Text = _Employee.EmployeeDetails.RegisteredPermanentResidence.RPRAddress;
            tb.Cell(9, 4).Range.Text = _Employee.EmployeeDetails.RegisteredPermanentResidence.PRPPostCode;
            tb.Cell(10, 2).Range.Text = _Employee.EmployeeDetails.RegisteredPermanentResidence.PRPArea;
            tb.Cell(10, 4).Range.Text = _Employee.EmployeeDetails.RegisteredPermanentResidence.PRPStreet;
            tb.Cell(11, 2).Range.Text = _Employee.EmployeeDetails.Family.FamilyAddress;
            tb.Cell(11, 4).Range.Text = _Employee.EmployeeDetails.Family.PostCode;
            tb.Cell(12, 2).Range.Text = _Employee.EmployeeDetails.Family.FamilyPhone;
            tb.Cell(12, 4).Range.Text = _Employee.Account.MobileNum;
            tb.Cell(12, 6).Range.Text = _Employee.EmployeeDetails.EmergencyContacts;
        }
        private void AddFamilyInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            int i = 0;
            foreach(FamilyMember familyMember in _Employee.EmployeeDetails.Family.FamilyMembers)
            {
                tb.Cell(_FamilyStartRow + i, 1).Range.Text = familyMember.Name;
                tb.Cell(_FamilyStartRow + i, 2).Range.Text = familyMember.Relationship;
                tb.Cell(_FamilyStartRow + i, 3).Range.Text = familyMember.Age.ToString();
                tb.Cell(_FamilyStartRow + i, 4).Range.Text = familyMember.Company;
                tb.Cell(_FamilyStartRow + i, 5).Range.Text = familyMember.Remark;
                i++;
            }
        }
        private void AddWorkInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            int i = 0;
            foreach (WorkExperience workExperience in _Employee.EmployeeDetails.Work.WorkExperiences)
            {
                tb.Cell(_WorkStartRow + i, 1).Range.Text = workExperience.ExperiencePeriod;
                tb.Cell(_WorkStartRow + i, 2).Range.Text = workExperience.Place;
                tb.Cell(_WorkStartRow + i, 3).Range.Text = workExperience.ContactPerson;
                tb.Cell(_WorkStartRow + i, 4).Range.Text = workExperience.Contect;
                tb.Cell(_WorkStartRow + i, 5).Range.Text = workExperience.Remark;
                i++;
            }
        }
        private void AddEducationInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            int i = 0;
            foreach (EducationExperience educationExperience in _Employee.EmployeeDetails.Education.EducationExperiences)
            {
                tb.Cell(_EducationStratRow + i, 1).Range.Text = educationExperience.ExperiencePeriod;
                tb.Cell(_EducationStratRow + i, 2).Range.Text = educationExperience.Place;
                tb.Cell(_EducationStratRow + i, 3).Range.Text = educationExperience.Contect;
                i++;
            }
        }

        private void AddLanguageInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            tb.Cell(_LanguageStratRow, 2).Range.Text = _Employee.EmployeeDetails.Education.ForeignLanguageAbility;
            tb.Cell(_LanguageStratRow+1, 2).Range.Text = _Employee.EmployeeDetails.Education.Certificates;
        }

        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private static void AddNeedRow(ref Microsoft.Office.Interop.Word.Table tb, int count, int rowIndex)
        {
            object row = tb.Rows[rowIndex];
            for (int i = 0; i < count - 1; i++)
            {
                tb.Rows[rowIndex].Select();
                tb.Rows.Add(ref row);
            }
        }

    }
}

