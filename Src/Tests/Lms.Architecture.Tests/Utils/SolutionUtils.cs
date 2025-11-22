namespace LMS.Architecture.Tests.Utils;

public static class SolutionUtils
{
    #region Private Variables

    private static readonly string SolutionRoot = FindSolutionRoot();

    #endregion

    public static TheoryData<string, Assembly> AllAssemblies => FindAssembliesByPattern(p => !p.Contains("Tests"));

    public static TheoryData<string, Assembly> FrontendAssemblies => FindAssembliesByPattern(p => p.EndsWith("Client"));

    public static Assembly FindAssemblyByProjectName(string projectName)
    {
        string csproj = Directory
            .GetFiles(SolutionRoot, $"{projectName}.csproj", SearchOption.AllDirectories)
            .FirstOrDefault()
            ?? throw new FileNotFoundException($"Project '{projectName}' not found in solution.");

        string dll = FindAssemblyForProject(csproj);
        return Assembly.LoadFrom(dll);
    }

    public static TheoryData<string, Assembly> FindAssembliesByPattern(Func<string, bool> projectNameFilter)
    {
        TheoryData<string, Assembly> result = new();

        foreach (string csproj in Directory.GetFiles(SolutionRoot, "*.csproj", SearchOption.AllDirectories))
        {
            string projectName = Path.GetFileNameWithoutExtension(csproj);

            if (!projectNameFilter(projectName))
                continue;

            try
            {
                string dll = FindAssemblyForProject(csproj);

                result.Add(projectName, Assembly.LoadFrom(dll));
            }
            catch
            {
                // ок, проект мог быть не собран — игнорируем
            }
        }

        return result;
    }

    #region Private

    private static string FindAssemblyForProject(string csprojPath)
    {
        string projectDir = Path.GetDirectoryName(csprojPath)!;
        string projectName = Path.GetFileNameWithoutExtension(csprojPath);
        string configuration = Path.Combine(
            Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory)!.FullName)!.Name, // Debug / Release
            new DirectoryInfo(AppContext.BaseDirectory).Name // net9.0
        );

        string bin = Path.Combine(projectDir, "bin", configuration);

        return Directory
            .GetFiles(bin, $"{projectName}.dll", SearchOption.AllDirectories)
            .First();
    }

    private static string FindSolutionRoot()
    {
        string? dir = AppContext.BaseDirectory;

        while (dir != null)
        {
            if (Directory.GetFiles(dir, "*.slnx", SearchOption.TopDirectoryOnly).Length != 0)
                return dir;

            dir = Directory.GetParent(dir)?.FullName;
        }

        throw new("Solution root not found.");
    }

    #endregion
}