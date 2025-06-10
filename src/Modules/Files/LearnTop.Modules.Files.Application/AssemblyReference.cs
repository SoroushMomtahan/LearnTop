using System.Reflection;

namespace LearnTop.Modules.Files.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
