
CREATE TABLE Students_INFO
(
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    Gender CHAR(1),
    Class NVARCHAR(50)
);


CREATE TABLE Courses_INFO
(
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    Credits INT,
    Department NVARCHAR(50)
);


CREATE TABLE Marks_INFO
(
    MarkId INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Score DECIMAL(5,2),
    ExamDate DATE,
    FOREIGN KEY (StudentId) REFERENCES Students_INFO(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Courses_INFO(CourseId)
);
