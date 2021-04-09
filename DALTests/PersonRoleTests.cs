using BlazorApp1.FakeDAL2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DALTests
{
    [TestClass]
    public class PersonRoleTests
    {
        [TestMethod]
        public void ThereArePersonRoles()
        {
            PersonRoleDAL prd = new PersonRoleDAL();
            Assert.IsTrue(prd.GetPersonRoles().Count() > 0);
        }
    }

}
