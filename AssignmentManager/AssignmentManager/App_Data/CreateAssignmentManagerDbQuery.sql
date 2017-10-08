CREATE DATABASE [AssignmentManager]

GO
USE [AssignmentManager]

CREATE TABLE [Assignments]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
	[IsDone] BIT NOT NULL
)

CREATE TABLE [Comments]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[AssignementId] int NOT NULL FOREIGN KEY REFERENCES [Assignments] ([Id]),
	[Content] VARCHAR(20) NOT NULL	
)

GO
INSERT INTO Assignments ([Title], [Description], [IsDone])
VALUES ('First Task', 'Created first', 0)

INSERT INTO Assignments ([Title], [Description], [IsDone])
VALUES ('Second Task', 'You cant always be first', 1)

INSERT INTO Comments ([AssignementId], [Content])
VALUES (1, 'We had to have some content')

INSERT INTO Comments ([AssignementId], [Content])
VALUES (2, 'This is just to fill up space')

INSERT INTO Comments ([AssignementId], [Content])
VALUES (2, 'Im repeating myself now')