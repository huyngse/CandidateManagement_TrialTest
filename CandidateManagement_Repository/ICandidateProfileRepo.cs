﻿using CandidateManagement_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repository
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidateProfiles();
        public CandidateProfile? GetCandidateProfile(string id);
    }
}
