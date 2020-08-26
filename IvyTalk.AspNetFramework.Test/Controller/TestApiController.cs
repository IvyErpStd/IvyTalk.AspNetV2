using System;
using System.Data;
using System.Diagnostics;
using IvyTalk.AspNet;
using IvyTalk.AspNet.Interfaces;

namespace IvyTalk.AspNetFramework.Test.Controller
{
    public class TestApiController : ApiController
    {
        public IActionResult ComplexType(string value1, int value2, decimal value3, Guid guid, DataTable dataTable)
        {
            Debug.WriteLine("value1={0}, value2={1}, value3={2}, guid={3}, dataTable={4}", value1, value2, value3,
                guid.ToString(), dataTable);

            return Json(new
            {
                value1 = value1,
                value2 = value2,
                value3 = value3,
                guid = guid,
                dataTable = dataTable,
                dateTime = DateTime.Now
            });
        }

        public Guid OtherResult()
        {
            return Guid.NewGuid();
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