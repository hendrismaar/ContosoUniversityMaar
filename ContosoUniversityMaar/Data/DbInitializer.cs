using ContosoUniversityMaar.Models;

namespace ContosoUniversityMaar.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstMidName="Kaarel-Martin", LastName="Noole",EnrollmentDate=DateTime.Parse("2019-02-11") },
                new Student { FirstMidName="brain-eating", LastName="amoeba",EnrollmentDate=DateTime.Now },
                new Student { FirstMidName="ddddddddddddd", LastName="d213124",EnrollmentDate=DateTime.Now },
                new Student { FirstMidName="Fred", LastName="Durst",EnrollmentDate=DateTime.Now },
                new Student { FirstMidName="LIMP BIZKUT", LastName="FOREVER!!!!!!!!!",EnrollmentDate=DateTime.Now }
            };

            // context.Students.AddRange(students);
            foreach (Student s in students ) 
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
{
                new Instructor {FirstMidName = "evil", LastName = "gang", HireDate = DateTime.Parse("1995-03-11")},
                new Instructor {FirstMidName = "Dalai", LastName = "Lama", HireDate = DateTime.Parse("1995-03-11")},
                new Instructor {FirstMidName = "jeff jeffff jefe jefjeff jeff", LastName = "my nama jeff", HireDate = DateTime.Parse("1995-03-11")},
                new Instructor {FirstMidName = "LOL!!!!!!", LastName = "bruger ham sandwich", HireDate = DateTime.Parse("1995-03-11")},
};
            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department
                {
                    Name = "Infotechnology",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "gang").ID
                },
                new Department
                {
                    Name = "How to become Jeff",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "my nama jeff").ID
                },
                new Department
                {
                    Name = "Sucking the tongues of 10 year old Indian kids",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "Lama").ID
                },
                new Department
                {
                    Name = "i have brain damage my head hurts",
                    Budget = 0,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID = instructors.Single(i => i.LastName == "bruger ham sandwich").ID
                },
            };
            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course() { CourseId = 1050, Title = "Programmeerimine", Credits = 160 },
                new Course() { CourseId = 2921, Title = "Keemia", Credits = 160 },
                new Course() { CourseId = 6323, Title = "Matemaatika", Credits = 160 },
                new Course() { CourseId = 2405, Title = "Usuõppe", Credits = 160 },
                new Course() { CourseId = 1738, Title = "Riigikaitse", Credits = 160 }
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
{
                            new OfficeAssignment()
                            {
                                InstructorID = instructors.Single(i => i.LastName == "Lama").ID,
                                Location = "Tibetian mountain range",
                            },
                            new OfficeAssignment()
                            {
                                InstructorID = instructors.Single(i => i.LastName == "bruger ham sandwich").ID,
                                Location = "mouth oompf",
                            },
                            new OfficeAssignment()
                            {
                                InstructorID = instructors.Single(i => i.LastName == "gang").ID,
                                Location = "Evil gang lair",
                            }
};
            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Keemia").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "gang").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Riigikaitse").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "gang").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Matemaatika").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "gang").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Keemia").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "Lama").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Programmeerimine").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "Lama").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Matemaatika").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "bruger ham sandwich").ID
                            },
                            new CourseAssignment
                            {
                                CourseID = courses.Single(c => c.Title == "Riigikaitse").CourseId,
                                InstructorID = instructors.Single(i => i.LastName == "bruger ham sandwich").ID
                            },
            };
            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment() { StudentId = 1, CourseId = 1050, Grade = Grade.A },
                new Enrollment() { StudentId = 1, CourseId = 6323, Grade = Grade.D },
                new Enrollment() { StudentId = 1, CourseId = 2405, Grade = Grade.C },
                new Enrollment() { StudentId = 1, CourseId = 1738, Grade = Grade.A },

                new Enrollment() { StudentId = 2, CourseId = 1050, Grade = Grade.F },
                new Enrollment() { StudentId = 2, CourseId = 2921, Grade = Grade.D },
                new Enrollment() { StudentId = 2, CourseId = 6323, Grade = Grade.F },
                new Enrollment() { StudentId = 2, CourseId = 2405, Grade = Grade.F },
                new Enrollment() { StudentId = 2, CourseId = 1738, Grade = Grade.A },

                new Enrollment() { StudentId = 3, CourseId = 1050, Grade = Grade.C },
                new Enrollment() { StudentId = 3, CourseId = 2405, Grade = Grade.F },
                new Enrollment() { StudentId = 3, CourseId = 1738, Grade = Grade.D },

                new Enrollment() { StudentId = 4, CourseId = 1050, Grade = Grade.F },
                new Enrollment() { StudentId = 4, CourseId = 2921, Grade = Grade.F },
                new Enrollment() { StudentId = 4, CourseId = 6323, Grade = Grade.F },
                new Enrollment() { StudentId = 4, CourseId = 2405, Grade = Grade.C },
                new Enrollment() { StudentId = 4, CourseId = 1738, Grade = Grade.F },

                new Enrollment() { StudentId = 5, CourseId = 1050, Grade = Grade.C },
                new Enrollment() { StudentId = 5, CourseId = 2921, Grade = Grade.D },
                new Enrollment() { StudentId = 5, CourseId = 6323, Grade = Grade.A },
                new Enrollment() { StudentId = 5, CourseId = 2405, Grade = Grade.B },
                new Enrollment() { StudentId = 5, CourseId = 1738, Grade = Grade.A }
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
