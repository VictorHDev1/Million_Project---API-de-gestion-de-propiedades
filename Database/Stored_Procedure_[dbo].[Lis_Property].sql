USE Temp_Developer
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************************************* 
	NOMBRE          :   List  Property 
	FUNCION         : 	List informacion Property
	APLICACION      :   ApiMillion
	REALIZADO       :   Victor Leaño 	
	VERSION         :   1.0.0  
**************************************************************************************
Caso de uso : 
Exec [dbo].[Lis_Property] 3,null,null
Exec [dbo].[Lis_Property] NULL,'250000','500000'
Exec [dbo].[Lis_Property] 1,'250000','500000'
**************************************************************************************/
cREATE  PROCEDURE [dbo].[Lis_Property]
@IdProperty int,
@MinPrice decimal (18,2),
@MaxPrice decimal (18,2)
AS BEGIN
	SET NOCOUNT ON;
	

If(@IdProperty is not null And @MinPrice is null And @MaxPrice is null)
	Begin 

			SELECT	
			 pro.[Name]
			,pro.[Address]
			,[Price]
			,[CodeInternal]
			,ow.[Name]
			,ow.[Address]
			,[Birthday]
			,[File]
			,[DateSale]
			,tr.[Name]
			,[Value]
			 [Tax]


			fROM	dbo.Property  PRO
			inner	Join dbo.Owner  ow
			on		pro.IdOwner = ow.IdOwner
			Inner	Join dbo.PropertyImage  img
			On		img.IdProperty = pro.IdProperty
			Left	Join dbo.PropertyTrace tr
			ON		tr.IdProperty =pro.IdProperty
			where  pro.IdProperty = @IdProperty
	End
	else If(@IdProperty is  null And @MinPrice is nOT null And @MaxPrice is nOT null)
	Begin 

			SELECT	
			 pro.[Name]
			,pro.[Address]
			,[Price]
			,[CodeInternal]
			,ow.[Name]
			,ow.[Address]
			,[Birthday]
			,[File]
			,[DateSale]
			,tr.[Name]
			,[Value]
			 [Tax]


			fROM	dbo.Property  PRO
			inner	Join dbo.Owner  ow
			on		pro.IdOwner = ow.IdOwner
			Inner	Join dbo.PropertyImage  img
			On		img.IdProperty = pro.IdProperty
			Left	Join dbo.PropertyTrace tr
			ON		tr.IdProperty =pro.IdProperty
			where  PRO.Price Between @MinPrice And @MaxPrice 

	End
	eLSE If(@IdProperty is not null And @MinPrice is NOT null And @MaxPrice is NOT null)
	Begin 

			SELECT	
			 pro.[Name]
			,pro.[Address]
			,[Price]
			,[CodeInternal]
			,ow.[Name]
			,ow.[Address]
			,[Birthday]
			,[File]
			,[DateSale]
			,tr.[Name]
			,[Value]
			 [Tax]


			fROM	dbo.Property  PRO
			inner	Join dbo.Owner  ow
			on		pro.IdOwner = ow.IdOwner
			Inner	Join dbo.PropertyImage  img
			On		img.IdProperty = pro.IdProperty
			Left	Join dbo.PropertyTrace tr
			ON		tr.IdProperty =pro.IdProperty
			where  pro.IdProperty = @IdProperty
			And PRO.Price Between @MinPrice And @MaxPrice 
	End
	
	
	

END


