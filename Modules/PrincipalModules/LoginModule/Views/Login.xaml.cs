using System.Windows;

namespace LoginModule.Views
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login 
    {
        public Login()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBox.Text = PasswordBox.Password;
        }
    }
}
