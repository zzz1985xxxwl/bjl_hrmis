Delete from TCardType
Delete from TCardPropertyPara
Delete from TCardPropertyEnumValue
Delete from TCardField

--属性参数
SET IDENTITY_INSERT TCardPropertyPara ON
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	1	,'录入人','',	0	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	2	,'需求调研人','',	0	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	3	,'调研时间','',	2	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	4	,'调研对象','',	0	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	5	,'调研地点','',	0	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	6	,'优先级','',	5	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	7	,'所处阶段','',	5	)
INSERT INTO [TCardPropertyPara](pkid,[Name],[Description],[EnumCardPropertyDataType])
VALUES(	8	,'需求类型','',	5	)

SET IDENTITY_INSERT TCardPropertyPara OFF

--卡片属性库中的属性，如果类型为“枚举”（EnumCardPropertyDataType.Enum），这个是枚举数值
--1--3是需求类型的参数，4--9是所处阶段的参数，10-14是优先级的参数
SET IDENTITY_INSERT TCardPropertyEnumValue ON
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	1	,'业务逻辑需求',	1	,'#000033',	8	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	2	,'用户界面需求',	2	,'#007534',	8	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	3	,'其它需求',	3	,'#015035',	8	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	4	,'需求调研阶段',	1	,'#022536',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	5	,'需求分析阶段',	2	,'#030037',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	6	,'设计阶段',	3	,'#037538',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	7	,'编码阶段',	4	,'#045039',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	8	,'测试阶段',	5	,'#052540',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	9	,'发布阶段',	6	,'#060041',	7	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	10	,'1',	1	,'#067542',	6	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	11	,'2',	2	,'#075043',	6	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	12	,'3',	3	,'#082544',	6	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	13	,'4',	4	,'#090045',	6	)
INSERT INTO TCardPropertyEnumValue(pkid,[Name],[Order],[Color],[CardPropertyParaID])
VALUES(	14	,'5',	5	,'#097546',	6	)

SET IDENTITY_INSERT TCardPropertyEnumValue OFF

--卡片类型
SET IDENTITY_INSERT TCardType ON
INSERT INTO TCardType(pkid,[Name],Color,Description)
VALUES	(1, '项目卡片', '#000033', '')
INSERT INTO TCardType(pkid,[Name],Color,Description)
VALUES	(2, '过程卡片', '#003366', '')
INSERT INTO TCardType(pkid,[Name],Color,Description)
VALUES	(3, '用户故事卡片', '#006699', '')
SET IDENTITY_INSERT TCardType OFF


--卡片类型属性
SET IDENTITY_INSERT TCardField ON
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	1	,	1	,	3	,'',	1	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	2	,	2	,	3	,'',	2	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	3	,	3	,	3	,'',	3	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	4	,	4	,	3	,'',	4	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	5	,	5	,	3	,'',	5	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	6	,	6	,	3	,'',	6	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	7	,	7	,	3	,'',	7	)
INSERT INTO [TCardField](pkid,[CardPropertyParaID],[CardTypeID],[FieldFormula],[Order])
VALUES(	8	,	8	,	3	,'',	8	)
SET IDENTITY_INSERT TCardField OFF

SET IDENTITY_INSERT TKey ON
INSERT INTO [TKey]([PKID],[TableName],[RowID])						
VALUES(	1,'TCardPropertyPara',1	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])	
VALUES(	2,'TCardPropertyPara',2	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	3,'TCardPropertyPara',3	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	4,'TCardPropertyPara',4	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	5,'TCardPropertyPara',5	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	6,'TCardPropertyPara',6	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	7,'TCardPropertyPara',7	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	8,'TCardPropertyPara',8	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	9,'TCardPropertyEnumValue',1	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	10,'TCardPropertyEnumValue',2	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	11,'TCardPropertyEnumValue',3	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	12,'TCardPropertyEnumValue',4	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	13,'TCardPropertyEnumValue',5	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	14,'TCardPropertyEnumValue',6	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	15,'TCardPropertyEnumValue',7	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	16,'TCardPropertyEnumValue',8	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	17,'TCardPropertyEnumValue',9	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	18,'TCardPropertyEnumValue',10	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	19,'TCardPropertyEnumValue',11	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	20,'TCardPropertyEnumValue',12	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	21,'TCardPropertyEnumValue',13	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	22,'TCardPropertyEnumValue',14	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	23,'TCardType',1	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	24,'TCardType',2	)
INSERT INTO [TKey]([PKID],[TableName],[RowID])
VALUES(	25,'TCardType',3	)


SET IDENTITY_INSERT TKey OFF


