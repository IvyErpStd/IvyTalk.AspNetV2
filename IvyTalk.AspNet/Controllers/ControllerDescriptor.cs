using System;
using System.Collections.Generic;
using System.Reflection;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class ControllerDescriptor
    {
        public ControllerDescriptor(ControllerBase controller)
        {
            Controller = controller;
        }

        private Type _type;

        /// <summary>
        /// 控制器
        /// </summary>
        public ControllerBase Controller { get; }

        /// <summary>
        /// Type
        /// </summary>
        public Type Type =>
            _type ?? (_type = Controller.GetType());


        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsDisable => false;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                if (!Type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
                {
                    return Type.Name;
                }

                return Type.Name.Substring(0, Type.Name.Length - 10);
            }
        }
    }
}