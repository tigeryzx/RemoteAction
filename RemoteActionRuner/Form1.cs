using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteActionRuner
{
    public partial class Form1 : Form
    {
        string appName = "RemoteAction";

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "远程控制服务";
            this.notifyIcon1.ShowBalloonTip(1000, "提示", "远程控制服务已运行中", ToolTipIcon.Info);

            this.killService();

            Process pro = new Process();
            pro.StartInfo.FileName = $"{appName}.exe";//程序全路径名称
            pro.StartInfo.Arguments = "";//命令行参数
            pro.StartInfo.UseShellExecute = true;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//隐藏可视化窗体
            pro.Start();
        }

        void killService()
        {
            System.Diagnostics.Process[] app = System.Diagnostics.Process.GetProcessesByName(appName);
            if (app.Length > 0) app[0].Kill();
        }

        private void 关闭服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.killService();
            this.Close();
        }
    }
}
