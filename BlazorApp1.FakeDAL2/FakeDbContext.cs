using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.FakeDAL2
{
    public class FakeDbContext : DbContext
    {
        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
    }
}
