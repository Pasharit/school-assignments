namespace DefaultNamespace;

public class zadacha_20
{
    
    var task01 = numbers.Select(n => n * n);

        foreach (var n in task01)
    {
        Console.WriteLine(n);
    }

}

var task02 = students.Select(s => new
{
    s.Name,
    s.City
});

foreach (var s in task02)
{
    Console.WriteLine($"{s.Name} / {s.City}");
}



var task03 = numbers.Where(n => n % 2 == 0);

foreach (var n in task03)
{
    Console.WriteLine(n);
}


var task04 = students.Where(s =>
    s.City == "Burgas" && s.Age >= 18);

foreach (var s in task04)
{
    Console.WriteLine(s);
}


var task05 = students
    .Where(s => s.Age >= 18)
    .Select(s => s.Name);

foreach (var name in task05)
{
    Console.WriteLine(name);
}




var task06 = numbers.OrderBy(n => n);

foreach (var n in task06)
{
    Console.WriteLine(n);
}



var task07 = students
    .Where(s => s.Age >= 18)
    .OrderBy(s => s.Age)
    .Select(s => s.Name);

foreach (var name in task07)
{
    Console.WriteLine(name);
}



var task08 = numbers.OrderBy(n => -n);

foreach (var n in task08)
{
    Console.WriteLine(n);
}



var task09 = students.First(s => s.City == "Sofia");

Console.WriteLine(task09);




try
{
    var task10 = students.First(s =>
        s.City == "Plovdiv");

    Console.WriteLine(task10);
}
catch (InvalidOperationException)
{
    Console.WriteLine("InvalidOperationException");
}




var task11 = students.Single(s => s.Id == 4);

Console.WriteLine(task11);



try
{
    var task12a = students.Single(s => s.Age == 18);
    Console.WriteLine(task12a);
}
catch (InvalidOperationException)
{
    Console.WriteLine(
        "InvalidOperationException: multiple matches");
}




try
{
    var task12b = students.Single(s => s.Id == 99);
    Console.WriteLine(task12b);
}
catch (InvalidOperationException)
{
    Console.WriteLine(
        "InvalidOperationException: no matches");
}




Console.WriteLine(numbers.First(n => n > 7));
// Result: 8

try
{
    Console.WriteLine(numbers.Single(n => n > 7));
}
catch (InvalidOperationException)
{
    Console.WriteLine("InvalidOperationException");
}
// Multiple numbers are greater than 7.

Console.WriteLine(numbers.Single(n => n > 10));
// Result: 12

try
{
    Console.WriteLine(numbers.First(n => n < 0));
}
catch (InvalidOperationException)
{
    Console.WriteLine("InvalidOperationException");
}
// No negative numbers exist.




var task14 = students.GroupBy(s => s.City);

foreach (var group in task14)
{
    Console.WriteLine(group.Key + ":");

    foreach (var student in group)
    {
        Console.WriteLine(student.Name);
    }
}



var task15 = students.GroupBy(s => s.Age >= 18);

foreach (var group in task15)
{
    if (group.Key)
    {
        Console.WriteLine("Adults:");
    }
    else
    {
        Console.WriteLine("Minors:");
    }

    foreach (var student in group)
    {
        Console.WriteLine(student.Name);
    }
}




var task16 = enrollments
    .Where(e => e.Grade >= 5)
    .GroupBy(e => e.CourseId);

foreach (var group in task16)
{
    Console.WriteLine("Course: " + group.Key);

    foreach (var e in group)
    {
        Console.WriteLine("Enrollment: " + e.Id);
    }
}




var task17 = enrollments.Join(
    students,
    e => e.StudentId,
    s => s.Id,
    (e, s) => new
    {
        EnrollmentId = e.Id,
        StudentName = s.Name,
        e.Grade
    }
);

foreach (var item in task17)
{
    Console.WriteLine(
        $"{item.EnrollmentId} / {item.StudentName} / {item.Grade}");
}





var task18 = courses.Join(
        enrollments,
        c => c.Id,
        e => e.CourseId,
        (c, e) => new
        {
            CourseTitle = c.Title,
            e.StudentId,
            e.Grade
        }
    )
    .Where(x => x.Grade >= 5);

foreach (var item in task18)
{
    Console.WriteLine(
        $"{item.CourseTitle}: {item.StudentId} / {item.Grade}");
}

// Algorithms is absent because
// there are no enrollments for this course.




var task19 = enrollments
    .Join(
        students,
        e => e.StudentId,
        s => s.Id,
        (e, s) => new
        {
            Enrollment = e,
            Student = s
        }
    )
    .Join(
        courses,
        x => x.Enrollment.CourseId,
        c => c.Id,
        (x, c) => new
        {
            x.Enrollment,
            x.Student,
            Course = c
        }
    )
    .Where(x => x.Enrollment.Grade >= 5)
    .OrderBy(x => x.Enrollment.Id)
    .Select(x => new
    {
        StudentName = x.Student.Name,
        CourseTitle = x.Course.Title,
        x.Enrollment.Grade
    });

foreach (var item in task19)
{
    Console.WriteLine(
        $"{item.StudentName} / {item.CourseTitle} / {item.Grade}");
}




var task20 = enrollments
    .Join(
        students,
        e => e.StudentId,
        s => s.Id,
        (e, s) => new
        {
            Enrollment = e,
            Student = s
        }
    )
    .Join(
        courses,
        x => x.Enrollment.CourseId,
        c => c.Id,
        (x, c) => new
        {
            CourseId = c.Id,
            CourseTitle = c.Title,
            StudentName = x.Student.Name,
            x.Enrollment.Grade
        }
    )
    .GroupBy(x => new
    {
        x.CourseId,
        x.CourseTitle
    })
    .OrderBy(g => g.Key.CourseId)
    .Select(g =>
    {
        var highest = g
            .OrderBy(x => -x.Grade)
            .First();

        return new
        {
            g.Key.CourseTitle,
            highest.StudentName,
            highest.Grade
        };
    });

foreach (var item in task20)
{
    Console.WriteLine(
        $"{item.CourseTitle} / {item.StudentName} / {item.Grade}");
}
