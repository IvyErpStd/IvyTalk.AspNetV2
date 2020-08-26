using System.Web;

namespace IvyTalk.AspNet.Interfaces
{
    /// <summary>
    /// Action 返回
    /// 传入 <see cref="HttpResponse"/>, 根据类型不同, 写入返回流
    /// </summary>
    public interface IActionResult
    {
        void Execute(HttpResponse response);
    }
}