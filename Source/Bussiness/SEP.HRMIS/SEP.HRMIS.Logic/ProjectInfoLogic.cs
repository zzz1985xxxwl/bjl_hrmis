using System;
using System.Collections.Generic;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class ProjectInfoLogic
    {
        public static void InsertProjectInfo(ProjectInfoEntity projectInfoEntity)
        {
            Valid(projectInfoEntity);
            ProjectInfoDA.InsertProjectInfo(projectInfoEntity);
        }

        public static void UpdateProjectInfo(ProjectInfoEntity projectInfoEntity)
        {
            var project = ProjectInfoDA.GetProjectInfoByPKID(projectInfoEntity.PKID);
            if (project != null)
            {
                Valid(projectInfoEntity);
                ProjectInfoDA.UpdateProjectInfo(projectInfoEntity, project.ProjectName);
            }
        }

        public static void DeleteProjectInfo(int pkid)
        {
            ProjectInfoDA.DeleteProjectInfo(pkid);
        }

        private static void Valid(ProjectInfoEntity projectInfoEntity)
        {
            if (ProjectInfoDA.GetExistsByNameDiffPKID(projectInfoEntity.ProjectName, projectInfoEntity.PKID))
            {
                throw new Exception("项目名称重复");
            }
            if (projectInfoEntity.ProjectName.Split(' ').Length > 1)
            {
                var code = projectInfoEntity.ProjectName.Split(' ')[0];
                if (code.Split('-').Length > 1)
                {
                    code = code.Split('-')[1];
                }
                if (ProjectInfoDA.GetExistsByCodeDiffPKID(code,
                                                          projectInfoEntity.PKID))
                {
                    throw new Exception("项目编号重复");
                }
            }
            else
            {
                throw new Exception("请填写项目编号");
            }
        }

        public static ProjectInfoEntity GetProjectInfoByPKID(int pkid)
        {
            return ProjectInfoDA.GetProjectInfoByPKID(pkid);
        }

        public static ProjectInfoEntity GetProjectInfoByName(string projectName)
        {
            return ProjectInfoDA.GetProjectInfoByName(projectName);
        }
        public static List<ProjectInfoEntity> GetProjectInfoByCondition(string name)
        {
            return ProjectInfoDA.GetProjectInfoByCondition(name);
        }

        public static ProjectInfoEntity GetProjectInfoByCode(string code)
        {
            return ProjectInfoDA.GetProjectInfoByCode(code);
        }
    }
}