alter table dbo.TTrainApplication add EduSpuCost Decimal(25,2)  NULL

--begin            �쳣��Ϣ        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSystemError' AND type = 'U')
	DROP TABLE TSystemError	
GO
--end            �쳣��Ϣ        -------------

--begin �쳣��Ϣ----------
CREATE TABLE	TSystemError	(
PKID	         INT	IDENTITY   NOT NULL,
ErrorType	     INT	           NOT NULL,  --���� 1�Ž�����,2�Ű����,3������̣�4�����������,5�Ӱ���������,6��Ч��������,7���¸�����,8��������,9��ѵ��������
MarkID           INT	           NOT NULL,  --��ʶID
 CONSTRAINT PK_TSystemError PRIMARY KEY NONCLUSTERED (PKID),
 CONSTRAINT TC_TSystemError UNIQUE NONCLUSTERED (PKID)
)
GO
--end �쳣��Ϣ----------