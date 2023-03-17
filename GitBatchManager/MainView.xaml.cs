using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GitBatchManager.Business;

namespace GitBatchManager
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainView_Loaded;
            ViewModel.Initialize(this);
        }
        private MainViewModel ViewModel => DataContext as MainViewModel;

        private async void SyncButton_OnClick(object sender, RoutedEventArgs e)
        {
            LogGrid.Visibility = Visibility.Visible;
            ExpandLogButton.Visibility = Visibility.Visible;
            var items = ViewModel.NugetReplaceItems;
            foreach (var repositoryItem in items)
            {
                var synchronizer = new RespositoryGitSynchronizer(repositoryItem.GetRepository());
                await synchronizer.SyncAsync(ShowCmdResult);
            }
        }

        private void ShowCmdResult(string output)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ErrorMessageTextBox.Text += $"{output}\n";
            });
        }
        private void ReplacingItem_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement uiElement && uiElement.DataContext is RepositoryItem item)
            {
                if (e.OriginalSource is CheckBox || e.OriginalSource is TextBox || e.OriginalSource is Button)
                {
                    return;
                }
                item.IsSelected = !item.IsSelected;
            }
        }

        private void FoldLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            LogGrid.Visibility = Visibility.Collapsed;
            ExpandLogButton.Visibility = Visibility.Visible;
        }

        private void ExpandLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            LogGrid.Visibility = Visibility.Visible;
        }
    }
}
