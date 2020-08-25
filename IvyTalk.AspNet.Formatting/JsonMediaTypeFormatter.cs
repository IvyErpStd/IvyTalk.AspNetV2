using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace IvyTalk.AspNet.Formatting
{
    public class JsonMediaTypeFormatter : BaseJsonMediaTypeFormatter
    {
        public JsonMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeConstants.ApplicationJsonMediaType);
            SupportedMediaTypes.Add(MediaTypeConstants.TextJsonMediaType);
        }

        public override JsonReader CreateReader(Type type, Stream stream, Encoding encoding)
        {
            return new JsonTextReader(new StreamReader(stream, encoding));
        }

        public override bool CanFormatterType(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.IsClass;
        }
    }
}