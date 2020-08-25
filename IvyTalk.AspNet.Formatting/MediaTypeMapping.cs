using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace IvyTalk.AspNet.Formatting
{
    /// <summary>
    /// MediaType 映射
    /// </summary>
    public abstract class MediaTypeMapping
    {
        protected MediaTypeMapping(MediaTypeHeaderValue mediaType)
        {
            MediaType = mediaType ?? throw new ArgumentNullException(nameof(mediaType));
        }

        protected MediaTypeMapping(string mediaTypeValue)
        {
            if (string.IsNullOrWhiteSpace(mediaTypeValue))
            {
                throw new ArgumentNullException(nameof(mediaTypeValue));
            }

            MediaType = new MediaTypeHeaderValue(mediaTypeValue);
        }

        public MediaTypeHeaderValue MediaType { get; }

        /// <summary>
        /// 是否匹配 MediaType
        /// </summary>
        public abstract bool TryMatchMediaType(HttpRequest request);
    }
}