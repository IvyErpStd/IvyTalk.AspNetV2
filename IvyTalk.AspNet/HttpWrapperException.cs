using System;
using System.Net;
using System.Web;

namespace IvyTalk.AspNet
{
    /// <summary>
    /// 包装 <see cref="HttpException"/> 异常类
    /// </summary>
    internal class HttpWrapperException : HttpException
    {
        public HttpWrapperException()
        {
        }
        
        public HttpWrapperException(HttpStatusCode code, string message, Exception innerException)
            : base((int) code, message, innerException)
        {
        }
        
        public HttpWrapperException(HttpStatusCode code, string message)
            : base((int) code, message)
        {
        }
        
        public HttpWrapperException(HttpStatusCode code, string message, int hr)
            : base((int) code, message, hr)
        {
        }
    }
}