using CandidateManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext _context;
        private static JobPostingDAO instance = new();

        public static JobPostingDAO Instance
        {
            get
            {
                instance ??= new JobPostingDAO();
                return instance;
            }
        }

        public JobPostingDAO()
        {
            _context = new CandidateManagementContext();
        }

        public JobPosting? GetJobPosting(string jobId)
        {
            return _context.JobPostings.SingleOrDefault(x => x.PostingId == jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
            return _context.JobPostings.ToList();   
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting? existingJobPosting = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (existingJobPosting == null)
                {
                    _context.JobPostings.Add(jobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting? existingJobPosting = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (existingJobPosting != null)
                {
                    _context.JobPostings.Remove(jobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting? existingJobPosting = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (existingJobPosting != null)
                {
                    _context.Entry(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

    }
}
