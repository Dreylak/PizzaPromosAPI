using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests
{
    public class TestBase
    {
        protected ApplicationDbContext DbContext { get; private set; }

        public TestBase()
        {
            InitiallizeDbContext();
        }

        private void InitiallizeDbContext()
        {
            string dbName = Guid.NewGuid().ToString();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: dbName).Options;
            DbContext = new ApplicationDbContext(options);
        }
    }
}
