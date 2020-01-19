using RemoteAction.PcAction.Modal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction
{
    public class CancelShutdownAction : BaseAction
    {
        public override string ActionKey => "CancelShutdown";

        public override string ActionName => "取消电脑关机";

        public override string Description => "";

        public override PcActionResult Execute(PcActionParam param)
        {
            Process.Start("shutdown", "-a");
            return new PcActionResult()
            {
                Msg = $"电脑关机已取消!",
                Success = true
            };
        }
    }
}
