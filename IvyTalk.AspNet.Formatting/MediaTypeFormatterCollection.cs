using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using IvyTalk.AspNet.Formatting.Utilities;

namespace IvyTalk.AspNet.Formatting
{
    public class MediaTypeFormatterCollection : Collection<MediaTypeFormatter>
    {
        public MediaTypeFormatterCollection()
            : this(CreateDefaultFormatters())
        {
        }

        public MediaTypeFormatterCollection(IEnumerable<MediaTypeFormatter> formatters)
        {
            if (formatters is null)
            {
                throw new ArgumentNullException(nameof(formatters));
            }

            foreach (var mediaTypeFormatter in formatters)
            {
                Add(mediaTypeFormatter);
            }
        }

        private static IEnumerable<MediaTypeFormatter> CreateDefaultFormatters()
        {
            return new MediaTypeFormatter[]
            {
                /* JSON 序列化 */
                new JsonMediaTypeFormatter()
            };
        }
        
        /// <summary>
        /// 寻找格式化器
        /// </summary>
        public virtual MediaTypeFormatter FindFormatter(Type type, MediaTypeHeaderValue mediaType)
        {
            foreach (var formatter in this)
            {
                if (formatter != null && formatter.CanFormatterType(type))
                {
                    foreach (MediaTypeHeaderValue supportedMediaType in formatter.SupportedMediaTypes)
                    {
                        if (supportedMediaType != null && supportedMediaType.IsSubsetOf(mediaType))
                        {
                            return formatter;
                        }
                    }
                }
            }

            return null;
        }
    }
}