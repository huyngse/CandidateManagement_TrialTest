using CandidateManagement_BusinessObject;
using CandidateManagement_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void jobPostingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dtgJobPosting.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new()
            {
                PostingId = txtPostId.Text,
                JobPostingTitle = txtTitle.Text,
                Description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text,
                PostedDate = DateTime.Parse(dpkPostDate.Text)
            };
            if (jobPostingService.AddJobPosting(job)) {
                MessageBox.Show("Add successful!");
            } else
            {
                MessageBox.Show("Something went wrong!");

            }
        }
    }
}
