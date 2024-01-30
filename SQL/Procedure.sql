--Table Creation:
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Salary DECIMAL(10, 2)
);

--Insert Procedure:
CREATE PROCEDURE InsertEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Salary DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, Salary)
    VALUES (@FirstName, @LastName, @Salary);
END;

--Select Procedure:
CREATE PROCEDURE GetEmployee
    @EmployeeID INT
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;

--Update Procedure:
CREATE PROCEDURE UpdateEmployee
    @EmployeeID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Salary DECIMAL(10, 2)
AS
BEGIN
    UPDATE Employees
    SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary
    WHERE EmployeeID = @EmployeeID;
END;

--Delete Procedure:
CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employees
    WHERE EmployeeID = @EmployeeID;
END;


--To use these stored procedures:
--Insert:
EXEC InsertEmployee @FirstName = 'John', @LastName = 'Doe', @Salary = 50000.00;
--Select:
EXEC GetEmployee @EmployeeID = 1;
--Update:
EXEC UpdateEmployee @EmployeeID = 1, @FirstName = 'UpdatedFirstName', @LastName = 'UpdatedLastName', @Salary = 60000.00;
--Delete:
EXEC DeleteEmployee @EmployeeID = 1;


