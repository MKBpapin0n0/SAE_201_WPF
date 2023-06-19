using Microsoft.VisualStudio.TestTools.UnitTesting;
using MATINFO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO.Tests
{
    [TestClass()]
    public class PersonnelTests
    {

        Personnel personnelTest = new Personnel(0, "TestEmail", "TestNom", "TestPrenom");

        [TestMethod()]
        public void CreateTest()
        {
            personnelTest.Create();

            bool materielTrouve = false;
            int idGenere = 0;

            foreach (Personnel unPersonnel in personnelTest.FindAll())
            {
                if (unPersonnel.Emailpersonnel == "TestEmail" && unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom")
                {
                    materielTrouve = true;
                    idGenere = unPersonnel.Idpersonnel;
                    break;
                }
            }

            Assert.IsTrue(materielTrouve);
            new Personnel(idGenere, "", "", "").Delete();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            personnelTest.Create();

            int idGenere = 0;

            foreach(Personnel unPersonnel in personnelTest.FindAll())
            {
                if (unPersonnel.Emailpersonnel == "TestEmail" && unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom")
                {
                    idGenere = unPersonnel.Idpersonnel;
                    break;
                }
            }

            new Personnel(idGenere, "", "", "").Delete();

            foreach (Personnel unPersonnel in personnelTest.FindAll())
            {
                if (unPersonnel.Emailpersonnel == "TestEmail" && unPersonnel.Nompersonnel == "TestNom" && unPersonnel.Prenompersonnel == "TestPrenom")
                {
                    Assert.Fail();
                }
            }
        }
    }
}