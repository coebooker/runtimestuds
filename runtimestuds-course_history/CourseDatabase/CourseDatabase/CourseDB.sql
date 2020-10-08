CREATE TABLE [dbo].[CourseDB]
(
	[name] TEXT NOT NULL PRIMARY KEY, 
    [title] TEXT NOT NULL, 
    [instructor] TEXT NOT NULL, 
    [credit] TEXT NOT NULL, 
    [seats] TEXT NOT NULL, 
    [num_time] INT NOT NULL, 
    [time_blocks] TEXT NOT NULL
)
