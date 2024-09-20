using CandidateManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;
        private static HRAccountDAO? instance;
        public HRAccountDAO()
        {
            context = new();
        }

        public static HRAccountDAO Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }
        public Hraccount? GetHraccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
        }
        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
