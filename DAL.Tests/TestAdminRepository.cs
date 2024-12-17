using Films.DAL.Entities;
using Films.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.DAL.Tests
{
    class TestAdminRepository
        : BaseRepository<Admin>
    {
        public TestAdminRepository(DbContext context)
            : base(context)
        {
        }
    }
}