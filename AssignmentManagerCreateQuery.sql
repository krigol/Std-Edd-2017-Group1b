CREATE DATABASE [AssignmentManager]

GO
USE [AssignmentManager]

CREATE TABLE [Assignments]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NULL,
	[IsDone] BIT NOT NULL
)

CREATE TABLE [Comments]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[AssignmentId] int NOT NULL FOREIGN KEY REFERENCES [Assignments] ([Id]) ON DELETE CASCADE,
	[Content] VARCHAR(100) NOT NULL	
)

GO
INSERT INTO Assignments  ([Title], [Description], [IsDone])
VALUES ('Study for university', 'I have exams I need to pass. Study is a must!', 0)

INSERT INTO Assignments  ([Title], [Description], [IsDone])
VALUES ('Check Facebook', 'There are new cat gifs I need to see', 1)

INSERT INTO Comments ([AssignmentId], [Content])
VALUES (1, 'I will just do it later')

INSERT INTO Comments ([AssignmentId], [Content])
VALUES (2, 'This cat is soooo fluffy')

INSERT INTO Comments ([AssignmentId], [Content])
VALUES (2, 'Next time I need to check hamsters!')
