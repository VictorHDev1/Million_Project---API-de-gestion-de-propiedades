Use PortafolioST




CREATE TABLE dbo.Owner_Audit (
    IdOwner INT ,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Photo NVARCHAR(MAX),
    Birthday DATE,
	UserName NVARCHAR(100) ,
	ITAudMachine VARCHAR (100),
	ITAudApp  VARCHAR (100),		
	ActionDate DATETIME,
	ActionType NVARCHAR(10)	
);



CREATE TABLE dbo.Property_Audit (
    IdProperty INT ,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Price DECIMAL(18,2) NOT NULL,
    CodeInternal NVARCHAR(50) UNIQUE NOT NULL,
    Year INT,
    IdOwner INT NOT NULL,
	UserName NVARCHAR(100) ,
	ITAudMachine VARCHAR (100),
	ITAudApp  VARCHAR (100),		
	ActionDate DATETIME,
	ActionType NVARCHAR(10)	
);


CREATE TABLE dbo.PropertyImage_Audit (
    IdPropertyImage INT ,
    IdProperty INT NOT NULL,
    [File] NVARCHAR(MAX),
    Enabled BIT NOT NULL DEFAULT 1,  
	UserName NVARCHAR(100) ,
	ITAudMachine VARCHAR (100),
	ITAudApp  VARCHAR (100),		
	ActionDate DATETIME,
	ActionType NVARCHAR(10)	
);


CREATE TABLE dbo.PropertyTrace_Audit (
    IdPropertyTrace INT ,
    DateSale DATE NOT NULL,
    Name NVARCHAR(100),
    Value DECIMAL(18,2) NOT NULL,
    Tax DECIMAL(18,2),
    IdProperty INT NOT NULL,  
	UserName NVARCHAR(100) ,
	ITAudMachine VARCHAR (100),
	ITAudApp  VARCHAR (100),		
	ActionDate DATETIME,
	ActionType NVARCHAR(10)	
);

