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
            dtgCandidate.ItemsSource = candidateProfileService.GetCandidateProfiles();
            cmbJobPosting.ItemsSource = jobPostingService.GetJobPostings();
            cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            cmbJobPosting.SelectedValuePath = "PostingId";
        }

        private void dtgCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid? dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
