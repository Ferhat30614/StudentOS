using Microsoft.AspNetCore.Identity;

namespace StudentOS.Api.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = "";
    public string Role { get; set; } = "";
}

public class Student
{
    public int Id { get; set; }
    public string UserId { get; set; } = "";
    public AppUser? User { get; set; }
    public string Number { get; set; } = ""; // okul no
}

public class Teacher
{
    public int Id { get; set; }
    public string UserId { get; set; } = "";
    public AppUser? User { get; set; }
    public string Title { get; set; } = "";
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new();
}

public class Enrollment
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
}

public class Grade
{
    public int Id { get; set; }
    public int EnrollmentId { get; set; }
    public Enrollment? Enrollment { get; set; }
    public decimal Value { get; set; } // 0-100
}

public class Attendance
{
    public int Id { get; set; }
    public int EnrollmentId { get; set; }
    public Enrollment? Enrollment { get; set; }
    public DateTime Date { get; set; }
    public bool Present { get; set; }
}
