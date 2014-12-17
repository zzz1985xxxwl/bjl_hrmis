CREATE TABLE TTrackCurveTemplate (
	ID						UNIQUEIDENTIFIER	NOT NULL,
	Title				    NVARCHAR(50)		NOT NULL,
	SecondTouchDays			INT		            NOT NULL,
	ThirdTouchDays			INT					NOT NULL,
	FourthTouchDays			INT			        NOT NULL,
	FifthTouchDays			INT		            NOT NULL,
	LoopDays				INT		            NOT NULL,
	UpToDays				INT	                NOT NULL,
	RelatedAccountID		INT					NOT NULL,
	TimeStamper				DATETIME			NOT NULL			

    CONSTRAINT PK_TTrackCurveTemplate PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TTrackCurveTemplate UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TRemind (
    ID					    UNIQUEIDENTIFIER	NOT NULL,
    [Content]               NVARCHAR(255)       NOT NULL,
    RemindTime				DATETIME 		    NOT NULL,
	CalendarEventId			UNIQUEIDENTIFIER	NULL,
	ReadStatusId			INT					NOT NULL,
	RelatedAccountId		INT			        NOT NULL,
	TimeStamper				DATETIME			NOT NULL	

    CONSTRAINT PK_TRemind PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TRemind UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TCalendarEvent (
    ID							UNIQUEIDENTIFIER	NOT NULL,
    Title						NVARCHAR(200)       NOT NULL,
	StartDateTime				DATETIME			NOT NULL,
    [Content]					NVARCHAR(2000) 		NOT NULL,
	ImportantDegreeId			INT					NOT NULL,
	EventStatusId				INT					NOT NULL,
	RelatedAccountId			INT					NOT NULL,
	Reason						NVARCHAR(200)		NULL,
	GiveUpTime					DATETIME			NULL,
	CompleteTime				DATETIME			NULL,
	CustomerId					UNIQUEIDENTIFIER    NULL,
	RelatedCustomerTrackCurveId	UNIQUEIDENTIFIER	NULL,
	TimeStamper					DATETIME			NOT NULL	

    CONSTRAINT PK_TCalendarEvent PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TCalendarEvent UNIQUE NONCLUSTERED (ID)
)
GO

CREATE TABLE TCustomerTrackCurve (
		ID						UNIQUEIDENTIFIER	NOT NULL,
        CustomerId				UNIQUEIDENTIFIER	NOT NULL,
		Title				    NVARCHAR(50)		NOT NULL,			
		TimeStamper				DATETIME			NOT NULL
	
    CONSTRAINT PK_TCustomerTrackCurveTemplate PRIMARY KEY NONCLUSTERED (CustomerId),
    CONSTRAINT TC_TCustomerTrackCurveTemplate UNIQUE NONCLUSTERED (CustomerId)
) 
GO
