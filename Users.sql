DROP TABLE IF EXISTS TutorialAppSchema.Users;

-- IF OBJECT_ID('TutorialAppSchema.Users') IS NOT NULL
--     DROP TABLE TutorialAppSchema.Users;

CREATE TABLE TutorialAppSchema.Users
(
    UserId INT IDENTITY(1, 1) PRIMARY KEY
    , FirstName NVARCHAR(50)
    , LastName NVARCHAR(50)
    , Email NVARCHAR(50) UNIQUE
    , Gender NVARCHAR(50)
    , Active BIT
);

DROP TABLE IF EXISTS TutorialAppSchema.UserSalary;

-- IF OBJECT_ID('TutorialAppSchema.UserSalary') IS NOT NULL
--     DROP TABLE TutorialAppSchema.UserSalary;

CREATE TABLE TutorialAppSchema.UserSalary
(
    UserId INT UNIQUE
    , Salary DECIMAL(18, 4)
);

DROP TABLE IF EXISTS TutorialAppSchema.UserJobInfo;

-- IF OBJECT_ID('TutorialAppSchema.UserJobInfo') IS NOT NULL
--     DROP TABLE TutorialAppSchema.UserJobInfo;

CREATE TABLE TutorialAppSchema.UserJobInfo
(
    UserId INT UNIQUE
    , JobTitle NVARCHAR(50)
    , Department NVARCHAR(50),
);

-- Declare variables for the loop
DECLARE @Counter INT = 1;
DECLARE @FirstName NVARCHAR(50);
DECLARE @LastName NVARCHAR(50);
DECLARE @Email NVARCHAR(50);
DECLARE @Gender NVARCHAR(50);
DECLARE @Active BIT;
DECLARE @Salary DECIMAL(18, 4);
DECLARE @JobTitle NVARCHAR(50);
DECLARE @Department NVARCHAR(50);

-- Seed mock data into Users, UserSalary, and UserJobInfo tables
WHILE @Counter <= 1000
BEGIN
    -- Generate fake user data
    SET @FirstName = 'FirstName' + CAST(@Counter AS NVARCHAR(50));
    SET @LastName = 'LastName' + CAST(@Counter AS NVARCHAR(50));
    SET @Email = 'user' + CAST(@Counter AS NVARCHAR(50)) + '@example.com';
    SET @Gender = CASE WHEN @Counter % 2 = 0 THEN 'Male' ELSE 'Female' END;
    SET @Active = CASE WHEN @Counter % 2 = 0 THEN 1 ELSE 0 END;
    
    -- Insert into Users table
    INSERT INTO TutorialAppSchema.Users (FirstName, LastName, Email, Gender, Active)
    VALUES (@FirstName, @LastName, @Email, @Gender, @Active);
    
    -- Insert corresponding data into UserSalary table
    SET @Salary = 30000.00 + (1000 * @Counter); -- Generate salary dynamically
    INSERT INTO TutorialAppSchema.UserSalary (UserId, Salary)
    VALUES (@Counter, @Salary);
    
    -- Insert corresponding data into UserJobInfo table
    SET @JobTitle = 'JobTitle' + CAST(@Counter AS NVARCHAR(50));
    SET @Department = 'Department' + CAST(@Counter AS NVARCHAR(50));
    INSERT INTO TutorialAppSchema.UserJobInfo (UserId, JobTitle, Department)
    VALUES (@Counter, @JobTitle, @Department);
    
    -- Increment the counter
    SET @Counter = @Counter + 1;
END;


-- USE DotNetCourseDatabase;
-- GO

-- SELECT  [UserId]
--         , [FirstName]
--         , [LastName]
--         , [Email]
--         , [Gender]
--         , [Active]
--   FROM  TutorialAppSchema.Users;

-- SELECT  [UserId]
--         , [Salary]
--   FROM  TutorialAppSchema.UserSalary;

-- SELECT  [UserId]
--         , [JobTitle]
--         , [Department]
--   FROM  TutorialAppSchema.UserJobInfo;
