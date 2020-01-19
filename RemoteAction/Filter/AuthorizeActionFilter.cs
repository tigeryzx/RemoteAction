using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RemoteAction.Config;
using RemoteAction.PcAction.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.Filter
{
    public class AuthorizeActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("token"))
            {
                var token = context.HttpContext.Request.Headers["token"];
                if (token != AppConfigManger.GetConfig().Token)
                    context.Result = new JsonResult(new PcActionResult()
                    {
                        Msg = "权限验证失败",
                        Success = false
                    });
            }
            else
                context.Result = new JsonResult(new PcActionResult()
                {
                    Msg = "未设置权限信息",
                    Success = false
                });
        }
    }
}
