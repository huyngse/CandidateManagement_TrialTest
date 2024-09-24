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
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateProfileService candidateProfileService;
        private IJobPostingService jobPostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            candidateProfileService = new CandidateProfileService();
            jobPostingService = new JobPostingService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void dtgCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid? dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                if (row != null)
                {
                    DataGridCell? rowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                    if (rowColumn != null)
                    {
                        string CandidateId = ((TextBlock)rowColumn.Content).Text;
                        CandidateProfile? candidateProfile = candidateProfileService.GetCandidateProfile(CandidateId);
                        if (candidateProfile != null)
                        {
                            txtCandidateId.Text = candidateProfile.CandidateId;
                            txtFullName.Text = candidateProfile.Fullname;
                            dpkBirthDay.SelectedDate = candidateProfile.Birthday;
                            txtImageUrl.Text = candidateProfile.ProfileUrl;
                            rtbDescription.Document.Blocks.Clear();
                            rtbDescription.Document.Blocks.Add(new Paragraph(new Run(candidateProfile.ProfileShortDescription)));
                            cmbJobPosting.SelectedValue = candidateProfile.PostingId;
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            dtgCandidate.ItemsSource = candidateProfileService.GetCandidateProfiles();
            cmbJobPosting.ItemsSource = jobPostingService.GetJobPostings();
            cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            cmbJobPosting.SelectedValuePath = "PostingId";
            txtCandidateId.Text = string.Empty;
            txtFullName.Text = string.Empty;
            dpkBirthDay.SelectedDate = DateTime.Now;
            txtImageUrl.Text = string.Empty;
            rtbDescription.Document.Blocks.Clear();
            cmbJobPosting.SelectedValue = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting? jobPosting = cmbJobPosting.SelectedItem as JobPosting;
            if (jobPosting != null)
            {
                CandidateProfile candidateProfile = new()
                {
                    Birthday = dpkBirthDay.SelectedDate,
                    CandidateId = txtCandidateId.Text,
                    Fullname = txtFullName.Text,
                    PostingId = jobPosting.PostingId,
                    ProfileShortDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text,
                    ProfileUrl = txtImageUrl.Text,
                };
                if (candidateProfileService.AddCandidateProfile(candidateProfile))
                {
                    MessageBox.Show("Add successful!");
                    LoadData();
                } else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new()
            {
                CandidateId = txtCandidateId.Text,
            };
            if (candidateProfileService.DeleteCandidateProfile(candidateProfile))
            {
                MessageBox.Show("Delete successful!");
                LoadData();
            } else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting? jobPosting = cmbJobPosting.SelectedItem as JobPosting;
            if (jobPosting != null)
            {
                CandidateProfile candidateProfile = new()
                {
                    Birthday = dpkBirthDay.SelectedDate,
                    CandidateId = txtCandidateId.Text,
                    Fullname = txtFullName.Text,
                    PostingId = jobPosting.PostingId,
                    ProfileShortDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text,
                    ProfileUrl = txtImageUrl.Text,
                };
                if (candidateProfileService.UpdateCandidateProfile(candidateProfile))
                {
                    MessageBox.Show("Update successful!");
                    LoadData();
                } else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }
    }
}
