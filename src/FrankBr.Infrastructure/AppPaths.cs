namespace FrankBr.Infrastructure;

public static class AppPaths
{
    public static string UserDataDirectory => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "FrankBr",
        "DesignStudio");
}
