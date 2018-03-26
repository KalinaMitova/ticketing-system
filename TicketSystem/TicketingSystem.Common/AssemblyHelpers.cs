namespace TicketingSystem.Common
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class AssemblyHelpers
    {
        public static string GetDirectoryFoeAssembly(Assembly assembly)
        {
            string assemblyLocation = assembly.CodeBase;
            UriBuilder location = new UriBuilder(assemblyLocation);
            string path = Uri.UnescapeDataString(location.Path);
            string directory = Path.GetDirectoryName(path);

            return directory;
        }
    }
}
