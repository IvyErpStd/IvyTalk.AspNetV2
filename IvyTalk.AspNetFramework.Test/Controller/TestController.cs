using System.Diagnostics;

namespace IvyTalk.AspNetFramework.Test.Controller
{
    public class TestController : IvyTalk.AspNet.Controller
    {
        public void TestAction(SerializeClassTest test)
        {
            Debug.WriteLine(test);
        }
    }

    public sealed class SerializeClassTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}