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
    public class Personnel : Crud<Personnel>
    {
        public ObservableCollection<Attribution> lesAttributions { get; set; }
        public Attribution UneAttribution { get; set; }

        public Personnel()
        {

        }

        /// <summary>
        /// Cette méthode sert a initialiser ce que comporte un personnel
        /// </summary>
        /// <param name="idpersonnel">ce paramètre est l'id du personnel</param>
        /// <param name="emailpersonnel">ce paramètre est l'email du personnel</param>
        /// <param name="nompersonnel">ce paramètre est le nom du personnel</param>
        /// <param name="prenompersonnel">ce paramètre est le prenom du personnel</param>
        public Personnel(int idpersonnel, string emailpersonnel, string nompersonnel, string prenompersonnel)
        {
            Idpersonnel = idpersonnel;
            Emailpersonnel = emailpersonnel;
            Nompersonnel = nompersonnel;
            Prenompersonnel = prenompersonnel;
        }

        public int Idpersonnel { get; set; }
        public string Emailpersonnel { get; set; }
        public string Nompersonnel { get; set; }
        public string Prenompersonnel { get; set; }

        /// <summary>
        /// Cette méthode permet d'ajouter un personnel de la table personnel de la BDD
        /// </summary>
        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Personnel VALUES({this.Idpersonnel},'{this.Emailpersonnel}','{this.Nompersonnel}','{this.Prenompersonnel}');");
        }

        /// <summary>
        /// Cette méthode permet de retirer un personnel de la table personnel de la BDD
        /// </summary>
        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Personnel WHERE idpersonnel = ({this.Idpersonnel})");
        }

        /// <summary>
        /// Cette méthode permet de récupérer tous les éléments de la table personnel sous forme de liste
        /// </summary>
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

        /// <summary>
        /// Cette méthode permet de d'afficher les personnels de la table personnel de la BDD
        /// </summary>
        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Personnel WHERE idpersonnel = ({this.Idpersonnel})");
        }

        /// <summary>
        /// Cette méthode permet de modifier un personnel de la table personnel de la BDD
        /// </summary>
        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Personnel SET emailpersonnel = '{this.Emailpersonnel}', nompersonnel = '{this.Nompersonnel}', prenompersonnel = '{this.Prenompersonnel}'  WHERE idpersonnel  = ({this.Idpersonnel})");
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un id qui n'est pas utiliser a un nouveau personnel
        /// </summary>
        public static int RecupeId()
        {
            DataAccess dat = new DataAccess();
            dat.OpenConnection();
            DataTable dt = dat.GetData("SELECT nextval('personnel_idpersonnel_seq'::regclass)\"IDPERS\" FROM personnel");
            int result = Convert.ToInt32(dt.Rows[0]["IDPERS"]);
            return result;
        }

        /// <summary>
        /// Cette méthode permet de faire fonctionner les tests unitaires
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Personnel personnel &&
                   Idpersonnel == personnel.Idpersonnel &&
                   Emailpersonnel == personnel.Emailpersonnel &&
                   Nompersonnel == personnel.Nompersonnel &&
                   Prenompersonnel == personnel.Prenompersonnel;
        }


        /// <summary>
        /// Cette méthode permet de faire fonctionner les tests unitaires
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Idpersonnel, Emailpersonnel, Nompersonnel, Prenompersonnel);
        }
    }
}
