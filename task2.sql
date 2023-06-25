-- NOTE: this is for MSSQL SERVER (T-SQL) dialect

-- Создание таблицы Products
CREATE TABLE Products (
  ProductId INT PRIMARY KEY,
  Name VARCHAR(100)
);

-- Создание таблицы Categories
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    Name VARCHAR(100)
);

-- Создание таблицы ProductCategories
CREATE TABLE ProductCategories (
   ProductId INT,
   CategoryId INT,
   PRIMARY KEY (ProductId, CategoryId),
   FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
   FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- Вставка данных в таблицу Products
INSERT INTO Products (ProductId, Name)
VALUES
    (1, 'Product 1'),
    (2, 'Product 2'),
    (3, 'Product 3'),
    (4, 'Product 4'),
    (5, 'Product 5');

-- Вставка данных в таблицу Categories
INSERT INTO Categories (CategoryId, Name)
VALUES
    (1, 'Category 1'),
    (2, 'Category 2'),
    (3, 'Category 3');

-- Вставка данных в таблицу ProductCategories
INSERT INTO ProductCategories (ProductId, CategoryId)
VALUES
    (1, 1),
    (1, 2),
    (2, 2),
    (3, 3);

--Выборка данных 
SELECT p.Name AS ProductName, COALESCE(c.Name, 'Without Category') AS CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.ProductId = pc.ProductId
LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId
