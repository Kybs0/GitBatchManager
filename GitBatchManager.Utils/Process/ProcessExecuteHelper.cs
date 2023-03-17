using System.Diagnostics;

namespace GitBatchManager.Utils
{
    /// <summary>
    /// 进程执行辅助类
    /// </summary>
    public class ProcessExecuteHelper
    {
        /// <summary>
        /// 执行参数
        /// </summary>
        /// <param name="exefile"></param>
        /// <param name="args"></param>
        /// <param name="useShell"></param>
        /// <param name="creatNoWindow"></param>
        public static void StartProcess(string exefile, string args, bool useShell = false, bool creatNoWindow = true)
        {
            var processInfo = new ProcessStartInfo
            {
                CreateNoWindow = creatNoWindow,
                UseShellExecute = useShell,
                WindowStyle = ProcessWindowStyle.Minimized,
                FileName = exefile,
                Arguments = args,
            };
            var process = Process.Start(processInfo);
            process.WaitForExit();
            process.Close();
        }
        /// <summary>
        /// 执行参数
        /// </summary>
        /// <param name="exefile"></param>
        public static void StartProcess(string exefile)
        {
            var processInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Minimized,
                FileName = exefile,
                Arguments = string.Empty,
            };
            var process = Process.Start(processInfo);
            process?.Close();
        }
    }
}
