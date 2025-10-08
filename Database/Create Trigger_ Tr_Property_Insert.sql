USE [PortafolioST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	TRIGGER iNSERT Tabla dbo.Property
-- =============================================
Create TRIGGER [dbo].[Tr_Property_Insert]
   ON  [dbo].[Property]
  FOR  insert  
	NOT FOR REPLICATION 
AS 
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRY
		DECLARE @program_name varchar(255)
		SELECT @program_name = program_name FROM MASTER..sysprocesses
		WHERE spid = @@spid 	
		
			
	    INSERT INTO dbo.Property_Audit
           (	IdProperty ,
				Name ,
				Address ,
				Price ,
				CodeInternal ,
				Year ,
				IdOwner ,
				UserName ,
				ITAudMachine ,
				ITAudApp  ,		
				ActionDate ,
				ActionType 
				)
        SELECT 
				IdProperty ,
				Name ,
				Address ,
				Price ,
				CodeInternal ,
				Year ,
				IdOwner ,
				SUSER_NAME(),
				HOST_NAME(),
				@program_name,
				GETDATE(),
				'INS'           
        FROM inserted
		
	END TRY 
	BEGIN CATCH 

	  RAISERROR('[dbo].[Tr_Property_Insert]', 16, 1 ) WITH LOG
	
	END CATCH

    

END