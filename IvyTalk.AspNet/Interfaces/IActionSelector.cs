using System.Collections.Generic;
using System.Reflection;
using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Interfaces
{
    public interface IActionSelector
    {
        List<MethodInfo> FindMatchMethods();
    }
}