using System.Collections;
using System.Collections.Generic;
using IvyTalk.AspNet.Formatting;

namespace IvyTalk.AspNet
{
    /// <summary>
    /// 暂时没用
    /// </summary>
    public class HttpConfiguration
    {
        public HttpConfiguration()
        {
            MediaTypeFormatters = new MediaTypeFormatterCollection();
        }

        /// <summary>
        /// 格式化器
        /// </summary>
        public MediaTypeFormatterCollection MediaTypeFormatters { get; }
    }
}