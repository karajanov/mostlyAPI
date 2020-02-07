using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class EnrolledInRepository : Repository<EnrolledIn>, IEnrolledInRepository
    {
        public EnrolledInRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
        }
    }
}
