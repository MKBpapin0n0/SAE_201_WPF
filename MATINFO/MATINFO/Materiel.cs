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
    public class Materiel : Crud<Materiel>
    {
        public Categorie UneCategorie { get; set; }

        public ObservableCollection<Attribution> lesAttributions { get; set; }

        public Materiel()
        {

        }

        /// <summary>
        /// Cette méthode sert a initialiser ce que comporte un matériel
        /// </summary>
        /// <param name="idmateriel">Ce paramètre est l'id du matériel</param>
        /// <param name="fk_idcategorie">Ce paramètre est l'id d'une catégorie</param>
        /// <param name="nommateriel">Ce paramètre est le nom materiel</param>
        /// <param name="referenceconstructeurmateriel">Ce paramètre est la reference du matériel</param>
        /// <param name="codebarreinventaire">Ce paramètre est le code barre d'un matériel</param>
        public Materiel(int idmateriel, int fk_idcategorie, string nommateriel, string referenceconstructeurmateriel, string codebarreinventaire)
        {
            Idmateriel = idmateriel;
            FK_Idcategorie = fk_idcategorie;
            Nommateriel = nommateriel;
            Referenceconstructeurmateriel = referenceconstructeurmateriel;
            Codebarreinventaire = codebarreinventaire;

        }

        public int Idmateriel { get; set; }
        public int FK_Idcategorie { get; set; }
        public string Nommateriel { get; set; }
        public string Referenceconstructeurmateriel { get; set; }
        public string Codebarreinventaire { get; set; }

        /// <summary>
        /// Cette méthode permet d'ajouter un matériel de la table materiel de la BDD
        /// </summary>
        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Materiel VALUES({this.Idmateriel},{this.FK_Idcategorie},'{this.Nommateriel}','{this.Referenceconstructeurmateriel}','{this.Codebarreinventaire}')");
        }

        /// <summary>
        /// Cette méthode permet de retirer un matériel de la table materiel de la BDD
        /// </summary>
        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Materiel WHERE idmateriel = ({this.Idmateriel})");
        }

        /// <summary>
        /// Cette méthode permet de récupérer tous les éléments de la table materiel sous forme de liste
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode permet de d'afficher les matériels de la table materiel de la BDD
        /// </summary>
        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Materiel WHERE idmateriel = ({this.Idmateriel})");
        }

        /// <summary>
        /// Cette méthode permet de modifier un matériel de la table materiel de la BDD
        /// </summary>
        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Materiel SET nommateriel = '{this.Nommateriel}', referenceconstructeurmateriel = '{this.Referenceconstructeurmateriel}', codebarreinventaire = '{this.Codebarreinventaire}'  WHERE idmateriel  = ({this.Idmateriel})");
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un id qui n'est pas utiliser a un nouveau matériel
        /// </summary>
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
