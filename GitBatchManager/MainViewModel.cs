using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GitBatchManager.Business;
using GitBatchManager.Utils;

namespace GitBatchManager
{
    class MainViewModel : BindingPropertyBase
    {
        public MainViewModel()
        {
            AddNugetItemCommand = new ActionCommand(AddNugetItem);
            DeleteNugetItemCommand = new ActionCommand<RepositoryItem>(DeleteNugetItem);
        }

        public void Initialize(MainView mainView)
        {
            _view = mainView;
            var repositories = GetRepositories();
            NugetReplaceItems = new ObservableCollection<RepositoryItem>(repositories.Select(i => new RepositoryItem(i)));
        }
        private List<Repository> GetRepositories()
        {
            var repositories = RepositoriesConfigs.GetRepositories();
            if (!repositories.Any())
            {
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Camera.Display.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Systems.InkAccelerator.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Systems.InkAccelerator.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Systems.Power.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Setting.Camera.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Setting.Audio.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Network.DeviceCard.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Network.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Device.Properties.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.UnRedo.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Windows.EasyStyles.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.NetPenetration.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.ota.core.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/RTC.NetEase.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.InstalledApps.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.net.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Files.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.webview.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Setting.Component.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.serviceentry.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.appstarter.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Channel.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Configurations.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Windows.Controls.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Storage.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Startup.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/h3c.browser.core.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Board.Core.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Windows.Core.git"));
                repositories.Add(new Repository(@"git@10.214.20.41:windowsappgroup/WindowsComponents/H3C.Log.git"));
            }

            return repositories;
        }

        #region 添加Nuget

        public ICommand AddNugetItemCommand { get; }

        private void AddNugetItem()
        {
            NugetReplaceItems.Add(new RepositoryItem());
        }

        #endregion
        #region 删除Nuget

        public ICommand DeleteNugetItemCommand { get; }

        private void DeleteNugetItem(RepositoryItem item)
        {
            NugetReplaceItems.Remove(item);
            RepositoriesConfigs.SaveSolutions(NugetReplaceItems.Select(i=>i.GetRepository()).ToList());
        }
        public ObservableCollection<RepositoryItem> NugetReplaceItems
        {
            get => _nugetReplaceItems;
            set
            {
                _nugetReplaceItems = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private ObservableCollection<RepositoryItem> _nugetReplaceItems;
        private MainView _view;
    }
}
