namespace Reflection_Tasks;

class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string res;

        Console.WriteLine("--------------------First task--------------------");
        res = spy.StealFieldInfo("Reflection_Tasks.Hacker", "username", "password");
        Console.WriteLine(res);

        Console.WriteLine("--------------------Second task--------------------");
        res = spy.AnalyzeAccessModifiers("Reflection_Tasks.Hacker");
        Console.WriteLine(res);

        Console.WriteLine("--------------------Third task--------------------");
        res = spy.RevealPrivateMethods("Reflection_Tasks.Hacker");
        Console.WriteLine(res);
    }
}