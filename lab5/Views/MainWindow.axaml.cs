using Avalonia.Controls;
using lab5.ViewModels;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFileBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                    context.LoadFile(path[0]);

            };

            this.FindControl<Button>("SaveFileBtn").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                if (path != null)
                    context.SaveFile(path);

            };

            this.FindControl<Button>("SetRegexBtn").Click += async delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                var regDialog = new RegexWindow();
                regDialog.setRegexText(context.RegexPattern);
                string? str = await regDialog.ShowDialog<string?>((Window)this.VisualRoot);
                if(str!=null)
                {
                    context.RegexPattern = str;
                }
            };
        }
    }
}
