using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab5.Views
{
    public partial class RegexWindow : Window
    {
        TextBox regexTextBox;
        public RegexWindow()
        {
            InitializeComponent();

            regexTextBox = this.FindControl<TextBox>("RegexTextBox");

            this.FindControl<Button>("OkBtn").Click += delegate
            {
                Close(regexTextBox.Text);
            };

            this.FindControl<Button>("CancelBtn").Click += delegate
            {
                Close();
            };

#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void setRegexText(string regexPattern) => regexTextBox.Text = regexPattern;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
