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
        public CandidateProfile? GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();
    }
}
