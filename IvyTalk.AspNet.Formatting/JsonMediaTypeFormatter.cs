using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace IvyTalk.AspNet.Formatting
{
    public class JsonMediaTypeFormatter : BaseJsonMediaTypeFormatter
    {
        public override JsonReader CreateReader(Type type, Stream stream, Encoding encoding)
        {
            return new JsonTextReader(new StreamReader(stream, encoding));
        }
    }
}