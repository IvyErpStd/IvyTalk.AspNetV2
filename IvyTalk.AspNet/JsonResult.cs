using System;
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

            string result = JsonConvert.SerializeObject(_class);

            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            response.Write(result);
        }
    }
}