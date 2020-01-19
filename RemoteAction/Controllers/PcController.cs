using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RemoteAction.Common;
using RemoteAction.Config;
using RemoteAction.Filter;
using RemoteAction.PcAction;
using RemoteAction.PcAction.Modal;

namespace RemoteAction.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PcController : ControllerBase
    {
        public PcController()
        {
            
        }

        [AuthorizeActionFilter]
        [HttpGet]
        public PcActionResult AutoAction(string msg)
        {
            if(!string.IsNullOrEmpty(msg))
                msg = ChineseConvertHelper.ToTraditional(msg);

            Console.WriteLine($"语音:{msg}");

            var result = new PcActionResult()
            {
                Msg = "我冇聽明你想做咩!",
                Success = false
            };

            if (!string.IsNullOrEmpty(msg))
            {
                if (this.CheckKeyWork(msg, new string[] { "取消" }, new string[] { "關機", "電腦" }))
                    result = new CancelShutdownAction().Execute(null);
                else if (this.CheckKeyWork(msg, new string[] { "關" }, new string[] { "馬上", "立即", "即刻" }))
                    result = new ShutdownNowAction().Execute(null);
                else if (this.CheckKeyWork(msg, new string[] { "分鐘" }, new string[] { "關機", "電腦" }))
                {
                    string minute = System.Text.RegularExpressions.Regex.Replace(msg, @"[^0-9]+", "");
                    result = new ShutdownWithDelayAction().Execute(new ShutdownDelayParam()
                    {
                        Minute = Convert.ToInt32(minute)
                    });
                }
                else if (this.CheckKeyWork(msg, new string[] { "打開" }, null))
                {
                    var appName = msg.Substring(msg.IndexOf("打開") + 2);
                    result = new ExecuteAppAction().Execute(new AppExecuteAppParam()
                    {
                        AppName = appName
                    });
                }
            }

            return result;
        }

        private bool CheckKeyWork(string msg, string[] keyword, string[] optKeyword )
        {
            foreach (var key in keyword)
            {
                if (!msg.Contains(key))
                    return false;
            }

            if (optKeyword == null || optKeyword.Length <= 0)
                return true;

            foreach(var key in optKeyword)
            {
                if (msg.Contains(key))
                    return true;
            }
            return false;
        }

        [AuthorizeActionFilter]
        [HttpPost]
        public PcActionResult DoAction([FromBody]PcActionParam param)
        {
            var action = PcActionManager.Default.GetActionByKey(param.ActionKey);
            return action.Execute(param);
        }
    }
}
