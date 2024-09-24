using CandidateManagement_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO? instance;
        public CandidateProfileDAO()
        {
            context = new();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }
        public CandidateProfile? GetCandidateProfile(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(x => x.CandidateId == id);
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existingModel = GetCandidateProfile(candidateProfile.CandidateId);
            try
            {
                if (existingModel == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existingModel = GetCandidateProfile(candidateProfile.CandidateId);
            try
            {
                if (existingModel != null)
                {
                    context.CandidateProfiles.Remove(existingModel);
                    context.SaveChanges();
                    isSuccess = true;
                }
            } catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existingModel = GetCandidateProfile(candidateProfile.CandidateId);
            try
            {
                if (existingModel != null)
                {
                    existingModel.Fullname = candidateProfile.Fullname;
                    existingModel.ProfileUrl = candidateProfile.ProfileUrl;
                    existingModel.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                    existingModel.Birthday = candidateProfile.Birthday;
                    existingModel.Posting = candidateProfile.Posting;
                    existingModel.PostingId = candidateProfile.PostingId;
                    context.SaveChanges();
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
