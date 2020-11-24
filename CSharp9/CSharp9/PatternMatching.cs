using static CSharp9.AccessType;
using static CSharp9.ContentType;

namespace CSharp9
{
    public class UserManager
    {
        public bool Func1(int num) =>
        num switch
        {
            < 0 => true,
            > 0 and < 10 => false,
            11 => true,
            12 => true,
            var n when n is 13 or 14 or 15 => true,
            _ => true
        };

        public int Func2(Person user) =>
        user switch
        {
            // Property Pattern
            { Age: 16 } => 0,
            { Age: > 50 or < 18 } => 0,
            { Name: "test1" or "test2" } => 1,
            { Age: > 18, Name: "test3" or "test4" } => 2,

            // Type Pattern
            OpenCaseFile o when o.Age is > 15 => 0,
            OpenCaseFile o when o.Age is < 15 && o.RiskLevel is 3 or 4 or 5 => 0,
            OpenCaseFile _ => 2,
            var u when u.Name is "" => 5,
            _ => 0
        };

        public static bool IsAccessOkOfficial(Person user, Content content, int season) => (user, content, season) switch
        {
            // Tuple + property patterns
            ({ Type: Child }, { Type: ChildsPlay }, _) => true,
            ({ Type: Child }, _, _) => false,
            (_, { Type: Public }, _) => true,
            ({ Type: Monarch }, { Type: ForHerEyesOnly }, _) => true,
            // Tuple + type patterns
            (OpenCaseFile f, { Type: ChildsPlay }, 4) when f.Name == "Sherlock Holmes" => true,
            // Property and type patterns
            { Item1: OpenCaseFile { Type: var type }, Item2: { Name: var name } }
                when type == PoorlyDefined && name.Contains("Sherrinford") && season >= 3 => true,
            // Tuple and type patterns
            (OpenCaseFile, var c, 4) when c.Name.Contains("Sherrinford") => true,
            // Tuple, Type, Property and logical patterns 
            (OpenCaseFile { RiskLevel: > 50 and < 100 }, { Type: StateSecret }, 3) => true,
            _ => false,
        };
    }


    public record Person(string Name, AccessType Type, int Age);

    public record OpenCaseFile(string Name, AccessType Type, int RiskLevel, int Age) : Person(Name, Type, Age);

    public record Content(string Name, ContentType Type);

    public enum AccessType
    {
        Child,
        Adult,
        PoorlyDefined,
        Monarch,
    }

    public enum ContentType
    {
        ChildsPlay,
        Public,
        StateSecret,
        ForHerEyesOnly
    }

}
