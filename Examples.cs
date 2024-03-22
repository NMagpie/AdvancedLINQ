namespace _9._Advanced_LINQ
{
    public class Examples
    {

        //Big method with all the examples

        public static void examplesMethod(List<Course> courses, List<Student> students) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////// JOINS

            Console.WriteLine("JOINS\n");

            // Join example

            Console.WriteLine("Join example\n");

            var joinExample = students.Join(courses,
                student => student.Id,
                course => course.StudentId,
                (student, course) => new { CourseName = course.CourseName, Student = student });

            foreach (var item in joinExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // GroupJoin example

            Console.WriteLine("GroupJoin example\n");

            var groupJoinExample = students.GroupJoin(joinExample,
                student => student,
                course => course.Student,
                (student, coursesCollection) => new { StudentName = student.Name, CoursesCollection = coursesCollection.Select(course => course.CourseName) }
                );

            Console.WriteLine();

            foreach (var item in groupJoinExample)
                Console.WriteLine($"{item.StudentName} [{string.Join(", ", item.CoursesCollection)}]");

            // Zip example

            Console.WriteLine("Zip example\n");

            var list1 = new[] {
                new { Str = "123", A = 1 },
                new { Str = "456", A = 2 },
                new { Str = "789", A = 3 },
                new { Str = "GHI", A = -3 },
            }.ToList();

            var list2 = new[] {
                new { Str = "ABC", A = -1 },
                new { Str = "DEF", A = -2 },
                new { Str = "GHI", A = -3 },
                new { Str = "789", A = 3 },
            }.ToList();


            var zipExample = list1.Zip(list2, (e1, e2) => new { e2.Str, e1.A });

            foreach (var item in zipExample)
                Console.WriteLine(item);

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// GROUPING

            Console.WriteLine("GROUPING\n");

            // GroupBy example

            Console.WriteLine("GroupBy example\n");

            var groupByExample = courses.GroupBy(course => course.CourseName);

            foreach (var item in groupByExample)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine("\t" + item1.StudentId);
                }
            }

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// SET OPERATIONS

            Console.WriteLine("SET OPERATIONS\n");

            // Concat example

            Console.WriteLine("Concat example\n");

            var concatExample = list1.Concat(list2);

            foreach (var item in concatExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Union example

            Console.WriteLine("Union example\n");

            var unionExample = list1.Union(list2);

            foreach (var item in unionExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Intersect example

            Console.WriteLine("Intersect example\n");

            var intersectExample = list1.Intersect(list2);

            foreach (var item in intersectExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Except example

            Console.WriteLine("Except example\n");

            var exceptExample = list1.Except(list2);

            foreach (var item in exceptExample)
                Console.WriteLine(item);

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// CONVERSION

            Console.WriteLine("CONVERSION\n");

            // OfType example

            Console.WriteLine("OfType example\n");

            List<object> intList = [1, 2, 3];

            var ofTypeExample = intList.OfType<int>();

            foreach (var item in ofTypeExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Cast example

            Console.WriteLine("Cast example\n");

            var castExample = intList.OfType<int>();

            foreach (var item in castExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // ToArray example

            Console.WriteLine("ToArray\n");

            var toArrayExample = intList.Select(x => x).ToArray();

            foreach (var item in toArrayExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // ToList example

            Console.WriteLine("ToList example\n");

            var toListExample = intList.Select(x => x).ToList();

            foreach (var item in toListExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // ToDictionary example

            Console.WriteLine("ToDictionary example\n");

            var i = 0;

            var toDictionaryExample = intList.Select(x => new { x, i = i++ }).ToDictionary(e => e.x, e => e.i);

            foreach (var item in toDictionaryExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // ToLookup example

            Console.WriteLine("ToLookup example\n");

            i = 0;

            var toLookupExample = intList.Select(x => new { x, i = i++ }).ToLookup(e => e.i);

            foreach (var item in toLookupExample)
                Console.WriteLine(item.Key);

            Console.WriteLine();

            // AsEnumerable example

            Console.WriteLine("AsEnumerable example\n");

            var asEnumerableExample = intList.AsEnumerable();

            foreach (var item in asEnumerableExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // AsQueryable example

            Console.WriteLine("AsQueryable example\n");

            var asQueryableExample = intList.AsQueryable();

            foreach (var item in asQueryableExample)
                Console.WriteLine(item);

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// AGGREGATION

            Console.WriteLine("AGGREGATION\n");

            // Count example

            Console.WriteLine("Count example\n");

            Console.WriteLine(intList.Count());

            Console.WriteLine();

            // Min example

            Console.WriteLine("Min example\n");

            Console.WriteLine(castExample.Min());

            Console.WriteLine();

            // Sum example

            Console.WriteLine("Sum example\n");

            Console.WriteLine(castExample.Sum());

            Console.WriteLine();

            // Aggregate example

            Console.WriteLine("Aggregate example\n");

            Console.WriteLine(castExample.Aggregate(1, (e, next) => next > e ? next : e));

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// QUANTIFIERS

            Console.WriteLine("QUANTIFIERS\n");

            // Contains example

            Console.WriteLine("Contains example\n");

            Console.WriteLine(castExample.Contains(1));

            Console.WriteLine();

            // Any example

            Console.WriteLine("Any example\n");

            Console.WriteLine(castExample.Any(e => e == 1));

            Console.WriteLine();

            // All example

            Console.WriteLine("All example\n");

            Console.WriteLine(castExample.Any(e => e > -1));

            Console.WriteLine();

            // SequenceEqual example

            Console.WriteLine("SequenceEqual example\n");

            Console.WriteLine(castExample.SequenceEqual([1, 2, 3]));

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// ELEMENT OPERATORS
            
            Console.WriteLine("ELEMENT OPERATIONS\n");

            // First example

            Console.WriteLine("First example\n");

            Console.WriteLine(intList.First());

            Console.WriteLine();

            // Last example

            Console.WriteLine("Last example\n");

            Console.WriteLine(intList.Last());

            Console.WriteLine();

            // Signle example

            Console.WriteLine("SingleOrDefault example\n");

            Console.WriteLine((Enumerable.Range(0,1)).SingleOrDefault(-1));

            Console.WriteLine();

            // ElementAt example

            Console.WriteLine("ElementAt example\n");

            Console.WriteLine(intList.ElementAt(0));

            Console.WriteLine();

            // DefaultIfEmpty example

            Console.WriteLine("DefaultIfEmpty example\n");

            List<int> anotherListBitesTheDust = [];

            foreach (var item in anotherListBitesTheDust.DefaultIfEmpty(-1))
                Console.WriteLine(item);

            Console.WriteLine();

            ///////////////////////////////////////////////////////////////////////////////////////////////////// GENERATION OPERATORS

            Console.WriteLine("GENERATION OPERATORS\n");

            // Empty example

            Console.WriteLine("Empty example\n");

            var emptyExample = Enumerable.Empty<int>();

            foreach (var item in emptyExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Repeat example

            Console.WriteLine("Repeat example\n");

            var repeatExample = Enumerable.Repeat("hello", 5);

            foreach (var item in repeatExample)
                Console.WriteLine(item);

            Console.WriteLine();

            // Range example

            Console.WriteLine("Range example\n");

            var rangeExample = Enumerable.Range(1, 30);

            foreach (var item in rangeExample)
                Console.WriteLine(item);

            Console.WriteLine();
        }

    }
}
