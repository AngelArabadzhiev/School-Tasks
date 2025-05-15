using System.Reflection;
using System.Security.Cryptography;
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
        FieldInfo[] fields = classType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance |
                                                 BindingFlags.Public);
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

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type? classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        sb.AppendLine($"All Private Methods of Class: {classType.Name}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (MethodInfo method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string GetGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type? classType = Type.GetType(className);
        MethodInfo[] methods =
            classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
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


    private string BeautifulFields(List<FieldInfo> fields)
    {
        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            var stringCurr = "";
            if (field.IsPrivate)
            {
                stringCurr += "private ";
            }
            else if (field.IsFamily)
            {
                stringCurr += "protected ";
            }
            else if (field.IsPublic)
            {
                stringCurr += "public ";
            }

            stringCurr += field.FieldType.Name + " ";
            stringCurr += field.Name;
            sb.AppendLine(stringCurr);
        }

        return sb.ToString();
    }

    public string HarvestSoil(string className, List<string> modifiers)
    {
        StringBuilder sb = new StringBuilder();
        var classType = Type.GetType(className);

        var fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        var protectedFields = fields.Where(x => x.IsFamily).ToList();
        var privateFields = fields.Where(x => x.IsPrivate).ToList();
        var publicFields = fields.Where(x => x.IsPublic).ToList();

        var finalFields = new List<FieldInfo>();
        ;

        if (modifiers.Contains("all") || (modifiers.Contains("public") && modifiers.Contains("private") &&
                                          modifiers.Contains("protected")))
        {
            return BeautifulFields(fields.ToList());
        }

        if (modifiers.Contains("public"))
        {
            finalFields.AddRange(publicFields);
        }

        if (modifiers.Contains("private"))
        {
            finalFields.AddRange(privateFields);
        }

        if (modifiers.Contains("protected"))
        {
            finalFields.AddRange(protectedFields);
        }

        return BeautifulFields(finalFields);
    }
}