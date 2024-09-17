using CandidateManagement_BusinessObject;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public class HRAccountRepo : IHRAccountRepo
    {

        public Hraccount? GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);

        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
