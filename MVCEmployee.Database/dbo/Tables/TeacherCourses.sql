CREATE TABLE [dbo].[TeacherCourses] (
    [TeacherId] INT NOT NULL,
    [CourseId]  INT NOT NULL,
    CONSTRAINT [PK_TeacherCourse] PRIMARY KEY CLUSTERED ([TeacherId] ASC, [CourseId] ASC),
    CONSTRAINT [FK_TeacherCourse_Course] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([CourseId]),
    CONSTRAINT [FK_TeacherCourse_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teachers] ([TeacherId])
);

