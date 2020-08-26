using System;
using System.IO;
using System.Text;
using System.Web;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Formatting;
using IvyTalk.AspNet.Interfaces;
using Newtonsoft.Json;

namespace IvyTalk.AspNet
{
    public class JsonResult<TSerializeClass> : IActionResult where TSerializeClass : class
    {
        private readonly TSerializeClass _class;

        public JsonResult(TSerializeClass @class)
        {
            _class = @class ?? throw new ArgumentNullException(nameof(@class));
        }

        public void Execute(ActionContext context)
        {
            HttpResponse response = context.ControllerContext.Response;
            HttpConfiguration configuration = context.ControllerContext.Configuration;

            JsonSerializer serializer = CreateSerializer(configuration);
            
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            using (JsonWriter writer = new JsonTextWriter(response.Output))
            {
                serializer.Serialize(writer, _class);
            }
        }

        private JsonSerializer CreateSerializer(HttpConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            JsonSerializerSettings settings = configuration.JsonSerializerSettings;
            if (settings is null)
            {
                return JsonSerializer.CreateDefault();
            }

            return JsonSerializer.Create(configuration.JsonSerializerSettings);
        }
    }
}