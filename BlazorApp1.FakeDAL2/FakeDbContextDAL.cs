using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class FakeDbContextDAL
    {
        //public void InitDb()
        //{
        //    var options = new DbContextOptionsBuilder<FakeDbContext>()
        //       .UseInMemoryDatabase(databaseName: "Test")
        //       .Options;



        //}

        private readonly FakeDbContext ctx;

        public FakeDbContextDAL()
        {

        }
    }
}
