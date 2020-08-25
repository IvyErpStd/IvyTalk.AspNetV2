using IvyTalk.AspNet.Controllers;

namespace IvyTalk.AspNet.Interfaces
{
    public interface IActionValueBinder
    {
        ActionBinding GetBinding(ActionDescriptor descriptor);
    }
}