using RemoteAction.PcAction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction
{
    public abstract class BaseAction : IBaseAction
    {
        public abstract string ActionKey { get; }

        public abstract string ActionName { get; }

        public abstract string Description { get; }

        public abstract PcActionResult Execute(PcActionParam param);
    }
}
