namespace AdventOfCode2025.Utils;
using System;
using System.IO;
using System.Linq;

public static class Paths
{
    private static readonly string Root = FindProjectRoot();

    public static string FromProjectRoot(params string[] parts)
        => Path.Combine(new[] { Root }.Concat(parts).ToArray());

    private static string FindProjectRoot()
    {
        // IMPORTANT: use the *project assembly* location, not AppContext.BaseDirectory
        // (JetBrains launcher can change BaseDirectory to its host folder)
        var assemblyDir = Path.GetDirectoryName(typeof(Paths).Assembly.Location)
                          ?? throw new InvalidOperationException("Could not determine assembly directory.");

        var dir = new DirectoryInfo(assemblyDir);

        while (dir != null)
        {
            // Prefer anchoring to the csproj folder (more precise than .git)
            if (dir.EnumerateFiles("*.csproj").Any())
                return dir.FullName;

            // Optional fallback: if you want repo root instead
            if (Directory.Exists(Path.Combine(dir.FullName, ".git")))
                return dir.FullName;

            dir = dir.Parent;
        }

        throw new DirectoryNotFoundException(
            $"Could not locate project root by walking up from assembly directory '{assemblyDir}'.");
    }
}

