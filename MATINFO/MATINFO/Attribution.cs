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
    public class Attribution : Crud<Attribution>
    {
        public Personnel UnPersonnel { get; set; }
        public Materiel UnMateriel { get; set; }

        public ObservableCollection<Personnel> lesPersonnels { get; set; }

        public Attribution()
        {

        }

        /// <summary>
        /// Cette méthode sert a initialiser ce que comporte une attribution
        /// </summary>
        /// <param name="fk_idpersonnel">Ce paramètre est l'id d'un personnel</param>
        /// <param name="fk_idmateriel">Ce paramètre est l'id d'un matériel</param>
        /// <param name="dateattribution">Ce paramètre est la date d'attribution</param>
        /// <param name="commentaireattribution">Ce paramètre est le commentaire d'une attribution</param>
        public Attribution(int fk_idpersonnel, int fk_idmateriel, DateTime dateattribution, string commentaireattribution)
        {
            FK_Idpersonnel = fk_idpersonnel;
            FK_Idmateriel = fk_idmateriel;
            Dateattribution = dateattribution;
            Commentaireattribution = commentaireattribution;
        }

        public int FK_Idpersonnel { get; set; }
        public int FK_Idmateriel { get; set; }
        public DateTime Dateattribution { get; set; }
        public string Commentaireattribution { get; set; }

        /// <summary>
        /// Cette méthode permet d'ajouter une attribution de la table est_attribue de la BDD
        /// </summary>
        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO est_attribue VALUES({this.FK_Idpersonnel},{this.FK_Idmateriel},'{this.Dateattribution}','{this.Commentaireattribution}')");
        }

        /// <summary>
        /// Cette méthode permet de retirer une attribution de la table est_attribue de la BDD
        /// </summary>
        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM est_attribue WHERE idmateriel = ({this.FK_Idmateriel})");
        }

        /// <summary>
        /// Cette méthode permet de récupérer tous les éléments de la table est_attribue sous forme de liste
        /// </summary>
        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributions = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, idmateriel, dateattribution, commentaireattribution from est_attribue";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution e = new Attribution(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), DateTime.Parse(row["dateattribution"].ToString()), (String)row["commentaireattribution"]);
                    lesAttributions.Add(e);
                }
            }
            return lesAttributions;
        }


        public ObservableCollection<Attribution> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode permet de d'afficher les attributions de la table est_attribue de la BDD
        /// </summary>
        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM est_attribue WHERE idmateriel = ({this.FK_Idmateriel})");
        }

        /// <summary>
        /// Cette méthode permet de modifier une attribution de la table est_attribue de la BDD
        /// </summary>
        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE est_attribue SET dateattribution = '{this.Dateattribution}', commentaireattribution = '{this.Commentaireattribution}'  WHERE idmateriel  = {this.FK_Idmateriel} and idpersonnel  = {this.FK_Idpersonnel}");
        }
    }
}
