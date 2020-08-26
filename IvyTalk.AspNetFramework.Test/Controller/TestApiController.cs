using System;
using System.Data;
using System.Diagnostics;
using IvyTalk.AspNet;

namespace IvyTalk.AspNetFramework.Test.Controller
{
    public class TestApiController : ApiController
    {
        public void DataTable(DataTable test)
        {
            Debug.WriteLine(test);
        }

        public void NameValue(string value1, int value2, decimal value3, Guid guid)
        {
            Debug.WriteLine("value1={0}, value2={1}, value3={2}", value1, value2, value3);
        }

        public void NameValueAndDataTable(string value1, int value2, decimal value3, Guid guid, DataTable dataTable)
        {
            Debug.WriteLine("value1={0}, value2={1}, value3={2}, guid={3}, dataTable={4}", value1, value2, value3, guid.ToString(), dataTable.Columns);
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