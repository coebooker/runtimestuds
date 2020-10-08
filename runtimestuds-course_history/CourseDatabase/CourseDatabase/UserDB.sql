CREATE TABLE [dbo].[UserDB]
(
	[username] TEXT NOT NULL PRIMARY KEY, 
    [type] TEXT NOT NULL, 
    [password] TEXT NOT NULL, 
    [fname] TEXT NOT NULL, 
    [mname] TEXT NOT NULL, 
    [lname] TEXT NOT NULL, 
    [currentSchedule] TEXT NULL, 
    [registeredCourse] TEXT NULL, 
    [advisor] TEXT NULL
)
