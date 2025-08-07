namespace LearnTop.Bootstrapper.Api;

internal sealed class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    private Person(){}
    public static IQueryable<Person> GeneratePeople(int? count)
    {
        string[] firstNames = new[] { "John", "Jane", "Peter", "Susan", "Michael", "Emily", "David", "Sarah", "Chris", "Jessica", "James", "Linda", "Robert", "Patricia", "William", "Jennifer" };
        string[] lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas" };
        var people = new List<Person>();
        var random = new Random();

        for (int i = 1; i <= count; i++)
        {
            string firstName = firstNames[random.Next(firstNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];
            
            // Generate a random birth date between 18 and 70 years ago
            DateTime birthDate = DateTime.Now.AddYears(-random.Next(18, 70)).AddDays(-random.Next(0, 365));

            people.Add(new Person
            {
                Id = i,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            });
        }
        return people.AsQueryable();
    }
}
