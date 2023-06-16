using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATINFO
{
    public class Attribution : Crud<Attribution>
    {

        public ObservableCollection<Personnel> lesPersonnels { get; set; }

        public Attribution()
        {

        }

        public Attribution(int fk_idpersonnel, int idmateriel, DateTime dateattribution, string commentaireattribution)
        {
            FK_Idpersonnel = fk_idpersonnel;
            Idmateriel = idmateriel;
            Dateattribution = dateattribution;
            Commentaireattribution = commentaireattribution;
        }

        public int FK_Idpersonnel { get; set; }
        public int Idmateriel { get; set; }
        public DateTime Dateattribution { get; set; }
        public string Commentaireattribution { get; set; }

        public void Create()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"INSERT INTO Attribution VALUES({this.FK_Idpersonnel},{this.Idmateriel},{this.Dateattribution},{this.Commentaireattribution})");
        }

        public void Delete()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"DELETE FROM Attribution WHERE idmateriel = ({this.Idmateriel})");
        }

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

        public void Read()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.GetData($"SELECT * FROM Attribution WHERE idmateriel = ({this.Idmateriel})");
        }

        public void Update()
        {
            DataAccess data = new DataAccess();
            data.OpenConnection();
            data.SetData($"UPDATE Attribution SET dateattribution = '{this.Dateattribution}', commentaireattribution = '{this.Commentaireattribution}'  WHERE idmateriel  = ({this.Idmateriel})");
        }
    }
}
