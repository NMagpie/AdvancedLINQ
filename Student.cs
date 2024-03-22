namespace _9._Advanced_LINQ
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Major { get; set; }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, age: {Age}, major: {Major}";
        }
    }
}
