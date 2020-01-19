using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RemoteAction.PcAction.Modal;

namespace RemoteAction.PcAction
{
    public class ShutdownWithDelayAction : BaseAction
    {
        public override string ActionKey => "ShutdownDelay";

        public override string ActionName => "电脑定时关机";

        public override string Description => "可设定电脑在多少分钟后关机";

        protected PcActionResult Shutdown(ShutdownDelayParam param)
        {
            if (param.Minute < 0)
                throw new Exception("关机分钟数不能少于0");

            var second = param.Minute * 60;
            var shutdownTime = DateTime.Now.AddMinutes(param.Minute);
            Process.Start("shutdown", "-s -t " + second);
            return new PcActionResult()
            {
                Msg = $"电脑将于{param.Minute}分钟後，即{shutdownTime.Hour}點{shutdownTime.Minute}分時关機!",
                Success = true
            };
        }

        protected virtual ShutdownDelayParam ConvertParam(PcActionParam param)
        {
            return param.ConvertParam<ShutdownDelayParam>();
        }

        public override PcActionResult Execute(PcActionParam param)
        {
            var p = this.ConvertParam(param);
            return this.Shutdown(p);
        }
    }

    public class ShutdownDelayParam : PcActionParam
    {
        public int Minute { get; set; }
    }
}
