using Microsoft.VisualStudio.TestTools.UnitTesting;
using MATINFO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

            foreach (Personnel unPersonnel in personnelTest.FindAll())
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


        [TestMethod()]
        public void UpdateTest()
        {
            personnelTest.Create();
            personnelTest.Nompersonnel = "Prout";
            personnelTest.Prenompersonnel = "Feur";
            personnelTest.Emailpersonnel = "emailTest.feur";
            personnelTest.Update();
            DataAccess data = new DataAccess();
            data.OpenConnection();
            DataTable datas = data.GetData("SELECT idpersonnel, emailpersonnel, nompersonnel,prenompersonnel FROM personnel WHERE idpersonnel = 0");
            Personnel personneVerif = new Personnel((int)datas.Rows[0]["idpersonnel"], datas.Rows[0]["emailpersonnel"].ToString(), datas.Rows[0]["nompersonnel"].ToString(), datas.Rows[0]["prenompersonnel"].ToString());
            personnelTest.Delete();
            Assert.AreEqual(personneVerif, personnelTest, "Erreur lors de l'update");

        }
    }
}