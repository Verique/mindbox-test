-- I assume tables are created like this:

-- CREATE TABLE Products (
--   Id INT PRIMARY KEY, "Name" TEXT NOT NULL
-- );
-- CREATE TABLE Categories (
--   Id INT PRIMARY KEY, "Name" TEXT NOT NULL
-- );
-- CREATE TABLE ProductCategories (
--   ProductId INT FOREIGN KEY REFERENCES Products(Id), 
--   CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
--   PRIMARY KEY (ProductId, CategoryId)
-- );

SELECT 
  Products."Name" as ProductName, 
  Categories."Name" as CategoryName 
FROM 
  Products 
  LEFT JOIN ProductCategories ON Products.Id = ProductCategories.ProductId 
  LEFT JOIN Categories ON ProductCategories.CategoryId = Categories.Id