using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO
{
    public class Materiel: Crud<Materiel>
    {
        public Materiel()
        {

        }

        public Materiel(int idmateriel, int fk_idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            Idmateriel = idmateriel;
            FK_Idcategorie = fk_idcategorie;
            Nommateriel = nommateriel;
            Referenceconstructeurmateriel = referenceconstructeurmateriel;
            Codebarreinventaire = codebarreinventaire;

        }

        public Categorie UneCategorie { get; set; }


        public int Idmateriel { get; set; }
        public int FK_Idcategorie { get; set; }
        public string Nommateriel { get; set; }
        public string Referenceconstructeurmateriel { get; set; }
        public string Codebarreinventaire { get; set; }

        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Materiel VALUES({this.Idmateriel},{this.FK_Idcategorie},'{this.Nommateriel}','{this.Referenceconstructeurmateriel}','{this.Codebarreinventaire}')");
        }

        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Materiel WHERE idmateriel = ({this.Idmateriel})");
        }

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire from materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel e = new Materiel(int.Parse(row["idmateriel"].ToString()), int.Parse(row["idcategorie"].ToString()), (String)row["nommateriel"], (String)row["referenceconstructeurmateriel"], (String)row["codebarreinventaire"]);
                    lesMateriels.Add(e);
                }
            }
            return lesMateriels;
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Materiel WHERE idmateriel = ({this.Idmateriel})");
        }

        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Materiel SET nommateriel = '{this.Nommateriel}', referenceconstructeurmateriel = '{this.Referenceconstructeurmateriel}', codebarreinventaire = '{this.Codebarreinventaire}'  WHERE idmateriel  = ({this.Idmateriel})");
        }

        public static int RecupeId()
        {
            DataAccess dat = new DataAccess();
            dat.OpenConnection();
            DataTable dt = dat.GetData("SELECT nextval('materiel_idmateriel_seq'::regclass)\"IDMAT\" FROM materiel");
            int result = Convert.ToInt32(dt.Rows[0]["IDMAT"]);
            return result;
        }
    }
}
