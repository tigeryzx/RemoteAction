using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction.Modal
{
    public interface IBaseAction
    {
        PcActionResult Execute(PcActionParam param);
    }
}
