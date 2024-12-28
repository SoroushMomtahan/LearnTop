using System.Reflection;

namespace LearnTop.Modules.Blogs.Application;

public static class AssemblyReference
{
    public static readonly Assembly BlogsAssembly = typeof(AssemblyReference).Assembly;
}
