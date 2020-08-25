﻿using System;
using System.Collections.Generic;
using System.Reflection;
using IvyTalk.AspNet.Controllers;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet
{
    public class Controller : ControllerBase
    {
        private ControllerContext _controllerContext;
        
        protected override void Execute(ControllerDescriptor descriptor, ControllerContext context)
        {
            ActionDescriptor actionDescriptor = FindAction(context);
            ActionContext = new ActionContext
            {
                Descriptor = actionDescriptor
            };
            
            Initialize(context);
        }

        protected ActionContext ActionContext { get; private set; }
        
        protected ControllerContext ControllerContext
        {
            get => _controllerContext;
            set
            {
                _controllerContext = value ?? throw new ArgumentNullException(nameof(value));
                if (ActionContext != null)
                {
                    ActionContext.ControllerContext = _controllerContext;
                }
            }
        }

        protected virtual void Initialize(ControllerContext context)
        {
            ControllerContext = context;
        }

        /// <summary>
        /// 寻找 Action
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException">匹配多个 Action</exception>
        private ActionDescriptor FindAction(ControllerContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            string actionName = context.RouteData.RouteName;
            return FindActionMethod(context, actionName);
        }

        private static ActionDescriptor FindActionMethod(ControllerContext context, string actionName)
        {
            IActionSelector selector = new DefaultActionSelector(context, actionName);
            List<MethodInfo> methodInfos = selector.FindMatchMethods();

            switch (methodInfos.Count)
            {
                case 0:
                    return null;

                case 1:
                    MethodInfo method = methodInfos[0];
                    return new ActionDescriptor(method, context.Descriptor);

                default:
                    throw new InvalidOperationException("存在多个相同的 Action, ActionSelector 无法做出选择!");
            }
        }
    }
}