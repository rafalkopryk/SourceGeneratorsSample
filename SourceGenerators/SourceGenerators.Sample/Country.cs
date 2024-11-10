using System.Runtime.CompilerServices;
using SmartEnumGenerators;

namespace SourceGenerators.Sample;

[SmartEnumGenerator]
public partial record Country(string CountryCode, [CallerMemberName] string CountryName = "")
{
    public static readonly Country Poland = new("PL");
    public static readonly Country Usa = new("US");
    public static readonly Country Germany = new("DE");
    public static readonly Country Switzerland = new("CH");
    public static readonly Country Sweden = new("SE");
};
