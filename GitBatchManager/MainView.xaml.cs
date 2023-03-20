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
            ViewModel.ErrorOutput += ViewModel_ErrorOutput;
            ViewModel.Initialize(this);
        }

        private MainViewModel ViewModel => DataContext as MainViewModel;

        private void ViewModel_ErrorOutput(object sender, string output)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ErrorMessageTextBox.Text += $"{output}\n";
                ErrorMessageTextBox.ScrollToEnd();
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
            ViewModel.IsLogVisible = false;
        }

        private void ExpandLogButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.IsLogVisible = true;
        }
    }
}
