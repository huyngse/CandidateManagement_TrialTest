using CandidateManagement_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public interface IJobPostingRepo
    {
        public JobPosting? GetJobPosting(string jobId);
        public List<JobPosting> GetJobPostings();
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);

    }
}
