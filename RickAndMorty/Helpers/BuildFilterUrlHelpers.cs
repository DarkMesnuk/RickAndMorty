namespace RickAndMorty.Helpers
{
    internal static class BuildFilterUrlHelpers
    {
        public static string BuildFilterUrl(this string baseUrl, string name = "") =>
            baseUrl + "?" + (!string.IsNullOrEmpty(name) ? $"{nameof(name)}={name}" : "");
    }
}