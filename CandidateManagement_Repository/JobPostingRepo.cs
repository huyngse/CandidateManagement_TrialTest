using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.DeleteJobPosting(jobPosting);
   
        public JobPosting? GetJobPosting(string jobId) => JobPostingDAO.Instance.GetJobPosting(jobId);

        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();

        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
    }
}
