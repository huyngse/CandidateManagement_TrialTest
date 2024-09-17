using CandidateManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public interface IJobPostingService
    {
        public JobPosting? GetJobPosting(string jobId);
        public List<JobPosting> GetJobPostings();
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
