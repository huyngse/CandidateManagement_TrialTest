using CandidateManagement_BusinessObject;
using CandidateManagement_Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService hRAccountService;
        public MainWindow()
        {
            InitializeComponent();
            hRAccountService = new HRAccountService();
       
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var account = hRAccountService.GetAccountByEmail(txtEmail.Text);
            if (account != null)
            {
                if (account.Password == txtPassword.Password)
                {
                    if (account.MemberRole == 1)
                    {
                        JobPostingWindow jobPostingWindow = new JobPostingWindow();
                        jobPostingWindow.Show();
                    } else
                    {
                        MessageBox.Show("Account doesn't have permission", "Alert Title", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else
                {
                    MessageBox.Show("Password isn't correct", "Alert Title", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Account doesn't exist", "Alert Title", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtPasswordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e); // Call the login button click event
            }
        }
    }
}