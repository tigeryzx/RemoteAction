using RemoteAction.PcAction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction
{
    public class PcActionManager
    {
        private static PcActionManager _PcActionManager;

        public static PcActionManager Default
        {
            get
            {
                if (_PcActionManager == null)
                    _PcActionManager = new PcActionManager();
                return _PcActionManager;
            }
        }

        public List<BaseAction> ActionList = new List<BaseAction>();

        protected PcActionManager()
        {
            this.ActionList.Add(new ShutdownNowAction());
            this.ActionList.Add(new ShutdownWithDelayAction());
            this.ActionList.Add(new CancelShutdownAction());
        }

        public IBaseAction GetActionByKey(string key)
        {
            var action = this.ActionList.SingleOrDefault(x => x.ActionKey.ToLower() == key.ToLower());
            if (action == null)
                throw new Exception($"未找到Key为[{key}]的动作");
            return action;
        }


    }
}
