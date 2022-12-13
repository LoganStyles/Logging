using Logging;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        var employee = new Employee { FirstName = "Susan", LastName = "Fredricks", Age = 28 };
        context.Employees.Add(employee);

        context.SaveChanges();
    }
}