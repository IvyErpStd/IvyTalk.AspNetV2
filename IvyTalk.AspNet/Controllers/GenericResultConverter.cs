using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    /// <summary>
    /// 通用类型转换器
    /// </summary>
    public class GenericResultConverter : ActionConverter
    {
        public GenericResultConverter(ActionDescriptor descriptor) : base(descriptor)
        {
        }
     
        public override bool Execute(ActionContext context, object result)
        {
            if (ActionDescriptor.ReturnType == typeof(void))
            {
                return false;
            }
         
            // TODO: 细分
            // 暂时粗暴
            
            context.ControllerContext.Response.Write(result);
            return true;
        }
    }
}