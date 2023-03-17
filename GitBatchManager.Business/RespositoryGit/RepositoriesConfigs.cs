using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GitBatchManager.Utils;
using Newtonsoft.Json;

namespace GitBatchManager.Business
{
    public static class RepositoriesConfigs
    {
        private const string UserOperationSection = "UserOperation";
        /// <summary>
        /// 当前解决方案
        /// </summary>
        private const string RepositoriesKey = "Repositories";
        public static List<Repository> GetRepositories()
        {
            var value = IniFileHelper.IniReadValue(UserOperationSection, RepositoriesKey);
            if (string.IsNullOrEmpty(value))
            {
                return new List<Repository>();
            }
            var solutions = JsonConvert.DeserializeObject<List<Repository>>(value);
            return solutions;
        }
        public static void SaveSolutions(List<Repository> solutionFiles)
        {
            var jsonData = JsonConvert.SerializeObject(solutionFiles);
            IniFileHelper.IniWriteValue(UserOperationSection, RepositoriesKey, jsonData);
        }

        private const string YeekitSettingSectionKey = "UiHabits";

        #region 窗口大小及位置

        /// <summary>
        /// 语言方向
        /// </summary>
        private const string WindowLocationKey = "WindowLocation";
        public static WindowLocationSizeMode GetWindowLocation()
        {
            var valueJson = IniFileHelper.IniReadValue(YeekitSettingSectionKey, WindowLocationKey);
            if (string.IsNullOrEmpty(valueJson))
            {
                return null;
            }
            var windowLocationSize = JsonConvert.DeserializeObject<WindowLocationSizeMode>(valueJson);
            return windowLocationSize;
        }

        public static void SaveWindowLocation(WindowLocationSizeMode locationSize)
        {
            var jsonData = JsonConvert.SerializeObject(locationSize);
            IniFileHelper.IniWriteValue(YeekitSettingSectionKey, WindowLocationKey, jsonData);
        }

        #endregion
    }
    public class WindowLocationSizeMode
    {
        public double Left { get; }
        public double Top { get; }
        public double ActualWidth { get; }
        public double ActualHeight { get; }
        public WindowState WindowState { get; set; }
        public WindowLocationSizeMode(double left, double top, double actualWidth, double actualHeight, WindowState windowState)
        {
            Left = left;
            Top = top;
            ActualWidth = actualWidth;
            ActualHeight = actualHeight;
            WindowState = windowState;
        }
    }
}
