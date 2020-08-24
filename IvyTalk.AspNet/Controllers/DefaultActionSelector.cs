using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNet.Controllers
{
    public sealed class DefaultActionSelector : IActionSelector
    {
        private readonly ControllerContext _context;
        private readonly string _actionName;

        public DefaultActionSelector(ControllerContext context, string actionName)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _actionName = actionName ?? throw new ArgumentNullException(nameof(actionName));
        }

        /// <summary>
        /// 寻找名称相符的 Method
        /// </summary>
        public List<MethodInfo> FindMatchMethods()
        {
            MethodInfo[] methodInfos = _context.Descriptor.Type.GetMethods();

            List<MethodInfo> matches = methodInfos
                .Where(i =>
                    MatchAliasName(i, _actionName) || MatchActionName(i, _actionName))
                .ToList();

            return matches;
        }

        private static bool MatchAliasName(MethodInfo methodInfo, string actionName)
        {
            throw new NotImplementedException();
            return false;
        }

        private static bool MatchActionName(MethodInfo methodInfo, string actionName)
        {
            return methodInfo.Name.Equals(actionName, StringComparison.OrdinalIgnoreCase);
        }
    }
}