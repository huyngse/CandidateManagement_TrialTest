using CandidateManagement_BusinessObject;
using CandidateManagement_Service;
using System;
using System.Collections.Generic;
using System.Data;
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
            LoadData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new()
            {
                PostingId = txtPostId.Text,
                JobPostingTitle = txtTitle.Text,
                Description = (new TextRange(
                    rtbDescription.Document.ContentStart,
                    rtbDescription.Document.ContentEnd).Text)
                    .TrimEnd('\r', '\n'),
                PostedDate = DateTime.Parse(dpkPostDate.Text)
            };
            if (jobPostingService.AddJobPosting(job))
            {
                MessageBox.Show("Jost Posting is added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            } else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                if (row != null)
                {
                    if (dataGrid.Columns[0].GetCellContent(row).Parent is DataGridCell rowColumn)
                    {
                        string postingId = ((TextBlock)rowColumn.Content).Text;
                        JobPosting? jobPosting = jobPostingService.GetJobPosting(postingId);
                        if (jobPosting != null)
                        {
                            txtPostId.Text = jobPosting.PostingId;
                            txtTitle.Text = jobPosting.JobPostingTitle;
                            rtbDescription.Document.Blocks.Clear();
                            rtbDescription.Document.Blocks.Add(new Paragraph(new Run(jobPosting.Description)));
                            dpkPostDate.SelectedDate = jobPosting.PostedDate;
                        }
                    }
                }
            }
        }

        private void LoadData()
        {
            dtgJobPosting.ItemsSource = jobPostingService.GetJobPostings();
            txtPostId.Text = String.Empty;
            txtTitle.Text = String.Empty;
            rtbDescription.Document.Blocks.Clear();
            dpkPostDate.SelectedDate = DateTime.Now;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new()
            {
                PostingId = txtPostId.Text,
            };
            if (jobPostingService.DeleteJobPosting(job))
            {
                MessageBox.Show("Jost Posting is deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            } else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new()
            {
                PostingId = txtPostId.Text,
                JobPostingTitle = txtTitle.Text,
                Description = (new TextRange(
                    rtbDescription.Document.ContentStart, 
                    rtbDescription.Document.ContentEnd).Text)
                    .TrimEnd('\r', '\n'),
                PostedDate = DateTime.Parse(dpkPostDate.Text)
            };
            if (jobPostingService.UpdateJobPosting(job))
            {
                MessageBox.Show("Jost Posting is updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            } else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
