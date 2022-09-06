using Microsoft.Extensions.Configuration;

namespace VFT.Shared
{
    public class AppSetting
    {
        public static IConfiguration Configuration;
        public static string HostUrl
        {
            get
            {
                return Configuration["HostUrl"] ?? string.Empty;
            }
        }

        public static string RedisCacheUrl
        {
            get
            {
                return Configuration["RedisCacheUrl"] ?? string.Empty;
            }
        }

        public static int RedisCachePort
        {
            get
            {
                return Configuration["RedisCachePort"] != null ? Convert.ToInt32(Configuration["RedisCachePort"]) : 0;
            }
        }

        public static string RedisCachePassword
        {
            get
            {
                return Configuration["RedisCachePassword"] ?? string.Empty;
            }
        }
        public static string EurekaAPIUrl
        {
            get
            {
                return Configuration["EurekaAPIUrl"] ?? string.Empty;
            }
        }

        public static string ServiceChatUrl
        {
            get
            {
                return Configuration["ServiceChatUrl"] ?? string.Empty;
            }
        }
    }
}
