using System;
using System.IO;
using GitBatchManager.Utils;

namespace GitBatchManager.Business
{
    /// <summary>
    /// 用户路径统一管理类
    /// </summary>
    public class UserPath
    {
        public UserPath()
        {
            //AppData
            _appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CustomText.ProjectName);
            //桌面
            _deskTopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PicturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            MultiMediaPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            //安装包
            AppRunningFolder = AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// AppData下项目路径
        /// </summary>
        public string DataFolder => EnsureDirectory(_appDataFolder);

        /// <summary>
        /// 文档
        /// </summary>
        public string DocumentsFolder { get; }

        /// <summary>
        /// 临时文件夹
        /// </summary>
        public string TempFolder => EnsureDirectory(Path.Combine(_appDataFolder, "Temp"));

        /// <summary>
        /// 桌面路径
        /// </summary>
        public string DesktopFolder => EnsureDirectory(_deskTopFolder);

        /// <summary>
        /// 用户配置路径
        /// </summary>
        public string UserIniPath => Path.Combine(DataFolder, "User.ini");

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; }

        /// <summary>
        /// 多媒体
        /// </summary>
        public string MultiMediaPath { get; }

        /// <summary>
        /// 应用运行文件夹
        /// </summary>
        public string AppRunningFolder { get; }

        #region 内部方法

        private string EnsureDirectory(string directory)
        {
            FolderHelper.CreateFolder(directory);
            return directory;
        }

        #endregion

        #region private fields
        private readonly string _appDataFolder;
        private readonly string _deskTopFolder;
        #endregion
    }
}