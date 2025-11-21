CREATE DATABASE StoreDB;
GO

USE StoreDB;
GO

--INT IDENTITY(1,1)
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    Sku NVARCHAR(50) UNIQUE NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT CHECK (Quantity > 0) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    OrderDate DATETIME2 DEFAULT SYSUTCDATETIME(),
    Status NVARCHAR(32) NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE INDEX IX_Orders_OrderDate
ON Orders (OrderDate);
