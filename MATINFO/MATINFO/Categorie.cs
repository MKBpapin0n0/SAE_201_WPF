using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//V.AB

namespace MATINFO
{
    public class Categorie : Crud<Categorie>
    {

        public ObservableCollection<Materiel> lesMateriels { get; set; }


        public Categorie()
        {

        }

        public Categorie(int idcategorie, string nomcategorie)
        {
            Idcategorie = idcategorie;
            Nomcategorie = nomcategorie;
            lesMateriels = new ObservableCollection<Materiel>();
        }

        public int Idcategorie { get; set; }
        public string Nomcategorie { get; set; }

        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from categorie_materiel";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie e = new Categorie(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesCategories.Add(e);
                }
            }
            return lesCategories;
        }

        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Categorie_materiel VALUES({this.Idcategorie},'{this.Nomcategorie}')");
        }

        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Categorie_materiel WHERE idcategorie = ({this.Idcategorie})");
        }

        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Categorie_materiel SET nomcategorie = '{this.Nomcategorie}'  WHERE idcategorie  = {this.Idcategorie}");
        }

        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Categorie_materiel WHERE idcategorie = {this.Idcategorie}");
        }

        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
        public void Remove(Materiel materiel)
        {
            this.lesMateriels.Remove(materiel);
        }
        public static int RecupeId()
        {
            DataAccess dat = new DataAccess();
            dat.OpenConnection();
            DataTable dt = dat.GetData("SELECT nextval('categorie_materiel_idcategorie_seq'::regclass)\"Tu\" FROM Categorie_materiel");
            int result = Convert.ToInt32(dt.Rows[0]["Tu"]);
            return result;
        }
    }
}
