using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);

        public CandidateProfile? GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
