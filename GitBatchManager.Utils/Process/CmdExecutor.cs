using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GitBatchManager.Utils
{
    public static class CmdExecutor
    {
        /// <summary>
        /// 以后台进程的形式执行应用程序（d:\*.exe）
        /// </summary>
        private static Process StartNewtProcess(string exe)
        {
            var process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = exe;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            return process;
        }

        /// <summary>
        /// 执行CMD命令
        /// </summary>
        public static string Run(string cmd)
        {
            using var process = StartNewtProcess("cmd.exe");
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
            string outStr = process.StandardOutput.ReadToEnd();
            return outStr;
        }

        /// <summary>
        /// 执行CMD语句,实时获取cmd输出结果，输出到call函数中
        /// </summary>
        /// <param name="cmdList">要执行的CMD命令</param>
        /// <param name="lineOutputAction">命令行即时输出</param>
        public static async Task<string> RunAsync(List<string> cmdList, Action<string> lineOutputAction)
        {
            return await Task.Run(() =>
            {
                using var process = StartNewtProcess("cmd.exe");
                cmdList.ForEach(process.StandardInput.WriteLine);
                process.StandardInput.WriteLine("exit");

                string outStr = "";
                string line;
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    if (!line.EndsWith(">exit"))
                    {
                        lineOutputAction?.Invoke(line);
                        outStr += line + "\r\n";
                    }
                }
                return outStr;
            });
        }

        /// <summary>
        /// 执行CMD语句,实时获取cmd输出结果，输出到call函数中
        /// </summary>
        /// <param name="cmd">要执行的CMD命令</param>
        /// <param name="lineOutputAction">命令行即时输出</param>
        public static async Task<string> RunAsync(string cmd, Action<string> lineOutputAction)
        {
            return await RunAsync(new List<string>() { cmd }, lineOutputAction);
        }
    }
}
