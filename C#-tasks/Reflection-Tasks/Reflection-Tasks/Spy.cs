using System.Reflection;
using System.Text;

namespace Reflection_Tasks;

public class Spy
{
    public string StealFieldInfo(string investigatedName, params string[] stringArr)
    {
        StringBuilder sb = new StringBuilder();
        Type? classType = Type.GetType(investigatedName);
        classType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.FullName == investigatedName);
        sb.AppendLine($"Class under investigation: {investigatedName.Replace("OOP2.", "")}");
        var classInstance = Activator.CreateInstance(classType);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (FieldInfo field in fields.Where(f => stringArr.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type? classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] publicMethodInfos = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] nonPmInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private");
        }

        foreach (MethodInfo method in nonPmInfos.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} has to be private");
        }

        foreach (MethodInfo method in publicMethodInfos.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} has to be private");
        }
        return sb.ToString().Trim();
    }

    public string GetGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type? classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods( BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set the field of {method.GetParameters()[0].ParameterType}");
        }
        return sb.ToString().Trim();
    }
}