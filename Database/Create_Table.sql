Use PortafolioST

-- =============================================
-- 1. TABLA: Owner
-- =============================================
CREATE TABLE dbo.Owner (
    IdOwner INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Photo NVARCHAR(MAX),
    Birthday DATE
);

-- =============================================
-- 2. TABLA: Property
-- =============================================
CREATE TABLE dbo.Property (
    IdProperty INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Price DECIMAL(18,2) NOT NULL,
    CodeInternal NVARCHAR(50) UNIQUE NOT NULL,
    Year INT,
    IdOwner INT NOT NULL,
    CONSTRAINT FK_Property_Owner FOREIGN KEY (IdOwner) REFERENCES Owner(IdOwner)
);

-- =============================================
-- 3. TABLA: PropertyImage
-- =============================================
CREATE TABLE dbo.PropertyImage (
    IdPropertyImage INT PRIMARY KEY IDENTITY(1,1),
    IdProperty INT NOT NULL,
    [File] NVARCHAR(MAX),
    Enabled BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_PropertyImage_Property FOREIGN KEY (IdProperty) REFERENCES Property(IdProperty)
);

-- =============================================
-- 4. TABLA: PropertyTrace (historial de ventas)
-- =============================================
CREATE TABLE dbo.PropertyTrace (
    IdPropertyTrace INT PRIMARY KEY IDENTITY(1,1),
    DateSale DATE NOT NULL,
    Name NVARCHAR(100),
    Value DECIMAL(18,2) NOT NULL,
    Tax DECIMAL(18,2),
    IdProperty INT NOT NULL,
    CONSTRAINT FK_PropertyTrace_Property FOREIGN KEY (IdProperty) REFERENCES Property(IdProperty)
);



-- =============================================
-- 6. DATOS DE PRUEBA
-- =============================================


INSERT INTO Owner (Name, Address, Photo, Birthday)
VALUES 
('John Doe', '123 Main St, New York, NY', NULL, '1980-05-12'),
('Jane Smith', '456 Oak Ave, Los Angeles, CA', NULL, '1975-09-30');


INSERT INTO Property (Name, Address, Price, CodeInternal, Year, IdOwner)
VALUES 
('Luxury Apartment', '123 Main St, New York, NY', 350000, 'APT-NY-001', 2010, 1),
('Beach House', '789 Ocean Dr, Miami, FL', 950000, 'BH-FL-002', 2015, 2);


INSERT INTO PropertyImage (IdProperty, [File], Enabled)
VALUES 
(2, 'https://example.com/images/property1-main.jpg', 1),
(2, 'https://example.com/images/property1-back.jpg', 1),
(3, 'https://example.com/images/property2-front.jpg', 1);

INSERT INTO PropertyTrace (DateSale, Name, Value, Tax, IdProperty)
VALUES 
('2020-03-15', 'Sale to Investor Group', 340000, 5000, 2),
('2022-07-20', 'Private Sale', 940000, 12000, 3);

