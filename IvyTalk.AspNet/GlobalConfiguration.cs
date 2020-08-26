using System;

namespace IvyTalk.AspNet
{
    public class GlobalConfiguration
    {
        private static readonly Lazy<HttpConfiguration> HttpConfiguration
            = new Lazy<HttpConfiguration>(() => new HttpConfiguration());

        /// <summary>
        /// Http 服务配置
        /// </summary>
        public static HttpConfiguration Configuration => HttpConfiguration.Value;

        public static void Configure(Action<HttpConfiguration> configurationCallback)
        {
            if (configurationCallback is null)
            {
                throw new ArgumentNullException(nameof(configurationCallback));
            }

            configurationCallback.Invoke(Configuration);
        }
    }
}