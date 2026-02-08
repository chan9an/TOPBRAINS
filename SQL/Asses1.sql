-- ===============================
-- Question 1 – Normalization
-- ===============================

-- Problems with Sales_Raw table:
-- 1) Multiple products, quantities, and prices stored in a single column → violates 1NF.
-- 2) Customer data repeated for multiple orders → violates 2NF.
-- 3) SalesPerson data repeated → violates 2NF/3NF.

-- Normalized Tables Design (3NF):

-- 1) Customers Table
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);

-- 2) Products Table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL
);

-- 3) SalesPersons Table
CREATE TABLE SalesPersons (
    SalesPersonID INT IDENTITY(1,1) PRIMARY KEY,
    SalesPersonName VARCHAR(100) NOT NULL
);

-- 4) Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    SalesPersonID INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SalesPersonID) REFERENCES SalesPersons(SalesPersonID)
);

-- 5) OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- ===============================
-- Question 2 – Third Highest Total Sales
-- ===============================

-- Assuming Orders and OrderDetails populated
SELECT DISTINCT TotalOrderAmount
FROM (
    SELECT o.OrderID,
           SUM(od.Quantity * od.UnitPrice) AS TotalOrderAmount,
           DENSE_RANK() OVER (ORDER BY SUM(od.Quantity * od.UnitPrice) DESC) AS rnk
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY o.OrderID
) t
WHERE rnk = 3;

-- ===============================
-- Question 3 – Salespersons with Total Sales > 60,000
-- ===============================

SELECT sp.SalesPersonName, SUM(od.Quantity * od.UnitPrice) AS TotalSales
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN SalesPersons sp ON o.SalesPersonID = sp.SalesPersonID
GROUP BY sp.SalesPersonName
HAVING SUM(od.Quantity * od.UnitPrice) > 60000;

-- ===============================
-- Question 4 – Customers spending more than average
-- ===============================

SELECT CustomerName, TotalSpent
FROM (
    SELECT c.CustomerName,
           SUM(od.Quantity * od.UnitPrice) AS TotalSpent
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY c.CustomerName
) t
WHERE TotalSpent > (SELECT AVG(TotalSpent) 
                    FROM (
                        SELECT SUM(od.Quantity * od.UnitPrice) AS TotalSpent
                        FROM Orders o
                        JOIN OrderDetails od ON o.OrderID = od.OrderID
                        GROUP BY o.CustomerID
                    ) sub);

-- ===============================
-- Question 5 – String & Date Functions
-- ===============================

SELECT 
    UPPER(c.CustomerName) AS CustomerName,
    MONTH(o.OrderDate) AS OrderMonth,
    o.OrderDate
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE YEAR(o.OrderDate) = 2026 AND MONTH(o.OrderDate) = 1;
