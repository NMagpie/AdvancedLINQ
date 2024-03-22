using _9._Advanced_LINQ;
using Newtonsoft.Json;


var coursesFile = "D:\\AM\\C#\\9. Advanced LINQ\\courses.json";

string text = File.Exists(coursesFile) ? File.ReadAllText(coursesFile) : "";

List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(text) ?? [];

/////////////////////////////////////////////////////////////////////////////////////////////////////

var studentsFile = "D:\\AM\\C#\\9. Advanced LINQ\\students.json";

text = File.Exists(studentsFile) ? File.ReadAllText(studentsFile) : "";

List<Student> students = JsonConvert.DeserializeObject<List<Student>>(text) ?? [];


// Get number of students by courses (used ToDictionary, GroupBy, Count)

var result = courses.GroupBy(course => course.CourseName)
    .Select((course) => new { courseName = course.Key, nrStudents = course.Count() })
    .ToDictionary( entry => entry.courseName, entry => entry.nrStudents );

foreach (var course in result)
{
    Console.WriteLine(course);
}

// Get first student having Ecology course

var result1 = students.GroupJoin(courses,
    student => student.Id,
    course => course.StudentId,
    (student, courseCollection) => new { StudentName = student.Name, CourseCollection = courseCollection })

    .Where(student => student.CourseCollection.Any( 
            course => course.CourseName.Equals("Ecology") ))
    .Select(student => student).First();

Console.WriteLine(result1);

var range = Enumerable.Range(-1, 10);

var range2 = Enumerable.Range(20, 10);

var zippedRanges = range.Zip(range2, (e, e1) => e * e1);

foreach (var item in zippedRanges)
{
    Console.WriteLine(item);
}

// Range range2 = Enumerable.Range(0, 100); // type mismatch... what did C# developers mean by that?