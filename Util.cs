using Microsoft.Extensions.Configuration;

namespace UIAutomation
{
    public static class Util
    {
        public static string GetKey(string key)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            IConfiguration config = builder.Build();
            return config[key];
        }
    }
}
