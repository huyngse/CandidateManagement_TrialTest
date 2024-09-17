using CandidateManagement_BusinessObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
           return jobPostingRepo.DeleteJobPosting(jobPosting);
        }

        public JobPosting? GetJobPosting(string jobId)
        {
           return jobPostingRepo.GetJobPosting(jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
           return jobPostingRepo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.UpdateJobPosting(jobPosting);
        }
    }
}
