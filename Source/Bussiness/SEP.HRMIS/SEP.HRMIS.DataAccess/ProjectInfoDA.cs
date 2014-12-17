using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class ProjectInfoDA
    {
        public static void InsertProjectInfo(ProjectInfoEntity projectInfoEntity)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
INSERT INTO [dbo].[TProjectInfo](
	[ProjectName]
	) VALUES(
	@ProjectName)
    SELECT @@IDENTITY
";
                dataOperator.SetParameter("@ProjectName", projectInfoEntity.ProjectName, SqlDbType.NVarChar, 200);
                object obj = dataOperator.ExecuteScalar();
                int returnValue;
                int.TryParse(obj.ToString(), out returnValue);
                projectInfoEntity.PKID = returnValue;
            }
        }

        public static void UpdateProjectInfo(ProjectInfoEntity projectInfoEntity,string oldProjectName)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
UPDATE [dbo].[TProjectInfo] SET
	[ProjectName]=@ProjectName
WHERE
	[PKID]=@PKID

UPDATE [dbo].TReimburse set Project=@ProjectName where Project=@OldProjectName
";

                dataOperator.SetParameter("@PKID", projectInfoEntity.PKID, SqlDbType.Int);
                dataOperator.SetParameter("@ProjectName", projectInfoEntity.ProjectName, SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@OldProjectName", oldProjectName, SqlDbType.NVarChar, 200);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static void DeleteProjectInfo(int pkid)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"Delete from  [dbo].[TProjectInfo] WHERE [PKID]=@PKID";
                dataOperator.SetParameter("@PKID", pkid, SqlDbType.Int);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static ProjectInfoEntity GetProjectInfoByPKID(int pKID)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	[PKID],
	[ProjectName]
FROM [dbo].[TProjectInfo] WITH(NOLOCK)
WHERE
	[PKID]=@PKID
";

                dataOperator.SetParameter("@PKID", pKID, SqlDbType.Int);

                ProjectInfoEntity projectInfoEntity = dataOperator.ExecuteEntity<ProjectInfoEntity>();

                return projectInfoEntity;
            }
        }

        public static ProjectInfoEntity GetProjectInfoByName(string name)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	[PKID],
	[ProjectName]
FROM [dbo].[TProjectInfo] WITH(NOLOCK)
WHERE
	[ProjectName]=@ProjectName
";

                dataOperator.SetParameter("@ProjectName", name, SqlDbType.NVarChar, 200);
                ProjectInfoEntity projectInfoEntity = dataOperator.ExecuteEntity<ProjectInfoEntity>();

                return projectInfoEntity;
            }
        }


        public static List<ProjectInfoEntity> GetProjectInfoByCondition(string name)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	[PKID],
	[ProjectName]
FROM [dbo].[TProjectInfo] WITH(NOLOCK)
WHERE
	1=1 
";
                if (!string.IsNullOrEmpty(name))
                {
                    dataOperator.CommandText += " and ProjectName like @ProjectName";
                    dataOperator.SetParameter("@ProjectName", "%" + name + "%", SqlDbType.NVarChar, 200);
                }
                return dataOperator.ExecuteEntityList<ProjectInfoEntity>();
            }
        }

        public static ProjectInfoEntity GetProjectInfoByCode(string code)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"select * from [dbo].[TProjectInfo] with(nolock) where  [ProjectName] like @Code";

                dataOperator.SetParameter("@Code", "%-" + code + " %", SqlDbType.NVarChar, 200);
                return dataOperator.ExecuteEntity<ProjectInfoEntity>();
            }
        }

        public static bool GetExistsByNameDiffPKID(string name, int pkid)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
IF EXISTS(select * from [dbo].[TProjectInfo] with(nolock) where  [ProjectName]=@ProjectName and PKID<>@PKID)
        begin
            select 1  
        end
        else
			select 0    
";

                dataOperator.SetParameter("@ProjectName", name, SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@PKID", pkid, SqlDbType.Int);
                var ans = Convert.ToInt32(dataOperator.ExecuteScalar());
                return ans > 0;
            }
        }

        public static bool GetExistsByCodeDiffPKID(string code, int pkid)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
IF EXISTS(select * from [dbo].[TProjectInfo] with(nolock) where  [ProjectName] like @Code and PKID<>@PKID)
        begin
            select 1  
        end
        else
			select 0    
";

                dataOperator.SetParameter("@Code", "%-" + code + " %", SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@PKID", pkid, SqlDbType.Int);
                var ans = Convert.ToInt32(dataOperator.ExecuteScalar());
                return ans > 0;
            }
        }
    }
}