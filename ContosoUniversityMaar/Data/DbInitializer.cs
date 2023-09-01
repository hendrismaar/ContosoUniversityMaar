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
