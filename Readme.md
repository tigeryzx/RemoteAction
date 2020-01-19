### 远程控制电脑操作
起初目的是想利用IOS上的“捷径”应用，利用SIRI配合DDNS来控制电脑远程定时关机，按性质来说只是一个玩具性的项目


#### 基本原理
使用Asp.DotNetCore作为服务端在被控端运行（自运行，不使用IIS等其它WEB服务器），再使用DDNS把电脑公布到外网，再而使用IOS上的SIRI发送API请求控制电脑做一些特定操作。

#### 目前包含功能
起初目的只是想远程关机，后面觉得有趣又搞了些其它功能，目前包含以下功能
+ 立即关机
+ X分钟后关机
+ 打开XX应用
+ ……其余可以自行扩展

#### 项目说明

+ ***RemoteAction*** 为主要的DotNetCore WebApi 项目，使用发布功能发布WIN X64能得到 RemoteAction.exe 这是核心程序
+ ***RemoteActionRuner*** 是一个用来运行起 RemoteAction.exe 的程序，其实直接运行核心程序也是可以的，但有个控制台显示着实在不好看，尝试过使用微软 Dotnet Core 提供专门的 Window Service包来发布，但结果是当以服务形式运行时，API打开电脑第三方应用程序时不显示，所以换成现在这种方式