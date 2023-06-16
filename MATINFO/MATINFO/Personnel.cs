using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO
{
    public class Personnel : Crud<Personnel>
    {
        public Personnel()
        {
            
        }

        public Personnel(int idpersonnel, string emailpersonnel, string nompersonnel, string prenompersonnel)
        {
            Idpersonnel = idpersonnel;
            Emailpersonnel = emailpersonnel;
            Nompersonnel = nompersonnel;
            Prenompersonnel = prenompersonnel;
        }

        public Attribution UneAttribution { get; set; }

        public int Idpersonnel { get; set; }
        public string Emailpersonnel { get; set; }
        public string Nompersonnel { get; set; }
        public string Prenompersonnel { get; set; }

        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Personnel VALUES({this.Idpersonnel},{this.Emailpersonnel},{this.Nompersonnel},{this.Prenompersonnel})");
        }

        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Personnel WHERE idpersonnel = ({this.Idpersonnel})");
        }

        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, emailpersonnel, nompersonnel, prenompersonnel from personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["emailpersonnel"], (String)row["nompersonnel"], (String)row["prenompersonnel"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Personnel WHERE idpersonnel = ({this.Idpersonnel})");
        }

        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Personnel SET emailpersonnel = '{this.Emailpersonnel}', nompersonnel = '{this.Nompersonnel}', prenompersonnel = '{this.Prenompersonnel}'  WHERE idpersonnel  = ({this.Idpersonnel})");
        }
    }
}
