using RemoteAction.Common;
using RemoteAction.Config;
using RemoteAction.PcAction.Modal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.PcAction
{
    public class ExecuteAppAction : BaseAction
    {
        public List<ExeAppConfig> appList = new List<ExeAppConfig>();

        public ExecuteAppAction()
        {
            var exeList = AppConfigManger.GetConfig().ActionConfig.ExecuteAppActionConfig.ExeAppConfig;
            if (exeList != null)
                this.appList = exeList;
        }

        public override string ActionKey => "ExecuteApp";

        public override string ActionName => "打開電腦應用";

        public override string Description => "";

        public override PcActionResult Execute(PcActionParam param)
        {
            var p = param.ConvertParam<AppExecuteAppParam>();
            var appName = ChineseConvertHelper.ToTraditional(p.AppName);
            var appInfo = appList.SingleOrDefault(x => ChineseConvertHelper.ToTraditional(x.AppName) == appName);

            if (appInfo != null)
            {
                if(!File.Exists(appInfo.Path))
                {
                    return new PcActionResult()
                    {
                        Msg = $"電腦上的{appName}未安裝!",
                        Success = true
                    };
                }

                Process.Start(appInfo.Path);
                return new PcActionResult()
                {
                    Msg = $"電腦{appName}打開啦!",
                    Success = true
                };
            }

            return new PcActionResult()
            {
                Msg = $"你所講應用{appName}未設定!",
                Success = true
            };
        }

    }

    public class AppExecuteAppParam : PcActionParam
    {
        public string AppName { get; set; }
    }
}
