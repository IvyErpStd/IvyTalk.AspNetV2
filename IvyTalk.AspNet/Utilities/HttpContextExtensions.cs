using System;
using System.Net.Http.Headers;
using System.Web;

namespace IvyTalk.AspNet.Utilities
{
    public static class HttpContextExtensions
    {
        public static MediaTypeHeaderValue ContentTypeToMediaType(this HttpRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string contentType = request.ContentType;
            if (string.IsNullOrEmpty(contentType))
            {
                return null;
            }

            string value = GetMediaType(contentType);
            return new MediaTypeHeaderValue(value);
        }

        private static string GetMediaType(string value)
        {
            // https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Type
            
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            int symbol = value.IndexOf(';');
            return symbol == -1 ? value : value.Substring(0, symbol + 1);
        }
    }
}