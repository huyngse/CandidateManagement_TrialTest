using CandidateManagement_BusinessObject;
using CandidateManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo _repo;
        public HRAccountService()
        {
            _repo = new HRAccountRepo();
        }
        public Hraccount? GetAccountByEmail(string email)
        {
            return _repo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetAccounts()
        {
            return _repo.GetHraccounts();
        }
    }
}
