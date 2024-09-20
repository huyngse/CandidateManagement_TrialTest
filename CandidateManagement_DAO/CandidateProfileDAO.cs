using CandidateManagement_BusinessObject;
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
    }
}
