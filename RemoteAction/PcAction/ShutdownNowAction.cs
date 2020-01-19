using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteAction.Config;
using RemoteAction.PcAction.Modal;

namespace RemoteAction.PcAction
{
    public class ShutdownNowAction : ShutdownWithDelayAction
    {
        public override string ActionKey => "ShutdownNow";

        public override string ActionName => "电脑立即关机";

        public override string Description => "";

        protected override ShutdownDelayParam ConvertParam(PcActionParam param)
        {
            return new ShutdownDelayParam()
            {
                Minute = AppConfigManger.GetConfig().ActionConfig.ShutdownNowActionConfig.DefaultShutdownMinute
            };
        }
    }
}
