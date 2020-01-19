using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.Config
{
    public class ActionConfig
    {
        public ShutdownNowActionConfig ShutdownNowActionConfig { get; set; }

        public ExecuteAppActionConfig ExecuteAppActionConfig { get; set; }
    }
}
