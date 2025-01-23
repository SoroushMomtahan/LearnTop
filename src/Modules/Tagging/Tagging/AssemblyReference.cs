using System.Reflection;

namespace Tagging;

public static class AssemblyReference
{
    public static readonly Assembly TaggingAssembly = typeof(AssemblyReference).Assembly;
}
