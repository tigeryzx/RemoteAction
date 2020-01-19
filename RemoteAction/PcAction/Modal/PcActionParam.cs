using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction.Modal
{
    public class PcActionParam
    {
        public string ActionKey { get; set; }

        public string Param { get; set; }

        public T ConvertParam<T>()
            where T : PcActionParam
        {
            if (this.GetType().Equals(typeof(T)))
                return (T)this;

            if (string.IsNullOrEmpty(this.Param))
                throw new ArgumentNullException("请求中原始参数为空");

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(this.Param);

            if (result == null)
                throw new ArgumentNullException("尝试获取动作参数，但JSON解析失败");

            return result;
        }
    }
}
