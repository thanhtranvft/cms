using System;
using System.Web;
using ServiceStack.Redis;

namespace VFT.Shared
{
    public class ElastiCacheHelper
    {
        private const bool _isDebugMode = false;

        public static bool SetCache(Object cachObject, string key, int timeout = -1)
        {
            if (string.IsNullOrEmpty(key)) return false;

            bool result = false;

            try
            {
                using (var redisClient = new RedisClient(AppSetting.RedisCacheUrl, AppSetting.RedisCachePort, AppSetting.RedisCachePassword))
                {
                    result = redisClient.Set(key, cachObject, TimeSpan.FromSeconds(86400)); //1 ngay
                }
            }
            catch (Exception ex)
            {
            }
            
            return result;
        }

        public static bool SetCache(Object cachObject, out string key)
        {
            key = Guid.NewGuid().ToString();
            return SetCache(cachObject, key);
        }

        public static bool UpdateCache(Object cachObject, string key)
        {
            return !string.IsNullOrEmpty(key) && SetCache(cachObject, key);
        }

        public static T GetCache<T>(string key)
        {
            if (string.IsNullOrEmpty(key)) return default(T);

            T result;

            try
            {
                using (var redisClient = new RedisClient(AppSetting.RedisCacheUrl, AppSetting.RedisCachePort, AppSetting.RedisCachePassword))
                {
                    result = redisClient.Get<T>(key);
                }
            }
            catch (Exception ex)
            {
                result = default(T);
            }

            return result;
        }

        public static IList<string> GetAllKeys()
        {
            IList<string>? result;

            try
            {
                using (var redisClient = new RedisClient(AppSetting.RedisCacheUrl, AppSetting.RedisCachePort, AppSetting.RedisCachePassword))
                {
                    result = redisClient.GetAllKeys();
                }
            }
            catch (Exception ex)
            {
                result = default(IList<string>);
            }

            return result;
        }

        public static bool DeleteCache(string key)
        {
            if (string.IsNullOrEmpty(key)) return false;

            bool result = false;

            try
            {
                using (var redisClient = new RedisClient(AppSetting.RedisCacheUrl, AppSetting.RedisCachePort, AppSetting.RedisCachePassword))
                {
                    result = redisClient.Remove(key);
                }
            }
            catch (Exception ex)
            {
            }
            
            return result;
        }
    }
}
