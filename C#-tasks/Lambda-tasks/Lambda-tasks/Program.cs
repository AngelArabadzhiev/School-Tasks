namespace Lambda_tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        var inputDumbWay = Console.ReadLine().Split(" ");
        var names = inputDumbWay.ToList();

        names.ForEach(delegate(string name) { Console.WriteLine(name); });
        //The code that I have commented out is a million times better and way easier to understand, but for the sake of the task I have also written it how it is intended.
        //string[] input = Console.ReadLine().Split(" ");
        //foreach (var splitString in input) Console.WriteLine(splitString);
    }

    private void Print(string name)
    {
        Console.WriteLine(name);
    }
}