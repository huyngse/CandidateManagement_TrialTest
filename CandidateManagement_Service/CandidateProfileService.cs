using CandidateManagement_BusinessObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        public CandidateProfileService()
        {
            candidateProfileRepo = new CandidateProfileRepo();
        }
        public CandidateProfile? GetCandidateProfile(string id)
        {
            return candidateProfileRepo.GetCandidateProfile(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return candidateProfileRepo.GetCandidateProfiles();
        }
    }
}
