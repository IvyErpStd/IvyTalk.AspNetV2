using System.Net.Http.Headers;
using IvyTalk.AspNet.Formatting.Utilities;

namespace IvyTalk.AspNet.Formatting
{
    public static class MediaTypeConstants
    {
        private static readonly MediaTypeHeaderValue DefaultApplicationJsonMediaType = new MediaTypeHeaderValue("application/json");
        private static readonly MediaTypeHeaderValue DefaultTextJsonMediaType = new MediaTypeHeaderValue("text/json");
        private static readonly MediaTypeHeaderValue DefaultApplicationFormUrlEncodedMediaType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        /// <summary>
        /// Content-Type: application/json
        /// </summary>
        public static MediaTypeHeaderValue ApplicationJsonMediaType => DefaultApplicationJsonMediaType.Clone();     
        
        /// <summary>
        /// Content-Type: text/json
        /// </summary>
        public static MediaTypeHeaderValue TextJsonMediaType => DefaultTextJsonMediaType.Clone();        
        
        /// <summary>
        /// Content-Type: application/x-www-form-urlencoded
        /// </summary>
        public static MediaTypeHeaderValue ApplicationFormUrlEncodedMediaType => DefaultApplicationFormUrlEncodedMediaType.Clone();
    }
}