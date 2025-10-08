Use  [Temp_Developer]

-- =============================================
-- 5. Creacion ÍNDICES 
-- =============================================

-- Property
CREATE NONCLUSTERED INDEX IX_Property_Price ON Property(Price);
CREATE NONCLUSTERED INDEX IX_Property_IdOwner ON Property(IdOwner);
CREATE NONCLUSTERED INDEX IX_Property_Address ON Property(Address);

-- Owner
CREATE NONCLUSTERED INDEX IX_Owner_Name ON Owner(Name);

-- PropertyImage
CREATE NONCLUSTERED INDEX IX_PropertyImage_IdProperty_Enabled ON PropertyImage(IdProperty, Enabled);

-- PropertyTrace
CREATE NONCLUSTERED INDEX IX_PropertyTrace_IdProperty_DateSale ON PropertyTrace(IdProperty, DateSale);
CREATE NONCLUSTERED INDEX IX_PropertyTrace_DateSale ON PropertyTrace(DateSale);