using System.Text.RegularExpressions;
using System.Web;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    /// <summary>
    /// <see cref="IActionResult"/> 返回值转换器
    /// </summary>
    public class ActionResultConverter : ActionConverter
    {
        public ActionResultConverter(ActionDescriptor descriptor) : base(descriptor)
        {
        }
        
        public override bool Execute(ActionContext context, object result)
        {
            if (result is IActionResult actionResult)
            {
                actionResult.Execute(context);
                return true;
            }

            return false;
        }
    }
}