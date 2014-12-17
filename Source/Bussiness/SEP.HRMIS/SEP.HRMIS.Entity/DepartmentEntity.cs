using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Entity
{
    public class DepartmentEntity
    {
        private int _PKID;
        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        private string _DepartmentName;
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        private int _LeaderId;
        /// <summary>
        /// 
        /// </summary>
        public int LeaderId
        {
            get
            {
                return _LeaderId;
            }
            set
            {
                _LeaderId = value;
            }
        }

        private int _ParentId;
        /// <summary>
        /// 
        /// </summary>
        public int ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                _ParentId = value;
            }
        }

        private string _Address;
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        private string _Phone;
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        private string _Fax;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                _Fax = value;
            }
        }

        private string _Others;
        /// <summary>
        /// 
        /// </summary>
        public string Others
        {
            get
            {
                return _Others;
            }
            set
            {
                _Others = value;
            }
        }

        private string _Description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private DateTime? _FoundationTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FoundationTime
        {
            get
            {
                return _FoundationTime;
            }
            set
            {
                _FoundationTime = value;
            }
        }


        public static Department Convert(DepartmentEntity entity)
        {
            Department model = new Department();
            model.Address = entity.Address;
            model.DepartmentID = entity.PKID;
            model.DepartmentLeader = new Account(entity.LeaderId, "", "");
            model.DepartmentName = entity.DepartmentName;
            model.Description = entity.Description;
            model.Fax = entity.Fax;
            model.Phone = entity.Phone;
            model.ParentDepartment = new Department(entity.ParentId, "");
            model.Others = entity.Others;
            model.FoundationTime = entity.FoundationTime;
            return model;
        }
    }
}

