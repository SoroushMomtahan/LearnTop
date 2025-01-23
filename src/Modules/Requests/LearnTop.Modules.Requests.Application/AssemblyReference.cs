using System.Reflection;

namespace LearnTop.Modules.Requests.Application;

public static class AssemblyReference
{
   public static readonly Assembly RequestsAssembly = typeof(AssemblyReference).Assembly; 
}
