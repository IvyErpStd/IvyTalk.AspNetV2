using System;
using System.Net.Http.Headers;

namespace IvyTalk.AspNet.Formatting
{
    public class UnsupportedMediaTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedMediaTypeException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="mediaType">The unsupported media type.</param>
        public UnsupportedMediaTypeException(string message, MediaTypeHeaderValue mediaType)
            : base(message)
        {
            MediaType = mediaType ?? throw new ArgumentNullException(nameof(mediaType));
        }

        public MediaTypeHeaderValue MediaType { get; private set; }
    }
}