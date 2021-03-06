﻿using System;
using System.Collections.Generic;
using System.Reflection;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public class ControllerDescriptor
    {
        public ControllerDescriptor(ControllerBase controller, HttpConfiguration configuration)
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private Type _type;

        /// <summary>
        /// 配置
        /// </summary>
        public HttpConfiguration Configuration { get; }

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