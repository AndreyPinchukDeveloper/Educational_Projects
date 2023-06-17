namespace BlazorApp1
{
    /// <summary>
    /// This class contains all services which connect in Program.cs file
    /// </summary>
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();
        }
    }
}
