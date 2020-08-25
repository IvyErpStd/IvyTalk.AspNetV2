using System;
using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace IvyTalk.AspNet.Formatting
{
    public abstract class BaseJsonMediaTypeFormatter : MediaTypeFormatter
    {
        public static readonly JsonSerializerSettings DefaultSetting = new JsonSerializerSettings()
        {
            // ContractResolver =,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None
        };

        protected BaseJsonMediaTypeFormatter()
        {
            _jsonSerializerSettings = DefaultSetting;
        }

        protected BaseJsonMediaTypeFormatter(BaseJsonMediaTypeFormatter formatter)
            : base(formatter)
        {
            _jsonSerializerSettings = formatter._jsonSerializerSettings;
        }

        private JsonSerializerSettings _jsonSerializerSettings;

        /// <summary>
        /// 序列化设置
        /// </summary>
        public JsonSerializerSettings JsonSerializerSettings
        {
            get => _jsonSerializerSettings;
            set => _jsonSerializerSettings = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override object ReadFromStream(Type type, Stream stream, HttpRequest request)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return ReadFromStream(type, stream, request.ContentEncoding);
        }

        public virtual object ReadFromStream(Type type, Stream stream, Encoding encoding)
        {
            using (JsonReader reader = CreateReader(type, stream, encoding))
            {
                if (reader is null)
                {
                    throw new InvalidOperationException("创建 JSONReader 失败!");
                }

                reader.CloseInput = true;

                JsonSerializer serializer =
                    CreateSerializer()
                    ?? throw new InvalidOperationException("创建 JSONSerializer 失败!");
                return serializer.Deserialize(reader, type);
            }
        }

        public abstract JsonReader CreateReader(Type type, Stream stream, Encoding encoding);

        public virtual JsonSerializer CreateSerializer()
        {
            return JsonSerializer.Create(JsonSerializerSettings);
        }
    }
}