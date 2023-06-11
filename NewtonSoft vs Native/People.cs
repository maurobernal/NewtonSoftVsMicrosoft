namespace NewtonSoft_vs_Native;

public class People
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birth { get; set; }
    private static People getPeople() =>
new People()
{
    Id = new Random().Next(999),
    FirstName = "Mauro",
    LastName = "Bernal",
    Birth = new DateOnly(1985, 01, 01)
};
    public static List<People> getPeoples(int count)
    {
        List<People> peoples = new List<People>();

        for (int i = 0; i < count; i++)
            peoples.Add(getPeople());
        return peoples;
    }


    public static string GetJsonFile(int count)
        => File.ReadAllText($"Json/{count}.json");
}
